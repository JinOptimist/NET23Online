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
            if (!string.IsNullOrEmpty(viewModel.SelectedBand))
            {
                var allbands = _rockLegendsRepository.GetAll();
                var targetBand = allbands.FirstOrDefault(x => x.GroupNames == viewModel.SelectedBand); //.ToLower()

                if (targetBand != null)
                {
                    targetBand.Likes++;
                    _rockLegendsRepository.Update(targetBand);
                }

                return RedirectToAction("Details", new { name = viewModel.SelectedBand });
            }
            return View();
        }

        public IActionResult Details(string name)
        {
            var rockDataList = _rockLegendsRepository.GetAll().ToList();
            var model = _rockService.GetBandDetails(name, rockDataList);
            return View(model);
        }
    }
}