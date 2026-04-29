namespace WebNet23Online.Data.Models.AnimalWorld
{
    public class AnimalFamilyData : BaseModel
    {
        public string AnimalFamilyName { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public virtual List<AnimalSpeciesData> Species { get; set; }

        public virtual UserData Creator { get; set; }
    }
}
