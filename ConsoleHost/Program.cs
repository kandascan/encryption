using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    class Key
    {
        public char Znak { get; set; }
        public int OryginalnyIndex { get; set; }
    }
    class Program
    {
        static void DrukujTablice(char[,] tablica, string klucz, int wiersze)
        {
            var linia = string.Empty;

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
                    Console.Write("{0} ",tablica[i,j]);
                }
                Console.WriteLine();
            }
        }

        static string SzyfrujTekst(char[,] tablica, string klucz, int wiersze)
        {
            List<Key> klucze = new List<Key>();
            for (int i = 0; i<klucz.Length; i++)
            {
                klucze.Add(new Key {OryginalnyIndex = i, Znak = klucz[i]});
            }

            var sortowaneKlucze = klucze.OrderBy(x => x.Znak).ToArray();
            
            var zaszyfrowanyTekst = "";

            var kolumna = 0;
            var indexKolumny = 0;
            var dodatkowaZmienna = 1;
            
            foreach (var keySort in sortowaneKlucze)
            {
                kolumna = keySort.OryginalnyIndex;
                indexKolumny = kolumna;
                for (int i = 0; i < wiersze; i++)
                {
                    if (kolumna < 0)
                    {
                        indexKolumny = klucz.Length - dodatkowaZmienna;
                        dodatkowaZmienna++;
                    }
                    
                    zaszyfrowanyTekst += tablica[i, indexKolumny];
                    indexKolumny--;
                    kolumna --;
                }
                dodatkowaZmienna = 1;
            }

            return zaszyfrowanyTekst;
        }

        static char[,] UtworzTabliceZTekstu(string tekst, int liczbaKolumn, int liczbaWierszy)
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

        static int ObliczLiczbeWierszy(string tekst, string klucz)
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

        static void Main(string[] args)
        {
            var tekst = "BRYLANTY_SĄ_W_MOJEJ_SKRYTCE_W_BANKU";
            var klucz = "MAROKO";

            var liczbaKolumn = klucz.Length;
            var liczbaWierszy = ObliczLiczbeWierszy(tekst, klucz);
            var tablica = UtworzTabliceZTekstu(tekst, liczbaKolumn, liczbaWierszy);

            DrukujTablice(tablica, klucz, liczbaWierszy);

            var zaszyfrowanyTekst = SzyfrujTekst(tablica, klucz, liczbaWierszy);
            Console.WriteLine();
            Console.WriteLine(tekst);
            Console.WriteLine(zaszyfrowanyTekst);
            Console.ReadLine();
        }
    }
}
