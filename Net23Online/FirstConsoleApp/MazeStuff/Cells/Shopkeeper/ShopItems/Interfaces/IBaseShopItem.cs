using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Interfaces
{
    internal interface IBaseShopItem
    {
        string Name { get; set; }
        ShopMenu MenuForShop { get; }

        void Execute(IBaseCharacter character);
    }
}