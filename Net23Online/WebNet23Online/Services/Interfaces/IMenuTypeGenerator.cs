using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IMenuTypeGenerator
    {
        void CreateMenuData(CreateMenuViewModel viewModel);
        void FeelDataBase();
        List<MenuTypeViewModel> GetAllMenuViewModel(string sortMenuName);
    }
}