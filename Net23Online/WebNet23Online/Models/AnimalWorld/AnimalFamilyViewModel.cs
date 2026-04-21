using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.AnimalWorld
{
    public class AnimalFamilyViewModel
    {
        [Required]
        [UniqueName(typeof(IAnimalFamilyRepository))]
        public string AnimalFamilyName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
