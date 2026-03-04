GuessTheNumberFromLvou(); // You can change it

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

GuessANumber();

static void GuessANumber()
{
    Console.WriteLine("Hello. Now we play the game \"Guess a number\". Please enter lower limit of the range.");
    var minNumber = ReadNumber();
    Console.WriteLine("Now enter upper limit of the range.");
    int maxNumber;
    do
    {
        maxNumber = ReadNumber();
        if (maxNumber < minNumber)
        {
            Console.WriteLine("Upper limit of the range can`t be lower than lower limit of the range.");
        }
    } while (maxNumber < minNumber);
    var randomizer = new Random();
    var hidden = randomizer.Next(minNumber, maxNumber);
    var tries = 10;
    Console.WriteLine($"Now guess the number in {tries} tries.");
    for (var i = 0; i < tries; i++)
    {
        Console.WriteLine($"This is your {i + 1} try.");
        var number = ReadNumber();
        if (number < hidden)
        {
            Console.WriteLine("Sorry, but my number is bigger.");
        }
        else if (number > hidden)
        {
            Console.WriteLine("Sorry, but my number is lower.");
        }
        else
        {
            Console.WriteLine("You guessed it. Congratulations!");
            return;
        }
    }

    Console.WriteLine("You lost.");
}

static int ReadNumber()
{
    int value;
    var thisIsANumber = false;
    do
    {
        var valueString = Console.ReadLine();
        thisIsANumber = int.TryParse(valueString, out value);
        if (!thisIsANumber)
        {
            Console.WriteLine($"\"{valueString}\" is not a number. Please enter a number.");
        }
    }
    while (!thisIsANumber);
    return value;
}