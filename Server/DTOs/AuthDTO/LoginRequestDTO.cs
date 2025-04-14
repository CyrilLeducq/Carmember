using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.AuthDTO
{
    public class LoginRequestDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est indispensable !")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit avoir au moins 6 caractères.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Le mot de passe doit contenir au moins une lettre et un chiffre.")]
        public string Password { get; set; }
    }
}
