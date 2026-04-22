using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services.DelightBistro
{
    public class IngredientGenerator : IIngredientGenerator
    {
        private IIngredientsRepository _ingredientsRepository;

        public IngredientGenerator(IIngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }
        public void FeelDataBase()
        {
            if (_ingredientsRepository.Any())
            {
                return;
            }
            _ingredientsRepository.Add(new IngredientData { Name = "Креветки" });
            _ingredientsRepository.Add(new IngredientData { Name = "Шампиньоны" });
            _ingredientsRepository.Add(new IngredientData { Name = "Лайм" });
            _ingredientsRepository.Add(new IngredientData { Name = "Паста" });
        }

        public CreateIngredientViewModel ConvertDataToVM(IngredientData ingredientData)
        {
            var ingredientViewModel = new CreateIngredientViewModel
            {
                Id = ingredientData.Id,
                Name = ingredientData.Name,
            };
            return ingredientViewModel;
        }

        public List<CreateIngredientViewModel> GenerateIngredients(List<IngredientData> ingredientsData)
        {
            var ingredientsViewModel = ingredientsData.Select(x => new CreateIngredientViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsSelected = false
            }).ToList();

            return ingredientsViewModel;
        }

        public void CreateIngredientData(CreateIngredientViewModel ingredient)
        {
            var ingredientData = new IngredientData
            {
                Name = ingredient.Name,
            };

            _ingredientsRepository.Add(ingredientData);
        }

    }
}
