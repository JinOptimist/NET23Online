using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace WebNet23Online.Models.CustomValidatioAttributes.AnimalWorld
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        private Type _repositoryType;
        private const string METHOD_NAME = "GetElementByName";

        public UniqueNameAttribute(Type repositoryType)
        {
            _repositoryType = repositoryType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            var repository = validationContext.GetRequiredService(_repositoryType);
            var method = _repositoryType.GetMethod(METHOD_NAME);
            if (method == null)
            {
                foreach (var interfaceType in _repositoryType.GetInterfaces())
                {
                    method = interfaceType.GetMethod(METHOD_NAME);
                    if (method != null)
                    {
                        break;
                    }
                }
            }

            if (method == null)
            {
                return new ValidationResult("Отсутствует метод");
            }

            var result = method.Invoke(repository, new object[] { name });
            if (result != null)
            {
                return new ValidationResult("Такое имя уже используется");
            }

            return ValidationResult.Success;
        }
    }
}
