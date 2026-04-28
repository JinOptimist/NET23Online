namespace WebNet23Online.Data.Models
{
    public class LittleLemonGuestData : BaseModel
    {
        public string Name { get; set; }

        public virtual List<LittleLemonData> Reservations { get; set; } = new();
    }
}
