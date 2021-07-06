using lukaKry_Calc_Library.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.ConsoleApp
{
    class RegistryConsoleApp : IRegistry
    {
        private List<ICalculation> _registry = new();

        public void AddItemToRegistry(ICalculation calc)
        {
            _registry.Add(calc);
        }

        public ICalculation GetLastItemFromRegistry()
        {
            return _registry[^1];
        }
    }
}
