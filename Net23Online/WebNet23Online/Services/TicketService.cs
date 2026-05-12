using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class TicketService : ITicketService
    {
        private IAuthService _authService;
        private ITicketRepository _ticketRepository;
        private IZooRepository _zooRepository;

        public TicketService(IAuthService authService, ITicketRepository ticketRepository, IZooRepository zooRepository)
        {
            _authService = authService;
            _ticketRepository = ticketRepository;
            _zooRepository = zooRepository;
        }

        public void Book (string zooName, TicketType type)
        {
            var user = _authService.GetUser();
            var zoo = _zooRepository.GetElementByName(zooName);
            TicketData ticketData = new TicketData
            {
                User = user,
                Zoo = zoo,
                TicketType = type,
                EventDate = DateTime.UtcNow.AddMonths(1),
                UniqueKey = Guid.NewGuid().ToString()
            };
            
            _ticketRepository.Add(ticketData);
        }
    }
}
