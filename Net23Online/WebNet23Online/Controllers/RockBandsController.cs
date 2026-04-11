using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class RockBandsController : Controller
    {
        private readonly IRockBandsService _rockBandsService;

        public RockBandsController(IRockBandsService rockBandsService)
        {
            _rockBandsService = rockBandsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new RockBandsIndexViewModel { Bands = _rockBandsService.GetBands() };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(BandBlockViewModel viewModel)
        {
            _rockBandsService.AddBand(viewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
