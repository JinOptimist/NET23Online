using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Services.Apis;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services;

public class AnimeGirlIndexFunService : IAnimeGirlIndexFunService
{
  private readonly JokeApi _jokeApi;
  private readonly WaifuApi _waifuApi;
  private readonly CatApi _catApi;

  public AnimeGirlIndexFunService(JokeApi jokeApi, WaifuApi waifuApi, CatApi catApi)
  {
    _jokeApi = jokeApi;
    _waifuApi = waifuApi;
    _catApi = catApi;
  }

  public async Task<AnimeGirlFunContent> LoadAsync(int characterCount)
  {
    var jokeDtoTask = _jokeApi.GetJoke();
    var waifuDtoTask = _waifuApi.GetWaifu();
    var catDtosTask = _catApi.GetCats();

    if (characterCount > 10)
    {
      Task.WaitAll(jokeDtoTask, waifuDtoTask, catDtosTask);
    }
    else
    {
      await Task.WhenAll(jokeDtoTask, waifuDtoTask, catDtosTask);
    }

    return new AnimeGirlFunContent
    {
      Joke = jokeDtoTask.Result,
      Waifu = waifuDtoTask.Result,
      Cats = catDtosTask.Result
    };
  }
}
