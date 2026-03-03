// GuessTheNumberFromLvou(); // You can change it
GuessTheNumberFromDimskiy();

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

static void GuessTheNumberFromDimskiy()
{
    int minNumber;
    int maxNumber;
    var isGuessCorrect = false;
    var isMaxBiggerThanMin = false;

    Console.WriteLine("Welcome! Let's play a Guessing game! Please, choose a range to play within!");

    do
    {
        minNumber = GetNumberFromConsole("Enter the minimum number: ");
        maxNumber = GetNumberFromConsole("Enter the maximum number: ");
        if (minNumber < maxNumber)
        {
            isMaxBiggerThanMin = true;
        }
        if (minNumber > maxNumber || maxNumber < minNumber || minNumber == maxNumber)
        {
            Console.WriteLine("Seems like you made a mistake. Try again!");
        }
    } while (!isMaxBiggerThanMin);

    var random = new Random();
    var numberToGuess = random.Next(minNumber, maxNumber);

    Console.WriteLine($"Thanks for your input! Now, guess a Number from {minNumber} to {maxNumber}! You've got 10 Attempts total! Good luck!");

    for (var attempt = 1; attempt <= 10 && !isGuessCorrect; attempt++)
    {
        var playersGuess = GetNumberFromConsole($"This is an attempt #{attempt}.");


        if (playersGuess < numberToGuess && attempt != 10)
        {
            Console.WriteLine("The number is BIGGER.");

        }

        if (playersGuess > numberToGuess && attempt != 10)
        {
            Console.WriteLine("The number is LESS.");
        }

        if (playersGuess == numberToGuess)
        {
            Console.WriteLine("You are CORRECT!. You Win!");
            isGuessCorrect = true;
        }
        
        if (attempt == 10 && playersGuess != numberToGuess)
        {
            Console.WriteLine("Sorry, you're out of attempts! You lose!");
        }
    }

    Console.WriteLine("Thanks for Playing!");
}
