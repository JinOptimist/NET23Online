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

Console.WriteLine("\n\nTask1");
Story.shortProfile.TellStory();

namespace Story
{
    public class shortProfile
    {
        public static void TellStory()
        {
            Console.WriteLine("\nHi, please answer a few questions so I can create a short profile.\n");
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            Console.WriteLine("\nWhen you was born?");

            DateTime dateToday = DateTime.Now;
            int dayOfBirthday;
            int monthOfBirdthday;
            int yearOfBirdthday;
            DateTime dateOfBirthday;
            int calculatedAge = 0;

            while (true)
            {
                try
                {
                    dayOfBirthday = ConvertStrToInt("Input your day of birthday", 1, 31);
                    monthOfBirdthday = ConvertStrToInt("Input your month of birthday", 1, 12);
                    yearOfBirdthday = ConvertStrToInt("Input your year of birthday", dateToday.Year - 150, dateToday.Year);

                    dateOfBirthday = new DateTime(yearOfBirdthday, monthOfBirdthday, dayOfBirthday);

                    if (yearOfBirdthday > dateToday.Year)
                    {
                        Console.WriteLine("You haven't been born yet. Input real date");
                        continue;
                    }

                    if (yearOfBirdthday + 150 < dateToday.Year)
                    {
                        Console.WriteLine("You are too old. Input real date");
                        continue;
                    }

                    calculatedAge = dateToday.Year - dateOfBirthday.Year;
                    if (dateOfBirthday.Month > dateToday.Month || (dateOfBirthday.Month == dateToday.Month && dateOfBirthday.Day > dateToday.Day))
                    {
                        calculatedAge = calculatedAge - 1;
                    }

                    //Console.WriteLine($"You was born in {dateOfBirthday.ToShortDateString()}.\n");
                    break;
                }
                catch (Exception ex) { Console.WriteLine("Please input real date"); }
            }
            //Metod to Convertation data
            static int ConvertStrToInt(string message = null, int minValue = int.MinValue, int maxValue = int.MaxValue)
            {
                if (message != null) Console.WriteLine($"{message}\nUse only numbers.");
                int resultInt;
                while (true)
                {
                    string inputStr = Console.ReadLine();
                    if (int.TryParse(inputStr, out resultInt))//Добавить и проверку на реальность данных
                    {
                        if (minValue <= resultInt && resultInt <= maxValue)
                            return resultInt;
                        else
                            Console.WriteLine($"Error! Values must be between {minValue} and {maxValue}.");
                    }
                    else
                    {
                        Console.WriteLine($"Error! The input must be numbers. {message}.");
                    }
                }
            }
            // Asking sex
            Console.WriteLine("Are you a woman or a man?");
            string sex;
            while (true)
            {
                sex = Console.ReadLine();
                switch (sex.ToLower())
                {
                    case "man":
                        if (calculatedAge > 18)
                            Console.WriteLine("\nCool. Let's go to a bar this weekend.");
                        else Console.WriteLine("\nTake some candy");
                        break;

                    case "woman":
                        if (calculatedAge > 18)
                            Console.WriteLine("\nLet's go to a restaurant this weekend.");
                        else Console.WriteLine("\nTake some candy");
                        break;

                    default:
                        Console.WriteLine($"\nI dont know about {sex}. Try again.");
                        continue;
                }
                break;
            }

            Console.WriteLine("\nWhere do you live?");
            var adress = Console.ReadLine();
            Console.WriteLine("\nWhat are your hobbies?");
            var hobbies = Console.ReadLine();
            Console.WriteLine("\nI have prepared your profile.");
            Console.WriteLine($"Name: {name}\nDate of birth: {dateOfBirthday.ToShortDateString()} ({calculatedAge} y.o.)\nSex: {sex}\nAdress: {adress}\nHobbies: {hobbies}");
            Console.WriteLine("\nI hope to see you soon, my friend!");
        }
    }
}

