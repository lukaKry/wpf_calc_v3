using lukaKry_Calc_Library.Logic.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lukaKry_Calc_Library.Logic
{
    public class CalculationsDictionary
    {
        // dlaczego to jest zle a kod na dole jest lepszy? ano dlatego, ze po wywolaniu metody getDictionary na obiektcie CalculationsDictionary
        // tak naprawde wspoldzielimy stan prywatny klasy z kims innym(tym kto wywoluje) wiec to juz jest pierwszy blad
        // drugi to to, ze kazdorazowe wywolanie metody dictionary z odpowiednim symbolem zawsze zwroci ta sama referencje, do nowego obiektu
        // poniewaz zapis w dictionary typu "+", new Sum() stworzy nowy obiekt Sum tylko raz, a za kazdym razem gdy ktos o niego zapyta, to dostanie ta sama referencje w zamian
        // a przeciez nie o to chodzi w tej metodzie
        // tu chodzi o to, ze kazde zapytanie skierowane do tej klasy zwroci konkretne faktory, ktore z kolei uruchomi swoja metode create i w ten sposob uzyskamy odpowiednia nowa instancje docelowego obiektu

        private readonly Dictionary<string, ISettable> _calculationsDictionary;
        public CalculationsDictionary()
        {
            _calculationsDictionary = new() { 
                { "+", new Sum() },         // to wlasnie ten kod jest nieladny i niebezpieczny... 
                { "-", new Subtraction() },
                { "*", new Multiplication() },
                { "/", new Division() } };
        }

        public Dictionary<string, ISettable> GetDictionary()
        {
            return _calculationsDictionary;
        }


        public void Bla()
        {
            var provider = new CalculationFactoryProvider();
            provider[CalculationType.Sum].Create();
        }
    }





    public interface ICalculationFactory
    {
        ICalculation Create();
    }

    /*class FooFactory : ICalculationFactory
    {
        public ICalculation Create()
        {
            throw new NotImplementedException();
        }
    }*/

    class SumCalculationFactory : ICalculationFactory
    {
        public ICalculation Create()
        {
            throw new NotImplementedException();
        }
    }

    public enum CalculationType
    {
        Sum,
        Substract,
        Multply,
        Division
    }
    public class CalculationFactoryProvider
    {
        private readonly Dictionary<CalculationType,  Func<ICalculationFactory>> _factories;

        public CalculationFactoryProvider() : this(GetPredefinedFactories())
        {
        }

        public CalculationFactoryProvider(Dictionary<CalculationType, Func<ICalculationFactory>> factories)
        {
            _factories = factories;
        }

        public ICalculationFactory this[CalculationType type]
        {
            get { return _factories[type](); }
        }

        private static Dictionary<CalculationType, Func<ICalculationFactory>> GetPredefinedFactories()
        {
            return new Dictionary<CalculationType, Func<ICalculationFactory>>()
            { {CalculationType.Sum, () =>new SumCalculationFactory() }  };
        }
    }
}
