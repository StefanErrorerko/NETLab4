using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NETLab4.SimpleExpressions;

namespace NETLab4.Tree
{
    public class Leaf : Component
    {
        public override SimpleExpression Value { get; set; }
        public Leaf(SimpleExpression value)
        {
            Value = value;
        }

        public override string ToString()
        {
            if(Value != null) return Value.ToString();
            return String.Empty;
        }
    }
}
