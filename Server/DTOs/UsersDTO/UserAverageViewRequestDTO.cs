namespace CarMember_server.DTOs.UsersDTO
{
    public class UserAverageViewRequestDTO
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public double AverageScore { get; set; }

        public int ReviewCount { get; set; }
    }
}
