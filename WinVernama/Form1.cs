using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Szyfry;

namespace WinVernama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSzyfruj_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKlucz.Text.Length == 0) throw new Exception("Podaj klucz");
                if (txtText.Text.Length == 0) throw new Exception("Podaj tekst do zaszyfrowania");

                txtZaszyfrowany.Text = Vernama.Szyfruj(txtText.Text, txtKlucz.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOdszyfruj_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKlucz.Text.Length == 0) throw new Exception("Podaj klucz");
                if (txtZaszyfrowany.Text.Length == 0) throw new Exception("Podaj ciag binarny do odszyfrowania");

                txtText.Text = Vernama.Odszyfruj(txtZaszyfrowany.Text, txtKlucz.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
