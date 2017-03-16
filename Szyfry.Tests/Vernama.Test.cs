using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Szyfry.Tests
{
    [TestFixture]
    class Vernama
    {
        [TestCase("Ala ma kota")]
        public void PowinienZaszyfrowacTekst(string text)
        {
            var zaszyfrowany = Szyfry.Vernama.Szyfruj(text);
            var oczekiwany = "10000011101100110000101000001101101110000101000001101011110111111101001100001";

            Assert.AreEqual(oczekiwany, zaszyfrowany);
        }

        [TestCase("10000011101100110000101000001101101110000101000001101011110111111101001100001")]
        public void PowinienOdszyfrowacTekst(string text)
        {
            var odszyfrowany = Szyfry.Vernama.Odszyfruj(text);
            var oczekiwany = "Ala ma kota";

            Assert.AreEqual(oczekiwany, odszyfrowany);
        }
    }
}
