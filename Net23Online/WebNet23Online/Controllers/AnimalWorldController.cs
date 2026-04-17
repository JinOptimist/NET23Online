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
            TempData["AnimalWorldAddMessage"] = "Форма добавления зоопарка отправлена.";
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
            TempData["AnimalWorldAddMessage"] = "Форма добавления рода отправлена.";
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
            TempData["AnimalWorldAddMessage"] = "Форма добавления вида отправлена.";
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult BindZooFamily()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BindZooFamily(BindZooFamilyViewModel viewModel)
        {
            TempData["AnimalWorldAddMessage"] = "Привязка зоопарка к родам отправлена.";
            return RedirectToAction("Add");
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
