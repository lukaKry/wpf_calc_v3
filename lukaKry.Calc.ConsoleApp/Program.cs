using lukaKry.Calc.Library.Logic;
using System;
using System.Collections.Generic;

namespace lukaKry.Calc.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instances for calculation builder, archiver
            var provider = new CalculationsFactoryProvider();
            var archiver = new SimpleCalculationArchiver();

            bool restart = false;
            do
            {
                Console.Clear();
                var calculationBuilder = new SimpleCalculationBuilder();
                var calculator = new Calculator(calculationBuilder);


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
                    archiver.SaveCalculation(calculationBuilder.ToString());
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

            // show calculaions history
            Console.WriteLine("Would You like to see calculations history? (y/n)");
            var answer2 = Console.ReadLine();
            if (answer2.ToUpper() == "Y")
            {
                var history = archiver.GetAllCalculations();

                foreach( var calc in history)
                {
                    Console.WriteLine(calc);

                }
            }
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
