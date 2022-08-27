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
                /*it's better to use verbatim identifier ('@') to not concatenate different strings. Smth like:
                Console.WriteLine(@"Запишiть ваш вираз у форматi:
tвираз = <простий вираз> | <складний вираз>
tпростий вираз = <число> | <iм'я змiнної>
складний вираз = (<вираз><знак операцiї><вираз>)
Наприклад: ((62+3)/(8,45*7))-4");
                */
                Console.WriteLine("Запишiть ваш вираз у форматi:\n" +
                    "\tвираз = <простий вираз> | <складний вираз>\n" +
                    "\tпростий вираз = <число> | <iм'я змiнної>\n" +
                    "\tскладний вираз = (<вираз><знак операцiї><вираз>)\n" +
                    "Наприклад: ((62+3)/(8,45*7))-4");

                // var exp
                string? exp = Console.ReadLine();

                // string (small first letter). And condition should be reversed - if(string.IsNull(blabla)) {return;} to remove extra brackets below
                if (!String.IsNullOrEmpty(exp))
                {
                    Console.WriteLine("Розбирається задане дерево парсером виразiв. Готово:");

                    // var parserAlfred
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
