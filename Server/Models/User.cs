using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarMember_server.Models;

public class User
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(50) , Column("firstname")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50) , Column("lasttname")]
    public string LastName { get; set; }

    [Required]
    [StringLength(150) , Column("email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [JsonIgnore]
    [StringLength(100) , Column("password")]
    public string Password { get; set; }

    [Required]
    [StringLength(50) , Column("password_salt")]
    public string PasswordSalt { get; set; }

    [StringLength(20) , Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [StringLength(200) , Column("profile_picture")]
    public string? ProfilePicture { get; set; }

    [StringLength(50) , Column("gender")]
    public string? Gender { get; set; }

    [Range(typeof(DateOnly), "1910-05-21", "9999-12-31"), Column("creation_date")]
    public DateTime? CreationDate { get; set; }

    [Required]
    [StringLength(50), Column("role")]
    public string Role { get; set; }




    [StringLength(36), Column("id_vehicule_model")]
    public string? IdVehiculeModel { get; set; }

    public VehiculeModel? VehiculeModel { get; set; }


    //public List<Review>? Reviews { get; set; } = new List<Review>();

    public List<Ride>? Rides { get; set; } = new List<Ride>();


}
