using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Explosives : BaseCell
    {
        public Explosives(Maze maze) : base(maze)
        {
        }
        public override char Symbol => 'E';
        public override bool Interaction(BaseCharacter character)
        {
            character.Hp--;

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
