using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NETLab4.Parts;

namespace NETLab4.Tree
{
    public class Leaf : Component
    {
        public override Part Value { get; set; }
        public Leaf(Part value)
        {
            Value = value;
        }

        public override string Expression()
        {
            if(Value != null) return Value.ToString();
            return String.Empty;
        }

        public override bool IsExpression()
        {
            return false;
        }
    }
}
