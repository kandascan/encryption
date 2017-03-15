using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Szyfry.Tests
{
    [TestFixture]
    class PrzekatnoKolumnowy
    {
        [TestCase("BRYLANTY_SĄ_W_MOJEJ_SKRYTCE_W_BANKU", "MAROKO")]
        public void PowinienZaszyfrowacTekst(string text, string klucz)
        {
            var zaszyfrowany = Szyfry.PrzekatnoKolumnowy.Szyfruj(text, klucz);

            Assert.AreEqual("RTER_NASM_TXB_JKEAL__J_UNĄOSCBYYWYWK", zaszyfrowany);
        }

        [TestCase("RTER_NASM_TXB_JKEAL__J_UNĄOSCBYYWYWK", "MAROKO")]
        public void PowinienOdszyfrowacTekst(string text, string klucz)
        {
            var odszyfrowany = Szyfry.PrzekatnoKolumnowy.Odszyfruj(text, klucz);

            Assert.AreEqual("BRYLANTY_SĄ_W_MOJEJ_SKRYTCE_W_BANKU", odszyfrowany);
        }
    }
}
