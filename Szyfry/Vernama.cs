using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szyfry
{
    public class Vernama
    {
        private static string KonwertujDoPostaciBinarnej(byte[] array)
        {
            string binary = string.Empty;
            foreach (var arr in array)
            {
                string bin = Convert.ToString(arr, 2);
                if (bin.Length < 7)
                {
                    bin = bin.Insert(0, "0");
                }
                binary += bin;
            }
            return binary;
        }

        private static string[] UtworzTablice(string binarny)
        {
            int pierwszy = 0;
            int n = binarny.Length / 7;
            string[] array = new string[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = binarny.Substring(pierwszy, 7);
                pierwszy += 7;
            }
            return array;
        }

        private static int[] KonwertujBajtDoDecymalnej(string[] byteArray)
        {
            var intArray = new int[byteArray.Length];
            for(int i=0; i<byteArray.Length; i++)
            {
                intArray[i] = Convert.ToInt32(byteArray[i], 2);
            }

            return intArray;
        }

        private static char[] KonwertujDecimalDoStringa(int[] array)
        {
            return array.Select(x => (char)x).ToArray();
        }

        public static string Odszyfruj(string binarny)
        {
            var array = UtworzTablice(binarny);
            var decimalArray = KonwertujBajtDoDecymalnej(array);
            var tablicaCzarow = KonwertujDecimalDoStringa(decimalArray);

            return new string(tablicaCzarow);
        }
        public static string Szyfruj(string text)
        {
            byte[] array = Encoding.ASCII.GetBytes(text);
            return KonwertujDoPostaciBinarnej(array);
        }
    }
}
