using System;
using System.Windows;
using System.Windows.Input;
using Roman.Commands;
using Roman.Models;

namespace Roman.ViewModels
{
    public class ConverterViewModel
    {
        public static string Input { get; set; }

        public static void DisplayResult()
        {
            try
            {
                if (Input == null)
                    throw new ArgumentNullException();

                int _decimal;
                int.TryParse(Input, out _decimal);

                if (_decimal != 0)
                {
                    DecimalModel decimalModel = new DecimalModel();

                    if (decimalModel != null)
                    {
                        decimalModel.Decimal = _decimal;
                        decimalModel.DisplayResult();
                        LogModel.InputLog.Add($"{_decimal} was converted to {decimalModel.ConvertedNumeral}");
                    }
                }
                else
                {
                    RomanModel romanModel = new RomanModel();

                    if (romanModel != null)
                    {
                        romanModel.Numeral = Input;
                        if (romanModel.Numeral != null)
                        {
                            romanModel.DisplayResult();
                            LogModel.InputLog.Add($"{Input.ToUpper()} was converted to {romanModel.ConvertedDecimal}");
                        }
                    }
                }
            }

            catch (ArgumentException e)
            {
                MessageBox.Show("Invalid input");
            }
        }
        #region Log Commands
        private DelegateCommand openLog { get; set; }
        private DelegateCommand saveLog { get; set; }
        private DelegateCommand newLog { get; set; }
        public ICommand OpenLogCommand
        {
            get
            {
                if (openLog == null)
                    openLog = new DelegateCommand(new Action(OpenLogExecuted), new Func<bool>(OpenLogCanExecute));
                return openLog;
            }
        }

        public ICommand SaveLogCommand
        {
            get
            {
                if (saveLog == null)
                    saveLog = new DelegateCommand(new Action(SaveLogExecuted), new Func<bool>(SaveLogCanExecute));
                return saveLog;
            }
        }

        public ICommand NewLogCommand
        {
            get
            {
                if (newLog == null)
                   newLog = new DelegateCommand(new Action(NewLogExecuted), new Func<bool>(NewLogCanExecute));
                return newLog;
            }

        }

        public void OpenLogExecuted()
        {
            LogModel.OpenLog();
        }

        public bool OpenLogCanExecute()
        {
            return true;
        }

        public void SaveLogExecuted()
        {
            LogModel.SaveLog();
        }

        public bool SaveLogCanExecute()
        {
            return true;
        }

        public void NewLogExecuted()
        {
            LogModel.NewLog();
        }

        public bool NewLogCanExecute()
        {
            return true;
        }
        #endregion

        #region Reference Table Command
        private DelegateCommand openTable { get; set; }
        public ICommand OpenTableCommand
        {
            get
            {
                if (openTable == null)
                    openTable= new DelegateCommand(new Action(OpenTableExecuted), new Func<bool>(OpenTableCanExecute));
                return openTable;
            }
        }

        public void OpenTableExecuted()
        {
            ReferenceTableModel.OpenTable();
        }

        public bool OpenTableCanExecute()
        {
            return true;
        }
        #endregion
    }
}
