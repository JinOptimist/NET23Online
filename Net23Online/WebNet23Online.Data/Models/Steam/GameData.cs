using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Enums.Steam;

namespace WebNet23Online.Data.Models.Steam
{
    public class GameData : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int? PublisherId {  get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; }    

        public virtual PublisherData Publisher { get; set; } 
        public virtual List<GameGenreData> GameGenres { get; set; }
    }
}
