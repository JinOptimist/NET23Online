namespace WebNet23Online.Data.Models
{
    public class AnimeData : BaseModel
    {
        public string Name { get; set; }

        public virtual AnimeStudioData Studio { get; set; }
        public virtual List<AnimeGirlData> Heroes { get; set; }
    }
}
