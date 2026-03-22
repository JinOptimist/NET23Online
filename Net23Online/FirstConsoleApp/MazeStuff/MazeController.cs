
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Interfaces;
using System.Diagnostics;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeController
    {
        private IMaze _maze;

        private MazeBuilder _mazeBuilder;
        private int _countSteps = 0;
        private const int STEPS_TO_ICE = 10; //Count steps to generate ice near hero

        public void Play()
        {
            var startPlayTime = Stopwatch.StartNew();
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

            startPlayTime.Stop();
            var timeSpentPlaying = startPlayTime.Elapsed;
            var spentTimeStatistics = $"{(int)timeSpentPlaying.TotalHours} H {timeSpentPlaying.Minutes} Min {timeSpentPlaying.Seconds} Sec";
            var heroStatistics = _maze.Hero;
            Console.Clear();
            Console.WriteLine(spentTimeStatistics);
            Console.WriteLine($"Coins earned: {heroStatistics.Coins}");
            Console.WriteLine($"Enemies killed: {heroStatistics.EnemiesKilled}");
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

            return true;
        }
    }
}
