

Console.WriteLine("What is you name?");
string userName;
do {
    userName = Console.ReadLine(); // read from console
} while (string.IsNullOrWhiteSpace(userName));

Console.WriteLine("When you was born?");
string yearOfBirthdayStr = Console.ReadLine(); // read from console
var yearOfBirthday = int.Parse(yearOfBirthdayStr); // "2000" => 2000
var currentYear = DateTime.Now.Year;
var age = currentYear -  yearOfBirthday;
do
{
    Console.WriteLine($"No. you aren't. Write you real age");
    yearOfBirthdayStr = Console.ReadLine(); // read from console
    yearOfBirthday = int.Parse(yearOfBirthdayStr); // "2000" => 2000
    age = currentYear - yearOfBirthday;

} while (age < 10 && string.IsNullOrWhiteSpace(yearOfBirthdayStr));

Console.WriteLine("What is you hobby?");
string hobby;
do
{
    hobby = Console.ReadLine(); // read from console
} while (string.IsNullOrWhiteSpace(hobby));

Console.WriteLine($"Hi {userName} cool you are {age} is old and you have a nice hobby {hobby}");

