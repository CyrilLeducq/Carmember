using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarMember_server.Models;

public class RideUser
{
    public Guid Id { get; set; }


    [Required]
    [Column("user_id")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [Required]
    [Column("ride_id")]
    public Guid RideId { get; set; }
    public Ride Ride { get; set; }

}
