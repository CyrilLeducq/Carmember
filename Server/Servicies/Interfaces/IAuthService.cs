using CarMember_server.DTOs.UsersDTO;


namespace CarMember_server.Servicies.Interfaces;


public interface IAuthService
{
    Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO loginDto);
}