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
    [StringLength(250), Column("departure_location_city")]
    public string DepartureLocationAdress { get; set; }

    [Required]
    [StringLength(100), Column("arrival_location_city")]
    public string ArrivalLocationCity { get; set; }

    [Required]
    [StringLength(250), Column("arrival_location_city")]
    public string ArrivalLocationAdress { get; set; }

    [Required]
    [Column("duration"), Range(0,2880)] // Durée en minutes, limité à 48h
    public int Duration { get; set; }

    [Required]
    [Column("cost_height"), Range(0,300000)] // Poids en grammes, limité à 300kg
    public int CostHeight { get; set; }

    [Required]
    [StringLength(100), Column("cost_cheese_type")]
    public string CostCheeseType { get; set; }


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


    public List<User>? Users { get; set; } = new List<User>();

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
    accepte,
    non_accepte
}
public enum SmokingReference
{
    accepte,
    non_accepte
}
public enum TalkingReference
{
    silencieux, 
    peu_bavard,
    bavard, 
    pipelette
}

