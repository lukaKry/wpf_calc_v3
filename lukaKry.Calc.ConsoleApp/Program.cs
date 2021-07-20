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

                var firstNum = GetUserInput("first number");
                calculationBuilder.AddNumber(firstNum);

                string calcTypeChoice = GetCalcTypeFromUser();
                calculationBuilder.AddCalculation(provider[GetCalculationType(calcTypeChoice)].Create());

                decimal secondNum = GetUserInput("second number");
                calculationBuilder.AddNumber(secondNum);

                try
                {
                    Console.WriteLine("result is: " + calculator.GetResult());
                    archiver.AddCalculation(calculationBuilder.Build());
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

            Console.WriteLine("Would You like to see calculations history? (y/n)");
            if (ShouldShowCalculationsHistory(Console.ReadLine()))
            {
                ShowCalculationsHistory(archiver);
            }
        }

        private static bool ShouldShowCalculationsHistory(string answer)
        {
            return answer.ToUpper() == "Y";
        }

        private static void ShowCalculationsHistory(SimpleCalculationArchiver archiver)
        {
            var history = archiver.GetAllCalculations();

            foreach (var calc in history)
            {
                Console.WriteLine(calc);
            }
        }

        private static string GetCalcTypeFromUser()
        {
            var correctInput = false;
            string calcTypeChoice;
            do
            {
                Console.WriteLine("Choose type of calculation\n+\tsum\n-\tsubtraction\n*\tmultiplication\n/\tdivision");
                calcTypeChoice = Console.ReadLine();
                correctInput = CalculationTypeChoiceCheck(calcTypeChoice);
                if (!correctInput) Console.WriteLine("Wrong input.");
            } while (!correctInput);

            return calcTypeChoice;
        }

        private static decimal GetUserInput(string inputType)
        {
            var correctInput = false;
            decimal number;
            do
            {
                Console.WriteLine($"Write {inputType}");
                correctInput = decimal.TryParse(Console.ReadLine(), out number);
                if (!correctInput) Console.WriteLine("Wrong input.");
            } while (!correctInput);

            return number;
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
