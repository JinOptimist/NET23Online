using System.Globalization;
using System.Text.RegularExpressions;

var person = new Person();
Console.WriteLine("Dear user, here you can fill your profile");

person.Name = Utility.GetValidName();

person.Birthdate = Utility.GetValidBirthdate();

person.Age = Utility.CalculateAge(person.Birthdate);

person.Hometown = Utility.GetValidLocation();

person.Hobbies = Utility.GetValidHobbies();

Console.Clear();
person.OutputSummary();

public static class Utility
{
    public static int CalculateAge(DateTime birthdate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthdate.Year;

        if (birthdate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }

    public static string GetValidName()
    {
        string name;
        do
        {
            Console.WriteLine("What is your name? (minimum 2 characters, only letters and spaces)");
            name = Console.ReadLine().ToLower().Trim() ?? "";

            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Try again");
            }
            else if (name.Length < 2)
            {
                Console.WriteLine("Name must be at least 2 characters long. Try again");
            }
            else if (!IsValidName(name))
            {
                Console.WriteLine("Name can only contain letters and spaces. Try again");
            }
            else
            {
                return FormatName(name);
            }

        } while (true);
    }

    public static string GetValidLocation()
    {
        string hometown;
        do
        {
            Console.WriteLine("Where are you from? (minimum 2 characters, only letters,spaces and hyphens)");
            hometown = Console.ReadLine().ToLower().Trim() ?? "";

            if (String.IsNullOrEmpty(hometown))
            {
                Console.WriteLine("Hometown cannot be empty. Try again");
            }
            else if (hometown.Length < 3)
            {
                Console.WriteLine("Hometown must be at least 3 characters long. Try again");
            }
            else if (!IsValidHometown(hometown))
            {
                Console.WriteLine("Name can only contain letters,spaces and hyphens. Try again");
            }
            else
            {
                return FormatLocationName(hometown);
            }

        } while (true);
    }

    public static List<string> GetValidHobbies()
    {
        var hobbies = new List<string>();
        Console.WriteLine("What are your hobbies?");
        Console.WriteLine("Hobby must be at least 4 characters long and can contain letters, numbers and spaces");
        Console.WriteLine("Type 'done' when finished");
        string hobby;
        do
        {
            hobby = Console.ReadLine().ToLower().Trim() ?? "";

            if (hobby.ToLower().Equals("done"))
            {
                break;
            }
            else if (IsValidHobby(hobby))
            {
                hobbies.Add(FormatHobby(hobby));
            }


        } while (true);

        return hobbies;
    }

    public static DateTime GetValidBirthdate()
    {
        while (true)
        {
            Console.WriteLine("What is your birthdate? Enter in format MM/dd/yyyy (03/02/2026)");
            var input = Console.ReadLine().Trim() ?? "";

            try
            {
                var birthdate = DateTime.ParseExact(input, "MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US"));

                if (birthdate > DateTime.Today)
                {
                    Console.WriteLine("Birthdate cannot be in the future. Try again");
                    continue;
                }
                else if (birthdate < DateTime.Today.AddYears(-150))
                {
                    Console.WriteLine("Age cannot be more than 150 years. Try again");
                }

                return birthdate;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format Please use the MM/dd/yyyy format (03/02/2026)");
            }
        }
    }

    private static bool IsValidHometown(string hometown)
    {
        return Regex.IsMatch(hometown, @"^[a-zA-Z\s\-]+$");
    }

    private static string FormatLocationName(string location)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location);
    }

    private static bool IsValidName(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
    }

    private static string FormatName(string name)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
    }

    private static bool IsValidHobby(string hobby)
    {
        if (String.IsNullOrEmpty(hobby))
        {
            Console.WriteLine("Hobby cannot be empty. Try again");
            return false;
        }
        else if (hobby.Length < 4)
        {
            Console.WriteLine("Hobby must be at least 4 characters long. Try again");
            return false;
        }
        else if (hobby.Length > 50)
        {
            Console.WriteLine("Hobby name is too long (maximum is 50 characters). Try again");
            return false;
        }
        else if (!Regex.IsMatch(hobby, @"^[a-zA-Z\s\-]+$"))
        {
            Console.WriteLine("Hobby can contain only letters, spaces and hyphens. Try again");
            return false;
        }

        return true;
    }
    private static string FormatHobby(string hobby)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(hobby);
    }
}

public class Person
{
    public string Name { get; set; }

    public int Age { get; set; }

    public DateTime Birthdate { get; set; }

    public string Hometown { get; set; }

    public List<string> Hobbies { get; set; }

    public Person()
    {
        Hobbies = new List<string>();
    }

    public void OutputSummary()
    {
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("Profile summary");
        Console.WriteLine(new string('=', 50));
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Birthdate: {Birthdate.ToString("MMMM dd, yyyy", CultureInfo.GetCultureInfo("en-US"))}");
        Console.WriteLine($"Hometown:{Hometown}");

        Console.WriteLine($"Hobbies: {Hobbies.Count}");
        if (Hobbies.Count > 0)
        {
            for (var i = 0; i < Hobbies.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Hobbies[i]}");
            }
        }
        else
        {
            Console.WriteLine("No hobbies specified");
        }
        Console.WriteLine(new string('=', 50));
    }
}

