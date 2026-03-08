using FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato;
using FirstConsoleApp.GuessTheNumberStuff;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

var botPlayer = new BotPlayer();
var botGame = new BullsAndCowsGame(botPlayer);
botGame.Play();