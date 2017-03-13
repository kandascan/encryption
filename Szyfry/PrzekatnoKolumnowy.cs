using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szyfry
{
    public class PrzekatnoKolumnowy
    {
        private static void DrukujTablice(char[,] tablica, string klucz, int wiersze)
        {
            var linia = String.Empty;

            var kolumny = klucz.Length;
            foreach (var key in klucz)
            {
                Console.Write("{0} ", key);
                linia += "--";
            }
            Console.WriteLine();
            Console.WriteLine(linia);
            for (int i = 0; i < wiersze; i++)
            {
                for (int j = 0; j < kolumny; j++)
                {
                    Console.Write("{0} ", tablica[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static string SzyfrujTekst(char[,] tablica, string klucz, int wiersze)
        {
            List<Key> key = new List<Key>();
            for (int i = 0; i < klucz.Length; i++)
            {
                key.Add(new Key { OryginalnyIndex = i, Znak = klucz[i] });
            }

            var sortowaneKlucze = key.OrderBy(x => x.Znak).ToArray();

            var zaszyfrowanyTekst = "";

            var kolumna = 0;
            var indexKolumny = 0;
            var iteratorKolumnowy = 1;

            foreach (var keySort in sortowaneKlucze)
            {
                kolumna = keySort.OryginalnyIndex;
                indexKolumny = kolumna;
                for (int i = 0; i < wiersze; i++)
                {
                    if (kolumna < 0)
                    {
                        indexKolumny = klucz.Length - iteratorKolumnowy;
                        iteratorKolumnowy++;
                    }

                    zaszyfrowanyTekst += tablica[i, indexKolumny];
                    indexKolumny--;
                    kolumna--;
                }
                iteratorKolumnowy = 1;
            }

            return zaszyfrowanyTekst;
        }

        private static char[,] UtworzTabliceZTekstu(string tekst, int liczbaKolumn, int liczbaWierszy)
        {
            var tablica = new char[liczbaWierszy, liczbaKolumn];
            var licznikPetli = 0;
            for (int i = 0; i < liczbaWierszy; i++)
            {
                for (int j = 0; j < liczbaKolumn; j++)
                {
                    if (licznikPetli >= tekst.Length)
                    {
                        tablica[i, j] = 'X';
                    }
                    else
                    {
                        tablica[i, j] = tekst[licznikPetli];
                    }
                    licznikPetli++;
                }
            }
            return tablica;
        }

        private static int ObliczLiczbeWierszy(string tekst, string klucz)
        {
            var liczbaWierszy = 0;

            if (tekst.Length % klucz.Length == 0)
            {
                liczbaWierszy = tekst.Length / klucz.Length;
            }
            else
            {
                liczbaWierszy = tekst.Length % klucz.Length + 1;
            }

            return liczbaWierszy;
        }

        public static string Szyfruj(string tekst, string klucz)
        {
            var liczbaKolumn = klucz.Length;
            var liczbaWierszy = ObliczLiczbeWierszy(tekst, klucz);
            var tablica = UtworzTabliceZTekstu(tekst, liczbaKolumn, liczbaWierszy);
            DrukujTablice(tablica, klucz, liczbaWierszy);
            var zaszyfrowanyTekst = SzyfrujTekst(tablica, klucz, liczbaWierszy);

            return zaszyfrowanyTekst;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static char[,] WypelnijTabliceDeszyfrujaca(char[,] tablica, string klucz, string tekst, int liczbaWierszy)
        {
            List<Key> key = new List<Key>();
            for (int i = 0; i < klucz.Length; i++)
            {
                key.Add(new Key { OryginalnyIndex = i, Znak = klucz[i] });
            }

            var sortowaneKlucze = key.OrderByDescending(x => x.Znak).ToArray();
            string odworoconyTekst = Reverse(tekst);
            var kolumnaDoZczytania = 0;
            var kolumnaPomocnicza = 0;
            var indexKolumnyPoczatkowej = 0;
            var dodatkowaZmienna = 0;
            var licznikTekstu = 0;
            var licznikKolumnowy = 0;
            var dodajDolicznikaKolumnowego = 0;
            

            foreach (var keySort in sortowaneKlucze)
            {
                kolumnaDoZczytania = keySort.OryginalnyIndex - klucz.Length;
                indexKolumnyPoczatkowej = kolumnaDoZczytania;
                //kolumnaDoZczytania += 1;
                while (kolumnaDoZczytania < 0)
                {
                    kolumnaDoZczytania++;
                    kolumnaPomocnicza++;
                    indexKolumnyPoczatkowej = kolumnaPomocnicza - 1;
                    dodatkowaZmienna = indexKolumnyPoczatkowej;
                }
                for (int i = liczbaWierszy-1; i > 0; i--)
                {
                    for (int j = 0; j < klucz.Length; j++)
                    {
                        if (dodatkowaZmienna >= klucz.Length)
                        {
                            indexKolumnyPoczatkowej = licznikKolumnowy + dodajDolicznikaKolumnowego;
                            dodajDolicznikaKolumnowego++;
                        }
                        if (j == indexKolumnyPoczatkowej)
                        {
                            tablica[i, j] = odworoconyTekst[licznikTekstu];
                            licznikTekstu++;
                        }
                    }
                    indexKolumnyPoczatkowej++;
                    dodatkowaZmienna++;
                }
                dodatkowaZmienna = 0;
                indexKolumnyPoczatkowej = 0;
            }


            return tablica;
        }

        private static char[,] UtworzTabliceDeszyfrujaca(string klucz, int liczbaWierszy)
        {
            var tablica = new char[liczbaWierszy, klucz.Length];
            return tablica;
        }

        public static string Odszyfruj(string tekst, string klucz)
        {
            var liczbaKolumn = klucz.Length;
            var liczbaWierszy = ObliczLiczbeWierszy(tekst, klucz);
            var tablica = UtworzTabliceDeszyfrujaca(klucz, liczbaWierszy);
            var wypelnionaTablica = WypelnijTabliceDeszyfrujaca(tablica, klucz, tekst, liczbaWierszy);


            return "";
        }
    }

    class Key
    {
        public char Znak { get; set; }
        public int OryginalnyIndex { get; set; }
    }
}
