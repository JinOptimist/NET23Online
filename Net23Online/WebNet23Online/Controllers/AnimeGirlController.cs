using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
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
        public IActionResult Index(int count)
        {
            var allDataFromDatabase = _webContext.AnimeGirls.ToList();


            var viewModels = _animeGirlGenerator.GenerateList(count);

            return View(viewModels);
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
