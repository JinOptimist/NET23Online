using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data.Models;
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

            //DataBase Is Empty
            var ingredients = "Креветки, Шампиньоны, Лайм, Паста";

            _ingredients = ingredients.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new CreateIngredientViewModel
                {
                    Name = x.Trim()
                }).ToList();
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
        
        public List<CreateIngredientViewModel> GenerateIngredients()
        {
            return _ingredients;
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

        public void CreateIngredient(CreateIngredientViewModel viewModel)
        {
            var ingredientData = new IngredientData
            {
                Name = viewModel.Name,
            };

            _ingredientsRepository.Add(ingredientData);
        }

    }
}
