﻿using lukaKry_Calc_Library.Logic;
using lukaKry_Calc_Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace lukaKry_Calc_Library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public Calculator Calculator { get; set; }

        private string _mainDisplay;

        public event PropertyChangedEventHandler PropertyChanged;

        public string MainDisplay
        {
            get { return _mainDisplay; }
            set
            {
                _mainDisplay = value;
                PropertyChanged?.Invoke(this, new(nameof(MainDisplay)));
            }
        }
        public RegistryWpfApp Registry { get; set; } = new();
        public ICalculationBuilder Builder { get; set; } = new SimpleCalculationBuilder();


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Calculator = new(Registry, Builder);

        }


        private void On_MemoryButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private void On_ClearButton_Clicked(object sender, RoutedEventArgs e)
        {
            Calculator.ResetCurrentCalculation();
            MainDisplay = "";
        }

        private void On_NumberButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                Builder.AddNumber(Convert.ToDecimal(button.Uid));
                MainDisplay += button.Uid;
            }
            catch ( DivideByZeroException ex)
            {
               _ = MessageBox.Show(ex.Message);
            }
        }

        private void On_SymbolButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            MainDisplay += button.Uid;
            Builder.AddCalculation(button.Uid);
        }

        private void On_EqualSignButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainDisplay += "=" + Calculator.GetResult();

        }

        private void On_CommaButton_Clicked(object sender, RoutedEventArgs e)
        {

        }

        private static CalculationType GetCalculationType(string calcTypeChoice)
        {
            switch (calcTypeChoice)
            {
                case "-": return CalculationType.Subtraction;
                case "*": return CalculationType.Multiplication;
                case "/": return CalculationType.Division;
                default: return CalculationType.Sum;
            }

        }
    }
}
