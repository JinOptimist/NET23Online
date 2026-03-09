using FirstConsoleApp.MazeStuff;

var mazeBuilder = new MazeBuilder();

var maze = mazeBuilder.Build(9, 4);

var mazeDrawer = new MazeDrawer();

mazeDrawer.Draw(maze);

