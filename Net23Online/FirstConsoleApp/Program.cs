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
