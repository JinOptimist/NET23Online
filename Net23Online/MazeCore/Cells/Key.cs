using MazeCore.Cells;
using MazeCore.Characters.Interfaces;
using MazeCore.Interfaces;

public class Key : BaseCell
{
    public Key(IMaze maze) : base(maze) { }

    public override char Symbol => 'K';


    
    public override bool Interaction(IBaseCharacter character)
    {
        character.Key++;
        Maze.EventHistory.Add("Look, it's a key");
        MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
        soundPlayer.PlayMusic("key_sound.wav", 0.6f);
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
