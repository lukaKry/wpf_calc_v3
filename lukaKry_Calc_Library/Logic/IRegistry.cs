namespace lukaKry_Calc_Library.Logic
{
    public interface IRegistry
    {
        ICalculation GetLastItemFromRegistry();
        void AddItemToRegistry(ICalculation calc);
    }
}