using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMember_server.Models;

public class Review
{
    public Guid Id { get; set; }

    [Required]
    [Range(0, 5), Column("score")]
    public int Score { get; set; }

    [Required]
    [StringLength(500), Column("comment")]
    public string Comment { get; set; }

    [Column("id_reviewed_user")]
    public string IdReviewedUser { get; set; }
    public User ReviewedUser { get; set; }

    [Column("id_author_user")]
    public string IdAuthorUser { get; set; }
    public User AuthorUser { get; set; }

}
