//GuessTheNumberFromLvou(); // You can change it
GuessTheNumberFromStas();

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
}