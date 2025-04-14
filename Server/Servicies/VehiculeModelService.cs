using Microsoft.AspNetCore.Mvc;

namespace CarMember_server.Servicies
{
    public class VehiculeModelService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
