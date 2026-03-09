using Validator = FirstConsoleApp.TowerOfHanoi.Helpers.InputFromUserValidator;
using static System.Console;

namespace FirstConsoleApp.TowerOfHanoi.Players
{
    public abstract class BasePlayer
    {
        public const int RODS_NUMBER = 3;
        public static int NumberOfDisks { get; set; }
        public static List<BasePlayer> PlayersList { get; set; } = new();
        public string Name { get; set; }
        public int NumberOfAttempts { get; set; }
        public int FromRodNumber { get; } = 1;
        public int ToRodNumber { get; } = 3;
        public int OtherRodNumber { get; } = 2;
        public Dictionary<int, Stack<int>> NumberOfRodAndStack { get; set; }

        protected Stack<int> rodFromStack = new(NumberOfDisks);
        protected Stack<int> rodOtherStack = new(NumberOfDisks);
        protected Stack<int> rodToStack = new(NumberOfDisks);
        protected Stack<int> clonedRodFromStack = new(NumberOfDisks);

        static BasePlayer()
        {
            ConfigurateGame();
        }

        public BasePlayer()
        {
            NumberOfRodAndStack = new Dictionary<int, Stack<int>>() {
                {FromRodNumber, rodFromStack},
                {OtherRodNumber, rodOtherStack},
                {ToRodNumber, rodToStack}
            };
        }

        public void Play()
        {
            ShowGreetingMsgToUser();

            PlayOneRound(NumberOfDisks, FromRodNumber, ToRodNumber, OtherRodNumber);

            ShowGameResultToUser();
        }

        private static void ConfigurateGame()
        {
            var inputFromUserNumberOfDisks = "";

            while (!Validator.IsNimberOfDisksValid(inputFromUserNumberOfDisks))
            {
                Write("Enter number of disks > 0: ");
                inputFromUserNumberOfDisks = ReadLine();
                _ = int.TryParse(inputFromUserNumberOfDisks, out int numberOfDisks);
                NumberOfDisks = numberOfDisks;
            }
        }

        protected void ShowGreetingMsgToUser()
            => WriteLine($"Hi {Name}. Let's start the game.");

        protected void ShowGameResultToUser()
            => WriteLine($"\n{ToString()}\n");

        public override string ToString()
            => $"Player: {Name}, Number of Attempts: {NumberOfAttempts}";

        public static List<BasePlayer> ShowSortedListOfPlayersInAscOrderOfAttemts()
            => PlayersList.OrderBy(player => player.NumberOfAttempts).ToList();

        protected abstract void PlayOneRound(int numberOfDisks, int fromRod, int toRod, int otherRod);
    }
}
