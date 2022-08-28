using NETLab4.Tree;
using NETLab4.SimpleExpressions;

namespace NETLab4.Parsers
{
    public class ParserAlfred : IParser
    {
        bool partRecording; //_partRecording and make all this fields private explicitly
        Component? currentNode; //_currentNode - '_' part is a code style convention https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
        string partValue = string.Empty; //same
        Component? lastNode; 
        public override Component Parse(string exp)
        {
            // root var not needed, it could already be currentNode = new Composite();
            var root = new Composite();
            currentNode = root;
            partRecording = false; //this flag actually should not be private var, it should be local var here in Parse() method and be a parameter in RecordValueAndCreateLeaf() method

            //var s, and you should avoid var naming in one letter (is it symbol?)
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
                        // use ??= assignment. currentNode.Parent ??= new Composite();
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
                        partRecording = true; // ??? чи делегат чи подія. you can leave it as flag
                        partValue += s;
                        break;
                }
            }
            // string
            if (!string.IsNullOrEmpty(partValue))
                RecordValueAndCreateLeaf();

            return currentNode;
        }
        private void RecordValueAndCreateLeaf()
        {
            //condition should be reversed - if(!partRecording) {return;} to remove extra brackets below
            if (!partRecording)
            { 
                return;
            }
            if (currentNode == null || partValue == null)
            {
                throw new ArgumentNullException("Recording was not run or current node was not selected");
            }

            //same brackets {}
            if (currentNode.Left == null)
                currentNode.Left = new Leaf(PartRecord(partValue));

            //same brackets {}
            else
                currentNode.Right = new Leaf(PartRecord(partValue));
            partValue = string.Empty;
            partRecording = false;
        }
        private SimpleExpression PartRecord(string rawPart)
        {
            //same brackets {} and out var num
            if (double.TryParse(rawPart, out double num)) return new Number(num);

            // else is redundant, because there is return after each if. same brackets {} and out var result
            if (Variable.TryParse(rawPart, out Variable? result)) return result;

            // else is redundant, because there is return after each if. same brackets {}
            throw new InvalidDataException();
        }
    }
}
