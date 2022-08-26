namespace NETLab4.SimpleExpressions
{
    public abstract class SimpleExpression
    {
        public abstract double Value { get; init; }
        public override string ToString() => Convert.ToString(Value);
    }
}
