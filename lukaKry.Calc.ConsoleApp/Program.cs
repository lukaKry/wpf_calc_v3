using System;
using System.Collections.Generic;
using lukaKry_Calc_Library.Logic;

namespace lukaKry.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instances for calculator, registry and calculation builder, add dictionary
            
            var provider = new CalculationsFactoryProvider();

            bool restart = false;
            do
            {
                Console.Clear();
                var registry = new RegistryConsoleApp();
                var calculationBuilder = new SimpleCalculationBuilder();
                var calculator = new Calculator(registry, calculationBuilder);


                // first number input
                var correctInput = false;
                decimal firstNum;
                do
                {
                    Console.WriteLine("Write first number");
                    correctInput = decimal.TryParse(Console.ReadLine(), out firstNum);
                    if (!correctInput) Console.WriteLine("Wrong input.");
                } while (!correctInput);

                calculationBuilder.AddNumber(firstNum);

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

                calculationBuilder.AddCalculation(provider[GetCalculationType(calcTypeChoice)].Create());

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
                    calculationBuilder.AddNumber(secondNum);
                    Console.WriteLine("result is: " + calculator.GetResult());
                }
                catch ( Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                restart = false;
                Console.WriteLine("Restart? (y/n)");
                var answer = Console.ReadLine();
                if (answer == "y") restart = true;
                


            } while (restart);
            Console.WriteLine("Bye bye");
        }

        private static CalculationType GetCalculationType(string calcTypeChoice)
        {
            switch (calcTypeChoice) 
            {
                case "-": return CalculationType.Subtraction;
                case "*": return CalculationType.Multiplication;
                case "/": return CalculationType.Division;
                default: return CalculationType.Sum;
            }

        }

        private static bool CalculationTypeChoiceCheck(string calcTypeChoice)
        {
            string[] validKeys = { "+", "-", "*", "/" };
            return Array.IndexOf(validKeys, calcTypeChoice) >= 0;
        }
    }
}
