using WebNet23Online.Data.Enums;

namespace WebNet23Online.Data.Models
{
    public class UserData : BaseModel
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public int UserProfileId { get; set; }

        public virtual List<UserData> MyFriends { get; set; }
        public virtual List<UserData> WhoIsMyFriends { get; set; }
        public virtual UserProfileData UserProfile { get; set; }
        public virtual List<LittleLemonData> LittleLemonDatas { get; set; }
    }
}
