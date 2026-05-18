using System.ComponentModel.DataAnnotations;

namespace WebNet23Online.Models.CustomValidatioAttributes.Steam
{
    public class NoSpecialCharactersAttribute : ValidationAttribute
    {
        private readonly char[] SPECIAL_CHARACTERS =
        {
           '@', '#', '$', '%', '^', '&', '*', ';', '/', '\\'
        };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var field = value as string;

            if (string.IsNullOrWhiteSpace(field))
            {
                return new ValidationResult("Field cannot be empty or whitespace");
            }

            if (SPECIAL_CHARACTERS.Any(c => field.Contains(c)))
            {
                var specialCharsString = string.Join(", ", SPECIAL_CHARACTERS);
                return new ValidationResult($"Field cannot contain special characters: {specialCharsString}");
            }

            return ValidationResult.Success;
        }
    }
}
