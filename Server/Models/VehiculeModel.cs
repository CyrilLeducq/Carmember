using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarMember_server.Models
{
    public class VehiculeModel
    {
        public Guid Id { get; set; }

        [Required]
        [Column("category")]
        public VehiculeCategory Category { get; set; }

        [Required]
        [StringLength(100), Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("number_of_seats")]
        public int NumberOfSeats { get; set; }


        public List<User>? Users { get; set; } = new List<User>();
    }

    public enum VehiculeCategory
    {
        Voiture,
        Velo,
        MonsterTruck,
        Moto,
        Camion,
        SideCar,
        Avion,
        Peniche,
        Voilier,
        Telepherique,
        Car
    }
}
