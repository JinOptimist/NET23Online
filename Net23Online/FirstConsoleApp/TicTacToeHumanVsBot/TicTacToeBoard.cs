
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


        public void Draw()
        {
            Console.WriteLine($" {Cell1} | {Cell2} | {Cell3} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Cell4} | {Cell5} | {Cell6} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {Cell7} | {Cell8} | {Cell9} ");
        }
        public bool TryMakeMove(int position, string playerMark)
        {
            if (position == 1 && Cell1 == "1")
            {
                Cell1 = playerMark;
                return true;
            }
            if (position == 2 && Cell2 == "2")
            {
                Cell2 = playerMark;
                return true;
            }
            if (position == 3 && Cell3 == "3")
            {
                Cell3 = playerMark;
                return true;
            }
            if (position == 4 && Cell4 == "4")
            {
                Cell4 = playerMark;
                return true;
            }
            if (position == 5 && Cell5 == "5")
            {
                Cell5 = playerMark;
                return true;
            }
            if (position == 6 && Cell6 == "6")
            {
                Cell6 = playerMark;
                return true;
            }
            if (position == 7 && Cell7 == "7")
            {
                Cell7 = playerMark;
                return true;
            }
            if (position == 8 && Cell8 == "8")
            {
                Cell8 = playerMark;
                return true;
            }
            if (position == 9 && Cell9 == "9")
            {
                Cell9 = playerMark;
                return true;
            }
            return false;
        }
        public bool IsGameOver (string mark)
        {
            if (Cell1 == mark && Cell2 == mark && Cell3 == mark)
            {
                return true; 
            }
            if (Cell4 == mark && Cell5 == mark && Cell6 == mark)
            {
                return true;
            }
            if (Cell7 == mark && Cell8 == mark && Cell9 == mark)
            {
                return true;
            }
            if (Cell1 == mark && Cell4 == mark && Cell7 == mark)
            {
                return true;
            }
            if (Cell2 == mark && Cell5 == mark && Cell8 == mark)
            {
                return true;
            }
            if (Cell3 == mark && Cell6 == mark && Cell9 == mark)
            { 
                return true;
            }
            if (Cell1 == mark && Cell5 ==mark && Cell9 == mark)
            {
                return true;
            }
            if (Cell3 == mark && Cell5 == mark && Cell7 == mark)
            {
                return true;
            }
            return false;
        }

    }

}
