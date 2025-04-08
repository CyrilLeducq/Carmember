using Microsoft.AspNetCore.Mvc;

namespace CarMember_server.Servicies
{
    public class ReviewService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
