namespace CarMember_server.DTOs.UsersDTO
{
    public class UserAverageViewResponseDTO
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double AverageScore { get; set; }

        public int ReviewCount { get; set; }
    }
}
