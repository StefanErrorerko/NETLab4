using NETLab4.Extensions;
using NETLab4.Parsers;

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

                var exp = Console.ReadLine();

                if (string.IsNullOrEmpty(exp))
                {
                    return;
                }
                Console.WriteLine("Розбирається задане дерево парсером виразiв. Готово:");

                var parserAlfred = new ParserAlfred();
                var root = parserAlfred.Parse(exp);
                Console.WriteLine(root.ToString().TrimFirstAndLast());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
