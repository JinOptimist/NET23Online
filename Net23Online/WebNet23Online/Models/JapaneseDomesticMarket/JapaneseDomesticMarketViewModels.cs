using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebNet23Online.Controllers;
using WebNet23Online.Models.AnimeGirl;

namespace WebNet23Online.Models.JapaneseDomesticMarket
{
    public class JapaneseDomesticMarketViewModels
    {
        public string Url { get; set; } = "";
        public string Marka { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Price { get; set; }
        public string ManufacturerType { get; set; } = "";

    }
}