namespace WebNet23Online.Models.AnimalWorld
{
    public class StartPageAnimalViewModel
    {
        public StartPageAnimalViewModel(string name, string briefDescription)
        {
            Name = name;
            BriefDescription = briefDescription;
        }

        public string Name { get; set; }

        public string BriefDescription { get; set; }
    }
}
