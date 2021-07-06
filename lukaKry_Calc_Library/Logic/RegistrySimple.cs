using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    class RegistrySimple : IRegistry
    {
        List<ICalculation> _simpleRegistry = new();
        public void AddItemToRegistry(ICalculation calc)
        {
            _simpleRegistry.Add(calc);
        }

        public ICalculation GetLastItemFromRegistry()
        {
            if (_simpleRegistry.Count < 1) throw new InvalidOperationException();
            return _simpleRegistry[^1];
        }
    }
}
