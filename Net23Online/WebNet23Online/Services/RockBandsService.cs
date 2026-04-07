using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Service
{
    public class RockBandsService : IRockBandsService
    {

        // STATIC IS A BAD IDEA — REMOVE AFTER ADD DATABASE
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

        public List<BandBlockViewModel> GetBands()
        {
            return _bands.ToList();
        }

        public void AddBand(BandBlockViewModel viewModel)
        {
            if (viewModel == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(viewModel.Name))
            {
                return;
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
        }
    }
}
