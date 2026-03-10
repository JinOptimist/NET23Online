using FirstConsoleApp.BullsAndCowsGame;

var settingsFactory = new GameSettingsFactory();
var settings = settingsFactory.ChooseGameSettings();
var randomNumberGenerator = new RandomNumberGenerator();
var game = new BullsAndCowsGameHumanVsBot(settings, randomNumberGenerator);
game.Play();