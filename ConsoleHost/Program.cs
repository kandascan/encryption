using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Szyfry;

namespace ConsoleHost
{
    
    class Program
    {


        static void Main(string[] args)
        {
            var tekst = "https://www.youtube.com/watch?v=8aMsJWpXyE8";
            var klucz = "HASLO";

            var szyfrowany = PrzekatnoKolumnowy.Szyfruj(tekst, klucz);

            var odszyfrowany = PrzekatnoKolumnowy.Odszyfruj(szyfrowany, klucz);
            Console.ReadLine();
        }
    }
}
