using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Models.Maze;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class MazeController : Controller
    {
        private IMazeService _mazeService;
        private WebContext _webContext;

        public MazeController(IMazeService mazeService, WebContext webContext)
        {
            _mazeService = mazeService;
            _webContext = webContext;
        }

        public IActionResult Index()
        {
            var maze = _mazeService.GetMaze();
            var mazeViewModel = _mazeService.Map(maze);
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
            _mazeService.BuildMaze(viewModel.Width, viewModel.Height, viewModel.Seed);
            return RedirectToAction("Index");
        }

        public IActionResult MoveRight()
        {
            _mazeService.MoveRight();
            return RedirectToAction("Index");
        }

        public IActionResult RebuildMaze()
        {
            _mazeService.BuildMaze(30, 10, 0);
            return RedirectToAction("Index");
        }
    }
}
