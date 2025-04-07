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
    public Guid? IdReviewedUser { get; set; }

    [ForeignKey("IdReviewedUser")]
    public User? ReviewedUser { get; set; }

    [Column("id_author_user")]
    public Guid? IdAuthorUser { get; set; }

    [ForeignKey("IdAuthorUser")]
    public User? AuthorUser { get; set; }

}
