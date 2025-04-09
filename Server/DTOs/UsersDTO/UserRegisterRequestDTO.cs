using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class CreateUserRequestDTO
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z'-]*$", ErrorMessage = "Le prénom doit débuter avec une lettre majuscule !")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z'-]*$", ErrorMessage = "Le Nom doit être écrit en lettres majuscules !")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "L'adresse e-mail est indispensable !")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail est invalide !")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\+([0-9]{1,4})[-. ]?([0-9]{1,4})[-. ]?([0-9]{1,4})[-. ]?([0-9]{1,4})[-. ]?([0-9]{1,4})$", ErrorMessage = "Le numéro de téléphone n'est pas valide !")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est indispensable !")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit avoir au moins 6 caractères.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Le mot de passe doit contenir au moins une lettre et un chiffre.")]
        public string Password { get; set; }

        [Url(ErrorMessage = "Le lien de l'image de profil est invalide.")]
        public string ProfilePicture { get; set; }

        [RegularExpression(@"^(Masculin|Feminin|Autre)$", ErrorMessage = "Le genre doit être 'Masculin', 'Feminin', ou 'Autre'.")]
        public string Gender { get; set; }
 

    }
}
