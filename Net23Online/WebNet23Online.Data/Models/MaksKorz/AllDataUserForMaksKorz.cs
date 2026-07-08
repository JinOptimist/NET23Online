using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class AllDataUserForMaksKorz:BaseModel
    {
        public List<DataUserForMaksKorz> User {  get; set; }
        public bool IsCurrentUserAdmin { get; set; }

    }
}
