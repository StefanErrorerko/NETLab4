using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLab4.Parts
{
    internal class Number : Part
    {
        public override int Value { get; set; }
        public Number(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            if (Value < 0)
            {
                return String.Format("({0})", Value);
            }
            return String.Format("{0}", Value);
        }
    }
}
