using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Data.Repositories.MaksKorz
{
    public interface ILocationConcertRepository
    {
        void Add(Location model);
        List<Location> GetAll();
        void Removed(Location model);
        List<Location> GetAllInclude();
        //bool Contains(Location model);
    }
}
