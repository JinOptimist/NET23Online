using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.TwentyOneGame
{
    public interface IPlayer
    {
        string Name { get; }
        public void TakeCard(Deck deck);
        public int GetScore();
        public void ClearHand();
        public string GetCards();
    }
}
