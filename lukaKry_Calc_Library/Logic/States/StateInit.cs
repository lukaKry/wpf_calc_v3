using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.States
{
    internal class StateInit : State
    {
        Controller _controller;

        public StateInit(Controller controller) : base(controller)
        {
            _controller = controller;
        }

        internal override void ClickSymbol() 
        { 
            // does nothing 
        }
        internal override void ClickNumber(string digit) 
        {
            _controller.Display.MainDisplay += digit;
        }
        internal override void ClickComma() 
        {
            _controller.Display.MainDisplay += ",";

            _controller.State = new StateEditFloatingPointNumber(_controller);
        }
        internal override void ClickEqualSign() 
        { 
            // does nothing
        }
    }
}
