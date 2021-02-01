using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUi
{
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }

        string GetCategory(ITrade trade);
        string GetSector(string sector);
    }
}
