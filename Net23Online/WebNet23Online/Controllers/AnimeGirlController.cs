using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Globalization;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class AnimeGirlController : Controller
    {
        private IAnimeGirlService _animeGirlService;
        private IAnimeGirlRepository _animeGirlRepository;
        private IAnimeRepository _animeRepository;
        private IAuthService _authService;

        public AnimeGirlController(IAnimeGirlService animeGirlGenerator,
            IAnimeGirlRepository animeGirlRepository,
            IAnimeRepository animeRepository,
            IAuthService authService)
        {
            _animeGirlService = animeGirlGenerator;
            _animeGirlRepository = animeGirlRepository;
            _animeRepository = animeRepository;
            _authService = authService;
        }

        //    /AnimeGirl/Index
        public IActionResult Index()
        {
            var animeGirlDatas = _animeGirlRepository.GetAllIncludeAnime();
            var animeDatas = _animeRepository.GetAll();

            var viewModels = _animeGirlService.GenerateList(animeGirlDatas);
            var animeViewModels = _animeGirlService.AnimeMap(animeDatas);

            var mainViewModel = new MainIndexViewModel
            {
                AnimeGirls = viewModels,
                Animes = animeViewModels,
                CanDeleteGirl = _authService.AtLeastModerator()
            };

            return View(mainViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateGirl()
        {
            var viewModel = new CreateAnimeGirlViewModel
            {
                Animes = _animeGirlService.GetListItemsWithAnime()
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateGirl(CreateAnimeGirlViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Animes = _animeGirlService.GetListItemsWithAnime();
                return View(viewModel);
            }

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
        [Authorize]
        public IActionResult CreateAnime()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
