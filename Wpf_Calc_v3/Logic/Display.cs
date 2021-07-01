namespace lukaKry_Calc_Wpf.Logic
{
    internal class Display
    {
        private string _mainDisplay;

        public string MainDisplay { get; set; }

        public void EditMainDisplayContent(string newContent = "")
        {
            _mainDisplay = newContent;
        }
    }
}