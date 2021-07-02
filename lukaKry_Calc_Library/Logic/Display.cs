namespace lukaKry_Calc_Library.Logic
{
    internal class Display
    {
        private string _mainDisplay;

        internal string MainDisplay { get; set; }

        internal void EditMainDisplayContent(string newContent = "")
        {
            _mainDisplay = newContent;
        }
    }
}