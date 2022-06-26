using System;
using NETLab4.Parsers;
using NETLab4.Parts;
using NETLab4.Tree;

namespace NETLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {       
                Console.WriteLine("Запишiть ваш вираз у форматi (4+x)/(7*...)-...");
                string? exp = Console.ReadLine();
                Console.WriteLine("Розбирається задане дерево парсером виразiв. Готово:");

                if (!String.IsNullOrEmpty(exp))
                {
                    var root = ExpressionParser.Parse(exp);
                    Console.WriteLine(root.Expression());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}