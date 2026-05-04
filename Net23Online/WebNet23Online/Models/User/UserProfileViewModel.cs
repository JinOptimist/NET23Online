using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data.Enums;

namespace WebNet23Online.Models.User
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }
        public string AvatarUrl { get; set; }
        public string UserName { get; set; }
        public Language Language { get; set; }
        public List<SelectListItem> Languages { get; set; } = new();
    }
}
