using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.RidesDTO
{
    public class AddPassengerRequestDTO
    {
        [Required(ErrorMessage = "L'ID du trajet est obligatoire.")]
        public Guid RideId { get; set; }

        [Required(ErrorMessage = "L'ID de l'utilisateur (passager) est obligatoire.")]
        public Guid UserId { get; set; }
    }
}
