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
        private List<CreateIngredientViewModel> _ingredients;
        private IIngredientsRepository _ingredientsRepository;
        private const string SEPARATOR = ",";

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

            var ingredients = "Креветки, Шампиньоны, Лайм, Паста";

            _ingredients = ingredients.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new CreateIngredientViewModel
                {
                    Name = x.Trim()
                }).ToList();

            var ingredientsVM = _ingredients;
            foreach (var ingredientVM in ingredientsVM)
            {
                CreateIngredientData(ingredientVM);
            }
        }

        //delete?
        public CreateIngredientViewModel ConvertDataToVM(IngredientData ingredientData)
        {
            var ingredientViewModel = new CreateIngredientViewModel
            {
                Id = ingredientData.Id,
                Name = ingredientData.Name,
            };
            return ingredientViewModel;
        }

        //FromData 
        public List<CreateIngredientViewModel> GenerateIngredients(List<IngredientData> ingredientsData)
        {
            var ingredientsViewModel = ingredientsData.Select(x => new CreateIngredientViewModel
            {
                Id = x.Id,
                Name = x.Name,
            });

            return ingredientsViewModel.ToList();
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
