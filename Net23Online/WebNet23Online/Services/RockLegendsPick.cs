using WebNet23Online.Data.Models;
using WebNet23Online.Models.RockLegendsPortal;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class RockLegendsPick : IRockLegendsPick
    {
        public RockLegendsPortalViewModel GetBandDetails(string id, List<RockLegendsData> rockLegendsDatas)
        {
            var model = new RockLegendsPortalViewModel { SelectedBand = id };

            var dbRow = rockLegendsDatas.FirstOrDefault();

            switch (id?.ToLower())
            {
                case "kiss":
                    model.BandName = "KISS";
                    model.Biography = "Боги грома и рок-н-ролла...";
                    model.PickTime = dbRow.Kiss;
                    break;
                case "ozzy":
                    model.BandName = "Ozzy Osbourne";
                    model.Biography = "Князь Тьмы, великий и ужасный...";
                    model.PickTime = dbRow.Ozzy;
                    break;
                case "acdc":
                    model.BandName = "AC/DC";
                    model.Biography = "Гром из Австралии...";
                    model.PickTime = dbRow.ACDC;
                    break;
                case "bon-jovi":
                    model.BandName = "Bon Jovi";
                    model.Biography = "Герои стадионного рока из Нью-Джерси...";
                    model.PickTime = dbRow.BonJovi;
                    break;
                case "rammstein":
                    model.BandName = "Rammstein";
                    model.Biography = "Грохот немецкой индустриальной машины...";
                    model.PickTime = dbRow.Rammstein;
                    break;
                case "tdg":
                    model.BandName = "Three Days Grace";
                    model.Biography = "Мастера альтернативного рока из Канады...";
                    model.PickTime = dbRow.ThreeDaysGrace;
                    break;
                case "slipknot":
                    model.BandName = "Slipknot";
                    model.Biography = "Девять масок, воплощающих коллективный кошмар...";
                    model.PickTime = dbRow.Slipknot;
                    break;
                case "skillet":
                    model.BandName = "Skillet";
                    model.Biography = "роповедники драйва и мощного альтернативного рока...";
                    model.PickTime = dbRow.Skillet;
                    break;
                case "metallica":
                    model.BandName = "Metallica";
                    model.Biography = "Абсолютные титаны, переписавшие законы тяжелой музыки...";
                    model.PickTime = dbRow.Metallica;
                    break;
                case "bmth":
                    model.BandName = "Bring Me The Horizon";
                    model.Biography = "Главные хамелеоны современной тяжелой сцены...";
                    model.PickTime = dbRow.BringMeTheHorizon;
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
