using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Ice : BaseCell
    {
        public override char Symbol => 'i';

        public Ice(Maze maze) : base(maze)
        {
        }

        public override bool Interaction(BaseCharacter character)
        {
            character.Hp -= 1; // Need a new method in Character for logic. (Other cells can change hp, speed)
            character.Speed -= 1;
            
            Maze.Cells.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X, //ground.X = this.X
                Y = Y,
            };
            Maze.Cells.Add(ground);

            return true;
        }
    }
}
