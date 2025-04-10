using CarMember_server.DTOs.UsersDTO;


namespace CarMember_server.Servicies.Interfaces;


public interface IAuthService
{
    Task<UserRegisterResponseDTO> UserRegister(UserRegisterRequestDTO registerDto);
    Task<UserLoginResponseDTO> UserLogin(UserLoginRequestDTO loginDto);
}