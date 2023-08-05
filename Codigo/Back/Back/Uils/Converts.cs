using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HirCasa.Back.Uils
{
    public static class Converts
    {
        public static string Interpolation(string a, string b)
        {
            string cadInterpolation = "";
            var cadenaBase = ((a.Length > b.Length) ? a : b).ToCharArray();
            var cadenaMerge = ((a.Length > b.Length) ? b : a).ToCharArray();
            for (int i = 0; i < cadenaBase.Length; i++)
            {
                cadInterpolation += cadenaBase[i];
                //int j = i - 1;
                if (i < cadenaMerge.Length)
                {
                    cadInterpolation += cadenaMerge[i];
                }
            }
            return cadInterpolation;
        }
        public static string ReverseString(string value)
        {
            string cad = "";
            char[] chars = value.ToArray();
            for (int t = chars.Length - 1; t > -1; t--)
            {
                cad += Converts.IncrementIntToChar((int)chars[t]);
            }

            return cad;
        }
        public static string IncrementIntToChar(int value)
        {
            string letter = "";
            value += 1;
            letter = ((Char)value).ToString();
            return letter;
        }
        public static byte[] ToArrayByte(string cad)
        {
            if (string.IsNullOrEmpty(cad))
            {
                return null;
            }
            else
            {
                return ASCIIEncoding.UTF8.GetBytes(cad);
            }
        }

    }
}
