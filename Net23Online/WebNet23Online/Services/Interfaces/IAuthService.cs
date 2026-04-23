using WebNet23Online.Data.Models;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAuthService
    {
        UserData? GetUser();
        int GetUserId();
        bool IsAuthenticated();
    }
}