using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class FoodItemData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string MenuType { get; set; }
        public string ImgURL { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
