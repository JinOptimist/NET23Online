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
        private const int _HP_COST = 1;
        public Trap(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '▣';

        public override bool Interaction(BaseCharacter character)
        {
            if (!character.HasHp(_HP_COST) || character.Hp <= _HP_COST)
            {
                character.Hp = 0;
                Maze.EventHistory.Add("LAST LIFE LOST,it's a trap ");
                character.GameOver();
                return false;
            }
            Maze.EventHistory.Add("Look out, it's a trap");
            character.SpendHp(_HP_COST);
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