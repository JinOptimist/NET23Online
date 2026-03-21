using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Interfaces;
using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems
{
    public abstract class BaseShopItem : IBaseShopItem
    {
        public ShopMenu MenuForShop { get; internal set; }
        public string Name { get; set; }
        public virtual string PriceDisplay => "";
        public abstract void Execute(IBaseCharacter character);
    }
}
