using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
namespace WebNet23Online.Models.CustomValidatioAttributes
{
    public class AllowedStringValuesAttribute : ValidationAttribute
    {
        private string[] _allowedStringValues;

        public AllowedStringValuesAttribute(params string[] allowedValues)
        {
            _allowedStringValues = allowedValues;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"The field {name} must be one of the following values: {string.Join(", ", _allowedStringValues)}."
                : ErrorMessage;
        }
        public override bool IsValid(object? value)
        {
            ArgumentNullException.ThrowIfNull(value);
            var stringValue = value as string;
            ArgumentNullException.ThrowIfNull(stringValue, "AllowedStringValuesAttribute must be used on string fields");

            return _allowedStringValues.Contains(stringValue);
        }
    }
}
