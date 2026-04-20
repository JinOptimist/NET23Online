using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.AnimeGirl
{
    public class CreateAnimeGirlViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? AnimeId { get; set; }

        public List<SelectListItem> Animes { get; set; } = new();
    }
}
