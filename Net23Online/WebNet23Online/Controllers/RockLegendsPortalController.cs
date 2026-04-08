using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.RockLegendsPortal;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class RockLegendsPortalController : Controller
    {
        private readonly IRockLegendsPick _rockService;

        public RockLegendsPortalController(IRockLegendsPick rockService)
        {
            _rockService = rockService;
        }

        [HttpGet]
        public IActionResult Index() => View();

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
            var model = _rockService.GetBandDetails(id);
            return View(model);
        }
    }
}