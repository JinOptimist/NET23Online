using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Rest : BaseCell
    {


        public Rest(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'Q';

        public override bool Interaction(BaseCharacter character)
        {
            character.Hp++;
            Maze.Cells.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Cells.Add(ground);

            return true;
        }
    }   
}