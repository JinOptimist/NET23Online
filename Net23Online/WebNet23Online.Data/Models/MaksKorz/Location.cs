using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class Location:BaseModel
    {
        public string Country { get; set; }
        public string NameStadium { get; set; }
        public int Capacity { get; set; } // вместимость
        public string URL { get; set; }
    }
}
