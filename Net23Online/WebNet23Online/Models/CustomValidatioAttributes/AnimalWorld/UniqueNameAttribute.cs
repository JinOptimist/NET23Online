using System.ComponentModel.DataAnnotations;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;

namespace WebNet23Online.Models.CustomValidatioAttributes.AnimalWorld
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        private Type _dataType;

        public UniqueNameAttribute(Type dataType)
        {
            _dataType = dataType;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            var targetInterface = typeof(IAnimalWorldRepository<>).MakeGenericType(_dataType);
            IServiceProvider serviceProvider = validationContext;
            var repository = serviceProvider.GetService(targetInterface);
            if (repository == null)
            {
                var implementationType = _dataType.Assembly.GetTypes()
                    .FirstOrDefault(t => t.IsClass && !t.IsAbstract && targetInterface.IsAssignableFrom(t));
                if (implementationType != null)
                {
                    var registeredInterface = implementationType.GetInterfaces()
                        .FirstOrDefault(i => serviceProvider.GetService(i) != null);
                    if (registeredInterface != null)
                    {
                        repository = serviceProvider.GetService(registeredInterface);
                    }
                    else
                    {

                        repository = serviceProvider.GetService(implementationType);
                    }
                }
            }

            if (repository == null)
            {
                return new ValidationResult($"Не удалось автоматически найти метод");
            }

            var nameableInterfaceType = typeof(INameableRepository<>).MakeGenericType(_dataType);
            var method = nameableInterfaceType.GetMethod(nameof(INameableRepository<BaseModel>.GetElementByName));

            if (method == null)
            {
                return new ValidationResult("Метод проверки уникальности не найден.");
            }

            var result = method.Invoke(repository, new object[] { name });

            if (result != null)
            {
                return new ValidationResult(ErrorMessage ?? "Такое имя уже используется");
            }

            return ValidationResult.Success;
        }
    }
}
