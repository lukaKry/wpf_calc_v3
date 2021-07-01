namespace lukaKry_Calc_Wpf.Logic
{
    interface ICalculation
    {
        decimal Calculate();
        void SetArgs(decimal x, decimal y);
    }
}