using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.AnimalWorld
{
    public class ZooViewModel
    {
        [Required]
        [UniqueName(typeof(IZooRepository))]
        public string ZooName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public List<AnimalSpeciesViewModel> AnimalSpecies { get; set; } = new List<AnimalSpeciesViewModel>();
    }
}
