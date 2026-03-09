using FirstConsoleApp.TowerOfHanoi.Helpers;
using Msg = FirstConsoleApp.TowerOfHanoi.Helpers.InteractionMsgWithUser;
using static System.Console;

namespace FirstConsoleApp.TowerOfHanoi.Players

{
    public class Human : BasePlayer
    {

        public Human(string name) : base()
        {
            Name = name;
            PlayersList.Add(this);
        }

        protected override void PlayOneRound(int numberOfDisks, int fromRod, int toRod, int otherRod)
        {
            for (int i = NumberOfDisks; i > 0; i--)
            {
                rodFromStack.Push(i);
                clonedRodFromStack.Push(i);
            }

            Msg.ShowMsgAboutCurentRodsState(this);

            do
            {
                var (inputFromRod, inputToRod) = Msg.ReceiveMoveActionFromUser();
                MoveDiskFromTo(inputFromRod, inputToRod);
            } while (!rodToStack.SequenceEqual(clonedRodFromStack) && !rodOtherStack.SequenceEqual(clonedRodFromStack));
        }

        private void MoveDiskFromTo(int fromRod, int toRod)
        {
            int disk = 0;
            var isStackFromEmpty = NumberOfRodAndStack[fromRod].Count == 0;
            var isStackToEmpty = NumberOfRodAndStack[toRod].Count == 0;

            if (!isStackFromEmpty &&
                (isStackToEmpty || NumberOfRodAndStack[toRod].Peek() > NumberOfRodAndStack[fromRod].Peek()))
            {
                disk = NumberOfRodAndStack[fromRod].Pop();
                NumberOfRodAndStack[toRod].Push(disk);

                NumberOfAttempts++;

                Msg.ShowMsgAboutCurentRodsState(this);
            }
            else
            {
                Write("Invalid operation.");
            }
        }
    }
}
