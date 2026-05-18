using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Data.Repositories.MaksKorz
{
    public class LocationConcertRepository: ILocationConcertRepository
    {
        private WebContext _webContext;
        protected DbSet<Location> _dbSet;
        public LocationConcertRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        public List<Location> GetAllInclude()
        {
            return _dbSet
                .Include(g => g.Id)
                .ToList();
        }
        public void Add(Location model)
        {
            _webContext.Add(model);
            _webContext.SaveChanges();
        }
        public void Removed(Location model)
        {
            _webContext.Remove(model);
            _webContext.SaveChanges();
        }
        public List<Location> GetAll()
        {
            return _webContext.LocationMK.ToList();
        }
        public bool GetLocationFromID(Location model)
        {
            return _webContext.LocationMK.Any(x => x.Id == model.Id);
        }
        //public bool Contains(Location model)
        //{
        //    return _webContext.LocationMK.Any(x => x.LastName == model.LastName);
        //}
    }
}
