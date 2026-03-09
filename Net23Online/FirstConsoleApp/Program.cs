//using FirstConsoleApp.GuessTheNumberStuff;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();
using FirstConsoleApp.TicTacToeHumanVsBot;


var game = new GameManagement();
game.Greeting();

while (true)
{
    game.Start();
    if (!game.IsReadyToPlayAgain())
    {
        break;
    }
}
