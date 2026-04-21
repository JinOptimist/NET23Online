using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces.DelightBistro;

namespace WebNet23Online.Models.CustomValidatioAttributes.DelightBistro
{
    public class IsUniqueIngredientAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is not string)
            {
                return new ValidationResult("Use letters");
            }

            var name = value as string;

            var repository=validationContext.GetRequiredService<IIngredientsRepository>();
            if (!repository.IsNameFree(name))
            {
                return new ValidationResult("Name is already used");

            }
            return ValidationResult.Success;
        }
    }
}
