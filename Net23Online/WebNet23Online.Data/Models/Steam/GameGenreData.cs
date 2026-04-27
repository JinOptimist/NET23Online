
namespace WebNet23Online.Data.Models.Steam
{
    public class GameGenreData : BaseModel
    {
        public string Name { get; set; }

        public virtual List<GameData> Games {  get; set; }
    }
}
