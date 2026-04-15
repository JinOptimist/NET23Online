using System;
using System.Linq;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories
{
    public class RockBandsRepository : BaseRepository<RockBandsData>
    {
        public RockBandsRepository(WebContext webContext) : base(webContext) { }

        public override void Add(RockBandsData model)
        {
            var normalizedName = model.Name?.Trim().ToLower();
            if (_dbSet.Any(x => x.Name.ToLower() == normalizedName))
            {
                throw new InvalidOperationException($"Rock band with name '{normalizedName}' already exists.");
            }

            model.Name = normalizedName;
            base.Add(model);
        }
    }
}
