GuessTheNumberFromIgor(); // You can change it

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
static void GuessTheNumberFromIgor()
{
    var minValue = GetNegativeNumbersFromConso("Enter a min value");
    int maxValue;
    do
    {
        maxValue = GetNegativeNumbersFromConso("Enter a max value");
        if (minValue >= maxValue)
        {
            Console.WriteLine("the maximum number is selected incorrectly");
        }
    } while (minValue >= maxValue);
    var numberOfAttempts = GetNegativeNumbersFromConso("Indicate the number of attempts");

    var random = new Random();
    var theNumber = random.Next(minValue, maxValue);

    var attempt = 0;
    var isGuessAreRight = false;
    do
    {
        attempt++;
        Console.WriteLine($"{attempt}/{numberOfAttempts} attempts remaining");
        var guess = GetNegativeNumbersFromConso("Enter your guess");

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
        if (attempt == numberOfAttempts)
        {
            Console.WriteLine("You lose");
        }
        isGuessAreRight = guess == theNumber;
    } while (!isGuessAreRight && attempt < numberOfAttempts);

    Console.WriteLine("The end");
}

static int GetNegativeNumbersFromConso(string messageForUser)
{
    var isThisANumberForMax = false;
    var number = 0;
    do
    {
        Console.WriteLine(messageForUser);
        var guessStr = Console.ReadLine();

        isThisANumberForMax = int.TryParse(guessStr, out number);
        if (!isThisANumberForMax || number < 0)
        {
            Console.WriteLine("It's not a number or negative numbers. Please enter just a number.");
        }

    } while (!isThisANumberForMax || number < 0);

    return number;
}
