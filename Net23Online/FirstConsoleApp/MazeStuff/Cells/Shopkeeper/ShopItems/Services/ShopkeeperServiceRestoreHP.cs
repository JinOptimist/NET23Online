using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services
{
    internal class ShopkeeperServiceRestoreHP : ShopkeeperService
    {
        public ShopkeeperServiceRestoreHP(int unitPrice) : base(unitPrice)
        {
            _name = "Restore HP";
        }
        public override void Execute(BaseCharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
