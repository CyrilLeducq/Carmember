namespace CarMember_server.DTOs.UsersDTO
{
    public class UserViewAllReviewsResponseDTO
    {
        public List<ReviewResponseDTO> Reviews { get; set; }
    }

    public class ReviewResponseDTO
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public string AuthorUserName { get; set; } 
    }
}
