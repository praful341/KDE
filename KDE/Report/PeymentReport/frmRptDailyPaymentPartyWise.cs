using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KDE
{
    public partial class frmRptDailyPaymentPartyWise : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        string str;
        SqlCommand cmd;

        public frmRptDailyPaymentPartyWise()
        {
            InitializeComponent();
        }

      
        private void Txt_Party_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    P_Code_Validation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void P_Code_Validation()
        {
            try
            {
                if (Txt_Party.Text == "")
                {
                    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Party.Focus();
                }
                else
                {

                    con.Open();
                    str = "select * from Mst_Party where Party_Code='" + Txt_Party.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtParty_Name.Text = dr["Party_Name"].ToString();
                        Txt_From_Date.Focus();

                        dr.Close();

                    }
                    else
                    {

                        MessageBox.Show("Enter Valid Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Txt_Party.Focus();
                    }


                } con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Txt_Com_Code.Text == "")
                //{
                //    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Txt_Com_Code.Focus();
                //}
                //else if (Txt_Party.Text == "")
                //{
                //    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Txt_Party.Focus();
                //}
                //else if (txt_billNo.Text == "")
                //{
                //    MessageBox.Show("Enter Bill No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txt_billNo.Focus();
                //}
                if (Txt_From_Date.Text == "  /  /")
                {
                    MessageBox.Show("Enter From Date....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_From_Date.Focus();
                }
                else if (Txt_To_Date.Text == "  /  /")
                {
                    MessageBox.Show("Enter To Date....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_To_Date.Focus();
                }

                else
                {
                    string str;
                    con.Open();
                    str = "select * from Payment_Details where Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Payment_Details");

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Data Found...!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Txt_From_Date.Focus();
                    }
                    else
                    {
                        frmRptDailyPaymentPartyViewer obj = new frmRptDailyPaymentPartyViewer();
                        obj.C_Code = Txt_From_Date.Text;

                        //obj.P_Code = Txt_Party.Text;
                        obj.F_Date = Txt_From_Date.Text;
                        obj.T_Date = Txt_To_Date.Text;
                        //obj.BillNo = txt_billNo.Text;

                        obj.Show();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }

        private void Txt_From_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    Txt_To_Date.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Txt_To_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    Btn_Save.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Txt_Party_Leave(object sender, EventArgs e)
        {
            Txt_Party.BackColor = System.Drawing.Color.White;
            Txt_Party.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_Party.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_Party_Enter(object sender, EventArgs e)
        {
            Txt_Party.BackColor = System.Drawing.Color.AntiqueWhite;
            Txt_Party.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_Party.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_From_Date_Enter(object sender, EventArgs e)
        {
            Txt_From_Date.BackColor = System.Drawing.Color.AntiqueWhite;
            Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_From_Date.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_From_Date_Leave(object sender, EventArgs e)
        {
            Txt_From_Date.BackColor = System.Drawing.Color.White;
            Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_From_Date.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_To_Date_Enter(object sender, EventArgs e)
        {
            Txt_To_Date.BackColor = System.Drawing.Color.AntiqueWhite;
            Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_To_Date.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_To_Date_Leave(object sender, EventArgs e)
        {
            Txt_To_Date.BackColor = System.Drawing.Color.White;
            Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_To_Date.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_Party_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                    P_code_help();

                if (e.KeyCode == Keys.Escape)
                    dataGridView1.Hide();
                Txt_Party.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void P_code_help()
        {
            con.Open();
            str = "select Party_Code,Party_Name,Party_Add,Party_Con_No from Mst_Party ";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter da;
            da = new SqlDataAdapter(cmd);
            DataSet ds;
            ds = new DataSet();
            da.Fill(ds, "Mst_Party");
            dataGridView1.DataSource = ds.Tables["Mst_Party"];
            dataGridView1.Show();
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_billNo_Enter(object sender, EventArgs e)
        {
            //txt_billNo.BackColor = System.Drawing.Color.AntiqueWhite;
            //txt_billNo.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txt_billNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_billNo_Leave(object sender, EventArgs e)
        {
            //txt_billNo.BackColor = System.Drawing.Color.White;
            //txt_billNo.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //txt_billNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_billNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Txt_From_Date.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
