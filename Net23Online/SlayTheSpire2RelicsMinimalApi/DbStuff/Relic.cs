namespace SlayTheSpire2RelicsMinimalApi.DbStuff
{
    public class Relic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; } = "";
        public string Characters { get; set; } = "All";
    }
}
