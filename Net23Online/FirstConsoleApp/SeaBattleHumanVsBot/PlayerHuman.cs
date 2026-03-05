namespace FirstConsoleApp.SeaBattleHumanVsBot;

public class PlayerHuman : Player
{
    public override bool MakeMove(Player enemy)
    {
        //ввод координат
        //enemy.field.shoot()
        return true;
    }

    public override void PlaceShips()
    {
        Console.WriteLine("Hello! It's a sea battle game with Bot!");
        Console.WriteLine("Let's arrange your ships!");
        ///ввод координат
        /// CanPlaceShip
        /// PlaceShip
    }
}