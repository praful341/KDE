using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace KDE
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
        }
        string getpassword;
        string regPath;
        public License(String passname, String path)
        {
            InitializeComponent();
            getpassword = passname;
            regPath = path;
        }
        public bool passwordEntry(String originalPass, String pass)
        {
            if (originalPass == pass)
            {
                RegistryKey regkey = Registry.CurrentUser;
                regkey = regkey.CreateSubKey(regPath);

                if (regkey != null)
                {
                    regkey.SetValue("Password", pass);
                }
                return true;
            }
            else
                return false;
        }

       
       

        private void License_Load(object sender, EventArgs e)
        {
        textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool value = passwordEntry(getpassword, textBox1.Text);
            if (value == true)
            {
                MessageBox.Show("Thank you for activation!", "Activate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Product Key is not valid! Please Enter a valid Product Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                button1.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox3.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                textBox1.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

       

    }
}
