using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class DoubleCoins:BaseCell
    {
        public override char Symbol => 'a';
        public DoubleCoins(Maze maze):base(maze)
        {
           
        }  

        public override bool Interaction(BaseCharacter character)
        {
            //Console.WriteLine();
            character.Coins =+2;
            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y
            };
            Maze.Surface.Add(ground);
            return true;
        }
    }
}
