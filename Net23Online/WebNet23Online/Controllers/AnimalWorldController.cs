using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddZoo()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddZoo(ZooViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (_animalWorldService.AddZoo(viewModel))
            {
                return RedirectToAction("Add");
            }
            
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddFamily()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddFamily(AnimalFamilyViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (_animalWorldService.AddAnimalFamily(viewModel))
            {
                return RedirectToAction("Add");
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddSpecies()
        {
            return View(_animalWorldService.GetAnimalSpeciesPageInfo());
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddSpecies(AnimalSpeciesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.AnimalFamilyNames = _animalWorldService.GetAnimalSpeciesPageInfo().AnimalFamilyNames;
                return View(viewModel);
            }

            if (_animalWorldService.AddAnimalSpecies(viewModel))
            {
                return RedirectToAction("Add");
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult BindZooAndAnimalSpecies()
        {
            return View(_animalWorldService.GetBingZooAndAnimalSpeciesInfo());
        }

        [HttpPost]
        [Authorize]
        public IActionResult BindZooAndAnimalSpecies(BindZooWithAnimalSpeciesViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var bindings = _animalWorldService.GetBingZooAndAnimalSpeciesInfo();
                viewModel.Zoos = bindings.Zoos;
                viewModel.AnimalSpecies = bindings.AnimalSpecies;
                return View(viewModel);
            }

            if (_animalWorldService.BindZooWithAnimalSpecies(viewModel.ZooId, viewModel.AnimalSpeciesId))
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
