using FirstConsoleApp.TowerOfHanoi.Players;
using static System.Console;

namespace FirstConsoleApp.TowerOfHanoi
{
    public class MyApplication
    {
        public static void PlayGame(BasePlayer basePlayer) 
            => basePlayer.Play();

        public static void ShowStatistics() 
            => BasePlayer.ShowSortedListOfPlayersInAscOrderOfAttemts().ForEach(elem => WriteLine(elem));

    }
}
