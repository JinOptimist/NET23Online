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

        private const int _HP_COLLECT = 1;
        public Rest(Maze maze) : base(maze)
        {
        }

        public override char Symbol => 'Q';
        public override bool IsBonusCell { get; init; } = true;


        public override bool Interaction(BaseCharacter character)
        {
            character.CollectHp(_HP_COLLECT);
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