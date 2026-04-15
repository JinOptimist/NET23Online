namespace WebNet23Online.Models.HabitTracker;

public class HabitTrackerViewModel
{
    public string UserName { get; set; }
    public List<HabitViewModel> Habits { get; set; } = new List<HabitViewModel>();
}