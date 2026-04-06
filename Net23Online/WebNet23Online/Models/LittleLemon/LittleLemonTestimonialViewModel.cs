namespace WebNet23Online.Models.LittleLemon
{
    public class LittleLemonTestimonialViewModel
    {
        public const int  REVIEW_SCALE_MAX_STARS = 5;
        public const string STAR_ICON_RELATIVE_URL = "/images/little-lemon/svg/Star.svg";

        public int StarRating { get; set; }
        public string UserPhotoUrl { get; set; } 
        public string UserPhotoAlt { get; set; } 
        public string AuthorDisplayName { get; set; } 
        public string AuthorNickName { get; set; }
        public string Quote { get; set; }

        public string StarsDescription => $"{StarRating} out of {REVIEW_SCALE_MAX_STARS} stars";
    }
}
