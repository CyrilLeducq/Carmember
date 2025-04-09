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
            var contacts = await _userService.GetAll();
            return Ok(contacts);
        }

    }
}
