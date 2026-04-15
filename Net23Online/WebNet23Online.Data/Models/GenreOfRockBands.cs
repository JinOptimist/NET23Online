using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class GenreOfRockBands : BaseModel
    {
        public string Name { get; set; }
        public ICollection<RockBandGenreData> RockBandGenres { get; set; }
    }   
}
