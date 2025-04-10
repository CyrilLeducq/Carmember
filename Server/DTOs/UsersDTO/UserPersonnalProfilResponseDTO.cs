using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserProfilResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Review> ReceivedReviews { get; set; } = new List<Review>();

        // Liste des avis donnés
        public List<Review> GivenReviews { get; set; } = new List<Review>();

        // Liste des rides passés
        public List<Ride> PastRides { get; set; } = new List<Ride>();

        // Liste des rides à venir
        public List<Ride> UpcomingRides { get; set; } = new List<Ride>();
    }
}
