using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAuthService
    {
        UserRole GetRole();
        UserData? GetUser();
        int GetUserId();
        string? GetUserName();
        bool IsAuthenticated();
        bool AtLeastModerator();
    }
}