using CarMember_server.Models;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideUpdateResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; } 

        public Ride? UpdatedRide { get; set; }

        public RideUpdateResponseDTO()
        {
            IsSuccessful = false;
            ErrorMessage = string.Empty;
        }
    }
}
