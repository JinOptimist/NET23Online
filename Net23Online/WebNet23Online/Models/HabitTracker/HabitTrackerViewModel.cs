namespace WebNet23Online.Models.HabitTracker;

public class HabitTrackerViewModel
{
    public List<HabitViewModel> Habits { get; set; } = new List<HabitViewModel>();
    public HabitViewModel EditHabit { get; set; } = new HabitViewModel();
}