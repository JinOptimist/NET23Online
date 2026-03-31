using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        //          /DelightBistro/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
