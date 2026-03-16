using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;
using System;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;
        private const int MAX_ICE = 8;
        private Random _random;

        public Maze Build(int width, int height, int? seed = null)
        {
            _maze = new Maze
            {
                Width = width,
                Height = height,
                Seed = seed ?? DateTime.Now.Millisecond
            };

            _random = new Random(_maze.Seed);

            var hero = GenerateHero();
            _maze.Hero = hero;

            GenerateWall();
            GenerateGround(hero.X, hero.Y);// Genrate path
            GenerateCoins();
            GenerateTrap();
            GeneratePortals();
            GenerateRest();
            GenerateDoors();
            GenerateMimics();
            GenerateLava();
            // Generate other cells
            GenerateIce();
            GenerateSpeedPotions();

            return _maze;
        }

        private Hero GenerateHero()
        {
            return new Hero(_maze)
            {
                X = 0,
                Y = 0,
            };
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
                        if (x % 3 == 0 && y % 3 == 0)
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
            var freeCells = _maze.Surface.Where(cell => cell is Ground).ToList();
            var randomCellIndex = _random.Next(0, freeCells.Count() - 1);
            var randomCell = freeCells[randomCellIndex];
            var mimic = new Mimic(_maze)
            {
                X = randomCell.X,
                Y = randomCell.Y,
            };
            ReplaceCell(mimic);
        }

        private void GenerateCoins(int maxCoinCount = 3)
        {
            var deadends = _maze
                .Surface
                .Where(x => x is Ground)
                .Where(x => GetNearCells<Ground>(x).Count() == 1)
                .ToList();

            for (int i = 0; i < maxCoinCount; i++)
            {
                var deadend = deadends[i];
                var coin = new Coin(_maze)
                {
                    X = deadend.X,
                    Y = deadend.Y,
                };
                ReplaceCell(coin);
            }
        }

        private void GenerateGround(int startX = 0, int startY = 0)
        {
            var miner = _maze[startX, startY];

            var wallsToDestroy = new List<BaseCell>();

            do
            {
                ReplaceCellToGround(miner); // Destoy wall 

                var nears = GetNearCells<Wall>(miner);

                wallsToDestroy.AddRange(nears);

                wallsToDestroy = wallsToDestroy
                    // .Where(cell => AllowToDestroy(cell))
                    .Where(AllowToDestroy)
                    .ToList();
                if (wallsToDestroy.Any())
                {
                    miner = GetRandomCell(wallsToDestroy);
                }
            } while (wallsToDestroy.Any());
        }

        private BaseCell GetRandomCell(List<BaseCell> wallsToDestroy)
        {
            var randomIndex = _random.Next(wallsToDestroy.Count);
            return wallsToDestroy[randomIndex];
        }

        private bool AllowToDestroy(BaseCell cell)
        {
            return _maze[cell.X, cell.Y] is Wall
                 && GetNearCells<Ground>(cell)
                .Count() < 2;
        }

        private IEnumerable<BaseCell> GetNearCells<TypeOfOurCell>(BaseCell miner)
            where TypeOfOurCell : BaseCell
        {
            return _maze.Surface
                .Where(cell => cell is TypeOfOurCell)
                .Where(cell =>
                    cell.Y == miner.Y && Math.Abs(cell.X - miner.X) == 1
                    || cell.X == miner.X && Math.Abs(cell.Y - miner.Y) == 1);
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
                    _maze.Surface.Add(wall);
                }
            }
        }

        private void GenerateTrap()
        {
            var nearcoins = _maze
                .Surface
                .Where(x => x is Ground)
                .Where(x => GetNearCells<Coin>(x).Count() == 1)
                .ToList();

            int goldcoins = _maze.Surface.OfType<Coin>().Count();

            for (int i = 0; i < goldcoins; i++)
            {
                var nearcoin = nearcoins[i];
                var trap = new Trap(_maze)
                {
                    X = nearcoin.X,
                    Y = nearcoin.Y,
                };
                ReplaceCell(trap);
            }
        }

        private void GeneratePortals()
        {
            var groundCells = _maze
                .Surface
                .Where(c => c is Ground)
                .ToList();

            for (var i = 0; i < groundCells.Count; i++)
            {
                var cellCurrent = groundCells[i];

                if (cellCurrent.X % 5 == 0)
                {
                    var portal = new Portal(_maze)
                    {
                        X = cellCurrent.X,
                        Y = cellCurrent.Y,

                    };

                    ReplaceCell(portal);
                }
            }
        }
        private void GenerateRest(int maxRestCount = 5)
        {
            var deadends = _maze
      .Surface
      .Where(x => x is Ground)
      .Where(x => GetNearCells<Ground>(x).Count() >= 3)
      .ToList();
            for (int i = 0; i < maxRestCount; i++)
            {
                var deadend = deadends[i];
                var rest = new Rest(_maze)
                {
                    X = deadend.X,
                    Y = deadend.Y,
                };
                ReplaceCell(rest);
            }
        }

        private void ReplaceCell(BaseCell newCell) // coin [1,1]
        {
            var oldCell = _maze
                .Surface
                .First(c => c.X == newCell.X && c.Y == newCell.Y);
            _maze.Surface.Remove(oldCell);

            _maze.Surface.Add(newCell); // replace
        }

        private void ReplaceCellToGround(BaseCell oldCell)
        {
            _maze.Surface.Remove(oldCell);

            var ground = new Ground(_maze)
            {
                X = oldCell.X,
                Y = oldCell.Y,
            };

            _maze.Surface.Add(ground);
        }

        private void GenerateIce(int countIce = 5)
        {
            countIce = Math.Min(MAX_ICE, countIce);

            for (int i = 0; i < countIce; i++)
            {
                var x = _random.Next(0, _maze.Width);
                var y = _random.Next(0, _maze.Height);

                var ice = new Ice(_maze)
                {
                    X = x,
                    Y = y,
                };

                ReplaceCell(ice);
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
            private void GenerateSpeedPotions(int maxSpeedPotionsCount = 3)
        {
            var deadendsWallsAround = _maze
                .Surface
                .Where(x => x is Ground)
                .Where(x => GetNearCells<Wall>(x).Count() == 3)
                .ToList();

            for (int i = 0; i < maxSpeedPotionsCount; i++)
            {
                var deadendWallsAround = deadendsWallsAround[i];
                var speedPotion = new SpeedPotions(_maze)
                {
                    X = deadendWallsAround.X,
                    Y = deadendWallsAround.Y,
                };
                ReplaceCell(speedPotion);
            }
        }
    }
}

