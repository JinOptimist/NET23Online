using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.Maks_Korz;

namespace WebNet23Online.Controllers
{
    public class MaksKorzController : Controller
    {
        DataUserForMaksKorz _user;
        Authorization _authorization;
        IDataUserForMaksKorzRepository _dataUserMK;
        public MaksKorzController(IDataUserForMaksKorzRepository dataUserMK)
        {
           
        }
        public IActionResult Index()
        {
            //var returnAllValue = _webContext.DataUserMK.ToList();
            return View();
        }

        public IActionResult FormUser()
        {
            var returnAllValue = _dataUserMK.GetAll;
            var resulDataNow = "";
            if(_authorization.GetDataNow() == "Morning")
            {
                resulDataNow = "Good Morning, " + _user.LastName;
            }
            if (_authorization.GetDataNow() == "Afternoon")
            {
                resulDataNow = "Good Afternoon, " + _user.LastName;
            }
            if (_authorization.GetDataNow() == "Evening")
            {
                resulDataNow = "Good Evening, " + _user.LastName;
            }
            return View(returnAllValue);
        }
        [HttpPost]
        public IActionResult Index(DataUserForMaksKorz data)
        {
            bool contains = _dataUserMK.Contains(data);
            if (contains)
            {
                return View();
            }
            var addNewUserForMK = new DataUserForMaksKorz
            {
                LastName = data.LastName,
                Country = data.Country,
                Age = data.Age
            };
            _dataUserMK.Add(addNewUserForMK);
            return RedirectToAction("FormUser");
            //return View("/Views/MaksKorz/FormUser.cshtml");
        }
    }
}
