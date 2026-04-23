using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface ISlayTheSpire2HeroesRepository : IBaseRepository<SlayTheSpire2HeroesData>
    {
        SlayTheSpire2HeroesData? GetById(int id);
    }
}
