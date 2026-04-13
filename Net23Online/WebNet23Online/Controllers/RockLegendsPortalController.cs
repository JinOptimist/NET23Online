using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.RockLegendsPortal;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class RockLegendsPortalController : Controller
    {
        private readonly IRockLegendsPick _rockService;
        private WebContext _webContext;


        public RockLegendsPortalController(IRockLegendsPick rockService, WebContext webContext)
        {
            _rockService = rockService;
            _webContext = webContext;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(RockLegendsPortalViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.SelectedBand))
            {

                var record = _webContext.RockLegends.FirstOrDefault();

                if (record != null)
                {

                    switch (viewModel.SelectedBand.ToLower())
                    {
                        case "kiss": record.Kiss++; break;
                        case "ozzy": record.Ozzy++; break;
                        case "acdc": record.ACDC++; break;
                        case "bon-jovi": record.BonJovi++; break;
                        case "rammstein": record.Rammstein++; break;
                        case "tdg": record.ThreeDaysGrace++; break;
                        case "slipknot": record.Slipknot++; break;
                        case "skillet": record.Skillet++; break;
                        case "metallica": record.Metallica++; break;
                        case "bmth": record.BringMeTheHorizon++; break;
                    }

                    _webContext.SaveChanges();
                }

                return RedirectToAction("Details", new { id = viewModel.SelectedBand });
            }
            return View();
        }

        public IActionResult Details(string id)
        {
            var rockDataList = _webContext.RockLegends.ToList();
            var model = _rockService.GetBandDetails(id, rockDataList);
            return View(model);
        }
    }
}