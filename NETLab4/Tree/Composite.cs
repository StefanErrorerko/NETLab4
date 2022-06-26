using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETLab4.Tree
{
    public class Composite : Component
    {
        public override Component Parent { get; set; }
        public override Component Left { get; set; }
        public override Component Right { get; set; }
        public override Connect Connector { get; set; }
        public Composite() { }

        public Composite(Connect connector)
        {
            Connector = connector;
        }

        public override string Expression()
        {
            string result = "(";
            result += Left.Expression();
            result += Connector;
            result += Right.Expression();
            return result + ")";
        }
    }
}
