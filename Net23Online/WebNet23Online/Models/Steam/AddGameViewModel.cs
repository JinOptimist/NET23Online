using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.Steam
{
    public class AddGameViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? PublisherId {  get; set; }
        public List<int> SelectedGenreIds { get; set; } = new();

        public List<SelectListItem> AllGenres { get; set; } = new ();
        public List<SelectListItem> Publishers { get; set; } = new();
    }
}