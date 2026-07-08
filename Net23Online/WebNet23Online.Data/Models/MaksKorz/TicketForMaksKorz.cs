using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class TicketForMaksKorz:BaseModel
    {
        public string NumberTicket { get; set; }
        public DateTime DateStatrConsert { get; set; }
        public DateTime DateFinishConsert { get; set; }
        //public int IDLocation { get; set; }//?
        public virtual List<Location> LocationConcertForMK { get; set; }
    }
}
