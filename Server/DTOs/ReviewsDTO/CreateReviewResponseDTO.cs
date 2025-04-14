namespace CarMember_server.DTOs.ReviewsDTO
{
    public class CreateReviewResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

        public Guid Id { get; set; }

        public int Score { get; set; }

        public string Comment { get; set; }

        public Guid AuthorUserId { get; set; }
        public string? AuthorUserName { get; set; }

        public Guid ReviewedUserId { get; set; }

        public string? ReviewedUserName { get; set; }
        //
    }
}
