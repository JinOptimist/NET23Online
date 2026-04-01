using Microsoft.AspNetCore.Mvc;

namespace WebNet23Online.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
