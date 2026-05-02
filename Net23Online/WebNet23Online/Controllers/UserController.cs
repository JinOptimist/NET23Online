using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Controllers.CustomAuthAttribute;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.User;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IAuthService _authService;
        public IUserRepository _userRepository;

        public UserController(IAuthService authService,
            IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        [IsModerator]
        public IActionResult Index(int cardId)
        {
            var usersFromDb = _userRepository.GetAll();
            var currentUser = _authService.GetUser()!;
            var viewModel = new UserIndexViewModel
            {
                Users = usersFromDb
                    .Select(x => new UserViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                    }).ToList(),
                IsCurrentUserAdmin = currentUser.Role == UserRole.Admin,
            };

            return View(viewModel);
        }

        public IActionResult Profile()
        {
            var currentUserLanguage = _authService.GetLanguage();
            var allLanguagesList = Enum
                .GetNames<Language>()
                .Select(x => new SelectListItem
                {
                    Text = x,
                    Value = x,
                    Selected = x == currentUserLanguage.ToString()
                })
                .ToList();

            var viewModel = new UserProfileViewModel
            {
                UserId = _authService.GetUserId(),
                UserName = _authService.GetUserName() ?? "unnamed",
                Language = currentUserLanguage,
                Languages = allLanguagesList
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateProfile(UserProfileViewModel viewModel)
        {
            UserData userData = new UserData
            {
                Id = viewModel.UserId,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Mobilephone = viewModel.Mobilephone,
                Language = viewModel.Language,
            };
            _userRepository.UpdateProfile(userData);
            var user = _authService.GetUser();

            HttpContext.SignOutAsync().Wait();

            _authService.SignIn(user);

            return RedirectToAction(nameof(Profile));
        }

        [IsAdmin]
        public IActionResult DeleteUser()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
