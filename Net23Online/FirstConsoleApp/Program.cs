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


Console.WriteLine("What is you name?");
var userName = Console.ReadLine(); // read from console

Console.WriteLine("When you was born?");
string yearOfBirthdayStr = Console.ReadLine(); // read from console
var yearOfBirthday = int.Parse(yearOfBirthdayStr); // "2000" => 2000
var currentYear = DateTime.Now.Year;
var age = currentYear -  yearOfBirthday;
if (age < 3)
{
    Console.WriteLine($"You are lier");
}


Console.WriteLine($"Hi {userName} cool you are {age} is old");

Console.WriteLine("What is you name?");
var Name = Console.ReadLine();
Console.WriteLine("What city were you born in?");
var City = Console.ReadLine();
Console.WriteLine("What is your education?");
var educ = Console.ReadLine();
Console.WriteLine("What is your hobby?");
var hob = Console.ReadLine();
Console.WriteLine("What year were you born?");
var BirthdayString = Console.ReadLine();
var Birthday = int.Parse(BirthdayString);
var DateNow = DateTime.Now.Year;
var Age1 = DateNow - Birthday;
if (Age1 < 5)
{
    Console.WriteLine($"Lier");
}
Console.WriteLine($"Hi {Name}, you were born in {Birthday} in the city {City}. You are {Age1} years old now. Your hobby is {hob}. You have a {educ}.");
