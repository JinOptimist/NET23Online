namespace FirstConsoleApp.SeaBattleHumanVsBot;

public abstract class Player
{ 
    /// <summary>
    /// ДОБАВИТЬ ТРИ ПОЛЯ
    /// LAST ROW
    /// LAST COL
    /// SHOT STATE MOVE INFO
    /// чтобы потом передать информацию о ходе бота
    /// </summary>
    public Field Field { get; set; } = new Field();

    public List<Ship> Ships { get; set; } = new List<Ship>();

    public int CountOfAliveShips()
    {
        return Ships.Count(ship => !ship.IsDestroyed());
    }
    
    public abstract void PlaceShips();
    
    public abstract bool MakeMove(Player enemy);
}