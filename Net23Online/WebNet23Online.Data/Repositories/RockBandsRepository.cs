using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class RockBandsRepository : BaseRepository<RockBandsData>, IRockBandsRepository
    {
        public RockBandsRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<RockBandsData> AsNoTracking()
        {
            return _dbSet.AsNoTracking();
        }

        public override void Add(RockBandsData model)
        {
            var normalizedName = model.Name?.Trim().ToLower();
            if (_dbSet.Any(x => x.Name.ToLower() == normalizedName))
            {
                throw new InvalidOperationException($"Rock band with name '{normalizedName}' already exists.");
            }

            model.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(normalizedName);
            base.Add(model);
        }
    }
}
