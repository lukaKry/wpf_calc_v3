using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.CalculationsBuilders;
using System;
using System.Collections.Generic;

namespace lukaKry.Calc.ConsoleApp
{
    class Program
    {
        private provider = new CalculationsFactoryProvider();
        static void Main(string[] args)
        {
            // create instances for calculation builder, archiver, providers
            var provider = new CalculationsFactoryProvider();
            var archiver = new SimpleCalculationArchiver();
            var builderProvider = new CalculationBuilderProvider();

            ICalculationBuilder builder = builderProvider[BuilderMode.simple]();
            
            if (args.Length > 0)
            {
                if (args[0].ToUpper() == "EXTENDED") builder = builderProvider[BuilderMode.extended]();
            }

            var calculator = new Calculator(builder);

            if( builder is SimpleCalculationBuilder)
            {
                RunSimpleCalculationCycle(builder, );
            }
            
            

            Console.WriteLine("Would You like to see calculations history? (y/n)");
            if (ShouldShowCalculationsHistory(Console.ReadLine()))
            {
                ShowCalculationsHistory(archiver);
            }
        }

        private static void RunSimpleCalculationCycle(SimpleCalculationBuilder builder)
        {
            bool restart = false;
            do
            {
                Console.Clear();

                var firstNum = GetUserInput("first number");
                builder.AddNumber(firstNum);

                string calcTypeChoice = GetCalcTypeFromUser();
                builder.AddCalculation(provider[GetCalculationType(calcTypeChoice)].Create());

                decimal secondNum = GetUserInput("second number");
                builder.AddNumber(secondNum);

                try
                {
                    Console.WriteLine("result is: " + calculator.GetResult());
                    archiver.AddCalculation(builder.Build());
                }
                catch (Exception e)
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

        private static void ChooseCalculatorMode(string calculatorMode, ref Calculator calculator)
        {
            if ( calculatorMode.ToUpper() == "EXTENDED" ) calculator = new Calculator(new ExtendedCalculationBuilder());
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
                Console.WriteLine(calc + " = " + calc.GetResult());
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
