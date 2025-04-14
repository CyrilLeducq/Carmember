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


    [Column("reviewed_user_id")]
    public Guid? ReviewedUserId { get; set; }

    [ForeignKey("ReviewedUserId")]
    public User? ReviewedUser { get; set; }


    [Column("author_user_id")]
    public Guid? AuthorUserId { get; set; }

    [ForeignKey("AuthorUserId")]
    public User? AuthorUser { get; set; }
}
