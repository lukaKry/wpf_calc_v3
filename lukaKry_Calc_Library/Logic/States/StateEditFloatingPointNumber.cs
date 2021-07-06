using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.States
{
    class StateEditFloatingPointNumber : State
    {
        Controller _controller;

        public StateEditFloatingPointNumber(Controller controller) : base(controller)
        {
            _controller = controller;
        }

        internal override void ClickComma()
        {
            // does nothing
        }

        internal override void ClickEqualSign()
        {
            throw new NotImplementedException();
        }

        internal override void ClickNumber(string digit)
        {
            throw new NotImplementedException();
        }

        internal override void ClickSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
