using FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato;
using FirstConsoleApp.GuessTheNumberStuff;
using FirstConsoleApp.Minesweeper;
using FirstConsoleApp.Sokoban;
using FirstConsoleApp.TicTacToeHumanVsBot;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

var botPlayer = new FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato.BotPlayer();
var botGame = new BullsAndCowsGame(botPlayer);
botGame.Play();
//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();
//using FirstConsoleApp.GuessTheNumberStuff;

var miner = new HardMode();
miner.PlayMinesweeper();


var botGameGuess = new GuessTheNumberGameHumanVsBot();
botGameGuess.Play();

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
