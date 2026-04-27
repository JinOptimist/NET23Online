using WebNet23Online.Data.Models;

namespace WebNet23Online.Models.Maks_Korz
{
    public class Authorization : IAuthorization
    {
        public void AddNewUser(DataUserForMaksKorz user)
        {
            var _user = new DataUserForMaksKorz();
            user = _user;
        }
        public string GetDataNow()
        {
            var dataNow = DateTime.Now;
            if (dataNow.Hour < 12)
            {
                return "Morning";
            }
            else if (dataNow.Hour < 17)
            {
                return "Afternoon";
            }
            else
            {
                return "Evening";
            }
        }
    }
}
