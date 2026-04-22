namespace WebNet23Online.Models.HabitTracker;

public class HabitViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public List<bool> WeekResults { get; set; } = new();
    public int DoneCount { get; set; }
    public double Percent { get; set; }    
}