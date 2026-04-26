using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models.AnimalWorld;

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
        public virtual List<ZooData> CreatedByMeZoos { get; set; }
        public virtual List<AnimalFamilyData> CreatedByMeAnimalFamilies { get; set; }
        public virtual List<AnimalSpeciesData> CreatedByMeAnimalSpecies { get; set; }
        
        public virtual List<HabitData> Habits { get; set; }
        public virtual List<HabitTrackerDiaryData> DiaryEntries { get; set; }
    }
}
