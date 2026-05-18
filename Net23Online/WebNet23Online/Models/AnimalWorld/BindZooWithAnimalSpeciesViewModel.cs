using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebNet23Online.Models.AnimalWorld
{
    public class BindZooWithAnimalSpeciesViewModel
    {
        [Required]
        public int ZooId { get; set; }

        [Required]
        public int AnimalSpeciesId { get; set; }

        public List<SelectListItem> Zoos { get; set; } = new();

        public List<SelectListItem> AnimalSpecies { get; set; } = new();
    }
}
