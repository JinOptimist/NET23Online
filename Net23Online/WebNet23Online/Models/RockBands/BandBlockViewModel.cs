using System.ComponentModel.DataAnnotations;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.RockBands
{
    public class BandBlockViewModel
    {
        public int Id { get; set; }

        [IsUniqBandName(ErrorMessage = "Such a group already exists")]
        public string Name { get; set; } = string.Empty;

        [TheWritingIsLongEnough(5, 25, ErrorMessage = "The description must contain between 5 and 25 words.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A url to the photo is required")]
        public string? ImageUrl { get; set; }
        public List<string> Genres { get; set; } = new();
        public List<int> GenreIds { get; set; } = new();

        public int[] SelectedGenreIds { get; set; } = Array.Empty<int>();
    }
}
