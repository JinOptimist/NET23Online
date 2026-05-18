using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Data.Models.MaksKorz;
using WebNet23Online.Data.Repositories.MaksKorz;
using WebNet23Online.Models.Maks_Korz;

namespace WebNet23Online.Controllers
{
    public class MaksKorzController : Controller
    {
        private IDataUserForMaksKorzRepository _dataUserMK;
        private ILocationConcertRepository _locationConcert;
        private static int saveTicket;
        public MaksKorzController(IDataUserForMaksKorzRepository dataUserMK, 
            ILocationConcertRepository locationConcert)
        {
            _dataUserMK = dataUserMK;
            _locationConcert = locationConcert;
        }
        [HttpGet]
        public IActionResult FormUser()
        {
            return View(_locationConcert.GetAll());
        }
        [HttpGet]
        //.Where(c=>c.Id==saveTicket).ToList()
        public IActionResult ByeTicket()
        {
            return View(_locationConcert.GetAll().Where(c => c.Id == saveTicket).ToList());
        }
        //ByeTicket
        [HttpPost]
        public IActionResult ByeTicket(DataUserCardForMaksKorz cardForMaksKorz)
        {
            var addCardForUser = new DataUserCardForMaksKorz
            {
                //NumberCard = cardForMaksKorz.NumberCard,
                CVV = cardForMaksKorz.CVV,
                BestBeforeDate = cardForMaksKorz.BestBeforeDate,
                NumberCard = new BankCardEncryption(cardForMaksKorz.NumberCard).ToString()//не знаю как правильно присвоить
            };
            return View();
        }
        [HttpGet]
        public IActionResult GetIDUser(string? ID)
        {
            saveTicket = int.Parse(ID);
            return RedirectToAction("ByeTicket");
        }
        //[HttpPost]
        //public IActionResult FormUser(string? ID)
        //{
        //    var saveTicket = ID;
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Location()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Location(Location data)
        {
            var addNewLocation = new Location
            {
                Country = data.Country,
                NameStadium = data.NameStadium,
                Capacity = data.Capacity
            };
            _locationConcert.Add(addNewLocation);
            return RedirectToAction("FormUser");
        }
        [HttpPost]
        public IActionResult Index(DataUserForMaksKorz data)
        {
            bool contains = _dataUserMK.Contains(data);
            if (contains)
            {
                return RedirectToAction("FormUser");
            }
            var addNewUserForMK = new DataUserForMaksKorz
            {
                LastName = data.LastName,
                Country = data.Country,
                Age = data.Age
            };
            _dataUserMK.Add(addNewUserForMK);
            //return RedirectToAction("FormUser");
            return View("/Views/MaksKorz/FormUser.cshtml");
        }
    }
}
