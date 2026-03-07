using FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato;
using FirstConsoleApp.GuessTheNumberStuff;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

//Test of the method for generating numbers with unique digits
var uniqueNumbers = new List<string>();
var BullsAndCowsBotPlayerObject = new BullsAndCowsGameBotPlayer();
BullsAndCowsBotPlayerObject.GenerateUniqueDigitNumbers(uniqueNumbers);
uniqueNumbers.ForEach(Console.WriteLine);
