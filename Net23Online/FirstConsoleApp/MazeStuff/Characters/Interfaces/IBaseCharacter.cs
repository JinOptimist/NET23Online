using FirstConsoleApp.MazeStuff.Cells.Interfaces;

namespace FirstConsoleApp.MazeStuff.Characters.Interfaces
{
    public interface IBaseCharacter : IBaseCell
    {
        int Burning { get; set; }
        int Coins { get; set; }
        int Hp { get; set; }
        int Keys { get; set; }
        string Name { get; set; }
        int Speed { get; set; }
        int SuperPower { get; set; }
        bool IsDead { get; set; } 
        
        bool HasKey(int amount);
        public bool HasHp(int amount);
        public bool HasCoins(int amount);
        public bool HasSpeeds(int amount);
        public bool HasSuperPower(int amount);
        void UseKey(int amount);
        public void SpendCoins(int amount);
        public void SpendHp(int amount);
        public void SpendSpeed(int amount);
        public void SpendSuperPower(int amount);
        public void CollectKey(int amount);
        public void CollectCoin(int amount);
        public void CollectHp(int amount);
        public void CollectSpeed(int amount);
        public void CollectSuperPower(int amount);

        public void GameOver();

    }
}