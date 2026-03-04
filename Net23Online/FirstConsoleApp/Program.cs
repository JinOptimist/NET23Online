
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