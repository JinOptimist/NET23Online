using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Migrations;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces.DelightBistro
{
    public interface IMenuRepository : IDelightBistro<MenuData>
    {
        List<MenuData> GetAllIncludeFoodItemsWithIngredients(string filterMenuName);
        
    }
}