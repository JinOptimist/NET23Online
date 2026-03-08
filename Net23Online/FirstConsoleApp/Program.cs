//using FirstConsoleApp.GuessTheNumberStuff;

//var botGame = new GuessTheNumberGameHumanVsBot();
//botGame.Play();
Console.Write("Insert size of game field: ");
int numberOfRowsInGameField = int.Parse(Console.ReadLine());
int numberOfColomnsInGameField = numberOfRowsInGameField;
int attempt = 0;

int[,] firstPlayerGameField = new int[numberOfRowsInGameField, numberOfColomnsInGameField];
int[,] secondPlayerGameField = new int[numberOfRowsInGameField, numberOfColomnsInGameField];
int[,] currentMatrix = firstPlayerGameField;
static void PrintMatrix (int[,] currentMatrix)
{
    for (int i = 0; i < currentMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < currentMatrix.GetLength(1); j++)
        {
            Console.Write(currentMatrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

Console.Write("First Player: choose row for Battleship#1: ");
int firstPlayerShipOneRow = int.Parse(Console.ReadLine()) - 1;
Console.Write("First Player: choose colomn for Battleship#1: ");
int firstPlayerShipOneColomn = int.Parse(Console.ReadLine()) - 1;
currentMatrix[firstPlayerShipOneRow, firstPlayerShipOneColomn] = 1;

Console.Write("First Player: choose row for Battleship#2: ");
int firstPlayerShipTwoRow = int.Parse(Console.ReadLine()) - 1;
Console.Write("First Player: choose colomn for Battleship#2: ");
int firstPlayerShipTwoColomn = int.Parse(Console.ReadLine()) - 1;
currentMatrix[firstPlayerShipTwoRow, firstPlayerShipTwoColomn] = 1;

currentMatrix = secondPlayerGameField;

Console.Write("Second Player: choose row for Battleship#1: ");
int secondPlayerShipOneRow = int.Parse(Console.ReadLine()) - 1;
Console.Write("Second Player: choose colomn for Battleship#1: ");
int secondPlayerShipOneColomn = int.Parse(Console.ReadLine()) - 1;
currentMatrix[secondPlayerShipOneRow, secondPlayerShipOneColomn] = 1;

Console.Write("Second Player: choose row for Battleship#2: ");
int secondPlayerShipTwoRow = int.Parse(Console.ReadLine()) - 1;
Console.Write("Second Player: choose colomn for Battleship#2: ");
int secondPlayerShipTwoColomn = int.Parse(Console.ReadLine()) - 1;
currentMatrix[secondPlayerShipTwoRow, secondPlayerShipTwoColomn] = 1;

currentMatrix = firstPlayerGameField;

static bool HasTargets(int[,] currentMatrix)
{
    for (int i = 0; i < currentMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < currentMatrix.GetLength(1); j++)
        {
            if (currentMatrix[i, j] == 1)
                return true;
        }
    }
    return false;
}

while (HasTargets(firstPlayerGameField) && HasTargets(secondPlayerGameField))
{
    string currentPlayer;

    if (attempt % 2 == 0)
    {
        currentPlayer = "Player 1";
        currentMatrix = secondPlayerGameField;
        PrintMatrix(firstPlayerGameField);
    }
    else
    {
        currentPlayer = "Player 2";
        currentMatrix = firstPlayerGameField;
        PrintMatrix (secondPlayerGameField);
    }

    Console.WriteLine($"{currentPlayer} turn");

    Console.Write("Choose row for attack: ");
    int hitRow = int.Parse(Console.ReadLine()) - 1;

    Console.Write("Choose column for attack: ");
    int hitColomn = int.Parse(Console.ReadLine()) - 1;

    if (hitRow >= 0 && hitRow < currentMatrix.GetLength(0) &&
        hitColomn >= 0 && hitColomn < currentMatrix.GetLength(1))
    {
        if (currentMatrix[hitRow, hitColomn] == 0)
        {
            Console.WriteLine("Missed");
        }
        else if (currentMatrix[hitRow, hitColomn] == 1)
        {
            Console.WriteLine("Killed");
            currentMatrix[hitRow, hitColomn] = 0;
        }

        attempt++;
    }
    else
    {
        Console.WriteLine("Coordinates out of bounds");
    }
}

if (!HasTargets(firstPlayerGameField))
{
    Console.WriteLine("Player 2 wins!");
}
else
{
    Console.WriteLine("Player 1 wins!");
}