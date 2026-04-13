using WebNet23Online.Data.Enums;

namespace WebNet23Online.Data.Models
{
    public class UserData : BaseModel
    {
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
