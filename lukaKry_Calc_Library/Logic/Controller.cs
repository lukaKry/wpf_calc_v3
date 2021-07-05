using lukaKry_Calc_Library.Logic.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    public class Controller
    {
        internal IState State { get; set; }
        private Calculator _calculator = new();
        private Display _display = new();

        public Controller()
        {
            State = new StateInit(this);
        }

        public void SymbolBtnPressed() 
        {
            State.ClickSymbol();
        }
        public void NumberBtnPressed() 
        {
            State.ClickNumber();
        }

        public void CommaBtnPressed()
        {
            State.ClickComma();
        }

        public void EqualSignBtnPressed() 
        {
            // _calculator.GetResutl()
            // _calculator.AddEquationToTheHistory()
            // _display.EditMainDisplayContent()

            
            
        }
        public void Reset()
        {
            _calculator = new();
            _display = new();
        }

    }
}
