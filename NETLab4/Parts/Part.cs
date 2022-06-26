using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLab4.Parts
{
    public abstract class Part
    {
        public abstract int Value { get; set; }
        public override string ToString() => Convert.ToString(Value);
    }
}
