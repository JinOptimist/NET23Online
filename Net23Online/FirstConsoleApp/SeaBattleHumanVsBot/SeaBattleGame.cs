namespace FirstConsoleApp.SeaBattleHumanVsBot;

public class SeaBattleGame
{
    private bool _isGameOver = false;

    private PlayerHuman _human = new();

    private PlayerBot _bot = new();

    private Player _currentTurn = new PlayerHuman(); // Bot or Human

    public void StartGame()
    {
        _human.PlaceShips();
        _bot.PlaceShips();

        Round();

        SayResults();
    }
    
    public void DicplayFields(Field playerField, Field enemyField)
    {
        Console.WriteLine("Ваше поле:              Поле противника:");
        Console.Write("  ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write(j + " ");
        }

        Console.Write("      ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write(j + " ");
        }

        Console.WriteLine();

        for (int i = 0; i < 10; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 10; j++)
            {
                var cell = playerField.Cells[i, j];

                var symbol = ' ';
                if (cell.State == CellState.Empty)
                    symbol = '~';
                if (cell.State == CellState.Hit)
                    symbol = 'x';
                if (cell.State == CellState.Miss)
                    symbol = '•';
                if (cell.State == CellState.Ship)
                    symbol = '▄';
                Console.Write(symbol + " ");
            }

            Console.Write("    ");

            Console.Write(i + " ");

            for (int j = 0; j < 10; j++)
            {
                var cell = enemyField.Cells[i, j];

                var symbol = ' ';
                if (cell.State == CellState.Empty)
                    symbol = '~';
                if (cell.State == CellState.Hit)
                    symbol = 'x';
                if (cell.State == CellState.Miss)
                    symbol = '•';
                if (cell.State == CellState.Ship)
                    symbol = '~';
                Console.Write(symbol + " ");
            }

            Console.WriteLine();
        }
    }

    public void Round()
    {
        do
        {
            DicplayFields(_human.Field, _bot.Field);

            Player enemy = _currentTurn == _human ? _bot : _human;
            var IslastMoveHitLucky = _currentTurn.MakeMove(enemy);

            ChangeTurnIfNeeded(IslastMoveHitLucky);
        } while (!_isGameOver);
    }
    public void ChangeTurnIfNeeded(bool lastMoveHit)
    {
        if (!lastMoveHit)
        {
            _currentTurn = _currentTurn == _human ? _bot : _human;
        }
    }


    /// <summary>
    /// итоги игры
    /// </summary>
    public void SayResults()
    {
        
    }

}