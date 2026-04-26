using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class JapaneseDomesticMarketCarsData : BaseModel
    {
        public string ManufacturerType { get; set; } = "";
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Url { get; set; } = "";
        public virtual JapaneseDomesticMarketManufacturerData JapaneseDomesticMarketManufacturerData { get; set; } = new();

    }
}
