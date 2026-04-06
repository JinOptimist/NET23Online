using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.RockLegendsPortal;

namespace WebNet23Online.Controllers
{
    public class RockLegendsPortalController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RockLegendsPortalViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.SelectedBand))
            {
                return RedirectToAction("Details", new { id = viewModel.SelectedBand });
            }

            return View();
        }

        public IActionResult Details(string id)
        {
            var model = new RockLegendsPortalViewModel
            {
                SelectedBand = id
            };

            return View(model);
        }
    }
}