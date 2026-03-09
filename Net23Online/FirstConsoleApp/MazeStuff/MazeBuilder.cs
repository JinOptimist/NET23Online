
using FirstConsoleApp.MazeStuff.Cells;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;

        public Maze Build(int width, int height)
        {
            _maze = new Maze
            {
                Width = width,
                Height = height,
            };

            GenerateWall();
            GenerateGround();// Genrate path
            GenerateCoins();
            // Generate other cells

            return _maze;
        }

        private void GenerateCoins()
        {
            var coin = new Coin(_maze)
            {
                X = 1,
                Y = 1,
            };
            ReplaceCell(coin);
        }

        private void ReplaceCell(BaseCell newCell) // coin [1,1]
        {
            var oldCell = _maze
                .Cells
                .First(c => c.X == newCell.X && c.Y == newCell.Y);
            _maze.Cells.Remove(oldCell);

            _maze.Cells.Add(newCell); // replace
        }

        private void GenerateGround()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (var x = 0; x < _maze.Width; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        var ground = new Ground(_maze)
                        {
                            X = x,
                            Y = y,
                        };

                        ReplaceCell(ground);
                    }
                }
            }
        }

        private void GenerateWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Width; x++)
                {
                    var wall = new Wall(_maze)
                    {
                        X = x,
                        Y = y
                    };
                    _maze.Cells.Add(wall);
                }
            }
        }
    }
}
