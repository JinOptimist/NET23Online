using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.AnimeGirl
{
    public class CreateAnimeViewModel
    {
        public string Name { get; set; }
        public string CoverUrl { get; set; }

        [MinMaxCheck(1, 100)]
        public int Rating { get; set; }
    }
}