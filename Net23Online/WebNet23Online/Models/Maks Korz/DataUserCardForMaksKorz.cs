using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Models.CustomValidatioAttributes;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class DataUserCardForMaksKorz:BaseModel
    {
        public DataUserForMaksKorz DataUserForKorz { get; set; }
        [CreditCard]
        //[ValidationLengthUserCard]
        public string NumberCard { get; set;}
        [StringLength(3)]
        public string CVV { get; set;}
        public string BestBeforeDate { get; set; }
    }
}
