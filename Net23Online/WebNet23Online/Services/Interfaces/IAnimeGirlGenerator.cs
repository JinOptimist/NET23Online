using WebNet23Online.Data.Models;
using WebNet23Online.Models.AnimeGirl;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimeGirlGenerator
    {
        AnimeGirlImageInfoViewModel Generate();
        List<AnimeGirlImageInfoViewModel> GenerateList(List<AnimeGirlData> animeGirlDatas);
        List<IndexAnimeViewModel> AnimeMap(List<AnimeData> animes);
    }
}