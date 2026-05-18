//using WebNet23Online.Data.Models.MaksKorz;
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Models.Maks_Korz
{
    public interface IAuthorization
    {
        void AddNewUser(DataUserForMaksKorz user);
        string GetDataNow();
    }
}
