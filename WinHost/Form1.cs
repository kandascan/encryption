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

namespace WinHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtZaszyfrowany.Text = PrzekatnoKolumnowy.Szyfruj(txtText.Text, txtKlucz.Text);
        }

        private void btnOdszyfruj_Click(object sender, EventArgs e)
        {
            txtText.Text = PrzekatnoKolumnowy.Odszyfruj(txtZaszyfrowany.Text, txtKlucz.Text);
        }
    }
}
