using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        private IAnimeRepository _animeRepository;

        public AnimeGirlController(IAnimeGirlGenerator animeGirlGenerator,
            IAnimeGirlRepository animeGirlRepository,
            IAnimeRepository animeRepository)
        {
            _animeGirlGenerator = animeGirlGenerator;
            _animeGirlRepository = animeGirlRepository;
            _animeRepository = animeRepository;
        }

        //    /AnimeGirl/Index
        public IActionResult Index()
        {
            var animeGirlDatas = _animeGirlRepository.GetAllIncludeAnime();
            var animeDatas = _animeRepository.GetAll();

            var viewModels = _animeGirlGenerator.GenerateList(animeGirlDatas);
            var animeViewModels = _animeGirlGenerator.AnimeMap(animeDatas);

            var mainViewModel = new MainIndexViewModel
            {
                AnimeGirls = viewModels,
                Animes = animeViewModels
            };

            return View(mainViewModel);
        }

        [HttpGet]
        public IActionResult CreateGirl()
        {
            var animes = _animeRepository.GetAll();
            var animeListItems = new List<SelectListItem>();
            animeListItems.Add(new SelectListItem
            {
                Text = "SelectAnime",
                Value = ""
            });
            animeListItems.AddRange(animes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));
            
            var viewModel = new CreateAnimeGirlViewModel
            {
                Animes = animeListItems
            };

            return View(viewModel);
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

            if (!_animeGirlRepository.IsNameFree(viewModel.Name))
            {
                return View(viewModel);
            }

            if (viewModel.AnimeId is not null
                && viewModel.AnimeId > 0)
            {
                var anime = _animeRepository.Get(viewModel.AnimeId.Value);
                animeGirlData.Animes.Add(anime!);
            }

            _animeGirlRepository.Add(animeGirlData);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateAnime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAnime(CreateAnimeViewModel viewModel)
        {
            var anime = new AnimeData
            {
                Name = viewModel.Name,
                CoverUrl = viewModel.CoverUrl
            };
            _animeRepository.Add(anime);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult LinkAnimeAndGirl(int animeId, int heroId)
        {
            _animeGirlRepository.Link(animeId, heroId);
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
