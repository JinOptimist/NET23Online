namespace WebNet23Online.Models.EventWorkshop
{
    public class EventInfoViewModel
    {
        public EventCategory Category { get; set; }
        public bool HasFood { get; set; }
        public bool HasGear { get; set; }
        public bool HasBed { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
