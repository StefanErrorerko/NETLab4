using NETLab4.Tree;

namespace NETLab4.ExpressionEditors
{
    public static class ExpressionDisplayer
    {
        public static string Display(Component root)
        {
            if(root != null)
                return TrimBrackets(root.ToString());
            return String.Empty;
        }

        public static string TrimBrackets(string exp)
        {
            if (exp != null)
                return exp.Substring(1, exp.Length - 2);
            return String.Empty;
        }
    }
}
