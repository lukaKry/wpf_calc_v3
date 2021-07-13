using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    class RegistrySimple : IRegistry
    {
        List<ICalculation> _list = new();
        public int Count => _list.Count;

        public void AddItem(ICalculation calc)
        {
            _list.Add(calc);
        }

        public ICalculation GetLastItem()
        {
            if (!_list.Any()) throw new InvalidOperationException();
            return _list.Last();
        }
    }
}
