using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems
{
    internal abstract class BaseShopItem
    {
        public ShopMenu _shopMenu {  get; internal set; }
        public string _name { get; set; }
        public abstract void Execute(BaseCharacter character);
    }
}
