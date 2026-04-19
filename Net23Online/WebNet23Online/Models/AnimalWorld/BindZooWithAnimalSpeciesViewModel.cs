using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.AnimalWorld
{
    public class BindZooWithAnimalSpeciesViewModel
    {
        public int ZooId { get; set; }
        public int AnimalSpeciesId { get; set; }
        public List<SelectListItem> Zoos { get; set; }
        public List<SelectListItem> AnimalSpecies { get; set; }
    }
}
