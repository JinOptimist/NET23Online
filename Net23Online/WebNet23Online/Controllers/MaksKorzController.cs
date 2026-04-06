using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.Maks_Korz;

namespace WebNet23Online.Controllers
{
    public class MaksKorzController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string LastName, int Age, string Country)
        {
            DataUser user = new DataUser();
            StatusUser status = new StatusUser();
            user.LastName = LastName;
            user.Age = Age;
            user.Country = Country;
            status.User = user;
            if (Age < 18)
            {
                status.Status = "Не совершенолетний!";
            }
            else
            {
                status.Status = "Cовершенолетний!";
            }
            return View("/Views/MaksKorz/FormUser.cshtml");
        }
    }
}
