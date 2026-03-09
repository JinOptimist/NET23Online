using FirstConsoleApp.GuessTheNumberStuff;

var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();


Console.WriteLine("What is your name?");
var userName = Console.ReadLine();

Console.WriteLine("When you was born?");
string yearOfBirthdayStr = Console.ReadLine();
var yearOfBirthday = int.Parse(yearOfBirthdayStr);

var currentYear = DateTime.Now.Year;
var age = currentYear - yearOfBirthday;


Console.WriteLine("Do you have a pet?");
string userPetAnswer = Console.ReadLine();



if (age < 3)
{
    Console.WriteLine("You are Lier");
}
else if (userPetAnswer == "yes")
{
    Console.WriteLine("What pet do you have?");
    string userPet = Console.ReadLine();
    Console.WriteLine($"Hi {userName}, cool you are {age} is old. You have a {userPet}");
}
else
{
    Console.WriteLine($"Hi {userName}, cool you are {age} is old. You don't have a pet");
}



    




