using WebNet23Online.Data.Models;

namespace WebNet23Online.Models.Maks_Korz
{
    public interface IAuthorization
    {
        void AddNewUser(DataUserForMaksKorz user);
        string GetDataNow();
    }
}
