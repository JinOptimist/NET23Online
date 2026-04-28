namespace WebNet23Online.Models.RockBands
{
    public class RockBandsIndexViewModel
    {
        public bool IsUserAuth { get; set; }
        public bool CanEditRockBandGenres { get; set; }
        public bool IsUserAuth { get; set; }
        public List<BandBlockViewModel> Bands { get; set; } = new();
        public List<GenreFilterItemViewModel> Genres { get; set; } = new();
        public int[] SelectedGenreIds { get; set; } = Array.Empty<int>();
        public int? EditBandId { get; set; }
        public BandBlockViewModel BandBlock { get; set; } = new BandBlockViewModel();
    }
}
