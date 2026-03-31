using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        //          /DelightBistro/Index
        public IActionResult Index(string menuType)
        {

            var viewModel = new MenuTypeViewModel() { };
            switch (menuType)
            {
                case "soups":
                    viewModel.MenuType = "Супы";
                    break;
                case "hot":
                    viewModel.MenuType = "Горячее";
                    break;
                case "salads":
                    viewModel.MenuType = "Салаты";
                    break;
                    // Нужен ли default?
            }

            return View(viewModel);
        }
    }
}
