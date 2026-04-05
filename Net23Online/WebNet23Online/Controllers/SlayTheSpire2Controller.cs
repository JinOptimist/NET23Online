using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.SlayTheSpire2;

namespace WebNet23Online.Controllers
{
    public class SlayTheSpire2Controller : Controller
    {
        const int TIER1 = 83;
        const int TIER2 = 119;
        const int TIER3 = 159;
        const int TIER4 = 262;
        const int TIER5 = 268;
        const int TIER6 = 425;
        // STATIC IS A BAD IDEA
        // REMOVE AFTER ADD DATABASE
        private static List<string> _urls = new List<string>
        {
            "https://i.postimg.cc/50RTLYz7/Screenshot-8.png",
            "https://i.kickstarter.com/assets/053/224/867/c8e77de37f7768a12dd13501ac6eda8f_original.png?fit=scale-down&origin=ugc&q=100&v=1775412597&width=680&sig=Q4zjgiT%2FMmrWi%2B6dDt8iC09zp3GIkX%2FwPqXd3XyBEBc%3D",
            "https://i.kickstarter.com/assets/053/208/462/b6e2675ac4cbd0b35ce2c76d91164849_original.png?fit=scale-down&origin=ugc&q=100&v=1775238001&width=680&sig=id6M9chY5sbypUA7QPljhHSJQ4s3PmyKXvFG77VSOrY%3D",
            "https://i.kickstarter.com/assets/053/224/714/94c5c6471cf2e379f48aae436fd7a659_original.png?fit=scale-down&origin=ugc&q=100&v=1775411466&width=680&sig=o6a47TEjBgpXdtTGoTVOfmvATIt8mlBqAw92GGvB5OA%3D",
            "https://i.kickstarter.com/assets/053/209/219/37a506ae780f90b9f87b83a482ae5e8b_original.png?fit=scale-down&origin=ugc&q=100&v=1775242939&width=680&sig=yEmzT5tLPLdo4dnJ3pJuXh%2FyO9AYwnGvMuu9qgBJax4%3D",
            "https://i.kickstarter.com/assets/053/208/472/98683c2818a3b876a138770ae0c57c4c_original.png?fit=scale-down&origin=ugc&q=100&v=1775238065&width=680&sig=vfZ%2FDP3amqgkVQ1zWONSZFDJ2Vtz6EauEsde7C1Gi%2F8%3D",
            "https://i.kickstarter.com/assets/053/208/480/ac534d61b5d5f90d32dd456741b545bb_original.png?fit=scale-down&origin=ugc&q=100&v=1775238095&width=680&sig=B8H9hA7dc4LC%2FKJDX4IVJxuDgPO0dFXOY28%2F8z2K5Ao%3D"
        };
        // STATIC IS A BAD IDEA
        // REMOVE AFTER ADD DATABASE
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
            model.ImageUrl = ResolveRewardImageUrl(model.DonationAmount);
            return View(model);
        }

        private static string? ResolveRewardImageUrl(int donationAmount)
        {
            if (donationAmount <= 0)
            {
                return null;
            }
            if (donationAmount <=TIER1)
            {
                return _urls[0];
            }

            if (donationAmount >= TIER6)
            {
                return _urls[6];
            }

            if (donationAmount >= TIER5)
            { 
                return _urls[5];
            }
            if (donationAmount >= TIER4)
            {  
                return _urls[4];
            }

            if (donationAmount >= TIER3)
            {
                return _urls[3];
            }
            if (donationAmount >= TIER2)
            {
                return _urls[2];
            }
            return _urls[1];
        }
    }
}
