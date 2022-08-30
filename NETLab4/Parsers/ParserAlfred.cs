using NETLab4.Tree;
using NETLab4.SimpleExpressions;

namespace NETLab4.Parsers
{
    public class ParserAlfred : IParser
    {
        private bool _partRecording;
        private Component? _currentNode;
        private string _partValue = string.Empty;
        private Component? _lastNode;             

        public override Component Parse(string exp)
        {
            _partRecording = false;
            _currentNode = new Composite();

            foreach (var sym in exp)
            {
                switch (sym)
                {
                    case '(':
                        _lastNode = _currentNode;
                        if (_currentNode.Left == null)
                        {
                            _currentNode.Left = new Composite();
                            _currentNode = _currentNode.Left;
                        }
                        else
                        {
                            _currentNode.Right = new Composite();
                            _currentNode = _currentNode.Right;
                        }
                        _currentNode.Parent = _lastNode;
                        break;
                    case ')':
                        RecordValueAndCreateLeaf();
                        _currentNode.Parent ??= new Composite();
                        _currentNode = _currentNode.Parent;
                        break;
                    case '*':
                    case '/':
                    case '+':
                    case '-':
                        if (_partRecording)
                            RecordValueAndCreateLeaf();
                        _currentNode.Connector = new Connect(sym);
                        break;
                    default:
                        _partRecording = true; 
                        _partValue += sym;
                        break;
                }
            }
            if (!string.IsNullOrEmpty(_partValue))
                RecordValueAndCreateLeaf();

            return _currentNode;
        }
        private void RecordValueAndCreateLeaf()
        {
            if (!_partRecording)
            { 
                return;
            }

            if (_currentNode == null || _partValue == null)
            {
                throw new ArgumentNullException("Recording was not run or current node was not selected");
            }

            if (_currentNode.Left == null)
            {
                _currentNode.Left = new Leaf(PartRecord(_partValue));
            }

            else
            {
                _currentNode.Right = new Leaf(PartRecord(_partValue));
            }
            _partValue = string.Empty;
            _partRecording = false;
        }
        private SimpleExpression PartRecord(string rawPart)
        {
            if (double.TryParse(rawPart, out var num))
            {
                return new Number(num);
            }
            if (Variable.TryParse(rawPart, out var result))
            {
                return result;
            }
            throw new InvalidDataException();
        }
    }
}
