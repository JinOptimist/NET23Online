using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class SlayTheSpire2HeroesRepository : BaseRepository<SlayTheSpire2HeroesData>, ISlayTheSpire2HeroesRepository
    {
        public SlayTheSpire2HeroesRepository(WebContext webContext) : base(webContext) { }

        public SlayTheSpire2HeroesData? GetById(int id) => Get(id);
    }
}
