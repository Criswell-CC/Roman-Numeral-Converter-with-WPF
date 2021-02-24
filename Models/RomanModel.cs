using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Roman.Models
{
    public class RomanModel
    {
        private string _numeral;
        public int ConvertedDecimal { get; private set; }
        public string Numeral
        {
            get { return _numeral; }

            set
            {
                try
                {
                    if (value.Length < 1 || value.Length > 15 || value == null)
                        throw new ArgumentException();

                    value = value.ToUpper();
                    List<char> inputNumeral = new List<char>(value);

                    for (int i = 0; i < inputNumeral.Count; i++)
                    {
                        if (inputNumeral[i] != 'I' && inputNumeral[i] != 'V' && inputNumeral[i] != 'X' && inputNumeral[i] != 'L' && inputNumeral[i] != 'C' && inputNumeral[i] != 'D' && inputNumeral[i] != 'M')
                            throw new ArgumentException();

                        //check if more than 4 of same character in a row
                        else if (i + 3 < (inputNumeral.Count) && inputNumeral[i] == inputNumeral[i + 1] && inputNumeral[i + 1] == inputNumeral[i + 2] && inputNumeral[i + 2] == inputNumeral[i + 3])
                            throw new ArgumentException();

                        //check if "VV" occurs
                        else if (i != (inputNumeral.Count - 1) && inputNumeral[i] == 'V' && inputNumeral[i] == inputNumeral[i + 1])
                            throw new ArgumentException();
                    
                        //check if "LL" occurs
                        else if (i != (inputNumeral.Count - 1) && inputNumeral[i] == 'L' && inputNumeral[i] == inputNumeral[i + 1])
                            throw new ArgumentException();

                        //check if "DD" occurs
                        else if (i != (inputNumeral.Count - 1) && inputNumeral[i] == 'D' && inputNumeral[i] == inputNumeral[i + 1])
                            throw new ArgumentException();

                        else if (i != (inputNumeral.Count - 1) && toInt(inputNumeral[i + 1]) > toInt(inputNumeral[i]))
                        {
                            if (inputNumeral[i] == 'I' && inputNumeral[i + 1] != 'V' && inputNumeral[i + 1] != 'X')
                                throw new ArgumentException();

                            //all 5-based numerals can't occur before a numeral larger than given numeral; i.e., the "subtractive method" only applies to 10-based numerals
                            else if (inputNumeral[i] == 'V' || inputNumeral[i] == 'L' || inputNumeral[i] == 'D')
                                throw new ArgumentException();

                            //check if "X" occurs before D or M, which is invalid; X can only be subtracted from L and C
                            else if (inputNumeral[i] == 'X' && inputNumeral[i + 1] != 'L' && inputNumeral[i + 1] != 'C')
                                throw new ArgumentException();
                        }
                    }

                    _numeral = new String(inputNumeral.ToArray());
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show("Invalid input");
                }

                catch (NullReferenceException e)
                {
                    Numeral = null;
                }
            }
        }
        public void DisplayResult()
        {
            ConvertedDecimal = ConvertToDecimal(_numeral);
            MessageBox.Show(ConvertedDecimal.ToString());
        }
        private int toInt(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }
        private int ConvertToDecimal(string _numeral)
        {

            int _decimal = 0;
            _numeral.ToCharArray();

            for (int i = 0; i < _numeral.Length; i++)
            {
                if (i != _numeral.Length-1 && toInt(_numeral[i]) < toInt(_numeral[i + 1]))
                {
                    _decimal += (toInt(_numeral[i + 1]) - toInt(_numeral[i]));
                    i++;
                }
                else
                {
                    _decimal += toInt(_numeral[i]);
                }
            }

            return _decimal;
        }
    }
}

