using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLab4.SimpleExpressions
{
    public class Variable : SimpleExpression
    {
        public string Name { get; init; }
        public override double Value { get; set; }

        public Variable(string name, double value)
        {
            Name = name;
            Value = value;
        }
        public Variable(string name)
        {
            Name = name;
        }
        public override string ToString() => Convert.ToString(Name);
    }
}
