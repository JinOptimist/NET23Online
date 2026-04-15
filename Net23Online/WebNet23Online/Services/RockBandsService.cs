using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class RockBandsService : IRockBandsService
    {
        private IRockBandsRepository _rockBandsRepository;

        public RockBandsService(IRockBandsRepository rockBandsRepository)
        {
            _rockBandsRepository = rockBandsRepository;
        }

        public List<BandBlockViewModel> GetBands(int[]? genreIds = null)
        {
            var bandsData = (genreIds is { Length: > 0 })
                ? _rockBandsRepository.GetByGenreIdsWithGenres(genreIds)
                : _rockBandsRepository.GetAllWithGenres();

            return bandsData
                   .OrderBy(b => b.Id)
                   .Select(b => new BandBlockViewModel
                   {
                       Name = b.Name,
                       Description = b.Description,
                       ImageUrl = string.IsNullOrWhiteSpace(b.Url) ? null : b.Url,
                       Genres = b.RockBandGenres
                            .Select(bg => bg.Genre.Name)
                            .OrderBy(x => x)
                            .ToList(),
                   })
                   .ToList();
        }

        public void AddBand(BandBlockViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrWhiteSpace(viewModel.Name))
            {
                return;
            }

            var newBand = new RockBandsData
            {
                Name = viewModel.Name.Trim(),
                Description = viewModel.Description?.Trim() ?? string.Empty,
                Url = string.IsNullOrWhiteSpace(viewModel.ImageUrl)
                    ? string.Empty
                    : viewModel.ImageUrl.Trim(),
            };

            _rockBandsRepository.Add(newBand);
        }
    }
}
