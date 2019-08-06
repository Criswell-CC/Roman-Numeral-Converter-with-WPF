using System;
using System.Windows;
using System.Windows.Input;
using Roman.ViewModels;

namespace Roman
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ConverterViewModel();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            CheckLogMenuItem.CommandTarget = this;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
                ConverterViewModel.DisplayResult();
                Keyboard.Focus(InputBox);
                InputBox.Text = "";
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.Button_OnClick(sender, e);
            }
        }

        private void Close_Executed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
