using System.Text.RegularExpressions;
using NETLab4.Tree;
using NETLab4.SimpleExpressions;

namespace NETLab4.ExpressionEditors
{
    public static class ExpressionParser    //??? норм шо паблік а не інтернал?
    {
        private static bool partRecording; 
        private static Component? currentNode; // ??? camel norm
        private static string? partValue;  // ??? а шо робить з '?'
        private static Component? lastNode;

        public static Component Parse(string exp)
        {
            var root = new Composite();
           
            partValue = String.Empty;
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
                        if(partRecording) 
                            RecordValueAndCreateLeaf();
                        currentNode.Connector = new Connect(s);
                        break;
                    default:
                        partRecording = true; 
                        partValue += s;
                        break;
                }
            }
            if(partValue != null) 
                RecordValueAndCreateLeaf();

            return currentNode;
        }

        private static SimpleExpression PartRecord(string rawPart)
        {
            if (IsNumber(rawPart)) return new Number(Convert.ToDouble(rawPart));
            else if (IsVariable(rawPart)) return new Variable(rawPart);
            else throw new InvalidDataException();
        }

        private static bool IsVariable(string rawPart)
        {
            return Regex.IsMatch(rawPart, @"^[A-z,a-z]+$");        // ??? чи норм? розширювати Стрінг? але це крінж чи у Variable
        }

        private static bool IsNumber(string rawPart)
        {
            try
            {
                Convert.ToDouble(rawPart);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void RecordValueAndCreateLeaf()      
        {
            if (partRecording)
            {
                if (currentNode == null || partValue == null)
                    throw new ArgumentNullException("Recording was not run or current node was not selected");
                if (currentNode.Left == null)
                    currentNode.Left = new Leaf(PartRecord(partValue));  
                else
                    currentNode.Right = new Leaf(PartRecord(partValue));    
                partValue = String.Empty;
                partRecording = false;
            }
        }
    }
}
