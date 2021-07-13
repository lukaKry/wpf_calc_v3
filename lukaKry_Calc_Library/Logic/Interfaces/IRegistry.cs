namespace lukaKry_Calc_Library.Logic
{
    public interface IRegistry
    {
        ICalculation GetLastItem();
        void AddItem(ICalculation calc);
    }
}