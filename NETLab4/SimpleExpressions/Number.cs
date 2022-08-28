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
            return Value.ToString();
        }
    }
}
