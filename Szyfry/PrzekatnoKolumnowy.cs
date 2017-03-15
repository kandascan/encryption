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

            var sortowaneKlucze = key.OrderBy(x => x.Znak).ThenBy(x => x.OryginalnyIndex).ToArray();
            var zaszyfrowanyTekst = "";

            foreach (var keySort in sortowaneKlucze)
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

        private static char[,] WypelnijTabliceDeszyfrujaca(char[,] tablica, string klucz, string tekst, int liczbaWierszy)
        {
            List<Key> key = new List<Key>();
            for (int i = 0; i < klucz.Length; i++)
            {
                key.Add(new Key { OryginalnyIndex = i, Znak = klucz[i] });
            }

            var sortowaneKlucze = key.OrderByDescending(x => x.Znak).ThenByDescending(x => x.OryginalnyIndex).ToArray();
            int indexTekstu = tekst.Length;
            foreach (var keySort in sortowaneKlucze)
            {
                int indexPoczatkowy = keySort.OryginalnyIndex;

                for (int i = 1; i < liczbaWierszy; i++)
                {
                    indexPoczatkowy--;
                    if (indexPoczatkowy < 0)
                    {
                        indexPoczatkowy = klucz.Length-1;
                    }
                }

                for (int i = liczbaWierszy-1; i >= 0; i--)
                {
                    for (int j = 0; j < klucz.Length; j++)
                    {
                        if (j == indexPoczatkowy)
                        {
                            char znak = tekst[indexTekstu-1];
                            tablica[i, j] = znak;
                            indexTekstu--;
                            indexPoczatkowy++;
                            if (indexPoczatkowy >= klucz.Length)
                            {
                                indexPoczatkowy = 0;
                            }
                            break;
                        }
                    }
                }
            }
            DrukujTablice(tablica,klucz,liczbaWierszy);
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
            return UtworzTekstZTablicy(wypelnionaTablica, liczbaWierszy, klucz);
        }
    }

    class Key
    {
        public char Znak { get; set; }
        public int OryginalnyIndex { get; set; }
    }
}
