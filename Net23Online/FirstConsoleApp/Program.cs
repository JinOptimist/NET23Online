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
var miner = new HardMode();
miner.PlayMinesweeper();
using FirstConsoleApp.Sokoban;

var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

var sokoban = new SokobanHumanVSBot();
sokoban.Play();
