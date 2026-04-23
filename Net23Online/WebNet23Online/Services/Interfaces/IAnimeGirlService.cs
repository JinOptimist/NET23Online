using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.AnimeGirl;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimeGirlService
    {
        AnimeGirlImageInfoViewModel Generate();
        List<AnimeGirlImageInfoViewModel> GenerateList(List<AnimeGirlData> animeGirlDatas);
        List<IndexAnimeViewModel> AnimeMap(List<AnimeData> animes);
        List<SelectListItem> GetListItemsWithAnime();
    }
}