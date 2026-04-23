using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories;

public class HabitDoneDatesRepository : BaseRepository<HabitDoneDatesData>, IHabitDoneDatesRepository
{
    public HabitDoneDatesRepository(WebContext context) : base(context)
    {
    }
    public void ChangeDayPointStatus(int habitId, int dayOfWeek)
    {
        Console.WriteLine($"CLICK: habitId={habitId}, dayOfWeek={dayOfWeek}");
        var today = DateTime.Today;
        Console.WriteLine($"TODAY: {DateTime.Today}");
        int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
        var weekStart = today.AddDays(-1* diff);
        Console.WriteLine($"WEEK START: {weekStart}");
        var targetDate = weekStart.AddDays(dayOfWeek);
        Console.WriteLine($"TARGET DATE: {targetDate}");

        var targetDateDone = _dbSet
            .Where(x => x.Habit.Id == habitId)
            .FirstOrDefault(x => x.DateOfCompletion.Date == targetDate.Date);
    
        if (targetDateDone == null)
        {
            var habit = _context.Habits.FirstOrDefault(x => x.Id == habitId);

            Add(new HabitDoneDatesData
            {
                DateOfCompletion = targetDate.Date,
                Habit = habit
            });
        }
        else
        {
            Remove(targetDateDone);
        }
        
        Console.WriteLine($"FOUND: {targetDateDone != null}");
        Console.WriteLine($"TARGET DATE: {targetDate}");

        var all = _dbSet
            .Where(x => x.Habit.Id == habitId)
            .ToList();

        foreach (var a in all)
        {
            Console.WriteLine($"IN DB: {a.DateOfCompletion}");
        }
    }
}