using WebNet23Online.Models.DTOs;

namespace WebNet23Online.Models.AnimeGirl;

public class AnimeGirlFunContent
{
  public JokeDto? Joke { get; set; }
  public WaifuDtoRoot? Waifu { get; set; }
  public List<CatDto>? Cats { get; set; }
}
