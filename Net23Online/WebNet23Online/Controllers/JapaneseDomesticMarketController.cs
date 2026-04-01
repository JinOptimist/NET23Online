using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers
{
    public class JapaneseDomesticMarketController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult Journal()
        {
            return View();
        }
    }
}
