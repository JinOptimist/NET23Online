using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem
{
    internal class ShopMenu
    {
        public List<BaseShopItem> MenuItems {  get; set; } = new ();
        public List<string> ShopHistory { get; set; } = new ();
        public char _cursor;
        public int _cursorPosition = 0;
    }
}
