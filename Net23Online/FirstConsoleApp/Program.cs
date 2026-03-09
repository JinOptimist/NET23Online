using FirstConsoleApp.MazeStuff;

var mazeBuilder = new MazeBuilder();

var maze = mazeBuilder.Build(24, 12);

var mazeDrawer = new MazeDrawer();

mazeDrawer.Draw(maze);
var botGame = new GuessTheNumberGameHumanVsBot();
botGame.Play();