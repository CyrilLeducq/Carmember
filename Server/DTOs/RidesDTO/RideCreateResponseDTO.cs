using CarMember_server.Models;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideCreateResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public Ride? CreatedRide { get; set; }
    }
}
