using System;
using System.Linq;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class RockBandsRepository : BaseRepository<RockBandsData>, IRockBandsRepository
    {
        public RockBandsRepository(WebContext webContext) : base(webContext) { }

        public override void Add(RockBandsData model)
        {
            var normalizedName = model.Name?.Trim().ToLower();
            if (_dbSet.Any(x => x.Name.ToLower() == normalizedName))
            {
                throw new InvalidOperationException($"Rock band with name '{normalizedName}' already exists.");
            }

            model.Name = normalizedName.Length == 1
               ? normalizedName.ToUpper()
               : char.ToUpper(normalizedName[0]) + normalizedName.Substring(1);
            base.Add(model);
            base.Add(model);
        }
    }
}
