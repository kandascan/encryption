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
        private static Key[] SortujKluczAscending(string klucz)
        {
            var key = klucz.Select((t, i) => new Key { OryginalnyIndex = i, Znak = t }).ToList();

            return key.OrderBy(x => x.Znak).ThenBy(x => x.OryginalnyIndex).ToArray();
        }
        private static string SzyfrujTekst(char[,] tablica, string klucz, int wiersze)
        {
            var kluczAsc = SortujKluczAscending(klucz);
            var zaszyfrowanyTekst = "";

            foreach (var keySort in kluczAsc)
            {
                var kolumna = keySort.OryginalnyIndex;
                for (int i = 0; i < wiersze; i++)
                {
                    for (int j = 0; j < klucz.Length; j++)
                    {
                        if (j == kolumna)
                        {
                            char znak = tablica[i, j];
                            zaszyfrowanyTekst += znak;
                            kolumna--;
                            if (kolumna < 0)
                            {
                                kolumna = klucz.Length - 1;
                            }
                            break;
                        }
                    }
                }
            }
            return zaszyfrowanyTekst;
        }

        private static char[,] UtworzTabliceZTekstu(string tekst, int kolumny, int wiersze)
        {
            var tablica = new char[wiersze, kolumny];
            var licznik = 0;
            for (int i = 0; i < wiersze; i++)
            {
                for (int j = 0; j < kolumny; j++)
                {
                    if (licznik >= tekst.Length)
                    {
                        tablica[i, j] = 'X';
                    }
                    else
                    {
                        tablica[i, j] = tekst[licznik];
                    }
                    licznik++;
                }
            }
            return tablica;
        }

        private static int ObliczLiczbeWierszy(string tekst, string klucz)
        {
            float wynik = tekst.Length/klucz.Length;

            if (tekst.Length % klucz.Length != 0)
            {
               wynik = wynik + 1;
            }

            return (int)wynik;
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

        private static string UtworzTekstZTablicy(char[,] tablica, int liczbaWierszy, string klucz)
        {
            var tekst = string.Empty;

            for (int i = 0; i < liczbaWierszy; i++)
            {
                for (int j = 0; j < klucz.Length; j++)
                {
                    char znak = tablica[i, j];
                    if (znak == 'X')
                    {
                        break;
                    }
                    tekst += znak;
                }
            }
            return tekst;
        }

        private static int IndexPoczatkowy(int oryginalnyIndex, int liczbaWierszy, int dlugoscKlucza)
        {
            int index = oryginalnyIndex;

            for (int i = 1; i < liczbaWierszy; i++)
            {
                index--;
                if (index < 0)
                {
                    index = dlugoscKlucza - 1;
                }
            }
            return index;
        }

        private static Key[] SortujKluczDescending(string klucz)
        {
           var key = klucz.Select((t, i) => new Key {OryginalnyIndex = i, Znak = t}).ToList();

            return key.OrderByDescending(x => x.Znak).ThenByDescending(x => x.OryginalnyIndex).ToArray();
        } 

        private static char[,] WypelnijTabliceDeszyfrujaca(char[,] tablica, string klucz, string tekst, int wiersze)
        {
            var kluczDes = SortujKluczDescending(klucz);
            int indexTekstu = tekst.Length;
            foreach (var keySort in kluczDes)
            {
                int kolumna = IndexPoczatkowy(keySort.OryginalnyIndex, wiersze, klucz.Length);

                for (int i = wiersze-1; i >= 0; i--)
                {
                    for (int j = 0; j < klucz.Length; j++)
                    {
                        if (j == kolumna)
                        {
                            char znak = tekst[indexTekstu-1];
                            tablica[i, j] = znak;
                            indexTekstu--;
                            kolumna++;
                            if (kolumna >= klucz.Length)
                            {
                                kolumna = 0;
                            }
                            break;
                        }
                    }
                }
            }
            DrukujTablice(tablica,klucz,wiersze);
            return tablica;
        }

        private static char[,] UtworzTabliceDeszyfrujaca(string klucz, string tekst, int wiersze)
        {
            var tablica = new char[wiersze, klucz.Length];
            return WypelnijTabliceDeszyfrujaca(tablica, klucz, tekst, wiersze);
        }

        public static string Odszyfruj(string tekst, string klucz)
        {
            var wiersze = ObliczLiczbeWierszy(tekst, klucz);
            var tablica = UtworzTabliceDeszyfrujaca(klucz, tekst, ObliczLiczbeWierszy(tekst, klucz));
            return UtworzTekstZTablicy(tablica, wiersze, klucz);
        }
    }

    class Key
    {
        public char Znak { get; set; }
        public int OryginalnyIndex { get; set; }
    }
}
