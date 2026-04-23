using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;

namespace WebNet23Online.Models.CustomValidatioAttributes.AnimalWorld
{
    public class ZooUniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value as string;
            var repository = validationContext.GetRequiredService<IZooRepository>();
            if (repository.GetElementByName(name) != null)
            {
                return new ValidationResult("Такое имя уже используется");
            }

            return ValidationResult.Success;
        }
    }
}
