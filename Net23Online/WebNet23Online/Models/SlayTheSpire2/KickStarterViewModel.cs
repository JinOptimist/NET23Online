namespace WebNet23Online.Models.SlayTheSpire2
{
    public class KickStarterViewModel
    {
        public int DonationAmount { get; set; }

        /// <summary>Картинка награды по сумме доната; null если сумма ниже минимального порога.</summary>
        public string? ImageUrl { get; set; }
    }
}
