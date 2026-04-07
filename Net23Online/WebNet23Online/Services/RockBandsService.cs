using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.RockBands;

namespace WebNet23Online.Service
{
    public class RockBandsService
    {

        // STATIC IS A BAD IDEA — REMOVE AFTER ADD DATABASE
        private static readonly List<BandBlockViewModel> _bands =
        [
            new BandBlockViewModel
            {
                Name = "Bring Me The Horizon",
                Description =
                    "Британская рок-группа, известная своим экспериментальным звучанием и мощной энергетикой.",
                ImageUrl = "/images/rock-bands/BMTH.jpg",
            },
            new BandBlockViewModel
            {
                Name = "Slipknot",
                Description = "Легендарная метал-группа с агрессивным стилем и уникальным визуальным образом.",
                ImageUrl = "/images/rock-bands/slipknot.jpg",
            },
            new BandBlockViewModel
            {
                Name = "Metallica",
                Description = "Одна из самых влиятельных метал-групп в истории с культовыми альбомами.",
                ImageUrl = "/images/rock-bands/metallica.jpg",
            },
        ];

    }
}
