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
            return View(_animalWorldService.GetStartInfo());
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
            if (_animalWorldService.AddZoo(viewModel))
            {
                return RedirectToAction("Add");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult AddFamily()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFamily(AnimalFamilyViewModel viewModel)
        {
            if (_animalWorldService.AddAnimalFamily(viewModel))
            {
                return RedirectToAction("Add");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddSpecies()
        {
            return View(_animalWorldService.GetAnimalSpeciesPageInfo());
        }

        [HttpPost]
        public IActionResult AddSpecies(AnimalSpeciesViewModel viewModel)
        {
            if (_animalWorldService.AddAnimalSpecies(viewModel))
            {
                return RedirectToAction("Add");
            }

            return View();
        }

        [HttpGet]
        public IActionResult BindZooFamily()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BindZooFamily(BindZooWithAnimalSpeciesViewModel viewModel)
        {
            //if (_animalWorldService.BindZooWithAnimalSpecies(viewModel))
            //{
            //    return RedirectToAction("Index");
            //}

            return View();
        }
    }
}
