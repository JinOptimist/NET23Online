GuessNumberFromOsama(); // You can change it

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
    
    
    string resultStr ;
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