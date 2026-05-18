using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Controllers.CustomAuthAttribute;

namespace WebNet23Online.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        [CanReserveZooVisit]
        public IActionResult ZooReservations(string zooName)
        {
            return View();
        }

        public IActionResult ReservationsDenied()
        {
            return View();
        }
    }
}
