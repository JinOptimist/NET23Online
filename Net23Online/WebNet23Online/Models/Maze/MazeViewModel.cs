namespace WebNet23Online.Models.Maze
{
    public class MazeViewModel
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<List<CellViewModel>> Rows { get; set; } = new();
    }
}
