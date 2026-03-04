using static System.Net.Mime.MediaTypeNames;
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
static void GuessTheNumberForLokit()
{
    int min, max;
    Console.WriteLine("Input range, For example: \'2,10'/");
    var range = Console.ReadLine();
    string[] split = range.Split(',');
    min = int.Parse(split[0]);
    max = int.Parse(split[1]);
    Console.Write("Input count attempt:");
    var count = Console.ReadLine();
    if (int.TryParse(count, out int number))
    {
        StartGame(number, min, max);
    }
    static void StartGame(int count, int min, int max)
    {
        var ran = new Random();
        var secretCount = ran.Next(min, max);
        int i = 0;
        while (count > i)
        {
            i++;
            Console.Write($"Input value {i}: ");
            var userCount = int.Parse(Console.ReadLine());
            if (userCount > secretCount)
            {
                Console.WriteLine("Your value the more for me!");
            }
            if (userCount < secretCount)
            {
                Console.WriteLine("Your value the less for me!");
            }
            if (userCount == secretCount)
            {
                Console.WriteLine("You are the champion!");
            }
            if (count == i)
            {
                Console.WriteLine($"Game over your count: {secretCount}");
            }
        }
    }



}