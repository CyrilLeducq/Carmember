using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideViewRequestDTO
    {
        [Required]
        public Guid RideId { get; set; }
    }
}
