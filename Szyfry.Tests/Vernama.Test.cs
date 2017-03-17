using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using NUnit.Framework;

namespace Szyfry.Tests
{
    [TestFixture]
    class Vernama
    {
        [TestCase("PLUTON", "MARS")]
        public void PowinienZaszyfrowacTekst(string text, string klucz)
        {
            var zaszyfrowany = Szyfry.Vernama.Szyfruj(text, klucz);
            var oczekiwany = "000111010000110100000111000001110000001000001111";

            Assert.AreEqual(oczekiwany, zaszyfrowany);
        }

        [TestCase("000111010000110100000111000001110000001000001111", "MARS")]
        public void PowinienOdszyfrowacTekst(string text, string klucz)
        {
            var odszyfrowany = Szyfry.Vernama.Odszyfruj(text, klucz);
            var oczekiwany = "PLUTON";

            Assert.AreEqual(oczekiwany, odszyfrowany);
        }
    }
}
