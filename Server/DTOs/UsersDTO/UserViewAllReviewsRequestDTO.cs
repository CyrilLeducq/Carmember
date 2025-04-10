using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class UserViewAllReviewsRequestDTO
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
