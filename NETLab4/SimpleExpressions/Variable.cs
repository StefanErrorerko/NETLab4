using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace NETLab4.SimpleExpressions
{
    public class Variable : SimpleExpression
    {
        public string Name { get; init; }
        public override double Value { get; init; }

        public Variable(string name, double value)
        {
            Name = name;
            Value = value;
        }
        public Variable(string name)
        {
            Name = name;
        }

        public static bool TryParse([NotNullWhen(true)] string? str, [NotNullWhen(true)] out Variable? result)
        {
            if (str != null && Regex.IsMatch(str, @"^[A-z,a-z]+$")) //same brackets {}
                result = new Variable(str);
            else result = null; //same brackets {}
            return result is not null;
        }
        public override string ToString() => Convert.ToString(Name);
    }
}
