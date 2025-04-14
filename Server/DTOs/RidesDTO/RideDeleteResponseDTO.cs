namespace CarMember_server.DTOs.RidesDTO
{
    public class RideDeleteResponseDTO
    {
        public bool IsSuccessful { get; set; } 
        public string? ErrorMessage { get; set; } 
        public string? Message { get; set; }
    }
}
