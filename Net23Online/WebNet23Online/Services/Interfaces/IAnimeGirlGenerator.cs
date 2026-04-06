using WebNet23Online.Models.AnimeGirl;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimeGirlGenerator
    {
        AnimeGirlImageInfoViewModel Generate();
        List<AnimeGirlImageInfoViewModel> GenerateList(int count);
    }
}