using MazeCore.Cells;
using MazeCore.Characters;
using MazeCore.Interfaces;
using System.Timers;

namespace MazeCore
{
    public class MazeController: IMazeController
    {
        private IMaze _maze;
        private Random _random;
        private Stranger _stranger;
        public const int CHANSE_STRANGER_APPEARED = 30;
        private System.Timers.Timer _gameTimer;
        private MazeBuilder _mazeBuilder;
        private int _countSteps = 0;
        private const int STEPS_TO_ICE = 10; //Count steps to generate ice near hero
        private const int MILISECONDS_TO_ESCAPE = 30000;
        private bool continuewGame = true;

        public void Play(int width = 24, int height = 12, bool isSecretMaze = false, Hero hero = null)
        {
            _mazeBuilder = new MazeBuilder();

            var soundPlayer = new MazeSoundPlayer();
            soundPlayer.PlayMusic("maze_soundtrack.wav", 0.3f, true);

            var mazeBuilder = new MazeBuilder();

            _maze = _mazeBuilder.Build(width, height, isSecretMaze: isSecretMaze, inputHero: hero);

            var mazeDrawer = new MazeDrawer();

            mazeDrawer.Draw(_maze);
            _random = new Random();
            _stranger = new Stranger(_maze, _random);

            Console.WriteLine("You have 30 seconds to escape");
            
            _gameTimer = new System.Timers.Timer(MILISECONDS_TO_ESCAPE);
            _gameTimer.Elapsed += OnTimedEvent;
            _gameTimer.AutoReset = false;
            _gameTimer.Enabled = true;

            while (continuewGame && !_maze.Hero.IsDead)
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
            if(!continuewGame || _maze.Hero.IsDead)
            {
                return false;
            }
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
                return continuewGame;
            }
            _maze.Hero.ProcessBurnEffect();

            if (destenationCell.Interaction(_maze.Hero))
            {
                _maze.Hero.X = destenationX;
                _maze.Hero.Y = destenationY;

                _countSteps++;
                int randomNumber = _random.Next(100);
                if (randomNumber < CHANSE_STRANGER_APPEARED)
                {
                    _stranger.Interaction(_maze.Hero);
                }

                if (!isSecretMaze)
                {
                    if (_countSteps % STEPS_TO_ICE == 0)
                    {
                        _mazeBuilder.GenerateIceNearHero();
                    }
                }
                if (destenationCell is ExitSecretRoom)
                {
                    return destenationCell.Interaction(_maze.Hero);
                }
            }
            if (_maze.Hero.Hp <= 0 && !_maze.Hero.IsDead)
            {
                _maze.Hero.Die(); 
                continuewGame = false;
                return false;
            }
            return continuewGame;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs time)
        {
            Console.Clear();
            Console.WriteLine("YOU LOST IN MAZE FOREVER");
            MazeSoundPlayer soundEndGame = new MazeSoundPlayer();
            soundEndGame.PlayMusic("end_of_timer.mp3");
            continuewGame = false;
        }

      
    }
}
