using System.ComponentModel.DataAnnotations;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Models.HabitTracker;

public class HabitViewModel
{
    public int Id { get; set; } = 0;
    
    [Required(ErrorMessage = "Enter the title")]
    [IsHabitTitleUniq]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Too long name")]
    public string Title { get; set; }
    
    [MinMaxCheck(1, 31, ErrorMessage = "From 1 to 31 days in month")]
    public int MonthGoal { get; set; }
    
    public List<bool> WeekResults { get; set; } = new();
    public int DaysInMonth { get; set; }
    public int DoneCountInMonth { get; set; }
    public double Percent { get; set; }
    
    public int UserId { get; set; }
}