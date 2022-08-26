using NETLab4.Extensions;
using NETLab4.Parsers;
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

                if (!String.IsNullOrEmpty(exp))
                {
                    Console.WriteLine("Розбирається задане дерево парсером виразiв. Готово:");
                    IParser parserAlfred = new ParserAlfred();
                    var root = parserAlfred.Parse(exp);
                    Console.WriteLine(root.ToString().TrimBrackets());
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
