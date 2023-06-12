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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer2.Interval = 4000;
            timer2.Start();
          
            
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
           
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
           
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            this.Hide();
            Login obj = new Login();
            obj.Show();
            timer2.Stop();
        }
    }
}
