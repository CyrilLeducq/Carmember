using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserRegisterResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public User? User { get; set; }
    }
}
