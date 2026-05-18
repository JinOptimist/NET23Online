using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces.DelightBistro;

namespace WebNet23Online.Data.Repositories
{
    public class IngredientsRepository : BaseRepository<IngredientData>, IIngredientsRepository
    {
        public IngredientsRepository(WebContext webContex) : base(webContex) { }
        public bool IsNameFree(string name)
        {
            return !_dbSet.Any(x => x.Name == name);
        }
    }
}
