using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class DataUserCardForMaksKorz:BaseModel
    {
        public virtual DataUserForMaksKorz DataUserForKorz { get; set; }
        [StringLength(16)]
        public string NumberCard { get; set; }
        [StringLength(3)]
        public string CVV { get; set; }
        public string BestBeforeDate { get; set; }
    }
}
