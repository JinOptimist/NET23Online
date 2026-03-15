using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Fire: BaseCell
    {
        public Fire (Maze maze) : base(maze)
        {
            
        }

        public override char Symbol => '^';


        public override bool Interaction(BaseCharacter character)
        {            
            character.Hp -= 1; // Need a new method in Character for logic. (Other cells can change hp)

            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            return true;
        }
       

}
}
