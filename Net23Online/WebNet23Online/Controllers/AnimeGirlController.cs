using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
   
    public class AnimeGirlController : Controller
    {
        private IAnimeGirlGenerator _animeGirlGenerator;
        private WebContext _webContext;

        public AnimeGirlController(IAnimeGirlGenerator animeGirlGenerator, WebContext webContext)
        {
            _animeGirlGenerator = animeGirlGenerator;
            _webContext = webContext;
        }

        //    /AnimeGirl/Index
        public IActionResult Index()
        {
            var animeGirlDatas = _webContext.AnimeGirls.ToList();

            var viewModels = _animeGirlGenerator.GenerateList(animeGirlDatas);

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateGirl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGirl(CreateAnimeGirlViewModel viewModel)
        {
            var animeGirlData = new AnimeGirlData
            {
                Description = viewModel.Description,
                Name = viewModel.Name,
                Url = viewModel.Url,
            };

            var isExisted = _webContext.AnimeGirls.Any(x => x.Name == viewModel.Name);
            if (isExisted)
            {
                return View(viewModel);
            }

            _webContext.AnimeGirls.Add(animeGirlData); // Want to add
            _webContext.SaveChanges();                 // Real add

            return RedirectToAction(nameof(Index));
        }

        //    /AnimeGirl/Handmade
        public IActionResult Handmade()
        {
            var minutes = DateTime.Now.Minute;
            var second = DateTime.Now.Second;
            var name = "Ivan";

            var viewModel = new HandMadeViewModel
            {
                Minutes = minutes,
                Seconds = second,
                Name = name
            };
            
            return View(viewModel);
        }
    }
}
