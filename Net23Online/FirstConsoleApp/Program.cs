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


// Console.WriteLine("What is you name?");
// var userName = Console.ReadLine(); // read from console
//
// Console.WriteLine("When you was born?");
// string yearOfBirthdayStr = Console.ReadLine(); // read from console
// var yearOfBirthday = int.Parse(yearOfBirthdayStr); // "2000" => 2000
// var currentYear = DateTime.Now.Year;
// var age = currentYear -  yearOfBirthday;
// if (age < 3)
// {
//     Console.WriteLine($"You are lier");
// }
//
//
// Console.WriteLine($"Hi {userName} cool you are {age} is old");

class Program
{
    public static int Sum(int a, int b) => a + b;
    public static int Minus(int a, int b) => a - b ;
    public static int Multiply(int a, int b) => a * b;
    public static int Divide(int a, int b)  => a / b;
    public static void PrintWordsStartWithA()
    {
        Console.WriteLine("Input your string");
        var stroka = Console.ReadLine();
        Console.WriteLine("Words in your string started with latter A:");
        var listOfWords = stroka.Split(' ');
        foreach (var word in listOfWords)
        {
            var lowerWord = word.ToLower();
            if (lowerWord.StartsWith("a"))
            {
                Console.WriteLine(word);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello. What is your name?");
        var userName = Console.ReadLine();

        Console.WriteLine($"Ok, {userName}, nice to meet you.");

        while (true)
        { 
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Outputs all words starting with the latter A");
            Console.WriteLine("3. Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                {
                    Console.WriteLine("Write the first number:");
                    var num1Str = Console.ReadLine();
                    var num1 = int.Parse(num1Str);
                    Console.WriteLine("Write the second number:");
                    var num2Str = Console.ReadLine();
                    var num2 = int.Parse(num2Str);

                    Console.WriteLine("Choose option:");
                    Console.WriteLine("1. +");
                    Console.WriteLine("2. -");
                    Console.WriteLine("3. *");
                    Console.WriteLine("4. /");
                    Console.WriteLine("5. Exit");
                    
                    var answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                        {
                            var result = Sum(num1, num2);
                            Console.WriteLine($"Your result is {result}");
                            break;
                        }
                        case "2":
                        {
                            var result = Minus(num1, num2);
                            Console.WriteLine($"Your result is {result}");
                            break;
                        }
                        case "3":
                        {
                            var result = Multiply(num1, num2);
                            Console.WriteLine($"Your result is {result}");
                            break;
                        }
                        case "4":
                        {
                            if (num2 == 0)
                            {
                                Console.WriteLine("You can't divide by zero");
                                break;
                            }
                            var result = Divide(num1, num2);
                            Console.WriteLine($"Your result is {result}");
                            break;
                        }
                        case "5":
                        {
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Invalid option");
                            break;
                        }
                    }
                    break;
                }
                case "2":
                {
                    PrintWordsStartWithA();
                    break;
                }
                case "3":
                    return;
                default:
                {
                    Console.WriteLine("Invalid option");
                    break;
                }
            }
        }
    } 
}