namespace WebNet23Online.Data.Models;

public class HabitDoneDatesData : BaseModel
{
    public DateTime Date { get; set; }
    public virtual HabitData Habit { get; set; }
}