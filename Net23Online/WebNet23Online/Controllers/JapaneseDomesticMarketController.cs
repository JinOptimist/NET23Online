using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NAudio;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Models.JapaneseDomesticMarket;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using WebNet23Online.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Controllers
{
    public class JapaneseDomesticMarketController : Controller
    {
        private IJapaneseDomesticMarketGenerator _jdmItemGenerator;
        private IJDMCatalogGenerator _jdmCatalogGenerator;
        private IJapaneseDomesticMarketRepository _japaneseDomesticMarketRepository;
        private IJapaneseDomesticMarketManufacturerRepository _japaneseDomesticMarketManufacturerRepository;

        public JapaneseDomesticMarketController(IJapaneseDomesticMarketGenerator jdmItemGenerator, IJDMCatalogGenerator jdmCatalogGenerator, IJapaneseDomesticMarketRepository japaneseDomesticMarketRepository, IJapaneseDomesticMarketManufacturerRepository japaneseDomesticMarketManufacturerRepository)
        {
            _jdmItemGenerator = jdmItemGenerator;
            _jdmCatalogGenerator = jdmCatalogGenerator;
            _japaneseDomesticMarketRepository = japaneseDomesticMarketRepository;
            _japaneseDomesticMarketManufacturerRepository = japaneseDomesticMarketManufacturerRepository;
        }
        
        public IActionResult Home()
        {
            return View();
        }
        
        public IActionResult Catalog(string manufacturerType)
        {
            var JapaneseDomesticMarketCarsData = _japaneseDomesticMarketRepository.GetAll();
            var jdmItems = _jdmItemGenerator.GenerateJDMCarsItems(JapaneseDomesticMarketCarsData);
            var viewModel = _jdmCatalogGenerator.GetManufacturerTypeFromJDMItems(jdmItems, manufacturerType);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateCars()
        {
            var manufactures = _japaneseDomesticMarketManufacturerRepository.GetAll();
            var manufacturesListItems = new List<SelectListItem>();
            
            manufacturesListItems.Add(new SelectListItem
            {
                Text = "Выбери производителя",
                Value = ""
            });
            manufacturesListItems.AddRange(manufactures.Select(x => new SelectListItem
            {
                Text = x.ManufacturerType,
                Value = x.Id.ToString()
            }));
            var viewModel = new JapaneseDomesticMarketViewModels
            {
                AllManufacturer = manufacturesListItems
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult CreateCars(JapaneseDomesticMarketViewModels viewModel)
        {
            if (viewModel.ManufactureId is null || viewModel.ManufactureId <= 0)
            {
                var manufactures = _japaneseDomesticMarketManufacturerRepository.GetAll();
                viewModel.AllManufacturer.AddRange(manufactures.Select(x => new SelectListItem
                {
                    Text = x.ManufacturerType,
                    Value = x.Id.ToString(),
                }));
                return View(viewModel);
            }
            var manufacturer = _japaneseDomesticMarketManufacturerRepository.Get(viewModel.ManufactureId.Value);
            if (manufacturer is null)
            {
                return RedirectToAction(nameof(Catalog));
            }
            var japaneseDomesticMarketCarsData = new JapaneseDomesticMarketCarsData
            {
                Id = viewModel.Id,
                Marka = viewModel.Marka,
                Model = viewModel.Model,
                Price = viewModel.Price,
                Url = viewModel.Url,
                ManufacturerType = manufacturer.ManufacturerType
            };
            _japaneseDomesticMarketRepository.Add(japaneseDomesticMarketCarsData);
            return RedirectToAction(nameof(Catalog));
        }

            [HttpGet]
        public IActionResult JDMBuilder()
        {
            var carsJdm = _japaneseDomesticMarketRepository.GetAll();
            var carsJdmViewModel = _jdmItemGenerator.GenerateJDMCarsItems(carsJdm);
            var viewModel = new JDMCatalogViewModels
            {
                CarsJDMItems = carsJdmViewModel
            };
            return View();
        }

        [HttpPost]
        public IActionResult JDMBuilder(JapaneseDomesticMarketViewModels jdmItem)
        {
            var jdmCarsData = new JapaneseDomesticMarketCarsData
            {
                ManufacturerType = jdmItem.ManufacturerType,
                Marka = jdmItem.Marka,
                Model = jdmItem.Model,
                Price = jdmItem.Price,
                Url = jdmItem.Url,
            };

            _japaneseDomesticMarketRepository.Add(jdmCarsData);
       
            return RedirectToAction(nameof(Catalog));
        }

        public IActionResult Journal()
        {
            return View();
        }

        public IActionResult LinkJdmQuiz(int manufactureId, int modelId)
        {
            _japaneseDomesticMarketRepository.Link(manufactureId, modelId);
            return RedirectToAction(nameof(Home));
        }
    }
}