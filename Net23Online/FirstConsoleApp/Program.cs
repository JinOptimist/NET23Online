using FirstConsoleApp.BullsAndCowsGame;

var settings = GameSettings.ChooseDifficulty();
var randomNumberGenerator = new RandomNumberGenerator();
var game = new BullsAndCowsGameHumanVsBot(settings, randomNumberGenerator);
game.Play();