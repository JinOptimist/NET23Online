using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class RockBandsData : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public virtual ICollection<RockBandGenreData> RockBandGenres { get; set; } = new List<RockBandGenreData>();
    }
}
