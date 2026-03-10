using FirstConsoleApp.GuessTheNumberStuff;

var botGame = new GuessTheNumberGameHumanVsBot();
botGame.Play();


//HOMEWORK 2

GuessTheNumberFromLvou();


static bool CheckMaxMin(int minValue, int maxValue)
{
    if (maxValue < minValue)
    {
        Console.WriteLine("Error: max value less than min value");
        return false;
    }
    else if ((maxValue - minValue) < 1)
    {
        Console.WriteLine("Error: (maxValue - minValue) < 1 ");
        return false;
    }

    return true;
}


static int GetNumberFromConsole(string messadgeForUser)
{
    var isThisANumber = false;
    var number = 0;
    do
    {
        Console.WriteLine(messadgeForUser);
        var guessStr = Console.ReadLine();
        isThisANumber = int.TryParse(guessStr, out number);
        if (!isThisANumber)
        {
            Console.WriteLine("It's not a number! Please, enter just a number");
        }
    } while (!isThisANumber);

    return number;
}


static void GuessTheNumberFromLvou()
{
    var minValue = 0;
    var maxValue = 0;
    var checkMaxMin = false;

    do
    {
        minValue = GetNumberFromConsole("Enter a min value");

        maxValue = GetNumberFromConsole("Enter a max value");

        checkMaxMin = CheckMaxMin(minValue, maxValue);
    } while (!checkMaxMin);

    Console.WriteLine($"You have chosen a number between {minValue} and {maxValue}.");

    Random random = new Random();
    int theNumber = random.Next(minValue, maxValue);

    var isGuessAreRight = false;

    var numberOfAttempts = 10;
    for (int i = 0; i < numberOfAttempts; i++)
    {
        Console.WriteLine($"This is attempt number {i + 1}");

        var guess = GetNumberFromConsole("Enter your guess");

        if (guess < theNumber)
        {
            Console.WriteLine("My number is bigger");
        }
        else if (guess > theNumber)
        {
            Console.WriteLine("My number is less");
        }
        else if (guess == theNumber)
        {
            Console.WriteLine("You are win !!! :)");
            isGuessAreRight = true;
            break;
        }
    }

    if (!isGuessAreRight)
    {
        Console.WriteLine("You lost :(");
    }
}


