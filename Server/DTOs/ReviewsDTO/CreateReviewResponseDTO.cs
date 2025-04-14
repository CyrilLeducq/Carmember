namespace CarMember_server.DTOs.ReviewsDTO
{
    public class CreateReviewResponseDTO
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public Guid AuthorUserId { get; set; }
        public Guid ReviewedUserId { get; set; }
    }
}
