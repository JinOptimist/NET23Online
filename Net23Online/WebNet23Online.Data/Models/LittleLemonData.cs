using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class LittleLemonData : BaseModel
    {
        public int NumberOfGuests { get; set; }
        public string SeatingPreference { get; set; }
        public string AvailableTimesOnly { get; set; }
        public string ReservationDateOnly { get; set; }
        public string Occasion { get; set; }
        public string UserComments { get; set; }
        public string UserName { get; set; }
    }
}
