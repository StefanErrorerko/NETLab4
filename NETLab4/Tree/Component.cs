using NETLab4.Parts;

namespace NETLab4.Tree
{
    public abstract class Component
    {
        public virtual Part Value { get; set; }
        public virtual Component Left { get; set; }
        public virtual Component Right { get; set; }
        public virtual Component Parent { get; set; }
        public virtual Connect Connector { get; set; }

        public abstract string Expression();

        public virtual bool IsExpression()
        {
            return true;
        }
    }
}
