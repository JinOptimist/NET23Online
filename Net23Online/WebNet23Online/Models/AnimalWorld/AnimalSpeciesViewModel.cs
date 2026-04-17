using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.AnimalWorld
{
    public class AnimalSpeciesViewModel
    {
        public string AnimalSpeciesName { get; set; }
        public List<SelectListItem> AnimalFamilyNames { get; set; }
        public string NativeRange { get; set; }
        public string Description { get; set; }
    }
}
