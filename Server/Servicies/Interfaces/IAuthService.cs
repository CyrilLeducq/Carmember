using Microsoft.AspNetCore.Mvc;

namespace CarMember_server.Servicies.Interfaces;


public interface IAuthService
{
    Task<ClientRegisterResponseDTO> ClientRegister(ClientRegisterRequestDTO registerDto);
    Task<ClientLoginResponseDTO> ClientLogin(LoginRequestDTO loginDto);
}