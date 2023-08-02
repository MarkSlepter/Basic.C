using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_PROJEKT
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            DialogResult Wynik = MessageBox.Show("Czy chczesz zamknić program ?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (Wynik == DialogResult.Yes)
                Application.Exit();
           
        }

        private void buttonMacierze_Click(object sender, EventArgs e)
        {
            Hide();
            // Otwarcie innego okna Prezentacja figur ze slajderzem
            FormMenu form1 = new FormMenu();
            FormBrylyReguralne form2 = new FormBrylyReguralne();


            form2.Show();
            form1.Close();
        }
    }
}
