using WebNet23Online.Data.Models;
using WebNet23Online.Models.RockLegendsPortal;

namespace WebNet23Online.Services.Interfaces
{
    public interface IRockLegendsPick
    {
        RockLegendsPortalViewModel GetBandDetails(int id, RockLegendsData bandData);
    }
}