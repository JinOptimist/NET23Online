//using FirstConsoleApp.GuessTheNumberStuff;
using FirstConsoleApp.TowerOfHanoi;
using FirstConsoleApp.TowerOfHanoi.Players;


//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();

// Реализация паттерна Шаблонный метод
MyApplication.PlayGame(new Human("Chuck Norris"));
MyApplication.PlayGame(new Human("Pink Panther"));
MyApplication.PlayGame(new Human("Jack Daniels"));
MyApplication.PlayGame(new MasterBot());

MyApplication.ShowStatistics();