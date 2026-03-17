using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Trap : BaseCell
    {
        public Trap(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '▣';

        public override bool Interaction(BaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("trap_sound.wav");

            Maze.EventHistory.Add("Look out, it's a trap");
            character.Hp--;
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