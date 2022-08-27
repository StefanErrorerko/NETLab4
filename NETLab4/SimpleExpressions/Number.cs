namespace NETLab4.SimpleExpressions
{
    internal class Number : SimpleExpression
    {
        public override double  Value { get; init; }
        public Number(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            // make it as ternary operator ?: and use string interpolation '$' instead of string.Format() - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            if (Value < 0)
            {
                return String.Format("({0})", Value);
            }
            return String.Format("{0}", Value);
        }
    }
}
