using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers
{
    public class AnimalWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
