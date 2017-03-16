using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szyfry
{
    public class Homofoniczny
    {
        private static Dictionary<char, List<char>> PobierzSlownik()
        {
            var dictionary = new Dictionary<char, List<char>>();
            dictionary.Add('A', new List<char> { '%', '&', 'O', ':', 'X', '>' });
            dictionary.Add('B', new List<char> { 'M', '!' });
            dictionary.Add('C', new List<char> { 'V', ']', '-'});

            return dictionary;
        }

        public static string Odszyfruj(string text)
        {
            var dictionary = PobierzSlownik();
            var odszyfrowany = string.Empty;

            foreach (var znak in text)
            {
                foreach (var dic in dictionary)
                {
                    foreach (var d in dic.Value)
                    {
                        if (d == znak)
                        {
                            odszyfrowany += dic.Key;
                        }
                    }
                }
            }
            return odszyfrowany;
        }

        private static char ZwrocZnak(List<char> listaZnakow)
        {
            Random rand = new Random();
            var index = rand.Next(0, listaZnakow.Count);
            return listaZnakow[index];
        }

        public static string Szyfruj(string text)
        {
            var dictionary = PobierzSlownik();
            var zaszyfrowany = string.Empty;

            foreach (var znak in text)
            {
                foreach (var dic in dictionary)
                {
                    if (znak == dic.Key)
                    {
                        zaszyfrowany += ZwrocZnak(dic.Value);
                        break;
                    }
                }
            }

            return zaszyfrowany;
        }
    }
}
