using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace KDE
{
    public partial class frmPurchaseParty : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        #endregion

        #region " Constructors "
        public frmPurchaseParty()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void Party_Master_Load(object sender, EventArgs e)
        {
            DateTime thedate;
            thedate = DateTime.Today;

            fillgrid();
            Clear();
            Undergrp1();
            Undergrp2();
            Undergrp3();
            Undergrp4();
            Undergrp5();
        }

        private void txt_party_code_Enter(object sender, EventArgs e)
        {
            txt_party_code.BackColor = Color.AntiqueWhite;
        }

        private void txt_party_name_Enter(object sender, EventArgs e)
        {
            txt_party_name.BackColor = Color.AntiqueWhite;
        }

        private void txt_party_add_Enter(object sender, EventArgs e)
        {
            txt_party_add.BackColor = Color.AntiqueWhite;
        }

        private void txt_party_con_no_Enter(object sender, EventArgs e)
        {
            txt_party_con_no.BackColor = Color.AntiqueWhite;
        }

        private void txt_pan_no_Enter(object sender, EventArgs e)
        {
            txt_pan_no.BackColor = Color.AntiqueWhite;
        }

        private void txt_party_code_Leave(object sender, EventArgs e)
        {
            txt_party_code.BackColor = Color.White;
        }

        private void txt_party_name_Leave(object sender, EventArgs e)
        {
            txt_party_name.BackColor = Color.White;
        }

        private void txt_party_add_Leave(object sender, EventArgs e)
        {
            txt_party_add.BackColor = Color.White;
        }

        private void txt_party_con_no_Leave(object sender, EventArgs e)
        {
            contact();
            txt_party_con_no.BackColor = Color.White;
        }

        private void txt_pan_no_Leave(object sender, EventArgs e)
        {
            txt_pan_no.BackColor = Color.White;
        }
        private void txt_party_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();
                    string str = "select * from Mst_PurchaseParty where Party_Code='" + txt_party_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtPartyID.Text = dr["Party_Id"].ToString();
                        txt_party_code.Text = dr["Party_Code"].ToString();
                        txt_party_name.Text = dr["Party_Name"].ToString();
                        txt_party_add.Text = dr["Party_Add"].ToString();
                        txt_party_con_no.Text = dr["Party_Con_No"].ToString();
                        txt_pan_no.Text = dr["PAN_No"].ToString();


                        txt_party_name.Focus();
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                    }
                    else
                    {
                        txt_party_name.Focus();
                        btn_update.Enabled = true;
                        btn_save.Enabled = false;
                    }
                    dr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txt_party_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_party_add.Focus();
                txt_party_add.SelectionStart = txt_party_add.Text.Length;
            }
        }

        private void txt_party_add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_party_con_no.Focus();
            }
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txt_party_add.Text = textInfo.ToTitleCase(txt_party_add.Text);
            txt_party_add.SelectionStart = txt_party_add.Text.Length;
        }

        private void txt_party_con_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back) || (!!char.IsPunctuation(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                txt_pan_no.Focus();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_party_code.Text == "")
                {
                    MessageBox.Show("Enter Party Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_code.Focus();
                    txt_party_code.BackColor = Color.AntiqueWhite;
                    txt_party_name.BackColor = Color.White;
                }
                else if (txt_party_name.Text == "")
                {
                    MessageBox.Show("Enter Party Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_name.Focus();
                    txt_party_name.BackColor = Color.AntiqueWhite;
                    txt_party_code.BackColor = Color.White;
                }
                else
                {
                    con.Open();
                    string str = "insert into Mst_PurchaseParty values('" + txt_party_code.Text + "','" + txt_party_name.Text + "','" + txt_party_add.Text + "','" + txt_party_con_no.Text + "','" + txt_pan_no.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved Sucessfuly....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillgrid();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_party_code.Text == "")
                {
                    MessageBox.Show("Enter Party Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_code.Focus();
                }
                else if (txt_party_name.Text == "")
                {
                    MessageBox.Show("Enter Party Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_name.Focus();
                }
                else
                {
                    con.Open();
                    string str = "update Mst_PurchaseParty set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "',Party_Con_No='" + txt_party_con_no.Text + "',PAN_No='" + txt_pan_no.Text + "',Party_Add='" + txt_party_add.Text + "' WHERE Party_Id = '" + txtPartyID.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Updated Successfully..!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    btn_save.Enabled = true;
                    btn_update.Enabled = false;
                    fillgrid();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    txtPartyID.Text = row.Cells["Party_Id"].Value.ToString();
                    txt_party_code.Text = row.Cells["Party_Code"].Value.ToString();
                    txt_party_name.Text = row.Cells["Party_Name"].Value.ToString();
                    txt_party_con_no.Text = row.Cells["Contact_No"].Value.ToString();

                    con.Open();
                    string str = "select * from Mst_PurchaseParty where Party_Id='" + txtPartyID.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        txt_party_add.Text = dr["Party_Add"].ToString();
                        txt_pan_no.Text = dr["PAN_No"].ToString();
                        con.Close();
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                        txt_party_code.Focus();
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txt_pan_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            //{
            //    e.Handled = true;
            //}
            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();
                    string str = "select * from Mst_PurchaseParty where Party_Code='" + txt_party_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    txt_party_name.BackColor = Color.White;
                    if (dr.Read())
                    {
                        btn_save.Enabled = false;
                        btn_update.Focus();
                        btn_update.Enabled = true;
                    }
                    else
                    {
                        btn_save.Focus();
                        btn_save.Enabled = true;
                        btn_update.Enabled = false;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_party_code.Text == "")
                {
                    MessageBox.Show("Enter Party Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_code.Focus();
                }
                else
                {
                    if (MessageBox.Show(" Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        string str = "delete Mst_PurchaseParty where Party_Id='" + txtPartyID.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully..!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();

                        fillgrid();
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txt_party_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txt_party_name.Focus();
            }
        }

        #endregion

        #region " Functions/ Procedures "
        public void fillgrid()
        {
            try
            {
                string str = "select Party_Id, Party_Code, Party_Name, Party_Con_No AS Contact_No from Mst_PurchaseParty ORDER BY Party_Code ";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Show();
                dataGridView1.ForeColor = Color.Black;
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void Clear()
        {
            txtPartyID.Text = string.Empty;
            txt_party_code.Text = string.Empty;
            txt_party_name.Text = string.Empty;
            txt_party_add.Text = string.Empty;
            txt_party_con_no.Text = string.Empty;
            txt_pan_no.Text = string.Empty;
            txt_party_code.Focus();
        }

        private void contact()
        {
            if (txt_party_con_no.Text == string.Empty)
            {
                txt_pan_no.Focus();
            }
            else if (txt_party_con_no.Text.Length < 10 || txt_party_con_no.Text.Length > 13)
            {
                MessageBox.Show("Contact No must be Required 10 Digit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_party_con_no.Focus();
                txt_party_con_no.Clear();
            }
        }

        public void Undergrp1()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=01";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.Close();

        }

        public void Undergrp2()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=02";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void Undergrp3()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=03";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void Undergrp4()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=04";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void Undergrp5()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=05";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        #endregion
    }
}







