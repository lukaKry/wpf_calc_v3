namespace lukaKry_Calc_Library.Logic
{
    public interface ISettableCalculation
    {
        ICalculation Arg1 { get; set; }
        ICalculation Arg2 { get; set; }
    }
}