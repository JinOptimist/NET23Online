using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Models.AnimalWorld;
using WebNet23Online.Models.CustomValidatioAttributes.AnimalWorld;

namespace WebNet23Online.Models.AnimalWorld
{
    public class AnimalFamilyViewModel
    {
        [Required]
        [UniqueName(typeof(AnimalFamilyData))]
        public string AnimalFamilyName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
