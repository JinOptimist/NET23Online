using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAuthService
    {
        UserData? GetUser();
        UserRole GetRole();
        int GetUserId();
        DataUserForMaksKorz? GetUser2();
        bool IsAuthenticated();
    }
}