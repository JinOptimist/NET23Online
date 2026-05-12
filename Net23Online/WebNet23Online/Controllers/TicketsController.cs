using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Controllers.CustomAuthAttribute;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [CanReserveZooVisit]
        [HttpPost]
        public IActionResult ZooReservations(string zooName)
        {
            _ticketService.Book(zooName, TicketType.ZooVisit);
            return View();
        }

        public IActionResult ReservationsDenied()
        {
            return View();
        }
    }
}
