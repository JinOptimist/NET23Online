using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Enums;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class DataUserForMaksKorz:BaseModel
    {
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
        public virtual List<TicketForMaksKorz> Ticket { get; set; }
        //public bool IsAdmin { get; set; }
    }
}
