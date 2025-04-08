using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserDeleteProfilRequestDTO
    {
  
        [Required(ErrorMessage = "L'ID utilisateur est requis.")]
        public Guid UserId { get; set; }
    }
}
