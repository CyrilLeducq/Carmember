using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarMember_server.Models;

public class Ride
{
    public Guid Id { get; set; }


    [Range(typeof(DateOnly), "2025-04-01", "9999-12-31"), Column("departure_date")]
    public DateTime? DepartureDate { get; set; }

    [Required]
    [StringLength(100), Column("departure_location_city")]
    public string DepartureLocationCity { get; set; }

    [Required]
    [StringLength(250), Column("departure_location_adress")]
    public string DepartureLocationAdress { get; set; }

    [Required]
    [StringLength(100), Column("arrival_location_city")]
    public string ArrivalLocationCity { get; set; }

    [Required]
    [StringLength(250), Column("arrival_location_adress")]
    public string ArrivalLocationAdress { get; set; }

    [Required]
    [Column("duration"), Range(0,2880)] // Durée en minutes, limité à 48h
    public int Duration { get; set; }

    [Required]
    [Column("cost_height"), Range(0,300000)] // Poids en grammes, limité à 300kg
    public int CostHeight { get; set; }

    [Required]
    [Column("cost_cheese_type")]
    public Cheesetype CostCheeseType { get; set; }


    [Required]
    [Column("musical_preference ")]
    public MusicalPreference MusicalReference { get; set; }

    [Required]
    [Column("animal_preference ")]
    public AnimalPreference AnimalReference { get; set; }

    [Required]
    [Column("smoking_preference  ")]
    public SmokingReference SmokingReference { get; set; }

    [Required]
    [Column("talking_preference  ")]
    public TalkingReference TalkingReference { get; set; }



    [Column("driver_user_id")]
    public Guid DriverUserId { get; set; }

    public User DriverUser { get; set; }


    public List<RideUser> RideUsers { get; set; } = new List<RideUser>();

}

public enum MusicalPreference
{ 
    aucune,
    un_peu,
    normal,
    beaucoup
}
public enum AnimalPreference
{
    non_accepte,
    accepte
}
public enum SmokingReference
{
    non_accepte,
    accepte
}
public enum TalkingReference
{
    silencieux, 
    peu_bavard,
    bavard, 
    pipelette

}public enum Cheesetype
{
    x,y
}

