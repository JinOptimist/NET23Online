using FirstConsoleApp.TowerOfHanoi.Players;
using Validator = FirstConsoleApp.TowerOfHanoi.Helpers.InputFromUserValidator;
using static System.Console;

namespace FirstConsoleApp.TowerOfHanoi.Helpers
{
    public static class InteractionMsgWithUser
    {
        public static void ShowMsgAboutCurentRodsState(BasePlayer basePlayer)
        {
            Write($"{basePlayer.FromRodNumber}:");
            basePlayer.NumberOfRodAndStack[basePlayer.FromRodNumber].ToList().ForEach(elem => Write(elem));
            Write($" {basePlayer.OtherRodNumber}:");
            basePlayer.NumberOfRodAndStack[basePlayer.OtherRodNumber].ToList().ForEach(elem => Write(elem));
            Write($" {basePlayer.ToRodNumber}:");
            basePlayer.NumberOfRodAndStack[basePlayer.ToRodNumber].ToList().ForEach(elem => Write(elem));
            WriteLine();
        }

        public static (int, int) ReceiveMoveActionFromUser()
        {
            string inputFromRod;
            string inputToRod;
            do
            {
                WriteLine();
                Write("Enter from rod > ");
                inputFromRod = ReadLine();
                Write("Enter to rod > ");
                inputToRod = ReadLine();
            } while (!Validator.IsActionWithRodsValid(inputFromRod) || !Validator.IsActionWithRodsValid(inputToRod));

            return (int.Parse(inputFromRod), int.Parse(inputToRod));
        }
    }
}
