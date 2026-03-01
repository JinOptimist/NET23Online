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

/*
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

Console.WriteLine($"Hi {userName} cool you are {age} is old"); */

            var name = "irina";
            var YouAge = 18;
            var MyAge = 24;
            var BirthdayYear = DateTime.Now.Year;
            var play_sport = "yes";
            var vid_sporta = "tenis";
            var let_v_sporte = 1;
            var raznica_vozrast = 1;

            Console.WriteLine("What's your name?");
            name = Console.ReadLine();
            Console.WriteLine("What year were you born?");
            BirthdayYear = Convert.ToInt32(Console.ReadLine());
            YouAge = DateTime.Now.Year - BirthdayYear;
            Console.WriteLine("Do you play sports?");
            play_sport = Console.ReadLine();

            if (play_sport == "yes" || play_sport == "Yes")
            {
                Console.WriteLine("What kind of sport do you play?");
                vid_sporta = Console.ReadLine();
                Console.WriteLine("How many years have you been practicing?");
                let_v_sporte = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine($"Hello, {name}, my name is Ira! Nice to meet you! You {YouAge}?");

            if (YouAge > MyAge)
            {
                raznica_vozrast = YouAge - MyAge;
                Console.WriteLine($"You're {raznica_vozrast} years older than me. This is a wonderful age!");
            }
            else
            {
                raznica_vozrast = Math.Abs(YouAge - MyAge);
                Console.WriteLine($"You're {raznica_vozrast} years younger than me. This is a wonderful age!");
            }


            if (play_sport == "yes" || play_sport == "Yes")
            {
                Console.WriteLine($"It's great that you've been {vid_sporta} this for {let_v_sporte} years. That's quite respectable!");
            }
            else if (play_sport == "no" || play_sport == "No")
            {
                Console.WriteLine("No hobbies? No problem, maybe you just don't have any free time.");
            }
            else
            {
                Console.WriteLine("I think we had a misunderstanding on the last question.");
            }
        

