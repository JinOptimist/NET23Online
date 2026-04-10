using MazeCore.Interfaces;
using WebNet23Online.Models.Maze;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class MazeService : IMazeService
    {
        private IMaze _maze;
        private IMazeBuilder _mazeBuilder;

        public MazeService(IMazeBuilder mazeBuilder)
        {
            _mazeBuilder = mazeBuilder;
        }

        public IMaze GetMaze()
        {
            if (_maze is null)
            {
                _maze = BuildMaze(30, 10, 0);
            }
            return _maze;
        }

        public IMaze BuildMaze(int width, int height, int seed)
        {
            _maze = _mazeBuilder.Build(width, height, seed);
            return _maze;
        }

        public void MoveRight()
        {
            var destenationX = _maze.Hero.X;
            var destenationY = _maze.Hero.Y;
            destenationX++;

            var destenationCell = _maze[destenationX, destenationY];
            if (destenationCell == null)
            {
                return;
            }

            if (destenationCell.Interaction(_maze.Hero))
            {
                _maze.Hero.X = destenationX;
                _maze.Hero.Y = destenationY;
            }
        }

        public MazeViewModel Map(IMaze maze)
        {
            var mazeViewModel = new MazeViewModel
            {
                Width = maze.Width,
                Height = maze.Height,
            };

            var hero = maze.Hero;
            for (int y = 0; y < maze.Height; y++)
            {
                var row = maze
                    .Surface
                    .Where(cell => cell.Y == y)
                    .OrderBy(cell => cell.X)
                    .Select(cell =>
                    {
                        var isHero = hero.X == cell.X && hero.Y == cell.Y;

                        return new CellViewModel
                        {
                            IsHero = isHero,
                            Symbol = isHero
                             ? hero.Symbol
                             : cell.Symbol,
                            X = cell.X,
                            Y = cell.Y,
                        };
                    })
                    .ToList();

                mazeViewModel.Rows.Add(row);
            }

            return mazeViewModel;
        }
    }
}
