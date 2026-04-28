using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models.Steam;

namespace WebNet23Online.Data.Models
{
    public class UserData : BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int? UserProfileId { get; set; }

        public virtual List<UserData> MyFriends { get; set; }
        public virtual List<UserData> WhoIsMyFriends { get; set; }
        public virtual UserProfileData? UserProfile { get; set; }

        public virtual List<IngredientData> CreatedIngredients { get; set; } = new();
        public virtual List<FoodItemData> CreatedFoodItems { get; set; } = new();
        public virtual List<MenuData> CreatedMenus { get; set; } = new();

        

        public virtual List<HabitData> Habits { get; set; }
        public virtual List<HabitTrackerDiaryData> DiaryEntries { get; set; }

        public virtual List<GameData> CreatedGames { get; set; }
        public virtual List<GameData> ModifiedGames { get; set; }
    }
}
