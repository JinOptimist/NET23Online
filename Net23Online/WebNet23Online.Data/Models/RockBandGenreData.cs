namespace WebNet23Online.Data.Models
{
    public class RockBandGenreData : BaseModel
    {
        public int RockBandId { get; set; }
        public int GenreId { get; set; }
        public virtual RockBandsData RockBand { get; set; } = null!;
        public virtual GenreOfRockBandsData Genre { get; set; } = null!;
    }
}