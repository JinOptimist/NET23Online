using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.SlayTheSpire2;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class SlayTheSpire2Controller : Controller
    {
        private readonly ISlayTheSpire2RewardImageService _rewardImageService;
        private readonly ISlayTheSpire2HeroesRepository _heroesRepository;

        public SlayTheSpire2Controller(
            ISlayTheSpire2RewardImageService rewardImageService,
            ISlayTheSpire2HeroesRepository heroesRepository)
        {
            _rewardImageService = rewardImageService;
            _heroesRepository = heroesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Heroes(int id)
        {
            var hero = _heroesRepository.GetById(id);
            var model = new HeroesViewModel
            {
                HeroId = id,
                Found = hero != null,
                Name = hero?.Name,
                Color = hero?.Color
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult KickStarter()
        {
            return View(new KickStarterViewModel());
        }

        [HttpPost]
        public IActionResult KickStarter(KickStarterViewModel model)
        {
            model ??= new KickStarterViewModel();
            model.ImageUrl = _rewardImageService.ResolveRewardImageUrl(model.DonationAmount);
            return View(model);
        }
    }
}
