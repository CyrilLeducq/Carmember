using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserProfilResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? Message { get; set; }

        public User? User { get; set; }
    }
}
