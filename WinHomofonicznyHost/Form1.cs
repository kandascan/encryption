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

namespace WinHomofonicznyHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSzyfruj_Click(object sender, EventArgs e)
        {
            txtZaszyfrowany.Text = Homofoniczny.Szyfruj(txtText.Text);
        }

        private void btnOdszyfruj_Click(object sender, EventArgs e)
        {
            txtText.Text = Homofoniczny.Odszyfruj(txtZaszyfrowany.Text);
        }
    }
}
