using WebNet23Online.Data.Enums.Steam;

namespace WebNet23Online.Data.HelperModels
{
    public class GameFilter
    {
        public GameGenre? Genre { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
