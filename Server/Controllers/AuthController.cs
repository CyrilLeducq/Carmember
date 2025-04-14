using CarMember_server.DTOs.AuthDTO;
using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Servicies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarMember_server.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("user/login")]
    [SwaggerOperation(Summary = "Se connecter en tant qu'Utilisateur et récupérer son JWT.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserLoginResponseDTO>> UserLogin([FromBody] UserLoginRequestDTO loginDto)
    {
        try
        {
            return await _authService.UserLogin(loginDto);
        }
        catch (Exception e)
        {
            return BadRequest(new UserRegisterResponseDTO
            { IsSuccessful = false, ErrorMessage = e.Message });
        }
    }
}
