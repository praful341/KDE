using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
namespace KDE
{
    public partial class frmBackup : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        //SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        #endregion

        #region " Constructors "
        public frmBackup()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void Backup_Load(object sender, EventArgs e)
        {
            //serverName(".");        
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            blank("backup");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "USE KDE;";
                string str1 = "BACKUP DATABASE KDE TO DISK = 'D:\\KDE Backup\\backupfile.Bak' WITH FORMAT,MEDIANAME = 'Z_SQLServerBackups',NAME = 'Full Backup of KDE';";
                SqlCommand cmd1 = new SqlCommand(str, con);
                SqlCommand cmd2 = new SqlCommand(str1, con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Back UP Create Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmbservername_SelectedIndexChanged(object sender, EventArgs e)
        {
            Createconnection();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        #endregion

        #region " Functions/ Procedures "
        public void serverName(string str)
        {
            try
            {
                //con = new SqlConnection("Data Source=" + str + ";Database=Master;data source=.; uid=sa; pwd=123;");
                con.Open();
                cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmbservername.Items.Add(dr[2]);

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Createconnection()
        {
            con = new SqlConnection("Data Source=" + (cmbdatabasename.Text) + ";Database=Master;data source=.; uid=sa; pwd=123;");
            con.Open();
            cmbdatabasename.Items.Clear();
            cmd = new SqlCommand("select * from sysdatabases", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbdatabasename.Items.Add(dr[0]);
            }
            dr.Close();
        }
        
        public void query(string que)
        {
            // ERROR: Not supported in C#: OnErrorStatement

            cmd = new SqlCommand(que, con);
            cmd.ExecuteNonQuery();
        }

        public void blank(string str)
        {
            if (string.IsNullOrEmpty(cmbservername.Text) | string.IsNullOrEmpty(cmbdatabasename.Text))
            {
               
                MessageBox.Show("Server Name & Database can not be Blank","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (str == "backup")
                {
                    saveFileDialog1.FileName = cmbdatabasename.Text;
                   
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string s = null;
                        s = saveFileDialog1.FileName;
                        query("Backup database " + cmbdatabasename.Text + " to disk='" + s + "'");
                        MessageBox.Show("Database BackUp has been created successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sorray!!Please First Save File ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }
            }
        }
        #endregion
    }
}
