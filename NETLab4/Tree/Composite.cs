namespace NETLab4.Tree
{
    public class Composite : Component
    {
        public override Component? Parent { get; set; }
        public override Component? Left { get; set; }
        public override Component? Right { get; set; }
        public override Connect? Connector { get; set; }
        public Composite() { } 

        public Composite(Connect connector)
        {
            Connector = connector;
        }

        public override string ToString()
        {
            string result = "(";
            if(Left != null)
                result += Left.ToString();
            result += Connector;
            if(Right != null)
                result += Right.ToString();
            return result + ")";
        }
    }
}
