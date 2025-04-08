namespace CarMember_server.DTOs.UsersDTO
{
    public class UserProfilRequestDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

       public string ProfilePicture { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
