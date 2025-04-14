using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.RidesDTO
{
    public class RideUpdateRequestDTO
    {
        [Required]
        public Guid RideId { get; set; }

        [Required(ErrorMessage = "La date de départ est obligatoire.")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "La ville de départ est obligatoire.")]
        public string DepartureLocationCity { get; set; }

        [Required(ErrorMessage = "L'adresse de départ est obligatoire.")]
        public string DepartureLocationAddress { get; set; }

        [Required(ErrorMessage = "La ville d'arrivée est obligatoire.")]
        public string ArrivalLocationCity { get; set; }

        [Required(ErrorMessage = "L'adresse d'arrivée est obligatoire.")]
        public string ArrivalLocationAddress { get; set; }

        [Required(ErrorMessage = "La durée du trajet est obligatoire.")]
        public TimeSpan Duration { get; set; }

        [Required(ErrorMessage = "Le coût en fromage (grammes) est obligatoire.")]
        [Range(0, double.MaxValue, ErrorMessage = "La quantité en gramme de fromage doit être positive")]
        public double CheeseCostInGrams { get; set; }

        [Required(ErrorMessage = "Le type de fromage est obligatoire.")]
        public string CheeseType { get; set; }

        [Required(ErrorMessage = "La référence musicale est obligatoire.")]
        public string MusicalReference { get; set; }

        public string AnimalReference { get; set; }
        public string SmokingReference { get; set; }
        public string TalkingReference { get; set; }
    }
}
