namespace CarMember_server.DTOs.RidesDTO
{
    public class RideDeleteRequestDTO
    {
        public Guid RideId { get; set; }
        public Guid UserId { get; set; }
    }
}
