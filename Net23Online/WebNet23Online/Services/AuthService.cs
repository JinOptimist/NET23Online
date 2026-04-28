using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class AuthService : IAuthService
    {
        public const string AUTH_KEY = "AuthNameSmile";
        public const string COOCKIE_ID_KEY = "Id";
        public const string COOCKIE_ROLE_KEY = "Role";
        public const string COOCKIE_NAME_KEY = "UserName";

        private IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        public AuthService(IHttpContextAccessor httpContextAccessor, 
            IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public int GetUserId()
        {
            var userIdStr = _httpContextAccessor.HttpContext!.User?.Claims
                .FirstOrDefault(x => x.Type == COOCKIE_ID_KEY)
                ?.Value;
            if (userIdStr is null)
            {
                return 0;
            }

            var userId = int.Parse(userIdStr);
            return userId;
        }
    
        public UserData? GetUser()
        {
            var userId = GetUserId();
            if (userId <= 0)
            {
                return null;
            }

            return _userRepository.Get(userId);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }

        /// <summary>
        /// You can't call this method if user not authenticated
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public UserRole GetRole()
        {
            if (!IsAuthenticated()) {
                throw new InvalidOperationException();
            }
            var roleStr = _httpContextAccessor.HttpContext!.User.Claims
                .First(x => x.Type == COOCKIE_ROLE_KEY)
                .Value;
            var role = Enum.Parse<UserRole>(roleStr);
            return role;
        }

        public bool AtLeastModerator()
        {
            if (!IsAuthenticated())
            {
                return false;
            }

            var role = GetRole();
            return role == UserRole.Moderator || role == UserRole.Admin;
        }
    }
}
