namespace FirstConsoleApp.SeaBattleHumanVsBot;

public class SeaBattleGame
{
    private bool _isGameOver = false;

    private PlayerHuman _human = new();

    private PlayerBot _bot = new();

    private Player _currentTurn; // Bot or Human

    private Player _winner;

    public void StartGame()
    {
        _currentTurn = _human;
        
        _human.PlaceShips();
        _bot.PlaceShips();

        Round();

        SayResults();
    }
    
    public void ShowFields(Field playerField, Field enemyField)
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
            ShowFields(_human.Field, _bot.Field);

            Player enemy = _currentTurn == _human ? _bot : _human;
            var IslastMoveHitLucky = _currentTurn.MakeMove(enemy);

            ChangeTurnIfNeeded(IslastMoveHitLucky);

            _isGameOver = enemy.CountOfAliveShips() == 0;

            if (_isGameOver)
            {
                _winner = _currentTurn;
            }
            
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
        if (_human == _winner)
        {
            Console.WriteLine("You are Win! My congratulations!");
            Console.WriteLine("Thanks for this game");
            Console.WriteLine("Goodbye");
        }
        else
        {
            Console.WriteLine("Bot is the winner. Thanks for this game");
            Console.WriteLine("You always can try again");
        }
    }

}