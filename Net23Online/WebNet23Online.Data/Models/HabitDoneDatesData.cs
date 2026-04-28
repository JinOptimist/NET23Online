namespace WebNet23Online.Data.Models;

public class HabitDoneDatesData : BaseModel
{
    public DateTime DateOfCompletion { get; set; }
    public int HabitId { get; set; }
    public virtual HabitData Habit { get; set; }
}