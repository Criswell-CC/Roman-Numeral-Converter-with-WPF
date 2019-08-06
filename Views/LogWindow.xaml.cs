using System.ComponentModel;
using System.Windows;
using Roman.Models;

namespace Roman.Windows
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        public LogWindow()
        {
            InitializeComponent();
            DataContext = new Roman.Models.LogModel();
        }

        public void LogWindow_Closing(object sender, CancelEventArgs e)
        {
            LogModel.windowOpen = false;
        }
    }
}
