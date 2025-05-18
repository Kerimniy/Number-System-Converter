using System;
using System.Text;
using System.Collections.Generic;
namespace Converter
{
    class Converter
    {
        public string ToBase(int number, int _base)
        {
            if (_base == 0 || _base > 36)
            {
                return "OutOfDegreeRange";
            }

            string output = "";
            char[] charbase = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            float _decimal = number;
            for (byte i = 0; i < number.ToString().Length; i++)
            {

                output = output.Insert(0, charbase[Convert.ToInt32(_decimal % _base)].ToString());
                _decimal = MathF.Floor(_decimal / _base);
            }

            string new_output = "";

            if (output[0] == '0')
            {
                for (byte j = 1; j < output.Length; j++)
                {
                    new_output = new_output.Insert(j - 1, output[j].ToString());
                }

            }
            else new_output = output;
            return new_output;
        }


        public int FromBase(string input, int _base)
        {
            if (_base == 0 || _base > 36)
            {
                return 0;
            }

            char[] charbase = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string numbers = "";          
            int output = 0;
            List<int> dynamicArray = new List<int>();
            for (byte m = 0; m < input.Length; m++)
            {
                for (byte i = 0; i < charbase.Length; i++)
                {
                    if (charbase[i] == input[m])
                    {

                        numbers = numbers.Insert(0, i.ToString());
                        dynamicArray.Add(i);

                    }

                }

            }
            for (int i = 0; i < dynamicArray.Count; i++)
            {

                int j = dynamicArray.Count - i;
                output += dynamicArray[i] * Convert.ToInt32(MathF.Pow(_base, j - 1));
            }

            return output;
        }
    }
}
