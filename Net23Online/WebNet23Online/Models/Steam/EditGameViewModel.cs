using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Enums.Steam;
using WebNet23Online.Models.CustomValidatioAttributes.Steam;

namespace WebNet23Online.Models.Steam
{
    public class EditGameViewModel
    {
        public int Id { get; set; }

        [Required]
        [UniqueGameTitle]
        [NoSpecialCharacters]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [NoSpecialCharacters]
        public string Description { get; set; } = string.Empty;

        [Required]
        [ValidateImageUrl]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [MaxPrice]
        public decimal Price { get; set; }

        [Required]
        public GameGenre Genre { get; set; }
        public int? PublisherId { get; set; }

        public List<GameGenre> Genres { get; set; } = new();
        public List<SelectListItem> Publishers { get; set; } = new();
    }
}
