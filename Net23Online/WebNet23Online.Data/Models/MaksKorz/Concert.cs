using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class Concert:BaseModel
    {
        public Location Llocation { get; set; }
        public DataUserForMaksKorz DataUserForKorz { get; set; }
        public string DataConcert { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Price { get; set; }
    }
}
