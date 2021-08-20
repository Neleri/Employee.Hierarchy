using System;
using System.Collections.Generic;
using System.Numerics;

namespace Exercise01
{
    public static class IntToWords
    {
        public static string GetOnes(string Number)
        {
            string[] words = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            int value = Convert.ToInt32(Number);
            string name = "";
            name = words[value - 1];
            return name;
        }

        public static string GetTens(string Number)
        {
            int value = Convert.ToInt32(Number);

            string[] words = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

            string name = null;
            name = words[value - 10];
            return name;
        }

        public static string ConvertWholeNumber(this long value)
        {
            string word = "";
            try
            {
                bool isDone = false;
                if (value > 0)
                {
                    int numDigits = value.ToString().Length;
                    int pos = 0;
                    string place = "";
                    switch (numDigits)
                    {
                        case 1:

                            word = GetOnes(value.ToString());
                            isDone = true;
                            break;

                        case 2:
                            word = GetTens(value.ToString());
                            isDone = true;
                            break;

                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (value.ToString().Substring(0, pos) != "0" && value.ToString().Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(value) + place + ConvertWholeNumber(value);
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(value) + ConvertWholeNumber(value);
                        }


                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        public static string ConvertToWords(string numb)
        {
            string wholeNo = numb;
            string points = "";
            string andStr = "";
            string pointStr = "";

            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";
                        pointStr = ConvertDecimals(points);
                    }
                }

            }
            catch { }
            return string.Format("{0} {1}{2}", ConvertWholeNumber(long.Parse(wholeNo)).Trim(), andStr, pointStr);
        }

        public static string ConvertDecimals(string number)
        {
            string convertedValue = "";
            string digit = "";
            string levelOnes = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    levelOnes = "Zero";
                }
                else
                {
                    levelOnes = GetOnes(digit);
                }
                convertedValue += " " + levelOnes;
            }
            return convertedValue;
        }

    }

}

