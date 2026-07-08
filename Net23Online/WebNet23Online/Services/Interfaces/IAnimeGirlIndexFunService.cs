using WebNet23Online.Models.AnimeGirl;

namespace WebNet23Online.Services.Interfaces;

public interface IAnimeGirlIndexFunService
{
  Task<AnimeGirlFunContent> LoadAsync(int characterCount);
}
