using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebNet23Online.Controllers.CustomAuthAttridute;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models.MaksKorz;
using WebNet23Online.Data.Repositories.MaksKorz;
using WebNet23Online.Models.Auth;
using WebNet23Online.Models.Home;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class MaksKorzAdminController : Controller
    {
        private IAdminForMaksKorzRepository _adminForMaksKorzRepository;
        private readonly IAuthService _authService;
        public MaksKorzAdminController(IAdminForMaksKorzRepository adminForMaksKorzRepository, IAuthService authService)
        {
            _adminForMaksKorzRepository = adminForMaksKorzRepository;
            _authService = authService;
        }
        public IActionResult Index()
        {
            var user = _adminForMaksKorzRepository.GetAll();
            var currentUser = _authService.GetUser2();
            var viewModel = new AllDataUserForMaksKorz
            {
                User = user
                .Select(x => new DataUserForMaksKorz{ 
                    Id = x.Id, 
                    LastName = x.LastName
                }).ToList(),
                IsCurrentUserAdmin = currentUser!.Role==UserRole.Admin,
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Deny()
        {
            return View();
        }
        [Authorize]
        [IsAdmin]
        [HttpGet]
        public IActionResult Location()
        {
            var user = _adminForMaksKorzRepository.GetAll();
            var currentUser = _authService.GetUser2();
            var viewModel = new AllDataUserForMaksKorz
            {
                User = user
                .Select(x => new DataUserForMaksKorz
                {
                    Id = x.Id,
                    LastName = x.LastName
                }).ToList(),
                IsCurrentUserAdmin = currentUser!.Role == UserRole.Admin,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = _adminForMaksKorzRepository.GetByNameAndPassword(viewModel.Login, viewModel.Password);
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
                new Claim(ClaimTypes.AuthenticationMethod, AuthService.AUTH_KEY)
            };
            var identity = new ClaimsIdentity(claims, AuthService.AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);
            HttpContext
                .SignInAsync(AuthService.AUTH_KEY, principal)
                .Wait();
            return RedirectToAction("Location");
        }
    }
}
