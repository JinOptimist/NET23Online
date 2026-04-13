namespace WebNet23Online.Data.Models;

public class HabitData : BaseModel
{
    public string Title { get; set; } 
    public string ColorOfDot { get; set; }
    
    public List<bool> WeekResults { get; set; }
    public int DoneCount { get; set; }
    public double Percent { get; set; }   
}