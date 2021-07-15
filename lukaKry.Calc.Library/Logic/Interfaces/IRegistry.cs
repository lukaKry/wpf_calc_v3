namespace lukaKry.Calc.Library.Logic
{
    public interface IRegistry
    {
        ICalculation GetLastItem();
        void AddItem(ICalculation calc);
    }
}