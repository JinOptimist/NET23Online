namespace FirstConsoleApp.SeaBattleHumanVsBot;

public abstract class Player
{
    public Field Field { get; set; } = new Field();

    public List<Ship> Ships { get; set; } = new List<Ship>();

    public int CountOfAliveShips()
    {
        int count = 0;
        foreach (var ship in Ships)
        {
            if (ship.IsDestroyed())
            {
                continue;
            }
            count++;
        }
        return count;
    }
    public abstract void PlaceShips();

    public abstract bool MakeMove(Player enemy);
}