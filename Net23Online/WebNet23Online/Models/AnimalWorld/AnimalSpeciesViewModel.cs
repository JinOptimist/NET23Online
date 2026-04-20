using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebNet23Online.Models.AnimalWorld
{
    public class AnimalSpeciesViewModel
    {
        [Required]
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
