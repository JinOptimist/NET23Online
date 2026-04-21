using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.AnimalWorld
{
    public class AnimalSpeciesViewModel
    {
        [Required]
        [UniqueName(typeof(IAnimalSpeciesRepository))]
        public string AnimalSpeciesName { get; set; }

        [Required]
        public int AnimalFamilyId { get; set; }

        public List<SelectListItem> AnimalFamilyNames { get; set; }

        [Required]
        public string NativeRange { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
    }
}
