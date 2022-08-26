namespace NETLab4.Extensions
{
    public static class StringExtensions
    {
        public static string TrimBrackets(this string? str)
        {
            if (!String.IsNullOrEmpty(str))
                return str.Substring(1, str.Length - 2);
            return String.Empty;
        }
    }
}
