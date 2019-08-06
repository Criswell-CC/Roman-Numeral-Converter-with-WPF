using Roman.Windows;

namespace Roman.Models
{
    public class ReferenceTableModel
    {
        public static bool windowOpen;

        public static void OpenTable()
        {
            ReferenceTableWindow referenceTableWindow = new ReferenceTableWindow();
            referenceTableWindow.Show();
            windowOpen = true;
        }
    }
}
