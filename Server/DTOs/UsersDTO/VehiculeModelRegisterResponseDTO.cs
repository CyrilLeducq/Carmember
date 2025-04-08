using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class VehiculeModelRegisterResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? Message { get; set; }

        public VehiculeModel? VehiculeModel { get; set; }
    }
}
