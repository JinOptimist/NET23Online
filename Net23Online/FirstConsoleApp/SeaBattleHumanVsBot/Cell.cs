namespace FirstConsoleApp.SeaBattleHumanVsBot;

public enum CellState
{
    Empty,
    Ship,
    Hit,
    Miss
}

public class Cell
{
    public int Row { get; }
    
    public int Col { get; }

    public CellState State { get; set; } 
    
    //а что если нет корабля?
    public Ship? Ship { get; set; }

    public Cell(int row, int col)
    {
        Row = row;
        Col = col;
        State = CellState.Empty;
    }
}