using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class VehiculeModelUpdateResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public VehiculeModel? UpdatedVehiculeModel { get; set; }
    }
}
