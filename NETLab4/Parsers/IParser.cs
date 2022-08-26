using NETLab4.Tree;

namespace NETLab4.Parsers
{
    public abstract class IParser
    {
        public abstract Component Parse(string exp);
    }
}
