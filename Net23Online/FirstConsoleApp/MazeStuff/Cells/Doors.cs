
using FirstConsoleApp.MazeStuff.Characters;
using System.Reflection.Metadata.Ecma335;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Doors : BaseCell
    {
        private bool _isOpen;
        public string DoorType { get; set; }
        private const int _COIN_COST = 1;
        public Doors(Maze maze) : base(maze)
        {
            _isOpen = false;
            DoorType = "Unknown";
        }

        public override char Symbol => _isOpen ? '.' : 'D';
        public override bool Interaction(BaseCharacter character)
        {
            const int MINCHOISES = 1;
            const int MAXCHOISES = 3;
            var cancle = MAXCHOISES;
            if (_isOpen)
            {
                return true;
            }
            Console.WriteLine($"\n {DoorType} Door is locked!");
            Console.WriteLine("Choose how to open it:");
            Console.WriteLine("1. Use Key");
            Console.WriteLine($"2. Pay {_COIN_COST} coins");
            Console.WriteLine("3. Cancle");

            while (true)
            {
                var choice = ReadMenuChoice(MINCHOISES, MAXCHOISES);
                if (choice == cancle)
                { 
                    return false;
                }
                var howToOPenDoor = choice switch
                {
                    1 => TryOpenWithKey(character, _COIN_COST),
                    2 => TryOpenWithCoins(character, _COIN_COST),
                    _ => false
                };
                if (!howToOPenDoor)
                {
                    continue;
                }
                return howToOPenDoor;
            }

        }
        private bool TryOpenWithKey(BaseCharacter character, int cost)
        {
            if (!character.HasKey())
            {
                Console.WriteLine(" You don't have a key!");
                return false;
            }

            character.UseKey(cost);
            Open();
            Console.WriteLine(" Door unlocked with key!");
            return true;
        }

        private bool TryOpenWithCoins(BaseCharacter character, int cost)
        {
            if (character.Coins < cost)
            {
                Console.WriteLine($" Not enough coins! Need {cost}, you have {character.Coins}");
                return false;
            }

            character.SpendCoins(cost);
            Open();
            Console.WriteLine($" Paid {cost} coins. Door is now open.");
            return true;
        }

        private static int ReadMenuChoice(int min, int max)
        {
            while (true)
            {
                Console.Write($"Your choice ({min}-{max}): ");
                if (int.TryParse(Console.ReadLine(), out var choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("Invalid choice. Try again.");
            }

        }
        private void Open()
        {
            _isOpen = true;
        }
    }
}