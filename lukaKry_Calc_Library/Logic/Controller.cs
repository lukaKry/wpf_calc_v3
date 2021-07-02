using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    public class Controller
    {
        private Calculator _calculator = new();
        private Display _display = new();

        public void SymbolBtnPressed() 
        { 
            // _calculator.EditEquation()
        }
        public void NumberBtnPressed() 
        {
            // _calculator.EditEquation()
            // _display.EditMainDisplayContent()
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
