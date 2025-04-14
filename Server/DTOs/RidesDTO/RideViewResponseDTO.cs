using CarMember_server.Models;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideViewResponseDTO
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }

        public DateTime DepartureDate { get; set; }
        public string DepartureLocationCity { get; set; }
        public string DepartureLocationAddress { get; set; }
        public string ArrivalLocationCity { get; set; }
        public string ArrivalLocationAddress { get; set; }

        public int DurationInMinutes { get; set; }
        public int CheeseCostInGrams { get; set; }
        public string CheeseType { get; set; }

        public string MusicalPreference { get; set; }
        public string AnimalPreference { get; set; }
        public string SmokingPreference { get; set; }
        public string TalkingPreference { get; set; }

        public Guid DriverUserId { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public string? DriverProfilePicture { get; set; }

        public List<User> Passengers { get; set; } = new();
    }
}
