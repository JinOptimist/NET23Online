using WebNet23Online.Models.RockBands;

namespace WebNet23Online.Services.Interfaces
{
    public interface IRockBandsService
    {
        void AddBand(BandBlockViewModel viewModel);
        List<BandBlockViewModel> GetBands(int[]? genreIds = null);
        List<GenreFilterItemViewModel> GetGenres();
    }
}