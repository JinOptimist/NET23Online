using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Models.CustomValidatioAttributes;

public class IsHabitTitleUniqAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not string title)
        {
            return ValidationResult.Success;
        }

        var repository = validationContext.GetRequiredService<IHabitRepository>();
        if (!repository.IsHabitTitleUniq(title))
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