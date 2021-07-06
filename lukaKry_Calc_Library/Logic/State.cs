using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    internal abstract class State
    {
        Controller _controller;

        protected State(Controller controller)
        {
            _controller = controller;
        }
        internal abstract void ClickSymbol();
        internal abstract void ClickNumber(string digit);
        internal abstract void ClickComma();
        internal abstract void ClickEqualSign();
    }
}
