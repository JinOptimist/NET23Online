
using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeController
    {
        private IMaze _maze;

        private Random _random = new Random();

        private MazeBuilder _mazeBuilder;
        private int _countSteps = 0;
        private const int STEPS_TO_ICE = 10; //Count steps to generate ice near hero

        public void Play()
        {
            _mazeBuilder = new MazeBuilder();

            var soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("maze_soundtrack.wav", 0.3f, true);

            var mazeBuilder = new MazeBuilder();

            _maze = _mazeBuilder.Build(24, 12);

            var mazeDrawer = new MazeDrawer();

            mazeDrawer.Draw(_maze);

            var continuewGame = true;
            while (continuewGame)
            {
                continuewGame = DoOneStep();
                mazeDrawer.Draw(_maze);
            }

        }

        private void OneStepMonster()
        {
            var countDirection = 4;

            var destenationX = _maze.Monster.X;
            var destenationY = _maze.Monster.Y;

            var direction = _random.Next(countDirection);

            switch (direction)
            {
                case 0:
                    {
                        destenationY--;
                        break;
                    }
                case 1:
                    {
                        destenationY++;
                        break;
                    }
                case 2:
                    {
                        destenationX--;
                        break;
                    }
                case 3:
                    {
                        destenationX++;
                        break;
                    }
            }

            var destenationCell = _maze[destenationX, destenationY];

            if (destenationCell == null || destenationCell.Symbol == '█')
            {
                OneStepMonster();
            }
            else
            {
                _maze.Monster.X = destenationX;
                _maze.Monster.Y = destenationY;
            }
        }

        /// <summary>
        /// Return true if game must be continue
        /// Return false game must be stopped
        /// </summary>
        /// <returns></returns>
        private bool DoOneStep()
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

                if (_countSteps % STEPS_TO_ICE == 0)
                {
                    _mazeBuilder.GenerateIceNearHero();
                }

            }

            if (_maze.Hero.X == _maze.Monster.X && _maze.Hero.Y == _maze.Monster.Y)
            {
                return false;
            }

            OneStepMonster();
            return true;
        }
    }
}
