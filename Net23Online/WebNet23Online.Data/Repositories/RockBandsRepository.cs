using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories
{
    public class RockBandsRepository : BaseRepository<RockBandsData>
    {
        public RockBandsRepository(WebContext webContext) : base(webContext) { }
    }
     public override void Add(RockBandsData model)
        {
            if (model.Name == model.Description)
            {
                throw new Exception("Be more creative");
            }

            base.Add(model);
        }
    }
