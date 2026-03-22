
using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using Microsoft.VisualBasic;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeController : IMazeController
    {
        private IMaze _maze;

        private MazeBuilder _mazeBuilder;
        private int _countSteps = 0;
        private const int STEPS_TO_ICE = 10; //Count steps to generate ice near hero


        public void Play(int width = 24, int height = 12, bool isSecretMaze = false, Hero hero = null) //Передать не Hero а Интерфейс? IBaseCaracter
        {

            _mazeBuilder = new MazeBuilder();

            var soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("maze_soundtrack.wav", 0.3f, true);

            _maze = _mazeBuilder.Build(width, height, isSecretMaze: isSecretMaze, inputHero: hero);

            var mazeDrawer = new MazeDrawer();

            mazeDrawer.Draw(_maze);

            var continuewGame = true;
            while (continuewGame)
            {
                continuewGame = DoOneStep(isSecretMaze);
                mazeDrawer.Draw(_maze);
            }

        }

        /// <summary>
        /// Return true if game must be continue
        /// Return false game must be stopped
        /// </summary>
        /// <returns></returns>
        private bool DoOneStep(bool isSecretMaze = false)
        {
            var destenationX = _maze.Hero.X;
            var destenationY = _maze.Hero.Y;
            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.W:
                    {
                        destenationY--;
                        break;
                    }
                case ConsoleKey.S:
                    {
                        destenationY++;
                        break;
                    }
                case ConsoleKey.A:
                    {
                        destenationX--;
                        break;
                    }
                case ConsoleKey.D:
                    {
                        destenationX++;
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        return false;
                    }
            }

            var destenationCell = _maze[destenationX, destenationY];
            if (destenationCell == null)
            {
                return true;
            }

            if (destenationCell.Interaction(_maze.Hero))
            {
                _maze.Hero.X = destenationX;
                _maze.Hero.Y = destenationY;

                _countSteps++;

                if (!isSecretMaze)
                {
                    if (_countSteps % STEPS_TO_ICE == 0)
                    {
                        _mazeBuilder.GenerateIceNearHero();
                    }
                }

                if (destenationCell is ExitSecretRoom)
                {
                    return /*false*/destenationCell.Interaction(_maze.Hero);//Выход из комнаты
                }
            }

            return true;
        }
    }
}
