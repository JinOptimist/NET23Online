using WebNet23Online.Models.RockLegendsPortal;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class RockLegendsPick : IRockLegendsPick
    {
        public RockLegendsPortalViewModel GetBandDetails(string id)
        {
            var model = new RockLegendsPortalViewModel { SelectedBand = id };

            switch (id?.ToLower())
            {
                case "kiss":
                    model.BandName = "KISS";
                    model.Biography = "Боги грома и рок-н-ролла...";
                    break;
                case "ozzy":
                    model.BandName = "Ozzy Osbourne";
                    model.Biography = "Князь Тьмы, великий и ужасный...";
                    break;
                case "acdc":
                    model.BandName = "AC/DC";
                    model.Biography = "Гром из Австралии...";
                    break;
                case "bon-jovi":
                    model.BandName = "Bon Jovi";
                    model.Biography = "Герои стадионного рока из Нью-Джерси...";
                    break;
                case "rammstein":
                    model.BandName = "Rammstein";
                    model.Biography = "Грохот немецкой индустриальной машины...";
                    break;
                case "tdg":
                    model.BandName = "Three Days Grace";
                    model.Biography = "Мастера альтернативного рока из Канады...";
                    break;
                case "slipknot":
                    model.BandName = "Slipknot";
                    model.Biography = "Девять масок, воплощающих коллективный кошмар...";
                    break;
                case "skillet":
                    model.BandName = "Skillet";
                    model.Biography = "роповедники драйва и мощного альтернативного рока...";
                    break;
                case "metallica":
                    model.BandName = "Metallica";
                    model.Biography = "Абсолютные титаны, переписавшие законы тяжелой музыки...";
                    break;
                case "bmth":
                    model.BandName = "Bring Me The Horizon";
                    model.Biography = "Главные хамелеоны современной тяжелой сцены...";
                    break;
                default:
                    model.BandName = "Unknown";
                    model.Biography = "Информация не найдена.";
                    break;
            }

            return model;
        }
    }
}
