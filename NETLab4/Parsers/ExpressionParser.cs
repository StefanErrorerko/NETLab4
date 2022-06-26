using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETLab4.Tree;
using NETLab4.Parts;

namespace NETLab4.Parsers
{
    public static class ExpressionParser
    {
        public static Component Parse(string exp)
        {
            var root = new Composite();
            Component currentNode = root;

            foreach (char s in exp)
            {
                switch (s)
                {
                    case '(':
                        var lastNode = currentNode;
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
                        if (currentNode.Parent == null) currentNode.Parent = new Composite();
                        currentNode = currentNode.Parent;
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '0':
                        if (currentNode.Connector == null && currentNode.Left != null)
                        {
                            currentNode.Left.Value.Value *= 10;
                            currentNode.Left.Value.Value += Convert.ToInt32(s.ToString());
                        }
                        else if (currentNode.Connector != null && currentNode.Right != null)
                        {
                            currentNode.Right.Value.Value *= 10;
                            currentNode.Right.Value.Value += Convert.ToInt32(s.ToString());
                        }
                        else
                        {
                            if (currentNode.Left == null) currentNode.Left = new Leaf(
                                new Number(Convert.ToInt32(s.ToString())));
                            else currentNode.Right = new Leaf(
                                new Number(Convert.ToInt32(s.ToString())));
                        }
                        break;
                    case '*':
                    case '/':
                    case '+':
                    case '-':
                        while (currentNode.Connector != null)
                        {
                            if (currentNode.Parent == null) currentNode.Parent = new Composite();
                            currentNode = currentNode.Parent;
                        }
                        currentNode.Connector = new Connect(s);
                        break;
                    default:
                        if (currentNode.Left == null) currentNode.Left = new Leaf(new Variable(s));
                        else currentNode.Right = new Leaf(new Variable(s));
                        break;
                }
            }
            return root;

        }
    }
}
