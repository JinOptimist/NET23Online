using FirstConsoleApp.MazeStuff.Characters;
namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class Ghost:BaseCell
    {
        private int BagWithCoins = 3;
        public Ghost(Maze maze) :base(maze) 
        {
        }
        public override char Symbol => 'G';

        public override bool Interaction(BaseCharacter character)
        {
            
            var random = new Random();
            var hitOrNotHero = random.Next(0,5) == 4? true:false;
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);
            //The chance to kill the ghost is 20%. 
            //If we miss, it takes our coin and runs away.
            //If we have no coins, it hits us for 1 hitpoint and runs away.
            //If we have 1 health left and no money, it disappears from the labyrinth.
            if (hitOrNotHero)
            {
                character.Coins += BagWithCoins;
                Maze.Surface.Remove(this);
                Maze.EventHistory.Add($"The Ghost is dead. Your reward - {BagWithCoins} coins");
            }
            else
            {
                if(character.Coins > 0) 
                {
                    character.Coins--;
                    BagWithCoins++;
                    Maze.EventHistory.Add("Ghost: Heheheh. Your coin - my coin. hehehe");
                }
                else 
                {
                    if(character.Hp <= 0) //
                    {
                        Maze.EventHistory.Add("Ghost: You are poor and weak. I have nothing more to do in this labyrinth, goodbye.");
                        Maze.Surface.Remove(this);
                        return true;
                    }
                    else 
                    {
                        character.Hp--;
                        Maze.EventHistory.Add("Ghost: Are you poor? I take your soul.");
                    } 
                }
                var runAwauFromHero= Maze.Surface.Where(cell => cell is Ground).
                                                   Where(cell => 
                                                            cell.X == X + 1 && cell.Y == Y
                                                         || cell.X == X - 1 && cell.Y == Y
                                                         || cell.X == X     && cell.Y == Y + 1
                                                         || cell.X == X     && cell.Y == Y - 1)
                                                   .ToList();
                var groundForReplace = runAwauFromHero[random.Next(0, runAwauFromHero.Count)];
                X = groundForReplace.X;
                Y = groundForReplace.Y;
                Maze.Surface.Remove(groundForReplace);
            }
            return true;
        }
    }
}
