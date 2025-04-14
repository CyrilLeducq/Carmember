using CarMember_server.Models;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideCreateResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public Ride? CreatedRide { get; set; }

        public Guid RideId { get; set; }
        public Guid DriverUserId { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureLocationCity { get; set; }
        public string DepartureLocationAdress { get; set; }
        public string ArrivalLocationCity { get; set; }
        public string ArrivalLocationAdress { get; set; }
        public int Duration { get; set; }
        public int CostHeight { get; set; }
        public string CostCheeseType { get; set; }
        public string MusicalPreference { get; set; }
        public string AnimalPreference { get; set; }
        public string SmokingPreference { get; set; }
        public string TalkingPreference { get; set; }
    }
}
