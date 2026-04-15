using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.RockBands;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class RockBandsService : IRockBandsService
    {
        private readonly WebContext _webContext;
        private 

        public RockBandsService(WebContext webContext)
        {
            _webContext = webContext;
        }

        public List<BandBlockViewModel> GetBands()
        {
            return _webContext.RockBand
                .AsNoTracking()
                .OrderBy(b => b.Id)
                .Select(b => new BandBlockViewModel
                {
                    Name = b.Name,
                    Description = b.Description,
                    ImageUrl = string.IsNullOrWhiteSpace(b.Url) ? null : b.Url,
                })
                .ToList();
        }

        public void AddBand(BandBlockViewModel viewModel)
        {
            if (viewModel == null || string.IsNullOrWhiteSpace(viewModel.Name))
            {
                return;
            }

            var newBand = new RockBandsData
            {
                Name = viewModel.Name.Trim(),
                Description = viewModel.Description?.Trim() ?? string.Empty,
                Url = string.IsNullOrWhiteSpace(viewModel.ImageUrl)
                    ? string.Empty
                    : viewModel.ImageUrl.Trim(),
            };

            _webContext.RockBand.Add(newBand);
            _webContext.SaveChanges();
        }
    }
}
