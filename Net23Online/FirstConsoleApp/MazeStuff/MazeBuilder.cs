using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;
using System;
using System.Diagnostics.Metrics;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeBuilder
    {
        private Maze _maze;
        private const int MAX_ICE = 8;
        private Random _random;
        private const int _MAX_DOORS_COUNT = 5;

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
            GenerateSuperPower();
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
            var doorAvailableCells = _maze.Surface
                .Where(cell => cell is Ground)
                .Where(cell => IsSuitableDoorPosition(cell.X, cell.Y))
                .ToList();
            var maxAvailableDoorsCount = doorAvailableCells.Count;
            if (maxAvailableDoorsCount <= 0)
            {
                return;
            }
            if (maxAvailableDoorsCount > _MAX_DOORS_COUNT)
            {
                maxAvailableDoorsCount = _MAX_DOORS_COUNT;
            }
            var selectedCells = SelectRandomDoorPositions(doorAvailableCells, maxAvailableDoorsCount);

            GenerateKeysForDoors(selectedCells.Count);

            for (int i = 0; i < selectedCells.Count; i++)
            {
                var cell = selectedCells[i];
                var door = new Doors(_maze)
                {
                    X = cell.X,
                    Y = cell.Y,
                };

                ReplaceCell(door);
            }

        }


        private bool IsSuitableDoorPosition(int x, int y)
        {
            var isHorizontalPassage = IsWallOrBoundary(x - 1, y) && IsWallOrBoundary(x + 1, y);

            var isVerticalPassage = IsWallOrBoundary(x, y - 1) && IsWallOrBoundary(x, y + 1);

            return isHorizontalPassage || isVerticalPassage;
        }
        private bool IsWallOrBoundary(int x, int y)
        {
            if (x < 0 || x >= _maze.Width || y < 0 || y >= _maze.Height)
            {
                return true;
            }

            return _maze[x, y] is Wall;
        }

        private List<BaseCell> SelectRandomDoorPositions(List<BaseCell> doorAvailablePositions, int maxDoorsCount)

        {
            var shuffledDoors = doorAvailablePositions
                .OrderBy(_ => _random.Next())
                .Take(maxDoorsCount)
                .ToList();
            return shuffledDoors;
        }

        private void GenerateKeysForDoors(int doorCount)
        {
            var availablePositions = _maze.Surface
                .Where(cell => cell is Ground)
                .OrderBy(_ => _random.Next())
                .Take(doorCount)
                .ToList();

            for (int i = 0; i < availablePositions.Count; i++)
            {
                var position = availablePositions[i];
                var key = new Key(_maze)
                {
                    X = position.X,
                    Y = position.Y,
                };
                ReplaceCell(key);
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

        private void GenerateCoins(int maxCoinCount = 4)
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
        
        private void GenerateSuperPower(int maxSuperPowerCount = 2)
        {
            /*
             размещение клеток супер силы:
             взяла все клетки, расстояние до которых 50% и выше от максимального расстояния
             нашла в них тупики
             выбрала рандомные клетки
             если тупиков нет, то выбрала рандомно две клетки среди отдаленных от начала лабиринта на 50%
             */

            
            var queue = new Queue<BaseCell>();
            var dictionaryCellsAndDistance = new Dictionary<BaseCell, int>();
            
            queue.Enqueue(_maze[0, 0]);
            dictionaryCellsAndDistance.Add(_maze[0, 0], 0);
            
            while (queue.Any())
            {
                var cell = queue.Dequeue();
                var groundNearCurrentCell = GetNearCells<Ground>(cell);

                foreach (var nearCell in groundNearCurrentCell)
                {
                    if (!dictionaryCellsAndDistance.ContainsKey(nearCell))
                    {
                        queue.Enqueue(nearCell);
                        var distance = dictionaryCellsAndDistance[cell];
                        dictionaryCellsAndDistance.Add(nearCell, distance + 1);
                    }
                }
            }
            
            var maxDistance = dictionaryCellsAndDistance
                .Values
                .Max();
            
            var minDistanceToGenerate = maxDistance * 0.5;

            var suitableCellsToGenerate = dictionaryCellsAndDistance
                .Keys
                .Where(cell => dictionaryCellsAndDistance[cell] >= minDistanceToGenerate)
                .ToList();

            var suitableDeadends = suitableCellsToGenerate
                .Where(cell => GetNearCells<Ground>(cell).Count() == 1)
                .ToList();

            BaseCell chosenCell;

            
            for (int i = 0; i < maxSuperPowerCount; i++)
            {
                if (suitableDeadends.Any())
                {
                    chosenCell = GetRandomCell(suitableDeadends);
                }
                else
                {
                    chosenCell = GetRandomCell(suitableCellsToGenerate);
                }
            
                var superPower = new SuperPower(_maze)
                {
                    X = chosenCell.X,
                    Y = chosenCell.Y,
                };
                
                ReplaceCell(superPower); 
                
                suitableCellsToGenerate.Remove(chosenCell);
                suitableDeadends.Remove(chosenCell);
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
        private void GenerateLava(int maxLavaCount = 2)
        {
            var walls = _maze.Surface
                .OfType<Wall>()
                .ToList();

            var lavaLake = walls
                .Where(cell =>
                    walls.Any(x => x.X == cell.X + 1 && x.Y == cell.Y) &&
                    walls.Any(x => x.X == cell.X && x.Y == cell.Y + 1) &&
                    walls.Any(x => x.X == cell.X + 1 && x.Y == cell.Y + 1))
                .ToList();

            if (lavaLake.Count > 0)
            {
                for (int i = 0; i < maxLavaCount && i < lavaLake.Count; i++)
                {
                    var corner = lavaLake[i];

                    ReplaceCell(new Lava(_maze) { X = corner.X, Y = corner.Y });
                    ReplaceCell(new Lava(_maze) { X = corner.X + 1, Y = corner.Y });
                    ReplaceCell(new Lava(_maze) { X = corner.X, Y = corner.Y + 1 });
                    ReplaceCell(new Lava(_maze) { X = corner.X + 1, Y = corner.Y + 1 });
                }

                return;
            }

            var surroundedWalls = walls
                .Where(x => GetNearCells<Ground>(x).Count() == 4)
                .ToList();

            for (int i = 0; i < maxLavaCount && i < surroundedWalls.Count; i++)
            {
                var wall = surroundedWalls[i];

                var lava = new Lava(_maze)
                {
                    X = wall.X,
                    Y = wall.Y,
                };

                ReplaceCell(lava);
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

