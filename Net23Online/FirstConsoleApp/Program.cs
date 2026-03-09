using FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato;
using FirstConsoleApp.GuessTheNumberStuff;
using FirstConsoleApp.Minesweeper;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

var botPlayer = new BotPlayer();
var botGame = new BullsAndCowsGame(botPlayer);
botGame.Play();
=======
using FirstConsoleApp.GuessTheNumberStuff;
using FirstConsoleApp.Minesweeper;
using FirstConsoleApp.TicTacToeHumanVsBot;
using FirstConsoleApp.Sokoban;
//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();
//using FirstConsoleApp.GuessTheNumberStuff;

var miner = new HardMode();
miner.PlayMinesweeper();


var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

var sokoban = new SokobanHumanVSBot();
sokoban.Play();
//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();




while (true)
{
    var game = new GameManagement();
    game.Greeting();
    game.Start();
    if (!game.IsReadyToPlayAgain())
    {
        break;
    }
}
>>>>>>> main
