namespace WebNet23Online.Models.RockBands
{
    public class RockBandsIndexViewModel
    {
        public List<BandBlockViewModel> Bands { get; set; } = new();
        public List<GenreFilterItemViewModel> Genres { get; set; } = new();
        public int[] SelectedGenreIds { get; set; } = Array.Empty<int>();
        public int? EditBandId { get; set; }
    }
}
