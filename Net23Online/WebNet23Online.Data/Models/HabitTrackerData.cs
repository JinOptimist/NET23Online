namespace WebNet23Online.Data.Models;

public class HabitTrackerData : BaseModel
{
    public string UserName { get; set; }
    public List<HabitData> Habits { get; set; }
}