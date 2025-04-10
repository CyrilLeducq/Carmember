using CarMember_server.DTOs.UsersDTO;
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
        [ProducesResponseType(typeof(IEnumerable<UserProfilResponseDTO>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        // [Authorize(Roles = Constants.RoleAdmin)] // => accessible aux admins
        [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        // GET /users/email
        [HttpGet("email")]
        [SwaggerOperation(Summary = "Obtenir un Utilisateur par son Email",
                  Description = "Récupère un Utilisateur en fonction de son Email unique.")]
        [ProducesResponseType(typeof(UserProfilResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller
        public async Task<IActionResult> GetByEmail([FromQuery] string? email)
        {

            var response = await _userService.GetByEmail(email);

            return response.User != null ? Ok(response) : NotFound($"Contact avec l'email {email} non trouvé.");

        }


        // POST /users
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouvel Utilisateur",
                  Description = "Ajoute un nouvel Utilisateur dans la table.")]
        [ProducesResponseType(typeof(UserRegisterResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] UserRegisterRequestDTO user)
        {
            throw new NotImplementedException();

            //try
            //{
            //    var newContact = await _userService.Create(user);
            //    return CreatedAtAction(nameof(GetById),
            //                           new { id = newContact.Id },
            //                           newContact);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest($"Erreur lors de la création du user : {ex.Message}");
            //}
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
            //    var updatedContact = await _userService.Update(id, user);
            //    return Ok(updatedContact);
            //}
            //catch (NotFoundException nex)
            //{
            //    return NotFound(nex.Message);
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
