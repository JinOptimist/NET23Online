using FirstConsoleApp.TowerOfHanoi.Players;
using static System.Console;

namespace FirstConsoleApp.TowerOfHanoi.Helpers
{
    public class InputFromUserValidator
    {
        public static bool IsNimberOfDisksValid(string inputFromUser)
            => int.TryParse(inputFromUser, out int parsedNumber) && parsedNumber > 0;

        public static bool IsActionWithRodsValid(string inputFromUser)
        {
            var isValid = int.TryParse(inputFromUser, out int parsedNumber) &&
                parsedNumber <= BasePlayer.RODS_NUMBER &&
                parsedNumber > 0;

            if (!isValid)
            {
                WriteLine("Invalid operation");
            }
            return isValid;
        }
    }
}
