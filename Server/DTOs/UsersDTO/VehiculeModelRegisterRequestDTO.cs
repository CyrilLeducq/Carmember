using CarMember_server.Models;
using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.UsersDTO
{
    public class VehiculeModelRegisterRequestDTO
    {
        [Required(ErrorMessage = "La catégorie du véhicule est obligatoire.")]
        public VehiculeCategory Category { get; set; }

        [Required(ErrorMessage = "Le nom du modèle est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom du modèle ne peut pas dépasser 100 caractères.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le nombre de sièges est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le nombre de sièges doit être supérieur à 0.")]
        public int NumberOfSeats { get; set; }
    }
}
