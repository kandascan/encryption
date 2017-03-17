using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szyfry
{
    public class Vernama
    {
        public static String ToBinary(Byte[] data)
        {
            return string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        private static string KonwertujDoPostaciBinarnej(byte[] array)
        {
            string binary = string.Empty;
            foreach (var arr in array)
            {
                binary += Convert.ToString(arr, 2).PadLeft(8, '0');
            }
            return binary;
        }

        private static string[] UtworzTablice(string binarny)
        {
            int pierwszy = 0;
            int n = binarny.Length/8;
            string[] array = new string[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = binarny.Substring(pierwszy, 8);
                pierwszy += 8;
            }
            return array;
        }

        private static int[] KonwertujBajtDoDecymalnej(string[] byteArray)
        {
            var intArray = new int[byteArray.Length];
            for (int i = 0; i < byteArray.Length; i++)
            {
                intArray[i] = Convert.ToInt32(byteArray[i], 2);
            }

            return intArray;
        }

        private static char[] KonwertujDecimalDoStringa(int[] array)
        {
            return array.Select(x => (char) x).ToArray();
        }

        public static string Odszyfruj(string binarny, string klucz)
        {
            var n = binarny.Length/8;
            var tablicaZKlucza = UtworzTabliceZKlucza(klucz, n);
            byte[] kluczArray = Encoding.ASCII.GetBytes(tablicaZKlucza);

            var kluczBinary = KonwertujDoPostaciBinarnej(kluczArray);

            var modulo2 = DodajKluczDoTextuModulo2(kluczBinary, binarny);

            var array = UtworzTablice(modulo2);
            var decimalArray = KonwertujBajtDoDecymalnej(array);
            var tablicaCzarow = KonwertujDecimalDoStringa(decimalArray);

            return new string(tablicaCzarow);
        }

        public static string Szyfruj(string text, string klucz)
        {
            byte[] array = Encoding.ASCII.GetBytes(text);
            var textBinarny = KonwertujDoPostaciBinarnej(array);

            var tablicaZKlucza = UtworzTabliceZKlucza(klucz, text.Length);
            byte[] kluczArray = Encoding.ASCII.GetBytes(tablicaZKlucza);
            var kluczBinary = KonwertujDoPostaciBinarnej(kluczArray);

            var modulo2 = DodajKluczDoTextuModulo2(kluczBinary, textBinarny);

            return modulo2;
        }

        private static string DodajKluczDoTextuModulo2(string klucz, string text)
        {
            string wynik = String.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                wynik += text[i] ^ klucz[i];
            }
            return wynik;
        }

        private static string UtworzTabliceZKlucza(string klucz, int n)
        {
            string tablicaKlucz = String.Empty;
            int iterator = 0;
            for (int i = 0; i < n; i++)
            {
                if (iterator >= klucz.Length) iterator = 0;
                tablicaKlucz += klucz[iterator];
                iterator++;
            }

            return tablicaKlucz;
        }
    }
}
