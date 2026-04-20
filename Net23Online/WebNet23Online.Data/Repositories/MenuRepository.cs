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
        public List<MenuData> GetAllIncludeFoodItemsWithIngredients(string sortMenuName)
        {
            var allMenus = _dbSet
                .Include(x => x.FoodItems)
                .ThenInclude(x => x.IngredientsList)
                .ToList();

            if (!string.IsNullOrEmpty(sortMenuName))
            {
                var sortMenu= allMenus.Where(x=>x.Name==sortMenuName).ToList();
                return sortMenu;
            }
            
            return allMenus;
        }
                
    }
}
