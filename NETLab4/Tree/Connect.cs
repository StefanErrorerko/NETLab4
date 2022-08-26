namespace NETLab4.Tree
{
    public class Connect
    {
        private static readonly List<char> _symbolCollection = new List<char>
        {
            '+', '-', '*', '/'
        };

        public char Symbol { get; init; }

        public Connect(char sym)
        {
            foreach(char s in _symbolCollection)
            {
                if (s == sym) Symbol = sym;
            }
        }
        public override string ToString() => Convert.ToString(Symbol);
    }
}
