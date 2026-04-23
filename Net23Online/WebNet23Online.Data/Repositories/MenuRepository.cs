using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces.DelightBistro;

namespace WebNet23Online.Data.Repositories
{
    public class MenuRepository : BaseRepository<MenuData>, IMenuRepository
    {
        public MenuRepository(WebContext webContext) : base(webContext) { }

        public List<MenuData> GetAllIncludeFoodItemsWithIngredients(string filterMenuName)
        {
            var allMenus = _dbSet
                .Include(x => x.FoodItems)
                .ThenInclude(x => x.IngredientsList)
                /*.ThenInclude(f => f.Creator)*/;

            if (!string.IsNullOrEmpty(filterMenuName))
            {
                var filterMenu = allMenus.Where(x => x.Name == filterMenuName).ToList();
                return filterMenu;
            }

            return allMenus.ToList();
        }

        public bool IsNameFree(string name)
        {
            return !_dbSet.Any(x => x.Name == name);
        }

    }
}
