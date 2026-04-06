using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
   
    public class AnimeGirlController : Controller
    {
        private IAnimeGirlGenerator _animeGirlGenerator;


        
        public AnimeGirlController(IAnimeGirlGenerator animeGirlGenerator)
        {
            _animeGirlGenerator = animeGirlGenerator;
        }

        //    /AnimeGirl/Index
        public IActionResult Index(int count)
        {
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
