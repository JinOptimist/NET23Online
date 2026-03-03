
GuessTheNumberFromNikita(); // You can change it

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


static void GuessTheNumberFromNikita()
{
    const int NUMBER_OF_MAX_ATTEMPTS = 10;
    const int MIN_RANGE_SIZE = 30;
    const int MAX_RANGE_SIZE = 500;
    const int MIN_START_VALUE = 1;
    const int MAX_START_VALUE = 1000;

    Console.WriteLine("Let's play the guess a number game!");
    int modeNumber;
    do
    {
        Console.WriteLine("Choose game mode:");
        Console.WriteLine($"{(int)MenuChoice.OwnRange} - Enter your own range");
        Console.WriteLine($"{(int)MenuChoice.RandomRange} - Use random range");
        Console.WriteLine($"{(int)MenuChoice.Exit} - Exit");
        Console.Write("Your choice: ");

        modeNumber = ReadNumberFromConsole();

        if (modeNumber < (int)MenuChoice.OwnRange || modeNumber > (int)MenuChoice.Exit)
        {
            Console.WriteLine($"You should enter a number between {(int)MenuChoice.OwnRange} and {(int)MenuChoice.Exit}");
        }

    } while (modeNumber < (int)MenuChoice.OwnRange || modeNumber > (int)MenuChoice.Exit);

    if (modeNumber == (int)MenuChoice.Exit)
    {
        Console.WriteLine("Goodbye");
        return;
    }

    int minValue = 0;
    int maxValue = 0;
    var random = new Random();

    if (modeNumber == (int)MenuChoice.OwnRange)
    {

        Console.Write("Enter the minimum value: ");
        minValue = ReadNumberFromConsole();

        do
        {
            Console.Write("Enter the maximum value: ");
            maxValue = ReadNumberFromConsole();

            if (maxValue <= minValue)
            {
                Console.WriteLine($"Maximum value must be greater than {minValue}");
            }
        } while (maxValue <= minValue);

    }
    else if (modeNumber == (int)MenuChoice.RandomRange)
    {
        int rangeSize = random.Next(MIN_RANGE_SIZE, MAX_RANGE_SIZE + 1);
        minValue = random.Next(MIN_START_VALUE, MAX_START_VALUE + 1);
        maxValue = minValue + rangeSize;
    }
    var numberToGuess = random.Next(minValue, maxValue);
    var attemptCounter = 0;

    int userNumber;

    Console.WriteLine($"The secret number is between {minValue} and {maxValue}");
    do
    {
        Console.WriteLine($"Enter your guess, it is your {attemptCounter + 1} attempt of {NUMBER_OF_MAX_ATTEMPTS}");
        userNumber = ReadNumberFromConsole();
        if (userNumber < minValue || userNumber > maxValue)
        {
            Console.WriteLine($"Please enter a number between {minValue} and {maxValue}");
            continue;
        }

        if (userNumber > numberToGuess)
        {
            Console.WriteLine("The secret number is smaller than your guess");
            attemptCounter++;
        }
        else if (userNumber < numberToGuess)
        {
            Console.WriteLine("The secret number is bigger than your guess");
            attemptCounter++;
        }
        else if (userNumber == numberToGuess)
        {
            Console.WriteLine("Congratulations! You've won :)");
            return;
        }
    } while (attemptCounter < NUMBER_OF_MAX_ATTEMPTS);

    Console.WriteLine($"Sorry, you've lost :( The secret number was {numberToGuess}");
}

static int ReadNumberFromConsole()
{
    int result;
    string input = Console.ReadLine();

    while (!int.TryParse(input, out result))
    {
        Console.WriteLine("Enter a valid number");
        input = Console.ReadLine();
    }

    return result;
}

enum MenuChoice
{
    OwnRange = 1,
    RandomRange = 2,
    Exit = 3
}