namespace NETLab4.Tree
{
    public class Connect
    {
        // better to rename it to just _symbols. And use HashSet<> instead of List<> - _symbols = new HashSet<char> {'+', '-', '*', '/'};
        private static readonly List<char> _symbolCollection = new List<char>
        {
            '+', '-', '*', '/'
        };

        public char Symbol { get; init; }

        public Connect(char sym)
        {
            // with HashSet<> it would be just - if(_symbols.Contains(sym)) without foreach
            foreach(char s in _symbolCollection)
            {
                if (s == sym) Symbol = sym;
            }
        }
        public override string ToString() => Convert.ToString(Symbol);
    }
}
