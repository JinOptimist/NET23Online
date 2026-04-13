using WebNet23Online.Services.Interfaces;
using WebNet23Online.Models.LittleLemon;

namespace WebNet23Online.Services
{
    public class LittleLemonTestimonialService: ILittleLemonTestimonialService
    {
        public List<LittleLemonTestimonialViewModel> GetTestimonials() {
            var testimonials = new List<LittleLemonTestimonialViewModel>
            {
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 5,
                    UserPhotoUrl = "/images/little-lemon/images/user-1.png",
                    UserPhotoAlt = "Testimonial 1",
                    AuthorDisplayName = "Jon Do",
                    AuthorNickName = "Johnny_utah",
                    Quote = "We had such a great time celebrating my grandmothers birthday!"
                },
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 5,
                    UserPhotoUrl = "/images/little-lemon/images/user-2.png",
                    UserPhotoAlt = "Testimonial 2",
                    AuthorDisplayName = "Naomi Noah",
                    AuthorNickName = "Naomi88-noa",
                    Quote = "Such a chilled out atmosphere - love it!"
                },
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 4,
                    UserPhotoUrl = "/images/little-lemon/images/user-3.png",
                    UserPhotoAlt = "Testimonial 3",
                    AuthorDisplayName = "Joni Sou",
                    AuthorNickName = "Sou_dark",
                    Quote = "Best Feta Salad in town. Flawless everytime!"
                },
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 5,
                    UserPhotoUrl = "/images/little-lemon/images/user-4.png",
                    UserPhotoAlt = "Testimonial 4",
                    AuthorDisplayName = "Sara Lopez",
                    AuthorNickName = "Sara72",
                    Quote = "Seriously cannot stop thinking about the Turkish Mac n' Cheese!!"
                }
            };
            return testimonials;
        }
    }
}
