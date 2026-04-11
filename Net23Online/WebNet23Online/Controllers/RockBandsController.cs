using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class RockBandsController : Controller
    {
        private readonly IRockBandsService _rockBandsService;
        private WebContext _webContext;

        public RockBandsController(IRockBandsService rockBandsService, WebContext webContext)
        {
            _rockBandsService = rockBandsService;
            _webContext = webContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewAllRockBandsDataFromDatabase = _webContext.RockBand.ToList();
            var viewModel = new RockBandsIndexViewModel { Bands = _rockBandsService.GetBands() };
            //var viewModel = new RockBandsIndexViewModel { Bands = _rockBandsService.GetBands() };
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
