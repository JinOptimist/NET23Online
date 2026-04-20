using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.Maks_Korz;

namespace WebNet23Online.Controllers
{
    public class MaksKorzController : Controller
    {
        DataUser user = new DataUser();
        Authorization authorization = new Authorization();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult FormUser()
        {
            //var resulDataNow = "";
            //if(authorization.GetDataNow() == "Morning")
            //{
            //    resulDataNow = "Good Morning, " + user.LastName;
            //}
            //if (authorization.GetDataNow() == "Afternoon")
            //{
            //    resulDataNow = "Good Afternoon, " + user.LastName;
            //}
            //if (authorization.GetDataNow() == "Evening")
            //{
            //    resulDataNow = "Good Evening, " + user.LastName;
            //}

            return View();
        }
        [HttpPost]
        public IActionResult Index(string LastName, int Age, string Country)
        {
            var status = new StatusUser();
            user.LastName = LastName;
            user.Age = Age;
            user.Country = Country;
            status.User = user;
            authorization.AddNewUser(user);
            if (Age < 18)
            {
                status.Status = "Не совершенолетний!";
            }
            else
            {
                status.Status = "Cовершенолетний!";
                return RedirectToAction("FormUser", "MaksKorz");

            }
            return View();
            
        }
    }
}
