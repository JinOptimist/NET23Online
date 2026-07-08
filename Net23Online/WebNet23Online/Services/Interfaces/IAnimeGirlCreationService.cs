using WebNet23Online.Data.Models;

namespace WebNet23Online.Services.Interfaces;

public interface IAnimeGirlCreationService
{
  void SaveUploadedImage(IFormFile image, AnimeGirlData character, string? formUrl, int? animeId);
}
