//GuessTheNumberFromLvou(); // You can change it

GuessTheNumberFromALexanderKartuz();
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

static void GuessTheNumberFromALexanderKartuz()
{
    var minValue = GetNumberFromConsole("Enter a min value.");
    var maxValue = 0;
    do
    {
        maxValue = GetNumberFromConsole("Enter a max value");
        if (maxValue <= minValue)
        {
            Console.WriteLine($"Error! Max value must be bigger then min value ({minValue}). Try enter max value again.");
        }

    } while (maxValue <= minValue);

    var random = new Random();
    var theNumber = random.Next(minValue, maxValue); // Random [minValue, maxValue]
        
    Console.WriteLine("Lets start a game.");
    Console.WriteLine($"Try to guess the number between {minValue} and {maxValue}.");

    var tries = 0;
    var maxTry = 10;
    var isGuessAreRight = false;

    do
    {
        tries++;
        Console.WriteLine($"Try {tries}/{maxTry}. You have {maxTry-tries+1} tries.");
        var guess = GetNumberFromConsole("Enter your guess.");

        if (guess < minValue || guess > maxValue)
        {
            Console.WriteLine($"The number is between {minValue} and {maxValue}! Try again.\n");
            continue;
        }
        if (guess < theNumber)
        {
            Console.WriteLine("My number is bigger.\n");
        }
        if (guess > theNumber)
        {
            Console.WriteLine("My number is less.\n");
        }
        if (guess == theNumber)
        {
            Console.WriteLine($"You are win. You used {tries} tries.\n");
        }

        isGuessAreRight = guess == theNumber;

    } while (!(isGuessAreRight || tries ==maxTry));
    if (!isGuessAreRight)
    {
        Console.WriteLine($"Game over!!! You have used all {maxTry} tries.\nThe number was: {theNumber}.");
        
    }
}

