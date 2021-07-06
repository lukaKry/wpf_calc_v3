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
        internal State State { get; set; }
        internal Calculator Calculator { get; set; }
        internal Display Display = new();

        public Controller()
        {
           State = new StateInit(this);
        }

        public void SymbolBtnPressed() 
        {
           // State.ClickSymbol();
        }
        public void NumberBtnPressed(string digit) 
        {
            State.ClickNumber(digit);
            
            Display.MainDisplay += digit;


            /*
            decimal result;

            if (decimal.TryParse(digit, out result))
                if (result >= 0 && result <= 9)
                    _calculator.EditCalculationsArg2(new Number(result));
            */

        }

        public void CommaBtnPressed()
        {
           // State.ClickComma();
        }

        public void EqualSignBtnPressed() 
        {
            // _calculator.GetResutl()
            // _calculator.AddEquationToTheHistory()
            // _display.EditMainDisplayContent()

            
            
        }
        public void Reset()
        {
            
        }

    }
}
