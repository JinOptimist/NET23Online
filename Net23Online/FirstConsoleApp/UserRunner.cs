using static System.Console;
using CheckName = MyCustomValidator.MyStringValidator;
using CheckYear = MyCustomValidator.MyDateValidator;

namespace FirstConsoleApp
{
    public static class UserRunner
    {
        public const int PERMITTED_AGE = 18;
        public static int yearNow = DateTime.Now.Year;
        public static int minNameLength = 0;
        public static int maxNameLength = 20;
        public static int minYear = 1900;
        public static string askNameQuestion = $"What is your name?\nName should contain between {minNameLength} and {maxNameLength} latin letters: ";
        public static string askYaerOfBirthQuestion = "What is your year of birth?\nYear should be in format YYYY: ";

        public static void Main(string[] args)
        {
            ShowFinalMsg(ReceiveUserName(), ReceiveUserAge());
        }

        public static void ShowFinalMsg(string userName, int userAge)
        {
            Write($"Hi {userName.ToUpper()}!\nSale of alcoholic beverages for people {userAge} years old " +
                $"{(userAge >= PERMITTED_AGE ? "is" : "is not")} allowed.");
        }

        public static int ReceiveUserAge()
        {
            string userYear;

            do
            {
                userYear = AskYearOfBirth();

            } while (!CheckYear.IsYearOfBirthValid(userYear, minYear, yearNow));

            var userAge = yearNow - int.Parse(userYear);
            return userAge;
        }

        public static string ReceiveUserName()
        {
            string userName;

            do
            {
                userName = AskUserName();

            } while (!CheckName.IsStringLengthValid(userName, minNameLength, maxNameLength) ||
                        !CheckName.DoesStringContainLatinLettersOnly(userName));
            return userName;
        }

        public static string AskUserName()
        {
            Write(askNameQuestion);
            return ReadLine();
        }

        public static string AskYearOfBirth()
        {
            Write(askYaerOfBirthQuestion);
            return ReadLine();
        }

    }
}
