using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;
        private Random _random;
        public const int RANDOM_MIMIC_CODE = 0;
        public const int COIN_LIKE_MIMIC_CODE = 1;
        public const int DOOR_LIKE_MIMIC_CODE = 2;

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
            // Generate other cells

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
            GenerateMimic(RANDOM_MIMIC_CODE);
            GenerateMimic(COIN_LIKE_MIMIC_CODE, 4);
            GenerateMimic(DOOR_LIKE_MIMIC_CODE, 2);
        }

        private void GenerateMimic(int type, int maxMimicCount = 2)
        {
            var freeCells = _maze
                .Surface
                .Where(cell => cell is Ground)
                .Where(x => type == RANDOM_MIMIC_CODE || 
                    type == COIN_LIKE_MIMIC_CODE && GetNearCells<Ground>(x).Count() == 1 || 
                    type == DOOR_LIKE_MIMIC_CODE && GetNearCells<Ground>(x).Count() > 1)
                .ToList();
            TryReplaceMimic(maxMimicCount, freeCells);
        }

        private void TryReplaceMimic(int maxMimicCount, List<BaseCell> cells)
        {
            for (int i = 0; i < maxMimicCount; i++)
            {
                var randomIndex = _random.Next(cells.Count());
                var randomCell = cells[randomIndex];
                var mimic = new Mimic(_maze)
                {
                    X = randomCell.X,
                    Y = randomCell.Y,
                };
                ReplaceCell(mimic);
            }
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
            var trap = new Trap(_maze)
            {
                X = 2,
                Y = 2,
            };
            ReplaceCell(trap);
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
        private void GenerateRest()
        {
            var rest = new Rest(_maze)
            {
                X = 3,
                Y = 3,
            };
            ReplaceCell(rest);
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

    }
}
