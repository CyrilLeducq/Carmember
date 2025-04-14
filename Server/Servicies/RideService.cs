using Microsoft.AspNetCore.Mvc;

namespace CarMember_server.Servicies
{
    public class RideService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
