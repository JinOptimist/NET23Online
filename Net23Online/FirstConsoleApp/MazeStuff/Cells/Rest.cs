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
    internal class Rest : BaseCell
    {

        private const int _HP_COLLECT = 1;

        public Rest(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => 'Q';
        public override bool IsBonusCell { get; init; } = true;


        public override bool Interaction(IBaseCharacter character)
        {
            character.CollectHp(_HP_COLLECT);
            MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("rest_sound.wav");

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