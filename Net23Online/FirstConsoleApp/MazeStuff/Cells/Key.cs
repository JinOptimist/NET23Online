using FirstConsoleApp.MazeStuff;
using FirstConsoleApp.MazeStuff.Cells;
using FirstConsoleApp.MazeStuff.Characters;

public class Key : BaseCell
{
    private const int _KEY_COLLECT = 1;
    public Key(Maze maze) : base(maze) { }

    public override char Symbol => 'K';

    public  bool Collect(BaseCharacter character)
    {
        character.CollectKey(_KEY_COLLECT);
        return true; 
    }
    public override bool Interaction(BaseCharacter character)
    {
        Maze.EventHistory.Add("Look, it's a key");
        Collect(character);
        ReplaceKeyToGround();
        return true;
    }
    private void ReplaceKeyToGround()
    {
        Maze.Surface.Remove(this);
        var ground = new Ground(Maze)
        {
            X = X,
            Y = Y,
        };
        Maze.Surface.Add(ground);
    }
}
