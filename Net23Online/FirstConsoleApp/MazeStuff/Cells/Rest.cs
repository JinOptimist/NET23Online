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


        public Rest(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => 'Q';
        public override bool IsBonusCell { get; init; } = true;


        public override bool Interaction(IBaseCharacter character)
        {
            PlayCellSound();

            character.Hp++;
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