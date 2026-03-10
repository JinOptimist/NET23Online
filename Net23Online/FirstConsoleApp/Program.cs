using FirstConsoleApp.MazeStuff;
using FirstConsoleApp.TwentyOneGame;

var mazeBuilder = new MazeBuilder();

var maze = mazeBuilder.Build(24, 12);

var mazeDrawer = new MazeDrawer();

mazeDrawer.Draw(maze);

CardGame cardGame = new CardGame();
cardGame.Start();