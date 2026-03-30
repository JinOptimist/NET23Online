using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimeGirl;

namespace WebNet23Online.Controllers
{
   
    public class AnimeGirlController : Controller
    {
        //    /AnimeGirl/Index
        public IActionResult Index(int count)
        {
            var viewModels = new List<AnimeGirlImageInfoViewModel>();
            viewModels.Add(new AnimeGirlImageInfoViewModel
            {
                Url = "https://img.freepik.com/premium-photo/hand-drawn-cartoon-anime-girl-illustration-camouflage-uniform_561641-5662.jpg",
                Title = "Арт и персонажи"
            });
            viewModels.Add(new AnimeGirlImageInfoViewModel
            {
                Url = "https://img.freepik.com/free-photo/anime-character-winter_23-2151843487.jpg?semt=ais_hybrid&amp;w=740",
                Title = "Зимнее настроение"
            });
            viewModels.Add(new AnimeGirlImageInfoViewModel
            {
                Url = "https://i.pinimg.com/474x/ed/3a/e8/ed3ae86ab479861a1e10e8d0caaf04de.jpg?nii=t",
                Title = "Ещё один любимый стиль"
            });

            viewModels = viewModels.Take(count).ToList();

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
