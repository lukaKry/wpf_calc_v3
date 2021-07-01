namespace Wpf_Calc_v3.Logic
{
    interface ICalculation
    {
        decimal Calculate();
        void SetArgs(decimal x, decimal y);
    }
}