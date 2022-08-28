namespace NETLab4.Tree
{
    public class Connect
    {
        private static readonly HashSet<char> _symbols = new HashSet<char>
        {
            '+', '-', '*', '/'
        };

        public char Symbol { get; init; }

        public Connect(char sym)
        {
            if (_symbols.Contains(sym))
            {
                Symbol = sym;
            }
        }
        public override string ToString() => Convert.ToString(Symbol);
    }
}
