namespace WebNet23Online.Models.RockBands
{
    public class BandBlockViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public List<string> Genres { get; set; } = new();
        public List<int> GenreIds { get; set; } = new();

        public int[] SelectedGenreIds { get; set; } = Array.Empty<int>();
    }
}
