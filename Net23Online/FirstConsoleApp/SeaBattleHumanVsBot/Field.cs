namespace FirstConsoleApp.SeaBattleHumanVsBot;
public enum ShotState
{
    Destroy,
    Damaged,
    Miss
}

public class Field
{
    public Cell[,] Cells { get; set; } =  new Cell[10, 10];

    public void MakeField()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Cell cell = new Cell(x, y);
            }
        }
    }

    //public Cell GetCell(int row, int col)

   // bool CanPlaceShip(int row, int col, int size, bool horizontal)

   //void PlaceShip(Ship ship)
   
   public ShotState Shot(Cell cellToShoot, Field field)
   {
       if (cellToShoot.State == CellState.Ship)
       {
           cellToShoot.State = CellState.Hit;
           
           cellToShoot.Ship.MarkHit(cellToShoot);

           if (cellToShoot.Ship.IsDestroyed())
           {
               var cellsNearDestroyedShip = cellToShoot.Ship.GetNeighboringCells(field);
               MakeNeighbordingCellsMiss(cellsNearDestroyedShip);
               return ShotState.Destroy;
           }

           return ShotState.Damaged;
       }

       return ShotState.Miss;
   }

   public void MakeNeighbordingCellsMiss(List<Cell> cells)
   {
       foreach (var cell in cells)
       {
           cell.State = CellState.Miss;
       }
   }
} 