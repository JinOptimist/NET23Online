using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class GenreOfRockBands : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<RockBandGenreData> RockBandGenres { get; set; } = new List<RockBandGenreData>();
    }   
}
