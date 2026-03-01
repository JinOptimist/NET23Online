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
//string yearOfBirthdayStr = Console.ReadLine(); // read from console
//var yearOfBirthday = int.Parse(yearOfBirthdayStr); // "2000" => 2000
//var currentYear = DateTime.Now.Year;
//var age = currentYear - yearOfBirthday;
//if (age < 3)
//{
//    Console.WriteLine($"Proceed to cycling room");
//}
//

Console.WriteLine("Name Yourself?");
var userName = Console.ReadLine();

Console.WriteLine("Did you spend much time in the cell?");
var Q1 = Console.ReadLine();
if (Q1 != "cells")
{
    Console.WriteLine($"Proceed to cycling room");
    return;
}

else Console.WriteLine("Have you ever been in an instituion?");
var Q2 = Console.ReadLine();
if (Q2 != "cells")
{
    Console.WriteLine($"Proceed to cycling room");
    return;
}

else Console.WriteLine("Do they keep you in a cell??");
var Q3 = Console.ReadLine();
if (Q3 != "cells")
{
    Console.WriteLine($"Proceed to cycling room");
    return;
}

else Console.WriteLine("When you're not performing your duties do they keep you in a little box?");
var Q4 = Console.ReadLine();
if (Q4 != "cells")
{
    Console.WriteLine($"Proceed to cycling room");
    return;
}

else Console.WriteLine($"We Done. {userName} you can pick up your bonus");