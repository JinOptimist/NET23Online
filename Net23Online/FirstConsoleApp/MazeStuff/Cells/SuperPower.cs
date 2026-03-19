using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells;

public class SuperPower : BaseCell
{
    public SuperPower(Maze maze) : base(maze)
    {
    }
    private const int _COIN_COST = 2;
    private const int _SUPER_POWER_COLLECT = 1;
    private const int _HP_COLLECT = 1;
    public override char Symbol => 'P';

    public override bool Interaction(BaseCharacter character)
    {
        if (character is not Hero hero || hero.Coins < _COIN_COST)
        {
            return true;
        }

        Maze.EventHistory.Add("SuperPower! +Hp. You can break the wall.");
        
        Maze.Surface.Remove(this);
        var ground = new Ground(Maze) { 
            X = X,
            Y = Y,
        };
        Maze.Surface.Add(ground);

        character.CollectHp(_HP_COLLECT);
        character.CollectSuperPower(_SUPER_POWER_COLLECT);
        character.SpendCoins(_COIN_COST);
        return true;
    }
}