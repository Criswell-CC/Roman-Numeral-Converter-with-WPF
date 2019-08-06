using System;
using System.Collections.Generic;
using System.Windows;

namespace Roman.Models
{
    public class DecimalModel
    {
        private int _decimal;
        public string ConvertedNumeral { get; private set; }
        public int Decimal
        {
            get { return _decimal; }

            set
            {
                try
                {
                    if (value < 0 || value > 3999)
                    {
                        throw new ArgumentException();
                    }
                    else if (value == 0)
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        _decimal = value;
                    }
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show("Invalid input");
                    _decimal = 0;
                }
            }
        }

        public void DisplayResult()
        {
            ConvertedNumeral = ConvertToNumeral(_decimal);
            MessageBox.Show(ConvertedNumeral);
        }

        private char toChar(int input)
        {
            switch (input)
            {
                case 1: return 'I';
                case 5: return 'V';
                case 10: return 'X';
                case 50: return 'L';
                case 100: return 'C';
                case 500: return 'D';
                case 1000: return 'M';
                default: return '0';
            }
        }

        public string ConvertToNumeral(int _decimal)
        {
            int i, c = 0;
            List<char> numeral = new List<char>();

            if ((_decimal / 1000) > 0)
            {
                for (i = c; i < c + (_decimal / 1000); i++)
                {
                    numeral.Add(toChar(1000));
                }

                c = c + (_decimal / 1000);
                _decimal = _decimal - (1000 * (_decimal / 1000));
            }

            if (_decimal < 1000 && _decimal > 899)
            {
                numeral.Add('C');
                c++;
                numeral.Add('M');
                c++;
                _decimal = _decimal - 900;
            }

            if (_decimal / 500 > 0)
            {
                for (i = c; i < c + (_decimal / 500); i++)
                {
                    numeral.Add(toChar(500));
                }
                c = c + (_decimal / 500);
                _decimal = _decimal - (500 * (_decimal / 500));
            }

            if (_decimal < 500 && _decimal > 399)
            {
                numeral.Add('C');
                c++;
                numeral.Add('D');
                c++;
                _decimal = _decimal - 400;
            }

            if (_decimal / 100 > 0)
            {
                for (i = c; i < c + (_decimal / 100); i++)
                {
                    numeral.Add(toChar(100));
                }
                c = c + (_decimal / 100);
                _decimal = _decimal - (100 * (_decimal / 100));
            }

            if (_decimal < 100 && _decimal > 89)
            {
                numeral.Add('X');
                c++;
                numeral.Add('C');
                c++;
                _decimal = _decimal - 90;
            }

            if (_decimal / 50 > 0)
            {
                for (i = c; i < c + (_decimal / 50); i++)
                {
                    numeral.Add(toChar(50));
                }
                c = c + (_decimal / 50);
                _decimal = _decimal - (50 * (_decimal / 50));
            }

            if (_decimal < 50 && _decimal > 39)
            {
                numeral.Add('X');
                c++;
                numeral.Add('L');
                c++;
                _decimal = _decimal - 40;
            }

            if (_decimal / 10 > 0)
            {
                for (i = c; i < c + (_decimal / 10); i++)
                {
                    numeral.Add(toChar(10));
                }
                c = c + (_decimal / 10);
                _decimal = _decimal - (10 * (_decimal / 10));
            }

            if (_decimal == 9)
            {
                numeral.Add('I');
                c++;
                numeral.Add('X');
                c++;
                _decimal = _decimal - 9;
            }

            if (_decimal / 5 > 0)
            {
                for (i = c; i < c + (_decimal / 5); i++)
                {
                    numeral.Add(toChar(5));
                }
                c = c + (_decimal / 5);
                _decimal = _decimal - (5 * (_decimal / 5));
            }

            if (_decimal == 4)
            {
                numeral.Add('I');
                c++;
                numeral.Add('V');
                c++;
                _decimal = _decimal - 4;
            }

            if (_decimal / 1 > 0)
            {

                for (i = c; i < c + (_decimal / 1); i++)
                {
                    numeral.Add(toChar(1));
                }

                c = c + (_decimal / 1);
                _decimal = _decimal - (1 * (_decimal / 1));
            }

            string resultString = new string(numeral.ToArray());
            return resultString;
        }
    }
}
