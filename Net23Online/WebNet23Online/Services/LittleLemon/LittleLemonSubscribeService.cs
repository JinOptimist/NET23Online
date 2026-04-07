using WebNet23Online.Services.Interfaces;

namespace TestApp.Services
{
    public class LittleLemonSubscribeService : ILittleLemonSubscribeService
    {
        public string GetSubscribeMessage(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return string.Empty;
            }
            var name = email
                .ToLower()
                .Split('@')[0]
                .Split('.')[0];
            if (IsRegistered(email))
            {
                return $"{name} you are already with us";
            }

            return $"Thanks {name} for subscribe";
        }

        private bool IsRegistered(string email)
        {
            var registeredEmails = new List<string>
            {
                "ali@gmail.com",
                "black.sea@example.com"
            };

            return registeredEmails
                .Contains(email);
        }

    }
}