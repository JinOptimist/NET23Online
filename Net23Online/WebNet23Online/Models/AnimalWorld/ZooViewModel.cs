using System.ComponentModel.DataAnnotations;

namespace WebNet23Online.Models.AnimalWorld
{
    public class ZooViewModel
    {
        [Required]
        public string ZooName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public List<AnimalSpeciesViewModel> AnimalSpecies { get; set; } = new List<AnimalSpeciesViewModel>();
    }
}
