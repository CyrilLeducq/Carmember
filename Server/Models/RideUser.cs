using System.ComponentModel.DataAnnotations.Schema;

namespace CarMember_server.Models;

public class RideUser
{
    public Guid Id { get; set; }



    [Column("user_id")]
    public Guid UserId { get; set; }
    public User User { get; set; }


    [Column("ride_id")]
    public Guid RideId { get; set; }
    public Ride Ride { get; set; }
}
