using WebNet23Online.Models.RockLegendsPortal;

namespace WebNet23Online.Services.Interfaces
{
    public interface IRockLegendsPick
    {
        RockLegendsPortalViewModel GetBandDetails(string id);
    }
}