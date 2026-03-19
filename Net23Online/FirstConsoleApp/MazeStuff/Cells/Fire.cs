using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Fire: BaseCell
    {
        public Fire (IMaze maze) : base(maze)
        {
            
        }

        public override char Symbol => '^';


        public override bool Interaction(IBaseCharacter character)
        {            
            character.Hp -= 1; 

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
