using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services
{
    internal class ShopkeeperServiceRestoreHP : IBaseShopkeeperService
    {
        public ShopkeeperServiceRestoreHP(int unitPrice) : base(unitPrice)
        {
            Name = "Restore HP";
        }
        public override void Execute(IBaseCharacter character)
        {
            
            if (character.Coins > 0)
            {
                character.Coins--;
                character.Hp++;
                MenuForShop.ShopHistory.Add("You restored 1 HP");
            }
            else
            {
                MenuForShop.ShopHistory.Add("You don't have any coin");
            }
        }
    }
}
