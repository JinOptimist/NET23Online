//Console.WriteLine("Hi I'm Pasha I write a book");
//Console.WriteLine("Hi I'm Alena");
//Console.WriteLine(("Hi I am Nikolai. Hello!"));
//Console.WriteLine("I want to work programmist!:");
//Console.WriteLine("Hi, I'm Dmitry. I like Videogames but suck at programming!");
//Console.WriteLine("Hello, my name is Ilya");
//Console.WriteLine("Hi I'm Stas - C++ Developer");
//Console.WriteLine("Hi I'm Valentin");
//Console.WriteLine("Hi I'm Osama");
//Console.WriteLine("I love to Learn");
//Console.WriteLine("Hello, I'm Alexander. My hobby is a waste of time");
//Console.WriteLine("Hi I'm Denis");
//Console.WriteLine("Hello, my name's Nikita. I like reading books.");
//Console.WriteLine("Hello, my name is Ira, i love my cats");
//Console.WriteLine("Hi I'm Sonya");
//Console.WriteLine("I love dancing");
//Console.WriteLine("I am trying again");
//Console.WriteLine("Igor, I like to drive a car.");
///////////////////////////////////////////////////////////

GuessTheNumberFromNikita(); // You can change it
GuessTheNumberFromAlexZ();
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
static void GuessTheNumberFromAlexZ()
{
    var random = new Random();
    int minNumber, maxNumber, numberOfAttrempts, chosenNumber, enteredNumber;
    var currentAttempt = 0;
    Console.WriteLine("HELLO. THE GAME BEGINS\nYou must enter the minimum and maximum boundaries in which I will guess the number.(MINimum must be LESS than the MAXimum and they must NOT BE EQUAL.)");
    for (; ; )
    {
        minNumber = GetNumberFromConsole("Enter MIN number");
        maxNumber = GetNumberFromConsole("Enter MAX number");

        if (minNumber >= maxNumber)
        {
            Console.WriteLine("NO NO NO! The MINimum must be LESS than the MAXimum and they must NOT BE EQUAL. Try again");
        }
        else
        {
            do
            {
                numberOfAttrempts = GetNumberFromConsole("Enter how many rounds there will be.");
                if (numberOfAttrempts < currentAttempt)
                {
                    Console.WriteLine("NO NO NO! The total number of rounds must be greater than 0");
                }
            } while (numberOfAttrempts < currentAttempt);

            break;
        }
    }
    Console.Clear();
    chosenNumber = random.Next(minNumber, maxNumber);
    Console.WriteLine($"Okay. You have {numberOfAttrempts} attempts. Good luck.");
    do
    {
        currentAttempt++;
        Console.WriteLine($"-------------------\nRound №{currentAttempt}|{numberOfAttrempts} (From {minNumber} to {maxNumber})");
        enteredNumber = GetNumberFromConsole("Enter number");
        if (minNumber > enteredNumber || maxNumber < enteredNumber)
        {
            Console.WriteLine($"We play in the range from {minNumber} to {maxNumber}.");
        }
        else if (enteredNumber > chosenNumber)
        {
            Console.WriteLine($"The mystical number is less than {enteredNumber}");
        }
        else if (enteredNumber < chosenNumber)
        {
            Console.WriteLine($"The mystical number is greater than {enteredNumber}");
        }
        else if (chosenNumber == enteredNumber)
        {
            Console.Clear();
            Console.WriteLine($"GREAT!! YOU WIN. It took you {currentAttempt} rounds to do this. Good job!:)");
            break;
        }
        if (numberOfAttrempts == currentAttempt)
        {
            Console.Clear();
            Console.WriteLine($"Sorry, but you lose.Mystical number is {chosenNumber}.:(");
        }

    } while (numberOfAttrempts > currentAttempt);
}

enum MenuChoice
{
    OwnRange = 1,
    RandomRange = 2,
    Exit = 3
}

