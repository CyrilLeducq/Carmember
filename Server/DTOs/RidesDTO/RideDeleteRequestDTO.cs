using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideDeleteRequestDTO
    {
        [Required]
        public Guid RideId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
