using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class JapaneseDomesticMarketRepository : BaseRepository<JapaneseDomesticMarketCarsData>, IJapaneseDomesticMarketRepository
    {
        public JapaneseDomesticMarketRepository(WebContext webContext) : base(webContext) 
        {
           
        }
        public List<JapaneseDomesticMarketCarsData> GetAllJdmCars()
        {
            return _dbSet
                .Include(g => g.JapaneseDomesticMarketManufacturerData)
                .ToList();
        }

        public void Link(int manufactureId, int modelId)
        {
            var manufacture = _context.ManufacturerJdm.First(x => x.Id == manufactureId);
            var carsJdm = _context.CarsJdm.First(x=>x.Id == modelId);
            manufacture.JapaneseDomesticMarketCarsDatas.Add(carsJdm);
            _context.SaveChanges();
        }
    }
}
