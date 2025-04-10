using CarMember_server.Models;

namespace CarMember_server.DTOs.UsersDTO
{
    public class OtherUserProfilResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Review> ReceivedReviews { get; set; } = new List<Review>();
    }
}
