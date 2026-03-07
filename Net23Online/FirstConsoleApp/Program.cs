using FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato;
using FirstConsoleApp.GuessTheNumberStuff;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

//Test of the method for generating numbers with unique digits
var uniqueNumbers = new List<string>();
var bot = new Bot();
bot.GenerateUniqueDigitNumbers(uniqueNumbers);
uniqueNumbers.ForEach(Console.WriteLine);
