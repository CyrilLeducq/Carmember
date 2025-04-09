using System.ComponentModel.DataAnnotations;
using CarMember_server.Validator;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserRegisterRequestDTO
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
        [PasswordValidator]
        public string Password { get; set; }


        public string ProfilePicture { get; set; }

       public string Gender { get; set; }
 

    }
}
