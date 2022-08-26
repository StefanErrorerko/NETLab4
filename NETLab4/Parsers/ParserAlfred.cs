using NETLab4.Tree;
using NETLab4.SimpleExpressions;

namespace NETLab4.Parsers
{
    public class ParserAlfred : IParser
    {
        bool partRecording;
        Component? currentNode;
        string partValue = string.Empty;
        Component? lastNode;
        public override Component Parse(string exp)
        {
            var root = new Composite();
            currentNode = root;
            partRecording = false;

            foreach (char s in exp)
            {
                switch (s)
                {
                    case '(':
                        lastNode = currentNode;
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = new Composite();
                            currentNode = currentNode.Left;
                        }
                        else
                        {
                            currentNode.Right = new Composite();
                            currentNode = currentNode.Right;
                        }
                        currentNode.Parent = lastNode;
                        break;
                    case ')':
                        RecordValueAndCreateLeaf();
                        if (currentNode.Parent == null) currentNode.Parent = new Composite();
                        currentNode = currentNode.Parent;
                        break;
                    case '*':
                    case '/':
                    case '+':
                    case '-':
                        if (partRecording)
                            RecordValueAndCreateLeaf();
                        currentNode.Connector = new Connect(s);
                        break;
                    default:
                        partRecording = true; // ??? чи делегат чи подія
                        partValue += s;
                        break;
                }
            }
            if (!String.IsNullOrEmpty(partValue))
                RecordValueAndCreateLeaf();

            return currentNode;
        }
        private void RecordValueAndCreateLeaf()
        {
            if (partRecording)
            {
                if (currentNode == null || partValue == null)
                    throw new ArgumentNullException("Recording was not run or current node was not selected");
                if (currentNode.Left == null)
                    currentNode.Left = new Leaf(PartRecord(partValue));
                else
                    currentNode.Right = new Leaf(PartRecord(partValue));
                partValue = string.Empty;
                partRecording = false;
            }
        }
        private SimpleExpression PartRecord(string rawPart)
        {
            if (double.TryParse(rawPart, out double num)) return new Number(num);
            else if (Variable.TryParse(rawPart, out Variable? result)) return result;
            else throw new InvalidDataException();
        }
    }
}
