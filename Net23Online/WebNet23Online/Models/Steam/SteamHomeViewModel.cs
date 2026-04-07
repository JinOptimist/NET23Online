namespace WebNet23Online.Models.Steam
{
    public class SteamHomeViewModel
    {
        public IList<SteamGameViewModel> Featured { get; set; }
        public IList<SteamGameViewModel> SpecialOffers { get; set; }
    }
}
