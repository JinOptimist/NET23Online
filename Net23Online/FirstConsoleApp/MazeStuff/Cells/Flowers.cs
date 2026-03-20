using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Flowers : BaseCell
    {
        public Flowers(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => 'Y';

        public override bool Interaction(IBaseCharacter character)
        {
            if (character.Hp > 3)
            {
                Maze.EventHistory.Add("oh, ah-choo");
                character.Hp = character.Hp - 1;
            }
            else
            {
                Maze.EventHistory.Add("mmm, they smell so delicious!");
                character.Hp++;
            }

            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);
            return true;
        }
    }
}
