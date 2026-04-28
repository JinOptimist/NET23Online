using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Controllers.CustomAuthAttribute;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.User;
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
                    .Select(x => new UserViewModel { 
                        Id = x.Id, 
                        Name = x.Name,
                    }).ToList(),
                IsCurrentUserAdmin = currentUser.Role == UserRole.Admin,
            };

            return View(viewModel);
        }

        [IsAdmin]
        public IActionResult DeleteUser()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
