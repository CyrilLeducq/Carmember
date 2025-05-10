using System.ComponentModel.DataAnnotations;
using CarMember_server.Models;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideCreateRequestDTO
    {
        [Required(ErrorMessage = "La date de départ est obligatoire.")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "La ville de départ est obligatoire.")]
        public required string DepartureLocationCity { get; set; }

        [Required(ErrorMessage = "L'adresse de départ est obligatoire.")]
        public required string DepartureLocationAddress { get; set; }

        [Required(ErrorMessage = "La ville d'arrivée est obligatoire.")]
        public required string ArrivalLocationCity { get; set; }

        [Required(ErrorMessage = "L'adresse d'arrivée est obligatoire.")]
        public required string ArrivalLocationAddress { get; set; }

        [Required(ErrorMessage = "La durée du trajet est obligatoire.")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "Le coût en fromage (grammes) est obligatoire.")]
        [Range(0, double.MaxValue, ErrorMessage = "La quantité en gramme de fromage doit être positive")]
        public int CheeseCostInGrams { get; set; }

        [Required(ErrorMessage = "Le type de fromage est obligatoire.")]
        public Cheesetype CheeseType{ get; set; }

        [Required(ErrorMessage = "La référence musicale est obligatoire.")]
        public MusicalPreference MusicalPreference { get; set; }

        public AnimalPreference AnimalPreference { get; set; }
        public SmokingPreference SmokingPreference { get; set; }
        public TalkingPreference TalkingPreference { get; set; }

        // Le conducteur est celui qui crée le trajet, donc l'ID de l'utilisateur créateur
        [Required(ErrorMessage = "L'ID de l'utilisateur créateur est obligatoire.")]
        public Guid DriverUserId { get; set; }

        
    }
}
