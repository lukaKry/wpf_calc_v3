using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    interface IState
    {
        void ClickSymbol();
        void ClickNumber () { }
        void ClickComma() { }
        void ClickEqualSign() { }
    }
}
