
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class PublisherRepository : BaseRepository<PublisherData>, IPublisherRepository
    {
        public PublisherRepository(WebContext context) : base(context)
        {
        }
    }
}
