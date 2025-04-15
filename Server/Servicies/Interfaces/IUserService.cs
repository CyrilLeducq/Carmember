using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Models;

namespace CarMember_server.Servicies.Interfaces;


public interface IUserService
{
    Task<IEnumerable<UserPersonnalProfilResponseDTO>> GetAll();
    Task<User?> GetUserById(string email);
    Task<UserPersonnalProfilResponseDTO?> GetPersonnalById(Guid id);
    Task<UserPersonnalProfilResponseDTO?> GetPersonnalByEmail(string email);
    Task<OtherUserProfilResponseDTO?> GetOtherById(OtherUserProfilRequest otherUserProfilRequest);
    Task<UserRegisterResponseDTO> Create(UserRegisterRequestDTO UserRegisterRequest);
    Task<UserUpdateResponseDTO> Update(UserUpdateRequestDTO UserProfilRequest);
    Task<UserDeleteProfilResponseDTO> Delete(UserDeleteProfilRequestDTO UserDeleteRequest);
}
