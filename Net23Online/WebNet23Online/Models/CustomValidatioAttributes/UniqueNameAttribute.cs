using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Models.CustomValidatioAttributes
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        private readonly Type _repositoryType;

        public UniqueNameAttribute(Type repositoryType)
        {
            _repositoryType = repositoryType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            var repository = validationContext.GetService(_repositoryType) as INameCheckable;
            var existingElement = repository.GetElementByName(name);
            if (existingElement != null)
            {
                return new ValidationResult("Такое имя уже занято.");
            }

            return ValidationResult.Success;
        }
    }
}
