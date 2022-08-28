namespace NETLab4.Extensions
{
    public static class StringExtensions
    {
        public static string TrimFirstAndLast(this string? str)
        {
            return !string.IsNullOrEmpty(str) ? str.Substring(1, str.Length - 2) : string.Empty;
        }
    }
}
