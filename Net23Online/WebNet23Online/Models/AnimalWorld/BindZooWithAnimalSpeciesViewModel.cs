using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.AnimalWorld
{
    public class BindZooWithAnimalSpeciesViewModel
    {
        public string ZooName { get; set; }
        public List<SelectListItem> Zoos { get; set; }
        public List<SelectListItem> AnimalSpecies { get; set; }
    }
}
