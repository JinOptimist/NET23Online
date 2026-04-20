namespace WebNet23Online.Models.Maks_Korz
{
    public class Authorization : IAuthorization
    {
        public void AddNewUser(DataUser user)
        {
            var _user = new DataUser();
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
