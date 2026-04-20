using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.SlayTheSpire2;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class SlayTheSpire2Controller : Controller
    {
        private readonly ISlayTheSpire2RewardImageService _rewardImageService;

        public SlayTheSpire2Controller(ISlayTheSpire2RewardImageService rewardImageService)
        {
            _rewardImageService = rewardImageService;
        }

        public IActionResult Index()
        {
            return View();
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
