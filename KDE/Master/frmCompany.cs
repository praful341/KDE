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
    public partial class frmCompany : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);


        #region " Data Members "
        #endregion

        #region " Constructors "
        public frmCompany()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_com_code.Focus();
            fill();
        }

        private void txt_com_code_Enter(object sender, EventArgs e)
        {
            txt_com_code.BackColor = Color.AntiqueWhite;
        }

        private void txt_com_code_Leave(object sender, EventArgs e)
        {
            txt_com_code.BackColor = Color.White;
        }

        private void txt_com_name_Enter(object sender, EventArgs e)
        {
            txt_com_name.BackColor = Color.AntiqueWhite;
        }

        private void txt_com_name_Leave(object sender, EventArgs e)
        {
            txt_com_name.BackColor = Color.White;
        }

        private void txt_com_add_Enter(object sender, EventArgs e)
        {
            txt_com_add.BackColor = Color.AntiqueWhite;
        }

        private void txt_com_add_Leave(object sender, EventArgs e)
        {
            txt_com_add.BackColor = Color.White;
        }

        private void txt_contact_no_Enter(object sender, EventArgs e)
        {
            txt_contact_no.BackColor = Color.AntiqueWhite;
        }

        private void txt_contact_no_Leave(object sender, EventArgs e)
        {
            txt_contact_no.BackColor = Color.White;
            contact();
        }

        private void txt_cst_no_Enter(object sender, EventArgs e)
        {
            txt_cst_no.BackColor = Color.AntiqueWhite;
        }

        private void txt_cst_no_Leave(object sender, EventArgs e)
        {
            txt_cst_no.BackColor = Color.White;
        }

        private void txt_gst_no_Enter(object sender, EventArgs e)
        {
            txt_gst_no.BackColor = Color.AntiqueWhite;
        }

        private void txt_gst_no_Leave(object sender, EventArgs e)
        {
            txt_gst_no.BackColor = Color.White;
        }

        private void txt_pan_no_Enter(object sender, EventArgs e)
        {
            txt_pan_no.BackColor = Color.AntiqueWhite;
        }

        private void txt_pan_no_Leave(object sender, EventArgs e)
        {
            txt_pan_no.BackColor = Color.White;
        }

        private void txt_com_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txt_pan_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_contact_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_com_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txt_com_code.Text == string.Empty)
                    {
                        MessageBox.Show("Enter Company Code", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_com_code.Focus();
                    }
                    else
                    {
                        con.Open();
                        string str = "select * from Mst_Company  where Com_Code='" + txt_com_code.Text + "' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            txt_com_name.Text = dr["Com_Name"].ToString();
                            txt_com_add.Text = dr["Com_Add"].ToString();
                            txt_contact_no.Text = dr["Contact_no"].ToString();
                            txt_cst_no.Text = dr["Cst_No"].ToString();
                            txt_gst_no.Text = dr["Gst_No"].ToString();
                            txt_pan_no.Text = dr["Pan_No"].ToString();
                            txt_extra.Text = dr["Com_Id"].ToString();
                            txt_com_name.Focus();
                            btn_save.Enabled = false;
                            btn_update.Enabled = true; ;

                        }
                        else
                        {
                            txt_com_name.Focus();
                            txt_com_name.Text = string.Empty;
                            txt_com_add.Text = string.Empty;
                            txt_contact_no.Text = string.Empty;
                            txt_cst_no.Text = string.Empty;
                            txt_gst_no.Text = string.Empty;
                            txt_pan_no.Text = string.Empty;
                            txt_extra.Text = string.Empty;
                            btn_update.Enabled = false;
                            btn_save.Enabled = true;
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txt_com_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txt_com_name.Text == string.Empty)
                    {
                        MessageBox.Show("Enter Company Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_com_name.Focus();
                    }
                    else
                    {
                        txt_com_add.Focus();
                        txt_com_add.SelectionStart = txt_com_add.Text.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txt_com_add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_contact_no.Focus();
            }
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txt_com_add.Text = textInfo.ToTitleCase(txt_com_add.Text);
            txt_com_add.SelectionStart = txt_com_add.Text.Length;
        }

        private void txt_contact_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsPunctuation(e.KeyChar) & (Keys)e.KeyChar != Keys.Back) || (!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txt_cst_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_gst_no.Focus();
            }
        }

        private void txt_gst_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_pan_no.Focus();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_com_code.Text == string.Empty)
                {
                    MessageBox.Show("Enter Company Code", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_com_name.Text == string.Empty)
                {
                    MessageBox.Show("Enter Company Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_name.Focus();
                }
                else
                {
                    con.Open();
                    string str = "insert into Mst_Company values ('" + txt_com_code.Text + "','" + txt_com_name.Text + "','" + txt_com_add.Text + "','" + txt_contact_no.Text + "','" + txt_cst_no.Text + "','" + txt_gst_no.Text + "','" + txt_pan_no.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    clear();
                    fill();

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

                if (txt_com_code.Text == string.Empty)
                {
                    MessageBox.Show("Enter Company Code", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_com_name.Text == string.Empty)
                {
                    MessageBox.Show("Enter Company Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_name.Focus();
                }
                else
                {
                    con.Open();
                    string str = "update Mst_Company set Com_Code='" + txt_com_code.Text + "',Com_Name='" + txt_com_name.Text + "',Com_Add='" + txt_com_add.Text + "',Contact_No='" + txt_contact_no.Text + "',Cst_No='" + txt_cst_no.Text + "',Gst_No='" + txt_gst_no.Text + "',Pan_No='" + txt_pan_no.Text + "' where Com_Id='" + txt_extra.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    clear();
                    fill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_com_code.Text == string.Empty)
                {
                    MessageBox.Show("Enter Company Code", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_code.Focus();
                }
                else if (txt_com_name.Text == string.Empty)
                {
                    MessageBox.Show("Enter Company Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_com_name.Focus();
                }
                else
                {

                    if (MessageBox.Show(" Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        string str = "delete Mst_Company where Com_Id='" + txt_extra.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        clear();
                        fill();
                    }
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
                    txt_com_code.Text = row.Cells["Company_Code"].Value.ToString();
                    txt_com_name.Text = row.Cells["Company_Name"].Value.ToString();
                    txt_com_add.Text = row.Cells["Company_Address"].Value.ToString();
                    txt_contact_no.Text = row.Cells["Contact_No"].Value.ToString();
                    txt_cst_no.Text = row.Cells["CST_No"].Value.ToString();
                    txt_gst_no.Text = row.Cells["GST_No"].Value.ToString();
                    txt_pan_no.Text = row.Cells["PAN_No"].Value.ToString();
                    txt_com_code.Focus();
                    btn_save.Enabled = false;
                    btn_update.Enabled = true;
                    con.Open();
                    string str = "select Com_Id from Mst_Company where Com_Code='" + txt_com_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_extra.Text = dr["Com_Id"].ToString();
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
        #endregion

        #region " Functions/ Procedures "
        public void fill()
        {
            try
            {
                dataGridView1.ForeColor = Color.Black;
                string str = "Select Com_Code as Company_Code,Com_Name as Company_Name,Com_Add as Company_Address,Contact_No,Cst_No as CST_No,Gst_No as GST_No,Pan_No as PAN_No from Mst_company";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void clear()
        {
            txt_com_code.Text = string.Empty;
            txt_com_name.Text = string.Empty;
            txt_com_add.Text = string.Empty;
            txt_contact_no.Text = string.Empty;
            txt_cst_no.Text = string.Empty;
            txt_gst_no.Text = string.Empty;
            txt_pan_no.Text = string.Empty;
            txt_extra.Text = string.Empty;
            txt_com_code.Focus();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
        }

        private void contact()
        {
            if (txt_contact_no.Text == string.Empty)
            {
                txt_cst_no.Focus();
            }
            else if (txt_contact_no.Text.Length < 10 || txt_contact_no.Text.Length > 13)
            {
                MessageBox.Show("Contact No must be Required 10 Digit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_contact_no.Focus();
                txt_contact_no.Clear();
            }
        }
        #endregion
    }
}
