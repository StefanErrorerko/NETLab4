using System;
using NETLab4.ExpressionEditors;
using NETLab4.SimpleExpressions;
using NETLab4.Tree;

namespace NETLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {       
                Console.WriteLine("Запишiть ваш вираз у форматi:\n" +
                    "\tвираз = <простий вираз> | <складний вираз>\n" +
                    "\tпростий вираз = <число> | <iм'я змiнної>\n" +
                    "\tскладний вираз = (<вираз><знак операцiї><вираз>)\n" +
                    "Наприклад: ((62+3)/(8,45*7))-4");
                string? exp = Console.ReadLine();
                Console.WriteLine("Розбирається задане дерево парсером виразiв. Готово:");

                if (!String.IsNullOrEmpty(exp))
                {
                    var root = ExpressionParser.Parse(exp);
                    Console.WriteLine(ExpressionDisplayer.Display(root));
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
