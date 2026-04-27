using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;

namespace WebNet23Online.Models.CustomValidatioAttributes;

public class IsHabitTitleUniqAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not string title)
        {
            return ValidationResult.Success;
        }

        var habitModel = validationContext.ObjectInstance as HabitViewModel;
        var habitId = habitModel.Id;

        var habitService = validationContext.GetRequiredService<IHabitService>();
        if (!habitService.IsHabitTitleUniq(title, habitId))
        {
            return new ValidationResult(
                string.IsNullOrEmpty(ErrorMessage) 
                    ? $"Name '{title}' is not unique"
                    : FormatErrorMessage(validationContext.MemberName)
            );
        }
        
        return ValidationResult.Success;
    }
}