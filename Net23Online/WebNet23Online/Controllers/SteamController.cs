using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.Steam;

namespace WebNet23Online.Controllers
{
    public class SteamController : Controller
    {
        public IActionResult Index(string? name)
        {
            var model = new NameViewModel
            {
                Name = string.IsNullOrWhiteSpace(name) ? "Guest" : name
            };

            return View(model);
        }
    }
}
