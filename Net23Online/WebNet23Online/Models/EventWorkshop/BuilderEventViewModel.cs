namespace WebNet23Online.Models.EventWorkshop
{
    public class BuilderEventViewModel
    {
        public string Category { get; set; }
        public bool HasFood { get; set; }
        public bool HasGear { get; set; }
        public bool HasBed { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public SpanTime Time {  get; set; }
    }
}
