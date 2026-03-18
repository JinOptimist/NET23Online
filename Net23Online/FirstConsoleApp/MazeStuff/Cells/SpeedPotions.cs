using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    /// <summary>
    /// When a hero picks up a speed potion, his speed increases by 1.
    /// </summary>
    internal class SpeedPotions : BaseCell
    {
        public SpeedPotions(Maze maze) : base(maze)
        {
        }
        public override char Symbol => 's';
        public override bool Interaction(BaseCharacter character)
        {
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("speedpotion_sound.flac");

            Maze.EventHistory.Add("You drank the speed potion! Now you move faster.");
            character.Speed++;

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
