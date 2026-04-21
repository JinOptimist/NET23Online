using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data.Enums.Steam;

namespace WebNet23Online.Models.Steam
{
    public class AddGameViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public GameGenre Genre { get; set; }
        public int? PublisherId {  get; set; }

        public List<GameGenre> AllGenres { get; set; } = new List<GameGenre>();
        public List<SelectListItem> Publishers { get; set; } = new();
    }
}

