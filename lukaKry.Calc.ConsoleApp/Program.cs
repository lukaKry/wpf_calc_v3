using lukaKry.Calc.Library.Logic;
using lukaKry.Calc.Library.Logic.CalculationsBuilders;
using System;
using System.Collections.Generic;

namespace lukaKry.Calc.ConsoleApp
{
    class Program
    {
        private static CalculationsFactoryProvider _calculationProvider = new();
        private static SimpleCalculationArchiver _archiver = new();
        private static CalculationBuilderProvider _builderProvider = new();
        private static ICalculationBuilder _builder = _builderProvider[BuilderMode.simple]();
        private static Calculator _calculator;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToUpper() == "EXTENDED") _builder = _builderProvider[BuilderMode.extended]();
            }

            _calculator = new Calculator(_builder);

            if( _builder is SimpleCalculationBuilder)
            {
                RunSimpleCalculationCycle();
            }

            if ( _builder is ExtendedCalculationBuilder)
            {
                RunExtendedCalculationCycle();
            }
            
            Console.WriteLine("Would You like to see calculations history? (y/n)");
            if (ShouldShowCalculationsHistory(Console.ReadLine()))
            {
                ShowCalculationsHistory(_archiver);
            }
        }

        private static void RunExtendedCalculationCycle()
        {
            do
            {
                Console.Clear();

                var num = GetUserInput("number");
                _builder.AddNumber(num);

                do
                {
                    string calcTypeChoice = GetCalcTypeFromUser();
                    _builder.AddCalculation(_calculationProvider[GetCalculationType(calcTypeChoice)].Create());

                    var num2 = GetUserInput("number");
                    _builder.AddNumber(num2);
                } while (IsEndOfEquation());

                try
                {
                    _archiver.AddCalculation(_builder.Build());
                    Console.WriteLine(_builder.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (ShouldRestart());
        }

        private static bool IsEndOfEquation()
        {
            Console.WriteLine("Press = to solve equation or anything else to continue");
            bool isEnd = !Equals(Console.ReadKey().Key, ConsoleKey.OemPlus);
            Console.WriteLine("\b");
            return isEnd;
        }

        private static void RunSimpleCalculationCycle()
        {
            do
            {
                Console.Clear();

                var firstNum = GetUserInput("first number");
                _builder.AddNumber(firstNum);

                string calcTypeChoice = GetCalcTypeFromUser();
                _builder.AddCalculation(_calculationProvider[GetCalculationType(calcTypeChoice)].Create());

                decimal secondNum = GetUserInput("second number");
                _builder.AddNumber(secondNum);

                try
                {
                    Console.WriteLine("result is: " + _calculator.GetResult());
                    _archiver.AddCalculation(_builder.Build());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (ShouldRestart());
            Console.WriteLine("Bye bye");
        }

        private static bool ShouldRestart()
        {
            Console.WriteLine("Restart? (y/n)");
            return Console.ReadLine().ToUpper() == "Y";
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
                Console.WriteLine(calc + "= " + calc.GetResult());
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
