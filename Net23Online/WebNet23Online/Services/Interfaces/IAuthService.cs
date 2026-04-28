using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAuthService
    {
        UserRole GetRole();
        UserData? GetUser();
        int GetUserId();
        bool IsAuthenticated();
        bool AtLeastModerator();
        bool IsCurrentUserAtLeastEmployee();
    }
}