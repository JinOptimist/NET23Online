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
            return View(_animalWorldService.GetAllAnimals());
        }

        [HttpGet]
        public IActionResult AddAnimal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnimal(AnimalSpeciesViewModel viewModel)
        {
            if (_animalWorldService.AddAnimal(viewModel))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AnimalSearch(AnimalSpeciesViewModel viewModel)
        {
            return PartialView(_animalWorldService.SearchAnimal(viewModel));
        }
    }
}
