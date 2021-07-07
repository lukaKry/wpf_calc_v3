using System;
using lukaKry_Calc_Library.Logic;

namespace lukaKry.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instances for calculator and registry
            var registry = new RegistryConsoleApp();
            var calculator = new Calculator(registry);

            bool restart = false;
            do
            {
                // first number input
                var correctInput = false;
                decimal firstNum;
                do
                {
                    Console.WriteLine("Write first number");
                    correctInput = decimal.TryParse(Console.ReadLine(), out firstNum);
                    if (!correctInput) Console.WriteLine("Wrong input.");
                } while (!correctInput);

                calculator.EditCalculationAddNumber(firstNum);


                // choose type of calculation
                correctInput = false;
                string calcTypeChoice;
                do
                {
                    Console.WriteLine("Choose type of calculation\n+\tsum\n-\tsubtraction\n*\tmultiplication\n/\tdivision");
                    calcTypeChoice = Console.ReadLine();
                    correctInput = CalculationTypeChoiceCheck(calcTypeChoice);
                    if (!correctInput) Console.WriteLine("Wrong input.");
                } while (!correctInput);

                calculator.AddCalculationType(calcTypeChoice);


                // second number input 
                correctInput = false;
                decimal secondNum;
                do
                {
                    Console.WriteLine("Write second number");
                    correctInput = decimal.TryParse(Console.ReadLine(), out secondNum);
                    if (!correctInput) Console.WriteLine("Wrong input.");
                } while (!correctInput);

                try
                {
                    calculator.EditCalculationAddNumber(secondNum);
                    Console.WriteLine("result is: " + calculator.GetResult());
                }
                catch ( DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }

                restart = false;
                Console.WriteLine("Restart? (y/n)");
                var answer = Console.ReadLine();
                if (answer == "y") restart = true;
                Console.Clear();
                calculator.ResetCurrentCalculation();

            } while (restart);
            Console.WriteLine("Bye bye");
        }

        private static bool CalculationTypeChoiceCheck(string calcTypeChoice)
        {
            string[] validKeys = { "+", "-", "*", "/" };
            return Array.IndexOf(validKeys, calcTypeChoice) >= 0;
        }
    }
}
