using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Services.Interfaces
{
    public interface ITicketService
    {
        public void Book(string zooName, TicketType type);
    }
}
