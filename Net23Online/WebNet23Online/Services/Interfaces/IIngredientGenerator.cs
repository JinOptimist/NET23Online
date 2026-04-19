using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IIngredientGenerator
    {
        CreateIngredientViewModel ConvertDataToVM(IngredientData ingredientData);
        List<CreateIngredientViewModel> GenerateIngredients(List<IngredientData> ingredientsData);
    }
}