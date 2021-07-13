using lukaKry_Calc_Library.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Wpf
{
    public class RegistryWpfApp : IRegistry
    {
        private List<ICalculation> _registry = new();

        public void AddItem(ICalculation calc)
        {
            _registry.Add(calc);
        }

        public ICalculation GetLastItem()
        {
            return _registry[^1];
        }
    }
}
