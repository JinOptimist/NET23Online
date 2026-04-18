using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimalWorld;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class AnimalWorldController : Controller
    {
        private IAnimalWorldService _animalWorldService;

        public AnimalWorldController(IAnimalWorldService animalWorldService)
        {
            _animalWorldService = animalWorldService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddZoo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddZoo(ZooViewModel viewModel)
        {
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult AddFamily()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFamily(AnimalFamilyViewModel viewModel)
        {
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult AddSpecies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSpecies(AnimalSpeciesViewModel viewModel)
        {
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult BindZooFamily()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BindZooFamily(BindZooWithAnimalSpeciesViewModel viewModel)
        {
            return RedirectToAction("Add");
        }
    }
}
