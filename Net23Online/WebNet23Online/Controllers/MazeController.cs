using MazeCore;
using MazeCore.Cells;
using MazeCore.Characters;
using MazeCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using WebNet23Online.Models.Maze;

namespace WebNet23Online.Controllers
{
    public class MazeController : Controller
    {
        // STATIC IS A BAD IDEA
        // REMOVE AFTER ADD DATABASE
        private static IMaze _maze;

        public IActionResult Index()
        {
            if (_maze == null)
            {
                // int? width, int? height, int? seed = null
                var mazeBuilder = new MazeBuilder();
                _maze = mazeBuilder.Build(30, 10);
            }
            
            var mazeViewModel = new MazeViewModel
            {
                Width = _maze.Width,
                Height = _maze.Height,
            };

            var hero = _maze.Hero;
            for (int y = 0; y < _maze.Height; y++)
            {
                var row = _maze
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

            return View(mazeViewModel);
        }

        [HttpGet]
        public IActionResult Builder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Builder(BuilderViewModel viewModel)
        {
            var mazeBuilder = new MazeBuilder();
            _maze = mazeBuilder.Build(viewModel.Width, viewModel.Height, viewModel.Seed);
            return RedirectToAction("Index");
        }

        public IActionResult MoveRight()
        {
            var destenationX = _maze.Hero.X;
            var destenationY = _maze.Hero.Y;
            destenationX++;

            var destenationCell = _maze[destenationX, destenationY];
            if (destenationCell == null)
            {
                return RedirectToAction("Index");
            }

            if (destenationCell.Interaction(_maze.Hero))
            {
                _maze.Hero.X = destenationX;
                _maze.Hero.Y = destenationY;
            }

            return RedirectToAction("Index");
        }

        public IActionResult RebuildMaze()
        {
            var mazeBuilder = new MazeBuilder();
            _maze = mazeBuilder.Build(30, 10);
            return RedirectToAction("Index");
        }
    }
}
