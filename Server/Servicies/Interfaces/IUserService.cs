using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Models;

namespace CarMember_server.Servicies.Interfaces;


public interface IUserService
{
    Task<IEnumerable<UserProfilResponseDTO>> GetAll();
    Task<UserProfilResponseDTO?> GetById(UserProfilRequestDTO UserProfilRequest);
    Task<UserProfilResponseDTO?> GetByEmail(UserProfilRequestDTO UserProfilRequest);
    Task<UserRegisterResponseDTO> Create(UserRegisterRequestDTO UserRegisterRequest);
    Task<UserUpdateResponseDTO> Update(UserUpdateRequestDTO UserProfilRequest);
    Task<UserDeleteProfilRequestDTO> Delete(UserDeleteProfilRequestDTO UserDeleteRequest);
}
