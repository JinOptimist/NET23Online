
namespace FirstConsoleApp.TicTacToeHumanVsBot
{
    public class TicTacToeBoard
    {
        public string Cell1 { get; set; } = "1";
        public string Cell2 { get; set; } = "2";
        public string Cell3 { get; set; } = "3";
        public string Cell4 { get; set; } = "4";
        public string Cell5 { get; set; } = "5";
        public string Cell6 { get; set; } = "6";
        public string Cell7 { get; set; } = "7";
        public string Cell8 { get; set; } = "8";
        public string Cell9 { get; set; } = "9";

        public int MoveCount { get; set; } = 0;

        public void Draw()
        {
            Console.WriteLine($" {Cell1} | {Cell2} | {Cell3} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Cell4} | {Cell5} | {Cell6} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Cell7} | {Cell8} | {Cell9} ");
        }
        public void TryMakeMove(int position, string playerMark)
        {

            playerMark = playerMark.ToLower();
            if (position == 1 && Cell1 == "1")
            {
                Cell1 = playerMark;
            }
            else if (position == 2 && Cell2 == "2")
            {
                Cell2 = playerMark;
            }
            else if (position == 3 && Cell3 == "3")
            {
                Cell3 = playerMark;
            }
            else if (position == 4 && Cell4 == "4")
            {
                Cell4 = playerMark;
            }
            else if (position == 5 && Cell5 == "5")
            {
                Cell5 = playerMark;
            }
            else if (position == 6 && Cell6 == "6")
            {
                Cell6 = playerMark;
            }
            else if (position == 7 && Cell7 == "7")
            {
                Cell7 = playerMark;
            }
            else if (position == 8 && Cell8 == "8")
            {
                Cell8 = playerMark;
            }
            else if (position == 9 && Cell9 == "9")
            {
                Cell9 = playerMark;
            }

            MoveCount++;
        }
        public bool IsGameOver (string playerMark)
        {
            playerMark = playerMark.ToLower();
            
            if (Cell1 == playerMark && Cell2 == playerMark && Cell3 == playerMark)
            {
                return true; 
            }
            if (Cell4 == playerMark && Cell5 == playerMark && Cell6 == playerMark)
            {
                return true;
            }
            if (Cell7 == playerMark && Cell8 == playerMark && Cell9 == playerMark)
            {
                return true;
            }
            if (Cell1 == playerMark && Cell4 == playerMark && Cell7 == playerMark)
            {
                return true;
            }
            if (Cell2 == playerMark && Cell5 == playerMark && Cell8 == playerMark)
            {
                return true;
            }
            if (Cell3 == playerMark && Cell6 == playerMark && Cell9 == playerMark)
            { 
                return true;
            }
            if (Cell1 == playerMark && Cell5 ==playerMark && Cell9 == playerMark)
            {
                return true;
            }
            if (Cell3 == playerMark && Cell5 == playerMark && Cell7 == playerMark)
            {
                return true;
            }
            return false;
        }

    }

}
