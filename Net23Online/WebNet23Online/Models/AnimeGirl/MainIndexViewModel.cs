namespace WebNet23Online.Models.AnimeGirl
{
    public class MainIndexViewModel
    {
        public List<AnimeGirlImageInfoViewModel> AnimeGirls { get; set; }
        public List<IndexAnimeViewModel> Animes { get; set; }
        public bool CanDeleteGirl { get; set; }
    }
}
