// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hi I'm Pasha");
Console.WriteLine(("Hi I am Nikolai. Hello!"));
Console.WriteLine("I want to work programmist!:");
Console.WriteLine("Hi I'm Pasha");
Console.WriteLine("Hi I'm Pasha I write a book");
Console.WriteLine("Hi, I'm Dmitry. I like Videogames but suck at programming!");
Console.WriteLine("Hello, my name is Ilya");
Console.WriteLine("Hello, my name's Nikita. I like reading.");
Console.WriteLine("Hi I'm Stas - C++ Developer");
Console.WriteLine("Hi I'm Valentin");
Console.WriteLine("Hi I'm Osama");
Console.WriteLine("I love to Learn");
Console.WriteLine("Hello, I'm Alexander. My hobby is a waste of time");
Console.WriteLine("Hello, my name's Nikita. I like reading books.");

Console.WriteLine("Hi I'm Sonya");
Console.WriteLine("I love dancing");

Console.WriteLine("Please, tell me your name");
string name = Console.ReadLine();
Console.WriteLine("Now tell me your family");
string family = Console.ReadLine();
Console.WriteLine($"Hello {family} {name}! I suggest you play a game. Guess a number.");
Console.ReadLine();
Console.WriteLine("Multiply it by 2.");
Console.ReadLine();
Console.WriteLine("Add 8 to the result.");
Console.ReadLine();
Console.WriteLine("Divide the resulting number by 2.");
Console.ReadLine();
Console.WriteLine("Subtract the number you initially thought of from the result.");
Console.ReadLine();
Console.WriteLine("I already know you got 4. If so, then write something, otherwise just press \"Enter\".");
string answer = Console.ReadLine();
if (answer == "")
{
    Console.WriteLine("You made a mistake in your calculations or are trying to deceive me.");
}
else
{
    Console.WriteLine("In fact, everything is simple. It's a math trick and the answer is always 4.");
}