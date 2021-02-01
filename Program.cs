using BankTrade;
using System;
using System.Collections.Generic;

namespace ConsoleUi
{
    class Program
    {
        static void Main(string[] args)
        {

            string sector;
            string moreTrade = string.Empty;

            List<string> categories = new List<string>();
            List<ITrade> portfolio = new List<ITrade>();

            Console.WriteLine("Bank's Portifolio \n");

            while (moreTrade != "0")
            {
                Trade trade = new Trade();

                Console.WriteLine("What is the value for your trade? " + Environment.NewLine);
                var valid = double.TryParse(Console.ReadLine(), out double value);

                if (!valid)
                    continue;
                trade.Value = value;

                Console.WriteLine("Is your trade Public or Private?");
                Console.WriteLine("0 - Public");
                Console.WriteLine("1 - Private" + Environment.NewLine);
                sector = Console.ReadLine();
                Console.WriteLine();

                trade.ClientSector = trade.GetSector(sector);

                Console.WriteLine("Do you want to continue?");
                Console.WriteLine("0 - Finish Operation");
                Console.WriteLine("1 - Next Trade " + Environment.NewLine);
                moreTrade = Console.ReadLine();
                Console.WriteLine();

                portfolio.Add(trade);
                categories.Add(trade.GetCategory(trade));
            }

            Console.WriteLine("[{0}]", string.Join(", ", categories));
        }
    }
}
