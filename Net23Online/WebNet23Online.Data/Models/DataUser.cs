using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class DataUserData : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public virtual List<DataUserData> User { get; set; } = new();
    }
}
