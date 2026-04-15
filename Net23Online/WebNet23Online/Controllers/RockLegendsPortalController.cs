using Microsoft.AspNetCore.Mvc;
using NAudio.Codecs;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.RockLegendsPortal;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class RockLegendsPortalController : Controller
    {
        private readonly IRockLegendsPick _rockService;
        private IRockLegendsRepository _rockLegendsRepository;


        public RockLegendsPortalController(IRockLegendsPick rockService, IRockLegendsRepository rockLegendsRepository)
        {
            _rockService = rockService;
            _rockLegendsRepository = rockLegendsRepository;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(RockLegendsPortalViewModel viewModel)
        {
            if (viewModel.SelectedBandId != 0)
            {
                var targetBand = _rockLegendsRepository.GetById(viewModel.SelectedBandId);

                if (targetBand != null)
                {
                    targetBand.Likes++;
                    _rockLegendsRepository.Update(targetBand);

                    return RedirectToAction("Details", new { id = targetBand.Id });
                }
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var targetBand = _rockLegendsRepository.GetById(id);
            if (targetBand == null)
            {
                return NotFound();
            }
            var model = _rockService.GetBandDetails(id, targetBand);
            return View(model);
        }
    }
}