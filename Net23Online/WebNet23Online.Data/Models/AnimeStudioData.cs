namespace WebNet23Online.Data.Models
{
    public class AnimeStudioData : BaseModel
    {
        public string Name { get; set; }

        public virtual List<AnimeData> Animes { get; set; }
    }
}
