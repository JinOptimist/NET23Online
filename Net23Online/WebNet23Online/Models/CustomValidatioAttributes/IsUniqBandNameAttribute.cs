using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Models.CustomValidatioAttributes
{
    public class IsUniqBandNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationResult.Success;
            }

            var normalizedName = name.Trim();
            var repository = validationContext.GetRequiredService<IRockBandsRepository>();

            var isNameTaken = repository.IsBandNameTaken(normalizedName);

            if (isNameTaken)
            {
                return new ValidationResult(ErrorMessage ?? "Such a group already exists");
            }

            return ValidationResult.Success;
        }
    }
}

