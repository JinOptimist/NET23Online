namespace WebNet23Online.Data.Models
{
    public class RockLegendsData : BaseModel
    {
        public string GroupNames { get; set; }
        public int Likes { get; set; }
        public int? RockLegendsGenresId { get; set; }
        public virtual RockLegendsGenres? Genres { get; set; } 
    }
}
