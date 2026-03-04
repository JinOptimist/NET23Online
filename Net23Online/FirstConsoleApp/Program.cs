//GuessTheNumberFromLvou(); // You can change it
GuessTheNumberFromStas();
﻿GuessNumberFromOsama(); // You can change it

//GuessTheNumberFromNikita(); // You can change it
//GuessTheNumberFromAlexZ();
static void GuessNumberFromOsama()
{

    PrintGreeting();
    while (true)
    {
        PlayRound();
        if (!AskRestart()) break;
    }
}
static void PrintGreeting()
{
    Console.WriteLine("=== Guess the Number ===");
}
static bool PlayRound()
{
    int minRange;
    int maxRange;
    do
    {
        Console.WriteLine("Enter min range:");
        minRange = ReadNumberFromUser();
        Console.WriteLine("Enter max range:");
        maxRange = ReadNumberFromUser();
    } while (!GetRange(minRange, maxRange));

    return IsNumberGuessed(minRange, maxRange);
}


static int ReadNumberFromUser()
{


    string resultStr;
    bool isNumber;
    int resultNumber;
    do
    {
        resultStr = Console.ReadLine();
        isNumber = int.TryParse(resultStr, out resultNumber);
        if (!isNumber)
        {
            Console.WriteLine("Invalid number. Try again:");
        }
    } while (!isNumber);

    return resultNumber;
}

static bool GetRange(int min, int max)
{
    while (min >= max)
    {

        Console.WriteLine("Error: Min must be less than Max. Try again!.");
        return false;
    }
    return true;
}

static bool IsNumberGuessed(int min, int max)
{
    int target = RandomNumber(min, max);
    int MaxAttempts = 10;

    for (int i = 1; i <= MaxAttempts; i++)
    {
        Console.WriteLine($"Attempt {i}/{MaxAttempts}. Guess:");
        int guess = ReadNumberFromUser();

        if (guess == target) { Console.WriteLine("You WIN!"); return true; }
        Console.WriteLine(guess < target ? "Too low!" : "Too high!");
    }
    Console.WriteLine($"Game Over. Number was {target}.");

    return false;
}
static int RandomNumber(int min, int max)
{
    var random = new Random();
    int target = random.Next(min, max + 1);
    return target;
}
static bool AskRestart()
{
    Console.WriteLine("Play again? (y/n)");
    return Console.ReadLine() == "y";
}


//GuessTheNumberFromLvou(); // You can change it
GuessTheNumberFromSleepaidy();
static int GetNumberFromConsole(string messageForUser)
{
    var isThisANumberForMax = false;
    var number = 0;
    do
    {
        Console.WriteLine(messageForUser);
        var guessStr = Console.ReadLine();

        isThisANumberForMax = int.TryParse(guessStr, out number);
        if (!isThisANumberForMax)
        {
            Console.WriteLine("It's not a number. Please enter just a number");
        }

    } while (!isThisANumberForMax);

    return number;
}

static void GuessTheNumberFromLvou()
{
    var random = new Random();
    var theNumber = random.Next(1, 10); // [1, 10]

    var minValue = GetNumberFromConsole("Enter a min value");

    var maxValue = GetNumberFromConsole("Enter a max value");

    var attempt = 0;
    var isGuessAreRight = false;
    do
    {
        attempt++;
        var guess = GetNumberFromConsole("Enter your guess");

        if (guess < theNumber)
        {
            Console.WriteLine("My number is bigger");
        }
        if (guess > theNumber)
        {
            Console.WriteLine("My number is less");
        }
        if (guess == theNumber)
        {
            Console.WriteLine("You are win");
        }

        isGuessAreRight = guess == theNumber;
    } while (!isGuessAreRight); // isGuessAreRight == false

    Console.WriteLine("The end");

}

static void GuessTheNumberFromSleepaidy()
static int GetNumberFromConsoleWithCheck(string messageForUser)
{
    var isThisANumber = false;
    var number = 0;
    do
    {
        Console.WriteLine(messageForUser);
        var guessStr = Console.ReadLine();

        isThisANumber = int.TryParse(guessStr, out number);
        if (!isThisANumber || number < 0)
        {
            Console.WriteLine("It's not a number or number is under 0. Please enter just a number");
        }

    } while (!isThisANumber || number < 0);

    return number;
}

static void GuessTheNumberFromStas()
{
    Console.WriteLine("Let's play the game Guess the number");
    var minValue = GetNumberFromConsoleWithCheck("Enter a min value");
    int maxValue;
    do
    {
        maxValue = GetNumberFromConsoleWithCheck("Enter a max value");
        if (maxValue <= minValue)
        {
            Console.WriteLine($"max value should be bigger than min value, try again");
        }
    } while (maxValue <= minValue);

    Console.WriteLine($"I guessed a number from {minValue} to {maxValue}");
    Console.WriteLine("The rules are simple: you have 10 tries\nIf the difference is from 50 to infinity, I'll say \"Cold\"\nIf the difference is from 10 to 50, I'll say \"Warm\"\nIf it's less than 10, I'll say \"Hot.\"");
    var random = new Random();
    var theNumber = random.Next(minValue, maxValue); 

    var attempt = 0;
    var isGuessAreRight = false;
    do
    {
        attempt++;
        var guess = GetNumberFromConsoleWithCheck($"Enter {attempt}th your guess");

        if (Math.Abs(guess- theNumber) > 50)
        {
            Console.WriteLine("\"Cold\"");
        }
        else if (Math.Abs(guess - theNumber) > 10)
        {
            Console.WriteLine("\"Warm\"");
        }
        if (Math.Abs(guess - theNumber) <= 10)
        {
            Console.WriteLine("\"Hot.\"");
        }
        if (Math.Abs(guess - theNumber) == 0)
        {
            Console.WriteLine("You are win");
        }

        isGuessAreRight = guess == theNumber;
        if(attempt == 10)
        {
            Console.WriteLine("You lose");
        }
    } while (!isGuessAreRight && attempt < 10); // isGuessAreRight == false

    Console.WriteLine("The end");

static void GuessTheNumberFromNikita()
{
    Console.WriteLine("Welcome to the game from sleepaidy!");
    int lowerLimit;
    int higherLimit;
    var guestIsCorrect = false;
    do
    {
        lowerLimit = GetNumberFromConsole("Enter the minimum number for your batch:");
        higherLimit = GetNumberFromConsole("Enter the maximum number for your batch:");
        if (lowerLimit < higherLimit)
        {
            guestIsCorrect = true;
            Console.WriteLine("The input is correct.");
            Console.WriteLine($"The game has begun. You have 10 attempts to guess the number between {lowerLimit} and {higherLimit}.");
        }
        else
        {
            Console.WriteLine("The input is incorrect.Try again.");
        }
    } while (guestIsCorrect == false);
    var randomNumber = new Random();
    var specifiedNumber = randomNumber.Next(lowerLimit, higherLimit);
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{i+1} attempt:");
        var guessTheNumber = GetNumberFromConsole("Guess the number:");
        if(guessTheNumber > higherLimit || guessTheNumber < lowerLimit)
        {
            Console.WriteLine("Your number is out of range. Try again.");
        }
        else if (guessTheNumber > specifiedNumber)
        {
            Console.WriteLine("Nice try, but my number is lower.");
        }
        else if (guessTheNumber < specifiedNumber)
        {
            Console.WriteLine("Nice try, but my number is higher.");
        }
        else
        {
            Console.WriteLine("You entered the correct number. You win!");
            Environment.Exit(0);
        }
    }
    Console.WriteLine($"You lose. The specified number was {specifiedNumber}.");
}