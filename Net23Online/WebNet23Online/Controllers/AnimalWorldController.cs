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
            return View(_animalWorldService.GetRandomAnimals());
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(StartPageBeastViewModel viewModel)
        {
            if (!_animalWorldService.AddAnimal(viewModel))
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AnimalSearch(StartPageBeastViewModel viewModel)
        {
            var searchBeast = _animalWorldService.SearchAnimal(viewModel);

            if (searchBeast == null)
            {
                return PartialView();
            }

            return PartialView(searchBeast);
        }
    }
}
