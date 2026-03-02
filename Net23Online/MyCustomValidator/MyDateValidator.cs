namespace MyCustomValidator
{
    public static class MyDateValidator
    {
        /// <summary>
        /// checks if the provided year of birth is a valid integer and falls within the specified minimum and maximum year range.
        /// </summary>
        /// <param name="year"></param> some string that needs to be checked for min and max values
        /// <param name="minYear"></param> minimum year that is allowed for the year of birth
        /// <param name="maxYear"></param> maximum year that is allowed for the year of birth
        /// <returns></returns>
        public static bool IsYearOfBirthValid(string year, int minYear, int maxYear)
        {
            bool isValid = int.TryParse(year, out int paresedYear);
            return isValid && paresedYear >= minYear && paresedYear <= maxYear;
        }
    }
}
