using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopMenuSystem;
using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services
{
    internal class ShopkeeperServiceRestoreHP : BaseShopkeeperService
    {
        public ShopkeeperServiceRestoreHP(int unitPrice) : base(unitPrice)
        {
            _name = "Restore HP";
        }
        public override void Execute(BaseCharacter character)
        {
            
            if (character.Coins > 0)
            {
                character.Coins--;
                character.Hp++;
                _shopMenu.ShopHistory.Add("You restored 1 HP");
            }
            else
            {
                _shopMenu.ShopHistory.Add("You don't have any coin");
            }
        }
    }
}
