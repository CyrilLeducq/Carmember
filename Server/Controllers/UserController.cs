using Microsoft.AspNetCore.Mvc;

namespace CarMember_server.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
