using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Extensions;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;
        private const int MAX_ICE = 8;
        private const int MIN_PORTAL_PAIRS = 2;
        private const int MAX_PORTAL_PAIRS = 5;
        private const double SINGLE_USE_PORTAL_CHANCE = 0.3;
        
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
            // Generate other cells
            GenerateIce();

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
            var deadends = GetDeadends();

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
            var deadends = GetDeadends();
            var intersections = GetIntersections();
            var corners = GetAvailableCorners();

            var potentialCellsForPortals = new List<BaseCell>();
            potentialCellsForPortals.AddRange(deadends);
            potentialCellsForPortals.AddRange(intersections);
            potentialCellsForPortals.AddRange(corners);

            potentialCellsForPortals = potentialCellsForPortals // или этот
                .Distinct()
                .ToList();

            //potentialPortals = potentialPortals  //какой вариант использовать?
            //    .GroupBy(c => (c.X, c.Y))
            //    .Select(c => c.First())
            //    .ToList();

            var requestedPortalPairsCount = _random.Next(MIN_PORTAL_PAIRS, MAX_PORTAL_PAIRS + 1);
            var maxPortalPairsCount = potentialCellsForPortals.Count / 2;
            var pairsCount = Math.Min(requestedPortalPairsCount, maxPortalPairsCount);

            if (pairsCount == 0)
            {
                return;
            }

            var totalPortals = pairsCount * 2;

            potentialCellsForPortals.Shuffle(_random);
            var selectedCells = potentialCellsForPortals
                .Take(totalPortals)
                .ToList();

            var portals = new List<Portal>();

            foreach (var cell in selectedCells)
            {
                var portal = new Portal(_maze)
                {
                    X = cell.X,
                    Y = cell.Y,
                    IsSingleUse = _random.NextDouble() < SINGLE_USE_PORTAL_CHANCE
                };

                ReplaceCell(portal);
                portals.Add(portal);
            }

            LinkPortals(portals);
        }

        private void LinkPortals(List<Portal> portals)
        {
            for (var i = 0; i < portals.Count; i += 2)
            {
                var currentPortal = portals[i];
                var linkedPortal = portals[i + 1];

                currentPortal.LinkedPortal = linkedPortal;
                linkedPortal.LinkedPortal = currentPortal;
            }
        }

        private List<BaseCell> GetIntersections()
        {
            var intersections = _maze
                 .Surface
                 .Where(c => c is Ground)
                 .Where(c => GetNearCells<Ground>(c).Count() >= 3)
                 .ToList();

            return intersections;
        }

        private List<BaseCell> GetAvailableCorners()
        {
            var corners = _maze.Surface
               .Where(cell => cell is Ground)
               .Where(cell =>
                   (cell.X == _maze.Width - 1 && cell.Y == 0)
                   || (cell.X == 0 && cell.Y == _maze.Height - 1)
                   || (cell.X == _maze.Width - 1 && cell.Y == _maze.Height - 1))
               .ToList();

            return corners;
        }

        private List<BaseCell> GetDeadends()
        {
            var deadends = _maze
                .Surface
                .Where(c => c is Ground)
                .Where(c => GetNearCells<Ground>(c).Count() == 1)
                .ToList();

            return deadends;
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
    }
}
