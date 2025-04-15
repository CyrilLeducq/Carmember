namespace CarMember_server.DTOs.UsersDTO
{
    public class UserDeleteProfilResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public Guid? UserId { get; set; }

        public string ConfirmationMessage { get; set; }

    }
}
