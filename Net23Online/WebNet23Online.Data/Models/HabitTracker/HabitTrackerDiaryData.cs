namespace WebNet23Online.Data.Models;

public class HabitTrackerDiaryData : BaseModel
{
    public DateTime Date { get; set; }
    public string Content { get; set; }
    
    public virtual UserData User { get; set; }
}