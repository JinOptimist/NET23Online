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

var horoscope = new Dictionary<string, string> 
{
    {"Aries ","March 2026 brings a transformative shift for Aries, as Mars enters Pisces on March 2, redirecting your fiery energy inward.  " +
                "This isn’t a loss of drive, but a call to channel it with intention, purpose, and emotional awareness—think controlled burn, not wildfire. "},
    {"Taurus","March 2026 begins with a focus on practical progress, stability, and quiet empowerment.  Taurus is encouraged to embrace " +
                "steady effort over quick results, especially in work and finances. Saturn in your eleventh house calls for better boundaries, rest, and solitude to manage energy, " +
                "while Jupiter supports productive networking and valuable connections. "},
    {"Gemini ","March 2026 brings a dynamic and transformative month for Gemini, marked by heightened mental energy, " +
                "new opportunities, and a strong focus on communication, relationships, and personal growth."},
    {"Cancer","March 2026 is a transformative month for Cancer, marked by significant astrological events and personal growth. " +
                "The month begins with Mars entering Pisces on March 2, fueling a drive to defend your beliefs and pursue goals with precision.  " +
                "A Full Moon Lunar Eclipse in Virgo on March 3 brings fated revelations, especially around communication, relationships, and personal projects—potentially " +
                "shifting dynamics with close friends or family. "},
    {"Leo","March 2026 is a dynamic and transformative month for Leo, " +
                "marked by a powerful progression from self-reflection to bold action. The month begins with a Full Moon Lunar Eclipse in Virgo on March 3," +
                " activating your 2nd house of finances, self-worth, and personal resources.  This event brings clarity to your financial situation—whether it’s a budget adjustment," +
                " a new income stream, or a shift in how you value yourself. It’s a pivotal moment for reassessing your priorities, especially around time, energy, and money. "},
    {"Virgo","March 2026 brings a powerful focus on identity, communication, and personal transformation for Virgos." +
                "  The month begins with a total lunar eclipse in your first house of identity on March 3rd, a pivotal moment that may signal the culmination of a personal" +
                " project or a turning point in how you show up in the world.  This eclipse urges you to reflect: Are you living authentically? If not, significant shifts may be" +
                " necessary to align with your soul’s calling. "},
    {"Scorpio","Ooooh. Your zodiac sign is scorpio... You don't need a horoscope. You're cool."},
    {"Sagittarius","Sagittarius, March 2026 is a transformative month centered on travel, education, and expanding your horizons, " +
                "energized by your ruling planet Jupiter.  This is a powerful time to pursue new opportunities, make valuable connections, and embrace growth."},
    {"Capricorn","March 2026 brings a blend of responsibility, " +
                "growth, and subtle transformation for Capricorns. The month opens with a focus on steady progress, " +
                "practical decisions, and strengthening relationships, especially within family and close circles.  " +
                "Jupiter’s movement through Gemini blesses your partnership zone, drawing helpful people into your life—whether at work, home, or socially."},
    {"Aquarius","March 2026 brings a powerful blend of focus, " +
                "financial clarity, and personal transformation for Aquarius. " +
                "The month begins with the Sun in Pisces, emphasizing money, values, and security, " +
                "encouraging you to assess your finances and set clear goals.  Spend wisely—avoid impulse buys, " +
                "track income and expenses, and consider low-risk savings to build long-term comfort."},
    {"Pisces","March 2026 is a powerful month of identity, renewal, and self-empowerment for Pisces.  " +
                "The month begins with Mars entering your sign on March 2, infusing you with bold energy and a renewed sense of purpose.  " +
                "This is your annual energy injection—your softness gains an edge, and you’re encouraged to speak up, claim your space, and act on your desires. "},
    {"Libra","March 2026 is a pivotal month for Libra, marked by deep emotional release, career breakthroughs, and a powerful shift " +
                "in relationships. The month begins with a surge of clarity and renewed momentum, setting the stage for significant personal growth and recognition."}
};

Console.WriteLine("Hello, what's your name?");
var name = Console.ReadLine();

Console.WriteLine($"Hello {name}, enter your date of birth (dd.mm.yyyy | 20.12.1998)");
var dateFromConsole = Console.ReadLine();


if (DateOnly.TryParse(dateFromConsole, out DateOnly dateOfBirth))
{ 
    Console.WriteLine("Do you want to listen to your horoscope for March? Type Yes if you want (Yes, please)");
    var answer = Console.ReadLine();
    if (answer == "Yes" || answer == "yes" || answer == "y" || answer == "ys" || answer == "es" || answer == "ye" || answer == "s" || answer == "e" || answer == "yeah" || answer == "go")
    {
        Console.WriteLine($"Okay {name}. Here's your horoscope for March of this year!!");
        switch (dateOfBirth.Month)
        {
            case 1:
                //Capricorn
                if (dateOfBirth.Day <= 19) Console.WriteLine(horoscope["Capricorn"]);
                //Aquarius
                else if (dateOfBirth.Day >= 20) Console.WriteLine(horoscope["Aquarius"]);
                break;

            case 2:
                //Aquarius
                if (dateOfBirth.Day <= 18) Console.WriteLine(horoscope["Aquarius"]);
                //Pisces
                else Console.WriteLine(horoscope["Pisces"]);
                break;

            case 3:
                //Aries
                if (dateOfBirth.Day >= 21) Console.WriteLine(horoscope["Aries"]);
                //Pisces
                else Console.WriteLine(horoscope["Pisces"]);
                break;

            case 4:
                //Aries
                if (dateOfBirth.Day <= 19) Console.WriteLine(horoscope["Aries"]);
                //Taurus
                else if (dateOfBirth.Day >= 20) Console.WriteLine(horoscope["Taurus"]);
                break;

            case 5:
                //Taurus
                if (dateOfBirth.Day <= 20) Console.WriteLine(horoscope["Taurus"]);
                //Gemini
                else if (dateOfBirth.Day >= 21) Console.WriteLine(horoscope["Gemini"]);
                break;

            case 6:
                //Gemini
                if (dateOfBirth.Day <= 20) Console.WriteLine(horoscope["Gemini"]);
                //Cancer
                else if (dateOfBirth.Day >= 21) Console.WriteLine(horoscope["Cancer"]);
                break;

            case 7:
                //Cancer
                if (dateOfBirth.Day <= 22) Console.WriteLine(horoscope["Cancer"]);
                //Leo
                else if (dateOfBirth.Day >= 23) Console.WriteLine(horoscope["Leo"]);
                break;

            case 8:
                //Leo
                if (dateOfBirth.Day <= 22) Console.WriteLine(horoscope["Leo"]);
                //Virgo
                else if (dateOfBirth.Day >= 23) Console.WriteLine(horoscope["Virgo"]);
                break;

            case 9:
                //Virgo
                if (dateOfBirth.Day <= 22) Console.WriteLine(horoscope["Virgo"]);
                //Libra
                else if (dateOfBirth.Day >= 23) Console.WriteLine(horoscope["Libra"]);
                break;

            case 10:
                //Libra
                if (dateOfBirth.Day <= 22) Console.WriteLine(horoscope["Libra"]);
                //Scorpio
                else if (dateOfBirth.Day >= 23) Console.WriteLine(horoscope["Scorpio"]);
                break;

            case 11:
                //Scorpio
                if (dateOfBirth.Day <= 21) Console.WriteLine(horoscope["Scorpio"]);
                //Sagittarius
                else if (dateOfBirth.Day >= 22) Console.WriteLine(horoscope["Sagittarius"]);
                break;

            case 12:
                //Sagittarius
                if (dateOfBirth.Day <= 21) Console.WriteLine(horoscope["Sagittarius"]);
                //Capricorn
                else if (dateOfBirth.Day >= 22) Console.WriteLine(horoscope["Capricorn"]);
                break;
        }
    }
    else 
    {
        Console.WriteLine("Eh.. well.. okay.. After rebooting your computer, your C drive will be formatted. You have an hour to find out my horoscope and stop it.");
    }
           
}
else 
    {
        Console.WriteLine("Unfortunately, you entered the wrong date...");
    }
Console.WriteLine($"{name}, have a nice day!");
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
