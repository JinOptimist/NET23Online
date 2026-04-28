using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces.Steam;

namespace WebNet23Online.Data.Repositories.Steam
{
    public class PublisherRepository : BaseRepository<PublisherData>, IPublisherRepository
    {
        public PublisherRepository(WebContext context) : base(context)
        {
        }
    }
}
