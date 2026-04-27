namespace WebNet23Online.Data.Models;

public class HabitData : BaseModel
{
    public string Title { get; set; } 
    public int MonthGoal  { get; set; }
    
    public int UserId { get; set; }  
    public virtual UserData User { get; set; }
    public virtual List<HabitDoneDatesData> CompletedDates { get; set; }
}