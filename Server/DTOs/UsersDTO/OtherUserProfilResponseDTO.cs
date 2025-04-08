namespace CarMember_server.DTOs.UsersDTO
{
    public class OtherUserProfilResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
