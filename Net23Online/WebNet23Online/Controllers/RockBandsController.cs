using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class RockBandsController : Controller
    {
        private readonly IRockBandsService _rockBandsService;

        public RockBandsController(IRockBandsService rockBandsService)
        {
            _rockBandsService = rockBandsService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] int[]? genreIds, [FromQuery] int? editBandId)
        {
            var selectedGenreIds = genreIds ?? Array.Empty<int>();
            var genres = _rockBandsService.GetGenres();
            foreach (var g in genres)
            {
                g.IsSelected = selectedGenreIds.Contains(g.Id);
            }

            var viewModel = new RockBandsIndexViewModel
            {
                Bands = _rockBandsService.GetBands(selectedGenreIds),
                Genres = genres,
                SelectedGenreIds = selectedGenreIds,
                EditBandId = editBandId,
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Index(RockBandsIndexViewModel viewModel)
        {
            var band = viewModel.BandBlock;
            if (!ModelState.IsValid)
            {
                var genres = _rockBandsService.GetGenres();
                var startViewModel = new RockBandsIndexViewModel
                {
                    Bands = _rockBandsService.GetBands(Array.Empty<int>()),
                    Genres = genres,
                    SelectedGenreIds = Array.Empty<int>(),
                    EditBandId = null,
                    BandBlock = band,
                };
                return View(startViewModel);
            }

            _rockBandsService.AddBand(band);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateGenres(int bandId, int[] selectedGenreIds)
        {
            _rockBandsService.UpdateBandGenres(bandId, selectedGenreIds);
            return RedirectToAction(nameof(Index), new { editBandId = bandId });
        }
    }
}
