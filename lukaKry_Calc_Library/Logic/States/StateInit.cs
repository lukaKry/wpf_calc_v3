using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic.States
{
    internal class StateInit : IState
    {
        Controller _controller;

        public StateInit(Controller controller)
        {
            _controller = controller;
        }

        void ClickSymbol() 
        { 
            // does nothing 
        }
        void ClickNumber() 
        {
            //_controller.State = new 

            // _calculator.EditEquation()
            // _display.EditMainDisplayContent()


        }
        void ClickComma() 
        {
            // _display.EditMainDisplayContent();
        }
        void ClickEqualSign() 
        { 
            // does nothing
        }

        void IState.ClickSymbol()
        {
            throw new NotImplementedException();
        }
    }
}
