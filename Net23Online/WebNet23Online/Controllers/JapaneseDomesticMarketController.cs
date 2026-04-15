using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NAudio;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using WebNet23Online.Models.JapaneseDomesticMarket;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace WebNet23Online.Controllers
{
    public class JapaneseDomesticMarketController : Controller
    {
        private IJapaneseDomesticMarketGenerator _jdmItemGenerator;
        private IJDMCatalogGenerator _jdmCatalogGenerator;
        public JapaneseDomesticMarketController(IJapaneseDomesticMarketGenerator jdmItemGenerator, IJDMCatalogGenerator jdmCatalogGenerator)
        {
            _jdmItemGenerator = jdmItemGenerator;
            _jdmCatalogGenerator = jdmCatalogGenerator;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Catalog(string manufacturerType)
        {
            var jdmItems = _jdmItemGenerator.GenerateJDMCarsItems();
            var viewModel = _jdmCatalogGenerator.GetManufacturerTypeFromJDMItems(jdmItems, manufacturerType);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult JDMBuilder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JDMBuilder(JapaneseDomesticMarketViewModels jdmItem)
        {
            _jdmItemGenerator.AddJDMItem(jdmItem);
            return RedirectToAction(nameof(Catalog));
        }

        public IActionResult Journal()
        {
            return View();
        }
    }
}