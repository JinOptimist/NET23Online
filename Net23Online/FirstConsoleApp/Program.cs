//Console.WriteLine("Hi I'm Pasha I write a book");
//Console.WriteLine("Hi I'm Alena");
//Console.WriteLine(("Hi I am Nikolai. Hello!"));
//Console.WriteLine("I want to work programmist!:");
//Console.WriteLine("Hi, I'm Dmitry. I like Videogames but suck at programming!");
//Console.WriteLine("Hello, my name is Ilya");
//Console.WriteLine("Hi I'm Stas - C++ Developer");
//Console.WriteLine("Hi I'm Valentin");
//Console.WriteLine("Hi I'm Osama");
//Console.WriteLine("I love to Learn");
//Console.WriteLine("Hello, I'm Alexander. My hobby is a waste of time");
//Console.WriteLine("Hi I'm Denis");
//Console.WriteLine("Hello, my name's Nikita. I like reading books.");
//Console.WriteLine("Hello, my name is Ira, i love my cats");
//Console.WriteLine("Hi I'm Sonya");
//Console.WriteLine("I love dancing");
//Console.WriteLine("I am trying again");
//Console.WriteLine("Igor, I like to drive a car.");

//var number1 = 5;
//var number2 = 2;
//var result = number1 - number2; // 3

//var name = "Ivan";
//var text1 = "5";
//var text2 = "2";
//// var testResult = text1 - text2; // error

//string text = "test";
//int number = 123;
//bool isSmartEnuoght = false; // true false

//var age = (2026 - 1988) * 2 - 1 * 5;// + - * /

//var longText = "My name is " + name + " I'm " + age + " old";
//var longText2 = $"My name is {name} I'm {age} old";

//var condition1 = true;
//var condition2 = false;
//var condition3 = condition1 && true; // and 2
//var condition4 = condition2 || condition3; // or 3
//var condition5 = !condition4; // not  1 
//var condition6 = condition5 && condition4 || !condition2;

//Console.WriteLine(name);


int age;
int height;
bool trust = true;


Console.WriteLine("We're Looking for a guy who kidnapped my dog! Tell me about yourself so I'll know it's not YOU!");
Console.WriteLine("First of all, What's your name?");
string name = Console.ReadLine();


if (name == "Dmitry" || name == "Dima" || name == "Pasha" || name == "Pavel")
{
    Console.WriteLine("Wow, no way! Just like my friends! How old are you?");
}
else
{
    Console.WriteLine("Wow, A strange name! Huh, how old are you?");
}

age = int.Parse(Console.ReadLine());

if (age < 3 || age > 100)
{
    Console.WriteLine("Are you joking? That's not funny! How tall are you? In centimiters.");
    trust = false;
}
else
{
    Console.WriteLine("Okay, so be it. How tall are you? Please answer in a number in centimiters");
}

height = int.Parse(Console.ReadLine());

if (trust == false)
{
    Console.WriteLine($"It was you,{name}! There's no way you can be {age} years old! I'll punch you! Even though you're {height} centimiters tall!");
}
if (trust == true && height < 250 || height > 50)
{
    Console.WriteLine($"Seems like you tell me the truth! Thanks, {name}. You are only {age} years old and you're already {height} centimiters tall! Wow! Have a good day!");
}
else
{
    Console.WriteLine($"{name}, you're {age} years old and you're {height} centimiters tall? I dont believe you! LIAR! I'll punch you!");
}
