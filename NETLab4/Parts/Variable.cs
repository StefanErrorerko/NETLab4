using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLab4.Parts
{
    public class Variable : Part
    {
        public char Name { get; init; }
        public override int Value { get; set; }

        public Variable(char name, int value)
        {
            Name = name;
            Value = value;
        }
        public Variable(char name)
        {
            Name = name;
        }

        public override string ToString() => Convert.ToString(Name);
    }
}
