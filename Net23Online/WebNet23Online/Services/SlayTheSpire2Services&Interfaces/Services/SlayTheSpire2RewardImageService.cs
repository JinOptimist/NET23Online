using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class SlayTheSpire2RewardImageService : ISlayTheSpire2RewardImageService
    {
        private const int TIER1 = 83;
        private const int TIER2 = 119;
        private const int TIER3 = 159;
        private const int TIER4 = 262;
        private const int TIER5 = 268;
        private const int TIER6 = 425;

        private static readonly string[] Urls =
        [
            "https://i.postimg.cc/50RTLYz7/Screenshot-8.png",
            "https://i.kickstarter.com/assets/053/224/867/c8e77de37f7768a12dd13501ac6eda8f_original.png?fit=scale-down&origin=ugc&q=100&v=1775412597&width=680&sig=Q4zjgiT%2FMmrWi%2B6dDt8iC09zp3GIkX%2FwPqXd3XyBEBc%3D",
            "https://i.kickstarter.com/assets/053/208/462/b6e2675ac4cbd0b35ce2c76d91164849_original.png?fit=scale-down&origin=ugc&q=100&v=1775238001&width=680&sig=id6M9chY5sbypUA7QPljhHSJQ4s3PmyKXvFG77VSOrY%3D",
            "https://i.kickstarter.com/assets/053/224/714/94c5c6471cf2e379f48aae436fd7a659_original.png?fit=scale-down&origin=ugc&q=100&v=1775411466&width=680&sig=o6a47TEjBgpXdtTGoTVOfmvATIt8mlBqAw92GGvB5OA%3D",
            "https://i.kickstarter.com/assets/053/209/219/37a506ae780f90b9f87b83a482ae5e8b_original.png?fit=scale-down&origin=ugc&q=100&v=1775242939&width=680&sig=yEmzT5tLPLdo4dnJ3pJuXh%2FyO9AYwnGvMuu9qgBJax4%3D",
            "https://i.kickstarter.com/assets/053/208/472/98683c2818a3b876a138770ae0c57c4c_original.png?fit=scale-down&origin=ugc&q=100&v=1775238065&width=680&sig=vfZ%2FDP3amqgkVQ1zWONSZFDJ2Vtz6EauEsde7C1Gi%2F8%3D",
            "https://i.kickstarter.com/assets/053/208/480/ac534d61b5d5f90d32dd456741b545bb_original.png?fit=scale-down&origin=ugc&q=100&v=1775238095&width=680&sig=B8H9hA7dc4LC%2FKJDX4IVJxuDgPO0dFXOY28%2F8z2K5Ao%3D"
        ];

        public string? ResolveRewardImageUrl(int donationAmount)
        {
            if (donationAmount <= 0)
            {
                return null;
            }

            if (donationAmount <= TIER1)
            {
                return Urls[0];
            }

            if (donationAmount >= TIER6)
            {
                return Urls[6];
            }

            if (donationAmount >= TIER5)
            {
                return Urls[5];
            }

            if (donationAmount >= TIER4)
            {
                return Urls[4];
            }

            if (donationAmount >= TIER3)
            {
                return Urls[3];
            }

            if (donationAmount >= TIER2)
            {
                return Urls[2];
            }

            return Urls[1];
        }
    }
}
