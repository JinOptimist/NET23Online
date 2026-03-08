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
    
    public Field()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Cells[x, y] = new Cell(x, y);
            }
        }
    }
    
    
    //координата - верхняя\левая палуба корабля
    public bool CanPlaceShip(int row, int column, int size, bool horizontal)
    {
        if (!horizontal)
        {
            if (column > 9  || column < 0) return false;//если выходит за границы столбцов

            if (row > 9 - size + 1 || row < 0) return false;
        }
        else
        {
            if (row > 9 || row < 0) return false;//если выходит за границы строк

            if (column > 9 - size + 1 || column < 0)  return false;  
            ///например: корабль длиной 4 должен начинаться
            /// максимум с 6ой клетки (6 7 8 9),
            /// тогда 9 - 4 + 1 = 6 
        }

        for (int c = 0; c < size; c++) //cделаем с каждой клеткой
        {
            var rows = 0;
            var cols = 0;
            for (int i = -1; i <= 1; i++) //в каждой ее строке
            {
                for (int j = -1; j <= 1; j++) // в каждом столбце
                {
                    if (!horizontal)
                    {
                        rows = row + i;
                        cols = column + j + c;
                    }
                    else
                    {
                        rows = row + i + c;
                        cols = column + j;
                    }
                    
                    if (rows < 0 || rows > 9 || cols < 0 || cols > 9) continue;
                    
                    Cell cell =  Cells[rows, cols];

                    if (cell.State != CellState.Empty) return false;
                }
            }
        }
        return true;
    }
    
   public ShotState Shot(Cell cellToShoot)
   {
       if (cellToShoot.State == CellState.Ship)
       {
           cellToShoot.State = CellState.Hit;
           
           cellToShoot.Ship.MarkHit(cellToShoot);

           if (cellToShoot.Ship.IsDestroyed())
           {
               var cellsNearDestroyedShip = cellToShoot.Ship.GetNeighboringCells(this);
               MakeNeighbordingCellsMiss(cellsNearDestroyedShip);
               
               return ShotState.Destroy;
           }

           return ShotState.Damaged;
       }

       cellToShoot.State = CellState.Miss;
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