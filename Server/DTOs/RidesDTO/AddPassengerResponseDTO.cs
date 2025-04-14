using CarMember_server.Models;

namespace CarMember_server.DTOs.RidesDTO
{
    public class AddPassengerResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
        public Ride? Ride { get; set; }
    }
}
