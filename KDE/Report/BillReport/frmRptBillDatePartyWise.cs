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
    public partial class frmRptBillDatePartyWise : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        string str;
        SqlCommand cmd;
        frmEnterPasword formlot = new frmEnterPasword();
        #endregion

        #region " Constructors "
        public frmRptBillDatePartyWise()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void Txt_Com_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    C_Code_Validation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Com_Code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Com_Code.Focus();
                }
                else if (Txt_From_Date.Text == "  /  /")
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
                    con.Open();
                    str = "select * from Trn_Items where Com_Code='" + Txt_Com_Code.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Trn_Items");

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No Data Found...!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Txt_Com_Code.Focus();
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        str = "select sum(amt1)+sum(amt2)+sum(amt3)+sum(amt4)+sum(amt5) from Trn_Items where Com_Code='" + Txt_Com_Code.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        SqlCommand cmdck = new SqlCommand(str, con);
                        var CmdCk = cmdck.ExecuteScalar();
                        int ck1 = Convert.ToInt32(cmdck.ExecuteScalar());

                        string str2 = string.Empty;
                        str2 = "select Amount from Bill_details where Com_Code='" + Txt_Com_Code.Text + "' AND From_date='" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and To_date='" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        SqlCommand cmdck2 = new SqlCommand(str2, con);
                        var CmdCk2 = cmdck2.ExecuteScalar();

                        frmRptBillPartyViewer obj = new frmRptBillPartyViewer();
                        obj.C_Code = Txt_Com_Code.Text;
                        obj.F_Date = Txt_From_Date.Text;
                        obj.T_Date = Txt_To_Date.Text;
                        obj.p_amt = txt_pen_amt.Text;
                        obj.Tot_Amt = txtTot_Amt.Text;

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

        private void Txt_Com_Code_Leave(object sender, EventArgs e)
        {
            Txt_Com_Code.BackColor = System.Drawing.Color.White;
            Txt_Com_Code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_Com_Code.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_Com_Code_Enter(object sender, EventArgs e)
        {
            Txt_Com_Code.BackColor = System.Drawing.Color.AntiqueWhite;
            Txt_Com_Code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_Com_Code.ForeColor = System.Drawing.Color.Black;
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

        private void Txt_Com_Code_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                    c_code_help();

                if (e.KeyCode == Keys.Escape)
                    dataGridView1.Hide();
                Txt_Com_Code.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_To_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Btn_Save.Focus();
        }

        #endregion

        #region " Functions/ Procedures "
        public string pass
        {
            get
            {
                return formlot.textBox1.Text;
            }
            set
            {
                formlot.textBox1.Text = value;
                textBox2.Text = formlot.textBox1.Text;
            }
        }

        private void C_Code_Validation()
        {
            try
            {
                if (Txt_Com_Code.Text == "")
                {
                    MessageBox.Show("Enter Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Com_Code.Focus();
                }
                else
                {

                    con.Open();
                    str = "select * from Mst_Company where Com_Code='" + Txt_Com_Code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        Txt_Com_Name.Text = dr["Com_Name"].ToString();
                        Txt_From_Date.Focus();
                        dr.Close();

                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Company Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Txt_Com_Code.Focus();

                    }


                } con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();

        }

        public void ShowMyDialogBox()
        {
            frmEnterPasword testDialog = new frmEnterPasword();

            // Show testDialog as a modal dialog and determine if DialogResult = OK. 
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox. 

            }
            else
            {
                this.textBox2.Text = testDialog.textBox1.Text;
            }
            testDialog.Dispose();
        }

        private void c_code_help()
        {
            con.Open();
            str = "select Com_Code,Com_Name,Com_Add,Contact_No from Mst_Company ";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataAdapter da;
            da = new SqlDataAdapter(cmd);
            DataSet ds;
            ds = new DataSet();
            da.Fill(ds, "Mst_Company");
            dataGridView1.DataSource = ds.Tables["Mst_Company"];
            dataGridView1.Show();
            con.Close();
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
        #endregion
    }
}
