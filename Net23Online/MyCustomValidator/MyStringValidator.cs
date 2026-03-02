using System.Text.RegularExpressions;

namespace MyCustomValidator
{

    public static class MyStringValidator
    {
        /// <summary>
        /// checks if the provided string contains only Latin letters (both uppercase and lowercase) and does not contain any other characters, such as digits, spaces, or special characters.
        /// </summary>
        /// <param name="text"></param> some string that needs to be checked for containing only Latin letters
        /// <returns></returns>
        public static bool DoesStringContainLatinLettersOnly(string text)
        {
            return Regex.IsMatch(text, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// checks if the length of the provided string is greater than the specified minimum length and less than the specified maximum length. It returns true if the string length is valid according to these criteria, and false otherwise.
        /// </summary>
        /// <param name="someString"></param> some string that needs to be checked for length
        /// <param name="minNameLength"></param> minimum length that is allowed for the string
        /// <param name="maxNameLength"></param> maximum length that is allowed for the string
        /// <returns></returns>
        public static bool IsStringLengthValid(string someString, int minNameLength, int maxNameLength)
        {
            return someString.Length > minNameLength && someString.Length < maxNameLength;
        }
    }
}
