using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Calc_v3.Logic
{
    public class Controller
    {
        private Calculator _calculator = new();
        private Display _display = new();       // dla poćwiczenia, można tu wbić interfejs IDisplay

        public void SymbolBtnPressed() 
        { 
            // _calculator.EditEquation()
        }
        public void NumberBtnPressed() 
        { 
            // _calculator.EditEquation()
            // _display.EditContent()
        }
        public void EqualSignBtnPressed() 
        { 
            // _calculator.GetResutl()
            // _calculator.AddEquationToTheHistory()
            // _display.EditContent()
        }
        public void Reset()
        {
            _calculator = new();
            _display = new();
        }

    }
}
