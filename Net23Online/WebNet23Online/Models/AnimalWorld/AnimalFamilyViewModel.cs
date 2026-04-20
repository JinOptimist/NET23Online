using System.ComponentModel.DataAnnotations;

namespace WebNet23Online.Models.AnimalWorld
{
    public class AnimalFamilyViewModel
    {
        [Required]
        public string AnimalFamilyName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
