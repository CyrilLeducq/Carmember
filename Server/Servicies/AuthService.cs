using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Helpers;
using CarMember_server.Models;
using CarMember_server.Servicies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CarMember_server.Servicies;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;

    private readonly ILogger<AuthService> _logger;
    private readonly AppSettings _appSettings;
    private readonly Encryptor _encryptor;

    public AuthService(IUserService userService,
                       ILogger<AuthService> logger,
                       IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _logger = logger;
        _appSettings = appSettings.Value;
        _encryptor = new Encryptor();
        //_httpContextAccessor = httpContextAccessor; //_httpContextAccessor.HttpContext...
        logger.LogInformation("Auth service created");
    }


    public async Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO loginDto)
    {
        try
        {
            var user = await _userService.GetUserById(loginDto.Email!);

            if (user == null)
                throw new KeyNotFoundException("Invalid Authentication !");

            var (verified, needsUpgrade) = _encryptor.Check(user.Password!, loginDto.Password!);

            if (!verified)
                throw new UnauthorizedAccessException("Invalid Authentication !");

            if (needsUpgrade)
            {
                UserUpdateRequestDTO userDto = new UserUpdateRequestDTO {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Password = loginDto.Password,
                    ProfilePicture = user.ProfilePicture,
                    Gender = user.Gender
                };

                await _userService.Update(userDto);
            }

            string token = CreateJwt(
                user.Role=="admin" ? Constants.RoleAdmin : Constants.RoleUsers,
                user.Id.ToString());

            return new UserLoginResponseDTO
            {
                IsSuccessful = true,
                Token = token,
                User = user
            };
        }
        catch (Exception e)
        {
            // Ajout du Logging de l'erreur rencontrée
            _logger.LogError(e, $"Erreur de connexion pour l'utilisateur {loginDto.Email}: {e.Message}");
            throw;
        }
    }

    private string CreateJwt(string role, string subjectId)
    {
        var claims = new List<Claim> // detinée à aller dans la partie Payload du JWT
            {
                new (ClaimTypes.Role, role),
                //new ("user_id", user.Id!.ToString()!),                  // personnalisé
                //new (ClaimTypes.NameIdentifier, user.Id!.ToString()!),  // recommandation Microsoft
                new (JwtRegisteredClaimNames.Sub, subjectId),  // recommandation JWT
            };

        var securityKey = _appSettings.SecretKey;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_appSettings.TokenExpirationDays),
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
