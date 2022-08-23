using System.Text.RegularExpressions;
using NETLab4.Tree;
using NETLab4.SimpleExpressions;

namespace NETLab4.ExpressionEditors
{
    public static class ExpressionParser    //??? норм шо паблік а не інтернал?
    {
        private static bool part_recording; 
        private static Component? currentNode; // ??? camel norm
        private static string? part_value;  // ??? а шо робить з '?'
        private static Component? lastNode;

        public static Component Parse(string exp)
        {
            var root = new Composite();
           
            part_value = String.Empty;
            currentNode = root;
            part_recording = false;

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
                        if(part_recording) 
                            RecordValueAndCreateLeaf();
                        currentNode.Connector = new Connect(s);
                        break;
                    default:
                        part_recording = true; // ??? чи делегат чи подія
                        part_value += s;
                        break;
                }
            }
            if(part_value != null) 
                RecordValueAndCreateLeaf();

            return currentNode;
        }

        private static SimpleExpression PartRecord(string raw_part)
        {
            if (IsNumber(raw_part)) return new Number(Convert.ToDouble(raw_part));
            else if (IsVariable(raw_part)) return new Variable(raw_part);
            else throw new InvalidDataException();
        }

        private static bool IsVariable(string raw_part)
        {
            return Regex.IsMatch(raw_part, @"^[A-z,a-z]+$");        // ??? чи норм? розширювати Стрінг? але це крінж чи у Variable
        }

        private static bool IsNumber(string raw_part)
        {
            try
            {
                Convert.ToDouble(raw_part);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void RecordValueAndCreateLeaf()      // handle? how
        {
            if (part_recording)
            {
                if (currentNode == null || part_value == null)
                    throw new NullReferenceException("Recording was not run or current node was not selected");
                if (currentNode.Left == null)
                    currentNode.Left = new Leaf(PartRecord(part_value));    // ??? delegate
                else
                    currentNode.Right = new Leaf(PartRecord(part_value));     // ??? same 
                part_value = String.Empty;
                part_recording = false;
            }
        }
    }
}
