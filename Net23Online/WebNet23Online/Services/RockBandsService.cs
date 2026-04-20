using NAudio.Codecs;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class RockBandsService : IRockBandsService
    {
        private IRockBandsRepository _rockBandsRepository;
        private IGenreOfRockBandsRepository _genreOfRockBandsRepository;

        public RockBandsService(
            IRockBandsRepository rockBandsRepository,
            IGenreOfRockBandsRepository genreOfRockBandsRepository)
        {
            _rockBandsRepository = rockBandsRepository;
            _genreOfRockBandsRepository = genreOfRockBandsRepository;
        }

        public List<BandBlockViewModel> GetBands(int[]? genreIds = null)
        {
            var bandsBlockViewData = (genreIds != null && genreIds.Length > 0)
                ? _rockBandsRepository.GetByGenreIdsWithGenres(genreIds)
                : _rockBandsRepository.GetAllWithGenres();

            return bandsBlockViewData
                   .OrderBy(b => b.Id)
                   .Select(b => new BandBlockViewModel
                   {
                       Id = b.Id,
                       Name = b.Name,
                       Description = b.Description,
                       ImageUrl = string.IsNullOrWhiteSpace(b.Url) ? null : b.Url,
                       GenreIds = b.RockBandGenres.Select(bg => bg.GenreId).ToList(),
                       Genres = b.RockBandGenres
                            .Select(bg => bg.Genre.Name)
                            .OrderBy(x => x)
                            .ToList(),
                   })
                   .ToList();
        }

        public List<GenreFilterItemViewModel> GetGenres()
        {
            return _genreOfRockBandsRepository
                .GetAll()
                .OrderBy(g => g.Name)
                .Select(g => new GenreFilterItemViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    IsSelected = false,
                })
                .ToList();
        }

        public void AddBand(BandBlockViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrWhiteSpace(viewModel.Name))
            {
                return;
            }

            var genreIds = (viewModel.SelectedGenreIds ?? Array.Empty<int>())
                .Where(x => x > 0)
                .Distinct()
                .ToArray();

            var newBand = new RockBandsData
            {
                Name = viewModel.Name.Trim(),
                Description = viewModel.Description?.Trim() ?? string.Empty,
                Url = string.IsNullOrWhiteSpace(viewModel.ImageUrl)
                    ? string.Empty
                    : viewModel.ImageUrl.Trim(),
                RockBandGenres = genreIds
                    .Select(id => new RockBandGenreData { GenreId = id })
                    .ToList(),
            };

            _rockBandsRepository.Add(newBand);
        }

        public void UpdateBandGenres(int bandId, int[] genreIds)
        {
            if (bandId <= 0)
            {
                return;
            }

            _rockBandsRepository.UpdateBandGenres(bandId, genreIds);
        }
    }
}
