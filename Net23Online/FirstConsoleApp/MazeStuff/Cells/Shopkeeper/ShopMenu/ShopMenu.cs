using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenu
{
    internal class ShopMenu
    {
        public List<string> MenuItems {  get; set; } = new ();
        public List<string> ShopHistory { get; set; } = new ();
        public char _cursor;
        public int _cursorPosition = 0;
    }
}
