using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class GenreOfRockBandsData : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<RockBandGenreData> RockBandGenres { get; set; } = new List<RockBandGenreData>();
    }   
}
