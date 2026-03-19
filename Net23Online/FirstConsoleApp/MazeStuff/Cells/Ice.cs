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
        private const int _HP_COST = 1;
        private const int _Speed_COST = 1;
        public override char Symbol => 'i';
        public Ice(Maze maze) : base(maze)
        {
        }

        public override bool Interaction(BaseCharacter character)
        {
            
            if (!character.HasHp(_HP_COST) || character.Hp <= _HP_COST)
            {
                Maze.EventHistory.Add("LAST LIFE LOST, It's An Ice ");
                character.Hp = 0;
                character.GameOver();
                return false;
            }
            if (!character.HasSpeeds(_Speed_COST))
            {
                Maze.EventHistory.Add("You are freezing!");
            }

            character.SpendHp(_HP_COST);
            character.SpendSpeed(_Speed_COST);


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
