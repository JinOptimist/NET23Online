
namespace WebNet23Online.Data.Models.Steam
{
    public class PublisherData : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<GameData> Games { get; set; }
    }
}
