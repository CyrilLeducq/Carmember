using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class RideUserViewResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public List<RideRegisterRequestDTO> Rides { get; set; }

        public RideUserViewResponseDTO()
        {
            Rides = new List<RideRegisterRequestDTO>();
        }
    }
}
