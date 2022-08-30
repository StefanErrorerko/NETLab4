using NETLab4.SimpleExpressions;

namespace NETLab4.Tree
{
    public class Leaf : Component
    {
        public override SimpleExpression? Value { get; set; }
        public Leaf(SimpleExpression value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? string.Empty;
        }
    }
}
