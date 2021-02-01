using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUi
{
    public class Trade : ITrade
    {
        public double Value
        {
            get; set;
        }

        public string ClientSector
        {
            get; set;
        }

        public string GetCategory(ITrade trade)
        {
            List<string> tradeCategories = new List<string> { "LOWRISK", "MEDIUMRISK", "HIGHRISK", "NOTCALCULATEDRISK" };
            string result = tradeCategories[3];

            if(trade.ClientSector != "")
            {
                if (trade.ClientSector == "Public")
                    result = trade.Value < 1000000
                           ? tradeCategories[0]
                           : tradeCategories[1];
                else
                    result = trade.Value > 1000000
                            ? tradeCategories[2]
                            : tradeCategories[3];
            }

            return result;
        }

        public string GetSector(string sector)
        {
            var result = sector == "0"
                        ? "Public"
                        : sector == "1"
                        ? "Private"
                        : "";

            return result;
        }
    }
}
