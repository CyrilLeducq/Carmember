using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class OtherUserProfilRequest
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
