using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Models;

namespace CarMember_server.Servicies.Interfaces;


public interface IUserService
{
    Task<IEnumerable<UserProfilResponseDTO>> GetAll();
    Task<UserProfilResponseDTO?> GetById(UserProfilRequestDTO UserProfilRequest);
    Task<UserProfilResponseDTO?> GetByEmail(UserProfilRequestDTO UserProfilRequest);
    Task<UserProfilResponseDTO> Create(UserProfilRequestDTO UserProfilRequest);
    Task<UserProfilResponseDTO> Update(Guid id, UserProfilRequestDTO UserProfilRequest);
    Task Delete(int id);
}
