using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("lukaKry_Calc_Library.UnitTests")]
namespace lukaKry_Calc_Library.Logic
{
    interface ICalculation
    {
        decimal GetResult();
    }
}
