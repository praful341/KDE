using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Drawing.Printing;


namespace KDE
{
    public partial class Bill_Details : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        string str;
        #endregion

        #region " Constructors "
        public Bill_Details()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void txtParty_Code_Enter(object sender, EventArgs e)
        {
            if (txtParty_Code.Focused == true)
            {
                txtParty_Code.SelectAll();
                txtParty_Code.BackColor = System.Drawing.Color.AntiqueWhite;
                txtParty_Code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtParty_Code.ForeColor = System.Drawing.Color.Black;
            }
            if (txtbillno.Focused == true)
            {
                txtbillno.SelectAll();
                txtbillno.BackColor = System.Drawing.Color.AntiqueWhite;
                txtbillno.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtbillno.ForeColor = System.Drawing.Color.Black;
            }
            if (Txt_From_Date.Focused == true)
            {
                Txt_From_Date.SelectAll();
                Txt_From_Date.BackColor = System.Drawing.Color.AntiqueWhite;
                Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_From_Date.ForeColor = System.Drawing.Color.Black;
            }
            if (Txt_To_Date.Focused == true)
            {
                Txt_To_Date.SelectAll();
                Txt_To_Date.BackColor = System.Drawing.Color.AntiqueWhite;
                Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_To_Date.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtParty_Code_Leave(object sender, EventArgs e)
        {
            if (txtParty_Code.Focused != true)
            {
                txtParty_Code.BackColor = System.Drawing.Color.White;
                txtParty_Code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtParty_Code.ForeColor = System.Drawing.Color.Black;
            }
            if (txtbillno.Focused != true)
            {
                txtbillno.BackColor = System.Drawing.Color.White;
                txtbillno.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtbillno.ForeColor = System.Drawing.Color.Black;
            }
            if (Txt_From_Date.Focused != true)
            {
                Txt_From_Date.BackColor = System.Drawing.Color.White;
                Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_From_Date.ForeColor = System.Drawing.Color.Black;
            }
            if (Txt_To_Date.Focused != true)
            {
                Txt_To_Date.BackColor = System.Drawing.Color.White;
                Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_To_Date.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txtParty_Code.Focus();
        }

        private void txtParty_Code_MouseClick(object sender, MouseEventArgs e)
        {
            txtParty_Code.SelectAll();
            txtbillno.SelectAll();
            Txt_From_Date.SelectAll();
            Txt_To_Date.SelectAll();
        }

        private void txtParty_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                P_Code_Validation();
            }
        }
        
        private void txtParty_Code_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtbillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Txt_From_Date.Focus();
            }
        }

        private void Txt_From_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Txt_To_Date.Focus();
            }
        }

        private void Txt_To_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Btn_Save.Focus();
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (txtParty_Code.Text != "")
            {
                if (txtbillno.Text == "" && Txt_From_Date.Text == "  /  /" && Txt_To_Date.Text == "  /  /")
                {
                    str = "select Bill_No,Party_Code,Party_Name,From_date,To_date,Amount from Bill_details where Party_Code='" + txtParty_Code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataAdapter da;
                    da = new SqlDataAdapter(cmd);
                    DataSet ds;
                    ds = new DataSet();
                    da.Fill(ds, "Bill_details");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Data Not Found..!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtParty_Code.Focus();
                        txtParty_Code.SelectAll();

                    }
                    else
                    {
                        dataGridView1.DataSource = ds.Tables["Bill_details"];
                        this.dataGridView1.Columns["Bill_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        this.dataGridView1.Columns["From_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        this.dataGridView1.Columns["To_date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                        this.dataGridView1.AutoResizeColumn(2, DataGridViewAutoSizeColumnMode.DisplayedCells);
                        dataGridView1.Show();
                    }
                    con.Close();
                }
                else
                {
                    if (txtbillno.Text != "" && Txt_From_Date.Text == "  /  /" && Txt_To_Date.Text == "  /  /")
                    {
                        str = "select Bill_No,Party_Code,Party_Name,From_date,To_date,Amount from Bill_details where Party_Code='" + txtParty_Code.Text + "' and Bill_No='" + txtbillno.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        SqlDataAdapter da;
                        da = new SqlDataAdapter(cmd);
                        DataSet ds;
                        ds = new DataSet();
                        da.Fill(ds, "Bill_details");
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Data Not Found..!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtParty_Code.Focus();
                            txtParty_Code.SelectAll();

                        }
                        else
                        {
                            dataGridView1.DataSource = ds.Tables["Bill_details"];
                            this.dataGridView1.Columns["Bill_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                            dataGridView1.Show();
                        }
                        con.Close();
                    }
                    else
                    {
                        if (txtbillno.Text == "" && Txt_From_Date.Text != "  /  /" && Txt_To_Date.Text != "  /  /")
                        {
                            str = "select Bill_No,Party_Code,Party_Name,From_date,To_date,Amount from Bill_details where Party_Code='" + txtParty_Code.Text + "' and From_date >= '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and To_date <='" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                            SqlCommand cmd = new SqlCommand(str, con);
                            SqlDataAdapter da;
                            da = new SqlDataAdapter(cmd);
                            DataSet ds;
                            ds = new DataSet();
                            da.Fill(ds, "Bill_details");
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                MessageBox.Show("Data Not Found..!!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtParty_Code.Focus();
                                txtParty_Code.SelectAll();

                            }
                            else
                            {
                                dataGridView1.DataSource = ds.Tables["Bill_details"];
                                this.dataGridView1.Columns["Bill_No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                this.dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                                dataGridView1.Show();
                            }
                            con.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtParty_Code.Focus();
                txtParty_Code.SelectAll();
            }
        }
        #endregion

        #region " Functions/ Procedures "
        private void P_Code_Validation()
        {
            try
            {
                if (txtParty_Code.Text == "")
                {
                    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtParty_Code.Focus();
                }
                else
                {
                    con.Open();
                    str = "select * from Mst_Party where Party_Code='" + txtParty_Code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtParty_Name.Text = dr["Party_Name"].ToString();
                        txtbillno.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid PartyCode", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }
        #endregion
    }
}
