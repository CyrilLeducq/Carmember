using System.Net;
using CarMember_server.DTOs.UsersDTO;
using CarMember_server.Helpers;
using CarMember_server.Servicies.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CarMember_server.Controllers
{

    [Route("/users")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET /users
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir la liste des Utilisateurs",
                  Description = "Récupère tous les utilisateurs.")]
        [ProducesResponseType(typeof(IEnumerable<UserPersonnalProfilResponseDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Roles = Constants.RoleAdmin)] // => accessible aux admins
        [Authorize(Roles = Constants.RoleAdmin)] // => accessible aux users connectés uniquement
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        // GET /users/email
        [HttpGet("email")]
        [SwaggerOperation(Summary = "Obtenir un Utilisateur par son Email",
                  Description = "Récupère un Utilisateur en fonction de son Email unique.")]
        [ProducesResponseType(typeof(UserPersonnalProfilResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller
        public async Task<IActionResult> GetByEmail([FromQuery] string? email)
        {

            var response = await _userService.GetPersonnalByEmail(email);

            return response != null ? Ok(response) : NotFound($"Contact avec l'email {email} non trouvé.");

        }
        // GET /users/id
        [HttpGet("id")]
        [SwaggerOperation(Summary = "Obtenir un Utilisateur par son ID",
                  Description = "Récupère un Utilisateur en fonction de son ID unique.")]
        [ProducesResponseType(typeof(UserPersonnalProfilResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById([FromQuery] string? id, [FromHeader(Name = "Authorization")] string bearer)
        {
            Console.WriteLine("ID:" +
                $"\n Bearer ID: [{JwtDecoder.GetId(bearer)}]" +
                $"Role: [{JwtDecoder.GetRole(bearer)}]");

            if (JwtDecoder.GetId(bearer) == id || JwtDecoder.GetRole(bearer) == Constants.RoleAdmin)
            {
                var response = await _userService.GetPersonnalById(Guid.Parse(id));

                return response != null ? Ok(response) : NotFound($"Contact avec l'email {id} non trouvé.");
            }
            else
            {
                return Unauthorized($"Vous n'avez pas les droits pour consulter l'Utilisateur {id}.");
            }

        }


        // POST /users
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouvel Utilisateur",
                  Description = "Ajoute un nouvel Utilisateur dans la table.")]
        [ProducesResponseType(typeof(UserRegisterResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller

        public async Task<IActionResult> Create([FromBody] UserRegisterRequestDTO user)
        {
            try
            {
                var newContact = await _userService.Create(user);
                return CreatedAtAction(nameof(GetById),
                                       new { id = newContact.User.Id },
                                       newContact);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du user : {ex.Message}");
            }
        }

        // PUT /users/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un user",
                  Description = "Met à jour les informations d'un user existant.")]
        [ProducesResponseType(typeof(UserUpdateResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateRequestDTO user)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var updatedContact = await _userService.Update(user);
            //    return Ok(updatedContact);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erreur lors de la mise à jour du user : {ex.Message}");
            //}
        }

        // DELETE /users/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un user",
                  Description = "Supprime un user à partir de son identifiant.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(UserDeleteProfilRequestDTO user)
        {
            throw new NotImplementedException();

            //try
            //{
            //    await _userService.Delete(id);
            //    //return Ok($"Contact {id} supprimé.")
            //    return NoContent();
            //}
            //catch (NotFoundException ex)
            //{
            //    return NotFound(ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erreur lors de la suppression du user : {ex.Message}");
            //}
        }

    }
}
