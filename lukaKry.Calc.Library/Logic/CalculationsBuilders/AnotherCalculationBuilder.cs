using lukaKry.Calc.Library.Logic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry.Calc.Library.Logic.CalculationsBuilders
{
    class AnotherCalculationBuilder : ICalculationBuilder
    {
        private List<decimal> _numbers = new() { 0 };
        private CalculationsFactoryProvider _provider = new();

        private List<ISettableCalculation> _calculations = new() { new Sum() };

        public void AddCalculation(ISettableCalculation calculation)
        {
            if (_numbers.Count() > _calculations.Count())
            {
                _calculations.Add(calculation);
            }
            else
            {
                _calculations[^1] = calculation;
            }
        }

        public void AddNumber(decimal number)
        {
            if (_numbers.Count() > _calculations.Count() + 1)
            {
                _numbers[^1] = number;
            }
            else
            {
                _numbers.Add(number);
            }
        }


        public ICalculation Build()
        {
            throw new NotImplementedException();

            // ustawia pole _result = Solve();

            // wówczas wywołując metodę toString() widoczne byłoby wynik... ale to też można i w ToString() użyć...



            // build wywoałany zaraz po utworzeniu buildera

            // build wywołany gdy jest za mało liczb - zduplikuj ostatnio wprowadzoną liczbę

            // build wywoałny gdy jest za dużo liczb

            // build wywołany gdy jest odpowiednia liczba kalkulacji i liczb
                
        }

        public void Reset()
        {
            // ustawia buildera do wartości początkowych
            throw new NotImplementedException();
        }

        public decimal Solve(List<ISettableCalculation> calcs, List<decimal> nums)
        {
            // 1. znajdz najwyższy priorytet na liście kalkulacji
            // 2. wybierz pierwszą kalkulację z najwyższym priorytetem, pobierz jej indeks
            // 3. utwórz kalkulację zgodnie z symbolem
            // 4. dodaj do niej dwa argumenty na pozycjach odpowiadających 
            // 5. usuń wykonaną kalkulację z listy
            // 6. usuń argumenty z listy 
            // 7. w miejsce pierwszego argumentu wpisz wynik kalkulacji 
            // 8. powołaj funkcję jeszcze raz 
            // 9. wykonuj funkcję tak długo, aż lista kalkulacji będzie pusta, a na liscie numerów bedzie tylko jedna wartość

            if (!calcs.Any()) return nums[0];

            var highestPriority = calcs.Max(p => p.Priority);
            var calculationToBeSolved = calcs.FirstOrDefault(p => p.Priority == highestPriority);
            var indexOfCalculationToBeSolved = calcs.IndexOf(calculationToBeSolved);

            calculationToBeSolved.Arg1 = new Number(nums[indexOfCalculationToBeSolved]);    // w takim przypadku możnaby dodać konstruktor z dwoma decimalami, który od razu by pakował i rozwiązywał równanie
            calculationToBeSolved.Arg2 = new Number(nums[indexOfCalculationToBeSolved+1]);

            calcs.RemoveAt(indexOfCalculationToBeSolved);
            nums.RemoveAt(indexOfCalculationToBeSolved + 1);
            nums[indexOfCalculationToBeSolved] = calculationToBeSolved.GetResult();

            return Solve(calcs, nums);
        }
    }
}
