using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.Auth;
using WebNet23Online.Services;

namespace WebNet23Online.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userRepository.GetByNameAndPassword(viewModel.Login, viewModel.Password);
            if (user == null)
            {
                ModelState.AddModelError(
                    nameof(LoginViewModel.Login), //"Login"
                    "There is no User with this login and password");
                return View(viewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(AuthService.COOCKIE_ID_KEY, user.Id.ToString()),
                new Claim(AuthService.COOCKIE_ROLE_KEY, user.Role.ToString()),
                new Claim(AuthService.COOCKIE_NAME_KEY, user.Name),
                new Claim(ClaimTypes.AuthenticationMethod, AuthService.AUTH_KEY)
            };

            var identity = new ClaimsIdentity(claims, AuthService.AUTH_KEY);

            var principal = new ClaimsPrincipal(identity);

            HttpContext
                .SignInAsync(AuthService.AUTH_KEY, principal)
                .Wait();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(LoginViewModel viewModel)
        {
            if (!_userRepository.IsNameUniq(viewModel.Login))
            {
                ModelState.AddModelError(nameof(LoginViewModel.Login), "Name is already used");
                return View(viewModel);
            }

            var user = new UserData
            {
                Name = viewModel.Login,
                Password = viewModel.Password,
            };

            _userRepository.Registration(user);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Deny()
        {
            return View();
        }
    }
}
