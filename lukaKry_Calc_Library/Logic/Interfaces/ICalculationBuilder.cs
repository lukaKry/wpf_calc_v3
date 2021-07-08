namespace lukaKry_Calc_Library.Logic
{
    public interface ICalculationBuilder
    {
        void AddNumber(decimal number);
        ICalculation Build();
    }
}