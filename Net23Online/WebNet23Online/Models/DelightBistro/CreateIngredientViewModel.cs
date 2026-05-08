using System.ComponentModel.DataAnnotations;
using WebNet23Online.Models.CustomValidatioAttributes.DelightBistro;

namespace WebNet23Online.Models.DelightBistro
{
    public class CreateIngredientViewModel
    {
        public int Id { get; set; }
        [Required]
        [IsUniqueIngredient]
        public string Name { get; set; }
        public int Price { get; set; } = 0;
        public bool IsSelected { get; set; } = false;
    }
}
