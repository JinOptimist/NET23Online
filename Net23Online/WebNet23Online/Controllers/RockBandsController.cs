using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers
{
    public class RockBandsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
