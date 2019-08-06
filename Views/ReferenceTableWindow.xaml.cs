using System.ComponentModel;
using System.Windows;
using Roman.Models;

namespace Roman.Windows
{
    public partial class ReferenceTableWindow : Window
    {
        public ReferenceTableWindow()
        {
            InitializeComponent();
        }

        public void ReferenceTableWindow_Closing(object sender, CancelEventArgs e)
        {
            ReferenceTableModel.windowOpen = false;
        }
    }
}
