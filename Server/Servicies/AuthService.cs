using Microsoft.AspNetCore.Mvc;

namespace CarMember_server.Servicies
{
    public class AuthService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
