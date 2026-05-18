using System.ComponentModel.DataAnnotations;

namespace WebNet23Online.Models.CustomValidatioAttributes
{
    public class ValidationLengthUserCardAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is not int)
            {
                throw new Exception("Min max attribute must be on the int Setting");
            }
            var number = (int)value;
            return number >= 0;
        }
    }
}
