
using FirstConsoleApp.MazeStuff.Cells;
using static System.Net.Mime.MediaTypeNames;

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
            GenerateLava();
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
        private void GenerateLava()
        {
            var squareSize = Math.Max(1, Math.Min(_maze.Width, _maze.Height) / 5);

            var startX = (_maze.Width - squareSize) / 2;
            var startY = (_maze.Height - squareSize) / 2;

            for (var y = startY; y < startY + squareSize; y++)
            {
                for (var x = startX; x < startX + squareSize; x++)
                {
                    var lava = new Lava(_maze)
                    {
                        X = x,
                        Y = y
                    };

                    ReplaceCell(lava);
                }
            }
        }
    }
}
