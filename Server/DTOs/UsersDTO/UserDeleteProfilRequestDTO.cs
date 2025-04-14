using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserDeleteProfilRequestDTO
    {
  
        [Required(ErrorMessage = "L'ID utilisateur est requis.")]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit avoir au moins 6 caractères.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
