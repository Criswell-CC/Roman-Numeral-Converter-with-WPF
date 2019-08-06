using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using Roman.Windows;

namespace Roman.Models
{
    public class LogModel
    {
        public static List<string> InputLog = new List<string>();
        public static bool windowOpen { get; set; }

        public static void SaveLog()
        {
            try
            {
                if (InputLog.Count == 0)
                    throw new NullReferenceException();

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text file (*.txt)|*.txt";

                string SaveString = String.Join("\n", InputLog);

                if (saveDialog.ShowDialog() == true)
                    File.WriteAllText("Log.txt", SaveString);
            }

            catch (NullReferenceException e)
            {
                MessageBox.Show("Log is currently empty");
            }
        }
        public static void OpenLog()
        {
            if (windowOpen)
                return;

            try { 
                if (InputLog.Count == 0)
                    throw new NullReferenceException();

                string SaveString = String.Join("\n", InputLog);

                LogWindow logWindow = new LogWindow();
                logWindow.textBlock.Text = SaveString;

                windowOpen = true;
                logWindow.Show();
            }

            catch (NullReferenceException e)
            {
                MessageBox.Show("Log is currently empty");
            }
        }

        public static void NewLog()
        {
            InputLog.Clear();
        }
    }
}
     