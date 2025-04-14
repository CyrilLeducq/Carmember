using CarMember_server.DTOs.RidesDTO;
using CarMember_server.Helpers;
using CarMember_server.Servicies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarMember_server.Controllers
{
    [Route("rides")]
    [ApiController]
    [Authorize]
    public class RideController : ControllerBase
    {
        private readonly IRideService _rideService;

        public RideController(IRideService rideService)
        {
            _rideService = rideService;
        }

        // POST /rides
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un trajet", Description = "Ajoute un nouveau trajet.")]
        [ProducesResponseType(typeof(RideCreateResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RideCreateRequestDTO request)
        {
            try
            {
                // Appel à la méthode CreateRide dans le service
                var response = await _rideService.CreateRide(request);

                // Vérifie si la création a réussi
                if (response.IsSuccessful)
                    return CreatedAtAction(nameof(ViewDetails), new { id = response.RideId }, response);
                else
                    return BadRequest(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                return BadRequest($"Erreur lors de la création du trajet : {ex.Message}");
            }
        }

        // PUT /rides/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un trajet", Description = "Met à jour un trajet existant.")]
        [ProducesResponseType(typeof(RideUpdateResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RideUpdateRequestDTO request)
        {
            try
            {
                // Appel à la méthode UpdateRide dans le service
                var response = await _rideService.UpdateRide(id, request);

                // Retourne la réponse en fonction du résultat
                return response.IsSuccessful ? Ok(response) : NotFound(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                return BadRequest($"Erreur lors de la mise à jour du trajet : {ex.Message}");
            }
        }

        // GET /rides/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Voir les détails d'un trajet", Description = "Récupère les détails d'un trajet par ID.")]
        [ProducesResponseType(typeof(RideViewResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ViewDetails([FromRoute] Guid id)
        {
            try
            {
                // Appel à la méthode ViewRideDetails dans le service
                var response = await _rideService.ViewRideDetails(new RideViewRequestDTO { RideId = id });

                // Vérifie si la méthode retourne des détails du trajet
                if (response != null)
                    return Ok(response);
                else
                    return NotFound($"Trajet avec l'ID {id} non trouvé.");
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                return BadRequest($"Erreur lors de la récupération des détails du trajet : {ex.Message}");
            }
        }

        // DELETE /rides/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un trajet", Description = "Supprime un trajet existant.")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, [FromHeader(Name = "Authorization")] string bearer)
        {
            try
            {
                // Récupère l'ID de l'utilisateur actuel à partir du token JWT
                var userId = JwtDecoder.GetId(bearer);

                // Vérifie si l'ID utilisateur est valide
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("L'utilisateur n'est pas authentifié.");
                }

                // Convertir userId en Guid
                var userGuid = Guid.Parse(userId);

                // Appel à la méthode GetRide pour vérifier si le trajet existe
                var ride = await _rideService.GetRideById(id);

                if (ride == null)
                {
                    return NotFound("Trajet non trouvé.");
                }

                // Vérifie si l'utilisateur qui tente de supprimer le trajet est le conducteur du trajet
                if (ride.DriverUserId != userGuid)
                {
                    return Forbid("Vous n'êtes pas autorisé à supprimer ce trajet.");
                }

                // Appel à la méthode DeleteRide dans le service
                var response = await _rideService.DeleteRide(id, userGuid);

                // Vérifie si la suppression a réussi
                if (response.IsSuccessful)
                    return Ok("Trajet supprimé avec succès.");
                else
                    return BadRequest(response.ErrorMessage);
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                return BadRequest($"Erreur lors de la suppression du trajet : {ex.Message}");
            }
        }
    }
}