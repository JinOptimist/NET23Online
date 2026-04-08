using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
