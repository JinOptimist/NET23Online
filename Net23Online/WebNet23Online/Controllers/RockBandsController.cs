using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.RockBands;

namespace WebNet23Online.Controllers
{
    public class RockBandsController : Controller
    {
        // STATIC IS A BAD IDEA — REMOVE AFTER ADD DATABASE (как у преподавателя в Maze)
        private static readonly List<BandBlockViewModel> _bands =
        [
            new BandBlockViewModel
            {
                Name = "Bring Me The Horizon",
                Description =
                    "Британская рок-группа, известная своим экспериментальным звучанием и мощной энергетикой.",
                ImageUrl = "/images/rock-bands/BMTH.jpg",
            },
            new BandBlockViewModel
            {
                Name = "Slipknot",
                Description = "Легендарная метал-группа с агрессивным стилем и уникальным визуальным образом.",
                ImageUrl = "/images/rock-bands/slipknot.jpg",
            },
            new BandBlockViewModel
            {
                Name = "Metallica",
                Description = "Одна из самых влиятельных метал-групп в истории с культовыми альбомами.",
                ImageUrl = "/images/rock-bands/metallica.jpg",
            },
        ];

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new RockBandsIndexViewModel { Bands = _bands.ToList() };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(BandBlockViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Name))
            {
                return RedirectToAction(nameof(Index));
            }

            _bands.Add(
                new BandBlockViewModel
                {
                    Name = viewModel.Name?.Trim() ?? string.Empty,
                    Description = viewModel.Description?.Trim() ?? string.Empty,
                    ImageUrl = string.IsNullOrWhiteSpace(viewModel.ImageUrl)
                        ? null
                        : viewModel.ImageUrl.Trim(),
                }
            );
            return RedirectToAction(nameof(Index));
        }
    }
}
