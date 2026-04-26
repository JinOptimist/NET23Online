using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class JapaneseDomesticMarketManufacturerRepository : BaseRepository<JapaneseDomesticMarketManufacturerData>, IJapaneseDomesticMarketManufacturerRepository
    {
        public JapaneseDomesticMarketManufacturerRepository(WebContext webContext) : base(webContext)
        {
        }
    }
}
