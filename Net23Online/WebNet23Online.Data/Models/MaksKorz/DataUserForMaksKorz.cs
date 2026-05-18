using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class DataUserForMaksKorz:BaseModel
    {
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public virtual List<TicketForMK> Ticket { get; set; }    

    }
}
