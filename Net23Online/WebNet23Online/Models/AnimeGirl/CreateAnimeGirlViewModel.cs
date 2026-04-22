using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.AnimeGirl
{
    public class CreateAnimeGirlViewModel
    {
        [IsUniqGirlName]
        [Required(ErrorMessage = "Name can not be empty")]
        public string Name { get; set; }
        
        [DoubleCheck]
        public string DoubleCheckName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Girl with out image is sad")]
        public string Url { get; set; }

        [MinMaxCheck(1, 5)]
        public int Size { get; set; }

        public int? AnimeId { get; set; }

        public List<SelectListItem> Animes { get; set; } = new();
    }
}
