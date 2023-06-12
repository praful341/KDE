using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDE
{
    public partial class frmEnterPasword : Form
    {
        public frmEnterPasword()
        {
            InitializeComponent();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123")
            {

                frmRptBillDate obj = new frmRptBillDate();
                obj.pass = textBox1.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Password....Enter Corrent Password.");
                textBox1.Focus();
            }

          
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (e.KeyChar == 13)
                    Btn_Save.Focus();
            }
        }

    }


}
