using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.SeaBattleHumanVsBot;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;
        private Random _random;
        private const int MAX_ICE = 15;

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
            GenerateIce(10);
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

        // [1] Можно ли сделать дженерик метод, ограничение с new()? (или метод должен принимать несколько типов через параметры)
        private void ReplaceCellToIce(BaseCell oldCell)
        {
            _maze.Surface.Remove(oldCell);

            var ice = new Ice(_maze)
            {
                X = oldCell.X,
                Y = oldCell.Y,
            };

            _maze.Surface.Add(ice);
        }

        private void GenerateIce(int countIce = 5)
        {
            countIce = Math.Min(MAX_ICE, countIce);

            var friendlyCells = _maze.Surface.Where(cell => cell.IsBonusCell).ToList();

            var nearCellsFromList = GetNearCellsFromList(friendlyCells);
            var uniqueCellsFromList = GetUniqueCellsFromList(nearCellsFromList.ToList());

            var maxCountIce = Math.Min(uniqueCellsFromList.Count, countIce);
            var randomCount = _random.Next(1, maxCountIce);

            for (int i = 0; i < randomCount; i++)
            {
                var oldCell = GetRandomCell(uniqueCellsFromList);
                ReplaceCellToIce(oldCell);
            }
        }

        /// <summary>
        /// Get near cells from cells in input List 
        /// </summary>
        /// <returns></returns>
        public List<BaseCell> GetNearCellsFromListTEST(List<BaseCell> inputCellList)
        {
            var outputNearCells = new List<BaseCell>();

            foreach (var cell in inputCellList)
            {
                var nearOneCell = GetNearCells<BaseCell>(cell).ToList();
                outputNearCells.AddRange(nearOneCell);
            }

            return outputNearCells;
        }

        public IEnumerable<BaseCell> GetNearCellsFromList(List<BaseCell> inputCellList)
        {
            foreach (var cell in inputCellList)
            {
                var nearOneCell = GetNearCells<BaseCell>(cell);
                foreach (var oneCell in nearOneCell)
                {
                    yield return oneCell;
                }
            }
        }

        /// <summary>
        /// Get list with unique cells from List
        /// </summary>
        /// <returns></returns>
        public List<BaseCell> GetUniqueCellsFromList0(List<BaseCell> inputCellList)
        {
            var uniqueCells = new List<BaseCell>();

            foreach (var cell in inputCellList)
            {
                bool isDublicates = uniqueCells.Any(c => c.X == cell.X && c.Y == cell.Y);
                if (!isDublicates)
                {
                    uniqueCells.Add(cell);
                }
            }
            return uniqueCells;
        }

        public List<BaseCell> GetUniqueCellsFromList(List<BaseCell> inputCellList)
        {
            return inputCellList.Distinct().ToList();
        }

        public void GenerateIceNearHero()
        {
            var cellsNearHero = GetNearCells<BaseCell>(_maze.Hero).ToList();
            var availableCells = cellsNearHero.Where(cell => cell is Ground).ToList();

            if (!availableCells.Any())
            {
                return;
            }

            var randomIceNearHero = GetRandomCell(availableCells);

            if (randomIceNearHero != null)
            {
                ReplaceCellToIce(randomIceNearHero);
            }
        }
    }
}
