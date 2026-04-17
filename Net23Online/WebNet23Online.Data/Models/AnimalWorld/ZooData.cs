namespace WebNet23Online.Data.Models.AnimalWorld
{
    public class ZooData : BaseModel
    {
        public string ZooName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public List<AnimalSpeciesData> AnimalSpecies { get; set; }
    }
}
