using NETLab4.SimpleExpressions;

namespace NETLab4.Tree
{
    public abstract class Component
    {
        public virtual SimpleExpression? Value { get; set; }
        public virtual Component? Left { get; set; }
        public virtual Component? Right { get; set; }
        public virtual Component? Parent { get; set; }
        public virtual Connect? Connector { get; set; }
    }
}
