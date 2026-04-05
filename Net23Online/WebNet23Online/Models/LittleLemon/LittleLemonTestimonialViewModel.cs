namespace WebNet23Online.Models.LittleLemon
{
    public class LittleLemonTestimonialViewModel
    {
        public const int ReviewScaleMaxStars = 5;
        public const string StarIconRelativeUrl = "/images/little-lemon/svg/Star.svg";

        public int StarRating { get; set; }
        public string UserPhotoUrl { get; set; } 
        public string UserPhotoAlt { get; set; } 
        public string AuthorDisplayName { get; set; } 
        public string AuthorNickName { get; set; }
        public string Quote { get; set; }

        public string StarsDescription => $"{StarRating} out of {ReviewScaleMaxStars} stars";
    }
}
