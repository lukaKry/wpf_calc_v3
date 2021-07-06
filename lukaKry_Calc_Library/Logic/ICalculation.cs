using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("lukaKry_Calc_Library.UnitTests")]
namespace lukaKry_Calc_Library.Logic
{
    public interface ICalculation
    {
        decimal GetResult();

        ICalculation Arg1 { set; }     // a moze wylaczyc gettera na argumentach? skoro jest potrzebna tylko metoda getResult
        ICalculation Arg2 { set; }
    }
}
