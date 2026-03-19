using FirstConsoleApp.MazeStuff.Cells;
using System.Reflection.Metadata.Ecma335;

namespace FirstConsoleApp.MazeStuff.Characters
{
    public abstract class BaseCharacter : BaseCell
    {
        protected BaseCharacter(Maze maze) : base(maze)
        {
        }

        public string Name { get; set; }
        public int Hp { get; set; } = 5;
        public int Coins { get; set; }
        public int Speed { get; set; }
        public int Burning { get; set; }
        public int Keys { get; set; }
        public int SuperPower { get; set; }
        public bool IsDead { get; set; } = false;

        public bool HasKey(int amount)
        {
            if (Keys >= amount)
            {
                return true;
            }
            return false;
        }
        public bool HasHp(int amount)
        {
            if (Hp >= amount)
            {
                return true;
            }
            return false;
        }
        public bool HasCoins(int amount)
        {
            if (Coins >= amount)
            {
                return true;
            }
            return false;
        }
        public bool HasSpeeds(int amount)
        {
            if (Speed >= amount)
            {
                return true;
            }
            return false;
        }
        public bool HasSuperPower(int amount)
        {
            if (SuperPower >= amount)
            {
                return true;
            }
            return false;
        }
        public void UseKey(int amount)
        {
            Keys-=amount;
        }
        public void SpendCoins(int amount)
        {
            Coins -= amount;
        }
        public void SpendHp(int amount)
        {
            Hp -= amount;
        }
        public void SpendSpeed(int amount)
        {
            Speed -= amount;
        }
        public void SpendSuperPower(int amount)
        {
            SuperPower -= amount;
        }
        public void CollectKey(int amount)
        {
            Keys=+ amount;
        }
        public void CollectCoin(int amount)
        {
            Coins = +amount;
        }
        public void CollectHp(int amount)
        {
            Hp = +amount;
        }
        public void CollectSpeed(int amount)
        {
            Speed = +amount;
        }

        public void CollectSuperPower(int amount)
        {
            SuperPower = +amount;
        }

        public virtual void GameOver()
        {
            Console.WriteLine("\n╔════════════════════════════════════════════╗");
            Console.WriteLine("║               GAME OVER                    ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine("\nYou have perished in the maze...");
            IsDead = true;
        }

    }
}
