
using FirstConsoleApp.MazeStuff.Cells;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;
        private const int MAX_ICE = 8;


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
            GenerateTrap();
            GenerateRest();
            GenerateDoors();
            GenerateMimics();
            // Generate other cells
            GenerateIce();

            return _maze;
        }

        private void GenerateDoors()
        {

            var doorCount = 0;
            for (int y = 1; y < _maze.Height; y++)
            {
                for (var x = 1; x < _maze.Width; x++)
                {
                    if (doorCount == 2)
                    {
                        break;
                    }
                    else
                    {
                        if (x % 3 == 0 && y % 3 == 0 )
                        {
                            var door = new Doors(_maze)
                            {
                                X = x,
                                Y = y,
                            };

                            ReplaceCell(door);
                            doorCount++;
                        }
                    }



                }
                if (doorCount == 2)
                {
                    break;
                }
            }
        }
        private void GenerateMimics()
        {
            var freeCells = _maze.Cells.Where(cell => cell is Ground).ToList();
            var randomizer = new Random();
            var randomCellIndex = randomizer.Next(0, freeCells.Count() - 1);
            var randomCell = freeCells[randomCellIndex];
            var mimic = new Mimic(_maze)
            {
                X = randomCell.X,
                Y = randomCell.Y,
            };
            ReplaceCell(mimic);
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

        private void GenerateTrap()
        {
            var trap = new Trap(_maze)
            {
                X = 2,
                Y = 2,
            };
            ReplaceCell(trap);
        } 
        private void GenerateRest()
        {
            var rest = new Rest(_maze)
            {
                X = 3,
                Y = 3,
            };
            ReplaceCell(rest);
        }

        private void GenerateIce(int countIce = 5)
        {
            countIce = Math.Min(MAX_ICE, countIce);
            var random = new Random();

            for (int i = 0; i < countIce; i++)
            {
                var x = random.Next(0, _maze.Width);
                var y = random.Next(0, _maze.Height);

                var ice = new Ice(_maze)
                {
                    X = x,
                    Y = y,
                };

                ReplaceCell(ice);
            }
        }
    }
}
