namespace lukaKry.Calc.Library.Logic
{
    public interface ICalculationBuilder
    {
        void AddNumber(decimal number);
        void AddCalculation(ISettableCalculation calculation);
        ICalculation Build();
        void Reset();
    }
}