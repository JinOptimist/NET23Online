using static System.Console;

namespace FirstConsoleApp.TowerOfHanoi.Players
{
    public class MasterBot : BasePlayer
    {
        public MasterBot() : base()
        {
            {
                Name = "Bot";
                PlayersList.Add(this);
            }
        }
        protected override void PlayOneRound(int numberOfDisks, int fromRod, int toRod, int otherRod)
        {
            if (numberOfDisks > 0)
            {
                NumberOfAttempts++;

                PlayOneRound(numberOfDisks - 1, fromRod, otherRod, toRod);
                WriteLine($"Move disk {numberOfDisks} from tower {fromRod} to tower {toRod}");
                PlayOneRound(numberOfDisks - 1, otherRod, toRod, fromRod);
            }
        }
    }
}

