using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class ExitSecretRoom : BaseCell
    {
        private readonly MazeController _mazeController;

        public ExitSecretRoom(IMaze maze, MazeController mazeController) : base(maze)
        {
            _mazeController = mazeController;
        }

        public override char Symbol => 'E';
        private int _countInteraction=0;
        private const int MAX_INTERACTION = 4;

        public override bool Interaction(IBaseCharacter character)
        {
            _countInteraction++;
            if (_countInteraction >= MAX_INTERACTION)
            {
                Maze.EventHistory.Add("Вы вышли из секретной комнаты");

                //_mazeController.Play(); Убтрать _mazeController из этого класса?

                _countInteraction = 0;

                return false;
            }
            return true;

        }

    }
}
