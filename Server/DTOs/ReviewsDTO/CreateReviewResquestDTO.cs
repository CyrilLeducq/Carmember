using System.ComponentModel.DataAnnotations;

namespace CarMember_server.DTOs.ReviewsDTO
{
    public class CreateReviewResquestDTO
    {
        [Required]
        public Guid AuthorUserId { get; set; }

        // L'ID de l'utilisateur qui reçoit l'avis
        [Required]
        public Guid ReviewedUserId { get; set; }

        // La note attribuée à l'utilisateur (0-5)
        [Required]
        [Range(0, 5, ErrorMessage = "Le score doit être compris entre 0 et 5.")]
        public int Score { get; set; }

        // Le commentaire de l'avis
        [Required]
        [StringLength(500, ErrorMessage = "Le commentaire ne peut pas dépasser 500 caractères.")]
        public string Comment { get; set; }
    }
}
