namespace lukaKry.Calc.Library.Logic
{
    public interface ICalculationBuilder
    {
        void AddNumber(decimal number);
        void AddCalculation(CalculationType calcType);
        ICalculation Build();
        void Reset();
    }
}