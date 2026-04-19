using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class MenuRepository : BaseRepository<MenuData>, IMenuRepository
    {
        public MenuRepository(WebContext webContext) : base(webContext)
        {

        }
        public List<MenuData> GetAllIncludeFoodItemsWithIngredients()
        {
            var menus = _dbSet
                .Include(x => x.FoodItems)
                .ThenInclude(x => x.IngredientsList)
                .ToList();

            foreach (var menu in menus)
            {
                menu.FoodItems ??= new List<FoodItemData>();
                foreach (var foodItem in menu.FoodItems)
                {
                    foodItem.IngredientsList ??= new List<IngredientData>();

                }

            }
            return menus;
        }
    }
}
