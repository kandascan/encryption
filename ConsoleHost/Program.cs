﻿using System;
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
            var tekst = "BRYLANTY_SĄ_W_MOJEJ_SKRYTCE_W_BANKU";
            var klucz = "MAROKO";

            var zaszyfrowany =  PrzekatnoKolumnowy.Szyfruj(tekst, klucz);
            
            Console.WriteLine();
            Console.WriteLine(tekst);
            Console.WriteLine(zaszyfrowany);

            Console.ReadLine();
        }
    }
}
