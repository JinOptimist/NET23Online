//using FirstConsoleApp.GuessTheNumberStuff;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();
using FirstConsoleApp.TicTacToeHumanVsBot;

var botGame = new TicTacToeBoard();
botGame.Draw();
var move1 = botGame.TryMakeMove(1, "O");
botGame.Draw();
var move2 = botGame.TryMakeMove(2, "x");
botGame.Draw();
var move3 = botGame.TryMakeMove(3, "O");
botGame.Draw();
var move4 = botGame.TryMakeMove(4, "x");
botGame.Draw();
var move5 = botGame.TryMakeMove(5, "O");
botGame.Draw();
var move6 = botGame.TryMakeMove(6, "x");
botGame.Draw();
var move7 = botGame.TryMakeMove(7, "O");
botGame.Draw();
var move8 = botGame.TryMakeMove(8, "x");
botGame.Draw();
var move9 = botGame.TryMakeMove(9, "o");
botGame.Draw();
if (botGame.IsGameOver("O") || botGame.IsGameOver("x"))
    {
    Console.WriteLine("player won");
}
