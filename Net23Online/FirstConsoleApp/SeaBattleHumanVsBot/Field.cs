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
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Cells[x, y] = new Cell(x, y);
            }
        }
    }
    
    //координата - верхняя\левая палуба корабля
    public bool CanPlaceShip(int row, int col, int size, bool horizontal)
    {
        if (!horizontal)
        {
            if (col > 10  || col < 1) //если выходит за границы столбцов
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (size == 1+i && row > 10-i && row < 1)
                {
                    return false;
                }
            }
        }
        else
        {
            if (row > 10 || row < 1) //если выходит за границы строк
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (size == 1+i && col > 10-i && col < 1)
                {
                    return false;
                }
            }
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
                        cols = col + j + c;
                    }
                    else
                    {
                        rows = row + i + c;
                        cols = col + j;
                    }
                    

                    if (rows < 1 ||
                        rows > 10 ||
                        cols < 1 ||
                        cols > 10)
                    {
                        continue;
                    }
                    
                    Cell cell =  Cells[rows-1, cols-1];

                    if (cell.State != CellState.Empty)
                    { 
                        return false;
                    }
                }
            }
        }
        return true;
    }

   //void PlaceShip(Ship ship)
   
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