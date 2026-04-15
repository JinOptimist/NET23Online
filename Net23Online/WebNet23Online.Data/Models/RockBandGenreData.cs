namespace WebNet23Online.Data.Models
{
    public class RockBandGenreData
    {
        public int RockBandId { get; set; }
        public RockBandsData RockBand { get; set; } = null!;
        public int genreId { get; set; }
        public GenreOfRockBands Genre { get; set; } = null!;
    }
}