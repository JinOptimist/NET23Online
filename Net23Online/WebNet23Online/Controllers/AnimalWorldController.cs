using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Models.AnimalWorld;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class AnimalWorldController : Controller
    {
        private IAnimalWorldService _animalWorldService;
        private WebContext _webContext;

        public AnimalWorldController(IAnimalWorldService animalWorldService, WebContext webContext)
        {
            _animalWorldService = animalWorldService;
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            var animals = _webContext.Beasts.ToList();
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
            if (_animalWorldService.AddAnimal(viewModel))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult AnimalSearch(StartPageBeastViewModel viewModel)
        {
            return PartialView(_animalWorldService.SearchAnimal(viewModel));
        }
    }
}
