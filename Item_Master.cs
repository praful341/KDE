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
    public partial class Item_Master : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        public Item_Master()
        {
            InitializeComponent();
        }

        private void Item_Master_Load(object sender, EventArgs e)
        {
            fillgrid();
            Clear();
        }

        private void txt_item_code_Enter(object sender, EventArgs e)
        {
            txt_item_code.BackColor = Color.AntiqueWhite;           
        }

        private void txt_item_name_Enter(object sender, EventArgs e)
        {
            txt_item_name.BackColor = Color.AntiqueWhite;
            txt_item_code.BackColor = Color.White;
        }

        private void txt_item_name_Leave(object sender, EventArgs e)
        {
            txt_item_name.BackColor = Color.White;
        }

        private void txt_item_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txt_item_name.Focus();

                    if (txt_item_code.Text == "")
                    {
                        MessageBox.Show("Enter Symbol..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_item_code.Focus();
                        txt_item_code.BackColor = Color.AntiqueWhite;
                        txt_item_name.BackColor = Color.White;
                    }
                    else
                    {
                        con.Open();
                        string str = "select * from Mst_Item where Item_Code='" + txt_item_code.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            txt_item_code.Text = dr["Item_Code"].ToString();
                            txt_item_name.Text = dr["Item_Name"].ToString();
                            txt_extra.Text = dr["Item_Id"].ToString();
                            txt_item_code.BackColor = Color.White;
                            btn_save.Enabled = false;
                            btn_update.Enabled = true;
                        }
                        else
                        {
                            txt_item_name.Text = string.Empty;
                            btn_save.Enabled = true;
                            btn_update.Enabled = false;
                        }
                        dr.Close();
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

        private void txt_item_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();
                    string str = "select * from Mst_Item where Item_Code='" + txt_item_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    txt_item_name.BackColor = Color.White;
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_item_code.Text == "")
                {
                    MessageBox.Show("Enter Item Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_item_code.Focus();
                    txt_item_code.BackColor = Color.AntiqueWhite;
                    txt_item_name.BackColor = Color.White;
                }
                else if (txt_item_name.Text == "")
                {
                    MessageBox.Show("Enter Item Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_item_name.Focus();
                    txt_item_name.BackColor = Color.AntiqueWhite;
                    txt_item_code.BackColor = Color.White;
                }
                else
                {
                    con.Open();
                    string str = "insert into Mst_Item values('" + txt_item_code.Text + "','" + txt_item_name.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved Sucessfuly....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    fillgrid();
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
                if (txt_item_code.Text == "")
                {
                    MessageBox.Show("Enter Item Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_item_code.Focus();
                    txt_item_code.BackColor = Color.AntiqueWhite;
                    txt_item_name.BackColor = Color.White;
                }
                else if (txt_item_name.Text == "")
                {
                    MessageBox.Show("Enter Item Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_item_name.Focus();
                    txt_item_name.BackColor = Color.AntiqueWhite;
                    txt_item_code.BackColor = Color.White;
                }
            else
                {
                    con.Open();
                    string str = "update Mst_Item set Item_Code='" + txt_item_code.Text + "',Item_Name='" + txt_item_name.Text + "' where Item_Id='" + txt_extra.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully..!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();                    
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_item_code.Text == "")
                {
                    MessageBox.Show("Enter Item Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_item_code.Focus();
                    txt_item_code.BackColor = Color.AntiqueWhite;
                    txt_item_name.BackColor = Color.White;

                }
                else if (txt_item_name.Text == "")
                {
                    MessageBox.Show("Enter Item Name", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_item_name.Focus();
                    txt_item_name.BackColor = Color.AntiqueWhite;
                    txt_item_code.BackColor = Color.White;
                }
                else
                {
                    if (MessageBox.Show(" Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        string str = "delete Mst_Item where Item_Id='" + txt_extra.Text + "'";
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            btn_save.Enabled = true;
        }

        public void Clear()
        {
            txt_item_code.Text = string.Empty;
            txt_item_name.Text = string.Empty;
            txt_item_code.Focus();
            txt_item_code.BackColor = Color.AntiqueWhite;
            txt_item_name.BackColor = Color.White;
        }

        public void fillgrid()
        {
            try
            {
                string str = "select Item_Code,Item_Name from Mst_Item";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Show();
                dataGridView1.ForeColor = Color.Black;
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

                    txt_item_code.Text = row.Cells["Item_Code"].Value.ToString();
                    txt_item_name.Text = row.Cells["Item_Name"].Value.ToString();
                    btn_save.Enabled = false;
                    btn_update.Enabled = true;                   

                    con.Open();
                    string str = "select Item_Id from Mst_Item where Item_Code='" + txt_item_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_extra.Text = dr["Item_Id"].ToString();
                        txt_item_code.Focus();
                        txt_item_code.BackColor = Color.AntiqueWhite;
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

        private void txt_item_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }               
    }       
}

