namespace CarMember_server.DTOs.RidesDTO
{
    public class PastRideResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }

        public List<PastRideDTO> PastRides { get; set; } = new();
    }

    public class PastRideDTO
    {
        public Guid RideId { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureLocationCity { get; set; }
        public string ArrivalLocationCity { get; set; }
        public int DurationInMinutes { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public string DriverProfilePicture { get; set; }
    }
}
