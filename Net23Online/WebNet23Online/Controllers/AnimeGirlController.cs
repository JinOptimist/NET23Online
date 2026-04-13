using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
   
    public class AnimeGirlController : Controller
    {
        private IAnimeGirlGenerator _animeGirlGenerator;
        private IAnimeGirlRepository _animeGirlRepository;

        public AnimeGirlController(IAnimeGirlGenerator animeGirlGenerator, 
            IAnimeGirlRepository animeGirlRepository)
        {
            _animeGirlGenerator = animeGirlGenerator;
            _animeGirlRepository = animeGirlRepository;
        }

        //    /AnimeGirl/Index
        public IActionResult Index()
        {
            var animeGirlDatas = _animeGirlRepository.GetAll();

            var viewModels = _animeGirlGenerator.GenerateList(animeGirlDatas);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateGirl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGirl(CreateAnimeGirlViewModel viewModel)
        {
            var animeGirlData = new AnimeGirlData
            {
                Description = viewModel.Description,
                Name = viewModel.Name,
                Url = viewModel.Url,
            };

            if (_animeGirlRepository.IsNameFree(viewModel.Name))
            {
                return View(viewModel);
            }

            _animeGirlRepository.Add(animeGirlData);

            return RedirectToAction(nameof(Index));
        }

        //    /AnimeGirl/Handmade
        public IActionResult Handmade()
        {
            var minutes = DateTime.Now.Minute;
            var second = DateTime.Now.Second;
            var name = "Ivan";

            var viewModel = new HandMadeViewModel
            {
                Minutes = minutes,
                Seconds = second,
                Name = name
            };
            
            return View(viewModel);
        }
    }
}
