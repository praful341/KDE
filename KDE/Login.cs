using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace KDE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    Login_Id_fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Login_Id_fill()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Login ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBox2.Focus();
            }

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.SelectAll();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    Password_fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public void Password_fill()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Password....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == ""|| textBox2.Text == "")
                {

                    if (textBox1.Text == "")
                    {
                        textBox1.Focus();
                    }
                    else
                    {
                        if (textBox2.Text == "")
                        {
                            textBox2.Focus();
                        }
                    }
                }



                if (textBox1.Text == "jalaram" && textBox2.Text == "3025")
                {

                    this.Hide();
                    MDIMaster obj = new MDIMaster();
                    obj.Show();

                }
                else
                {
                    MessageBox.Show("Please Check Your Login ID and Password....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            textBox1.Text = "jalaram";
            textBox2.Text = "3025";
            button1_Click(null, null);
        }
    }
}
