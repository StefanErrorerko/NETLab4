namespace NETLab4.Extensions
{
    public static class StringExtensions
    {
        public static string TrimBrackets(this string? str)
        {
            // this method dont actually trim brackets, it trims first and last symbols of the string.
            // if you want to trim brackets you should use string.Trim() method
            // it can be simplified with ?: - return !string.IsNullOrEmpty(str) ? str.Trim('{', '}') : string.Empty;

            return !String.IsNullOrEmpty(str) ? str.Substring(1, str.Length - 2) : String.Empty;
        }
    }
}
