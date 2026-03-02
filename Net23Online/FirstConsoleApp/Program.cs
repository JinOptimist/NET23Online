GuessTheNumberFromSonyaFed(); // You can change it

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

static void GuessTheNumberFromSonyaFed()
{
    int minValue;
    int maxValue;
    do
    {
        minValue = GetNumberFromConsole("Enter a min value");
        maxValue = GetNumberFromConsole("Enter a max value");

        if (minValue > maxValue)
        {
            Console.WriteLine("Your min value is bigger then max value. It's incorrect. Try again");
        }
        if (minValue == maxValue)
        {
            Console.WriteLine("Your min value is equal with max value. It's incorrect. Try again");
        }
    } while(minValue >= maxValue);
    
    var random = new Random();
    var theNumber = random.Next(minValue, maxValue);

    var attempt = 0;
    var isGuessAreRight = false;
    do
    {
        Console.WriteLine($"You have {10-attempt} guesses left");
        attempt++;
        Console.WriteLine($"The rage of the number is from {minValue} to {maxValue}");
        var guess = GetNumberFromConsole("Enter your guess");

        if (guess < theNumber)
        {
            Console.WriteLine("My number is bigger");
            minValue = guess;
        }
        if (guess > theNumber)
        {
            Console.WriteLine("My number is less");
            maxValue = guess;
        }

        isGuessAreRight = guess == theNumber;
    } while (!isGuessAreRight && attempt < 10); // isGuessAreRight == false

    if (isGuessAreRight)
    {
        Console.WriteLine("You win");
    }
    else
    {
        Console.WriteLine("You lose");
    }
    Console.WriteLine("The end");
}

