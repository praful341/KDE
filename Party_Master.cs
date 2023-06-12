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
    public partial class Party_Master : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
       
        public Party_Master()
        {
            InitializeComponent();
        }

        private void Party_Master_Load(object sender, EventArgs e)
        {
            Undergrp1();
            Undergrp2();
            Undergrp3();
            Undergrp4();
            Undergrp5();
            fillgrid();
            Clear();
            color();
        }

        private void txt_party_code_Enter(object sender, EventArgs e)
        {
            txt_party_code.BackColor = Color.AntiqueWhite;
        }

        private void txt_party_name_Enter(object sender, EventArgs e)
        {
            txt_party_name.BackColor = Color.AntiqueWhite;
            txt_party_code.BackColor = Color.White;
        }

        private void txt_party_add_Enter(object sender, EventArgs e)
        {
            txt_party_add.BackColor = Color.AntiqueWhite;
            txt_party_name.BackColor = Color.White;
        }

        private void txt_party_con_no_Enter(object sender, EventArgs e)
        {
            txt_party_con_no.BackColor = Color.AntiqueWhite;
            txt_party_add.BackColor = Color.White;
        }

        private void txt_pan_no_Enter(object sender, EventArgs e)
        {
            txt_pan_no.BackColor = Color.AntiqueWhite;
            txt_party_con_no.BackColor = Color.White;
        }

        private void cmb_item_1_Enter(object sender, EventArgs e)
        {
            cmb_item_1.BackColor = Color.AntiqueWhite;
            txt_pan_no.BackColor = Color.White;
        }

        private void txt_rate_1_Enter(object sender, EventArgs e)
        {
            txt_rate_1.BackColor = Color.AntiqueWhite;
            cmb_item_1.BackColor = Color.White;
        }

        private void cmb_item_2_Enter(object sender, EventArgs e)
        {
            cmb_item_2.BackColor = Color.AntiqueWhite;
            txt_rate_1.BackColor = Color.White;
        }

        private void txt_rate_2_Enter(object sender, EventArgs e)
        {
            txt_rate_2.BackColor = Color.AntiqueWhite;
            cmb_item_2.BackColor = Color.White;
        }

        private void cmb_item_3_Enter(object sender, EventArgs e)
        {
            cmb_item_3.BackColor = Color.AntiqueWhite;
            txt_rate_2.BackColor = Color.White;
        }

        private void txt_rate_3_Enter(object sender, EventArgs e)
        {
            txt_rate_3.BackColor = Color.AntiqueWhite;
            cmb_item_3.BackColor = Color.White;
        }

        private void cmb_item_4_Enter(object sender, EventArgs e)
        {
            cmb_item_4.BackColor = Color.AntiqueWhite;
            txt_rate_3.BackColor = Color.White;
        }

        private void txt_rate_4_Enter(object sender, EventArgs e)
        {
            txt_rate_4.BackColor = Color.AntiqueWhite;
            cmb_item_4.BackColor = Color.White;
        }

        private void cmb_item_5_Enter(object sender, EventArgs e)
        {
            cmb_item_5.BackColor = Color.AntiqueWhite;
            txt_rate_4.BackColor = Color.White;
        }

        private void txt_rate_5_Enter(object sender, EventArgs e)
        {
            txt_rate_5.BackColor = Color.AntiqueWhite;
            cmb_item_5.BackColor = Color.White;
        }

        private void txt_rate_1_Leave(object sender, EventArgs e)
        {
            txt_rate_1.BackColor = Color.White;
        }

        private void txt_rate_2_Leave(object sender, EventArgs e)
        {
            txt_rate_2.BackColor = Color.White;
        }

        private void txt_rate_3_Leave(object sender, EventArgs e)
        {
            txt_rate_3.BackColor = Color.White;
        }

        private void txt_rate_4_Leave(object sender, EventArgs e)
        {
            txt_rate_4.BackColor = Color.White;
        }

        private void txt_rate_5_Leave(object sender, EventArgs e)
        {
            txt_rate_5.BackColor = Color.White;
        }

        private void txt_party_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();
                    string str = "select * from Mst_Party where Party_Code='" + txt_party_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_party_code.Text = dr["Party_Code"].ToString();
                        txt_party_name.Text = dr["Party_Name"].ToString();
                        txt_party_add.Text = dr["Party_Add"].ToString();
                        txt_party_con_no.Text = dr["Party_Con_No"].ToString();
                        txt_pan_no.Text = dr["PAN_No"].ToString();
                        cmb_item_1.Text = dr["Item_1"].ToString();
                        txt_rate_1.Text = dr["Rate_1"].ToString();
                        cmb_item_2.Text = dr["Item_2"].ToString();
                        txt_rate_2.Text = dr["Rate_2"].ToString();
                        cmb_item_3.Text = dr["Item_3"].ToString();
                        txt_rate_3.Text = dr["Rate_3"].ToString();
                        cmb_item_4.Text = dr["Item_4"].ToString();
                        txt_rate_4.Text = dr["Rate_4"].ToString();
                        cmb_item_5.Text = dr["Item_5"].ToString();
                        txt_rate_5.Text = dr["Rate_5"].ToString();
                        txt_extra.Text = dr["Party_Id"].ToString();

                        txt_party_name.Focus();
                        txt_party_code.BackColor = Color.White;
                        txt_rate_1.BackColor = Color.White;
                        txt_rate_2.BackColor = Color.White;
                        txt_rate_3.BackColor = Color.White;
                        txt_rate_4.BackColor = Color.White;
                        txt_rate_5.BackColor = Color.White;
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                    }
                    else
                    {
                        txt_party_name.Text = string.Empty;
                        btn_save.Enabled = true;
                        txt_party_add.Text = string.Empty;
                        txt_party_con_no.Text = string.Empty;
                        txt_pan_no.Text = string.Empty;
                        cmb_item_1.SelectedIndex = -1;
                        txt_rate_1.Text = string.Empty;
                        cmb_item_2.SelectedIndex = -1;
                        txt_rate_2.Text = string.Empty;
                        cmb_item_3.SelectedIndex = -1;
                        txt_rate_3.Text = string.Empty;
                        cmb_item_4.SelectedIndex = -1;
                        txt_rate_4.Text = string.Empty;
                        cmb_item_5.SelectedIndex = -1;
                        txt_rate_5.Text = string.Empty;

                        txt_party_name.Focus();
                        txt_party_code.BackColor = Color.White;
                        txt_rate_1.BackColor = Color.White;
                        txt_rate_2.BackColor = Color.White;
                        txt_rate_3.BackColor = Color.White;
                        txt_rate_4.BackColor = Color.White;
                        txt_rate_5.BackColor = Color.White;
                        btn_update.Enabled = false;
                        btn_save.Enabled = true;
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

        private void txt_pan_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmb_item_1.Focus();
            }
        }

        private void cmb_item_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_1.Focus();
            }
        }

        private void txt_rate_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cmb_item_2.Focus();
            }
        }

        private void cmb_item_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_2.Focus();
            }
        }

        private void txt_rate_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cmb_item_3.Focus();
            }
        }

        private void cmb_item_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_3.Focus();
            }
        }

        private void txt_rate_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cmb_item_4.Focus();
            }
        }

        private void cmb_item_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_4.Focus();
            }
        }

        private void txt_rate_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cmb_item_5.Focus();
            }
        }

        private void cmb_item_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_5.Focus();
            }
        }

        private void txt_rate_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();
                    string str = "select * from Mst_Party where Party_Code='" + txt_party_code.Text + "'";
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

        private void cmb_item_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rate_1.Focus();
            txt_rate_1.BackColor = Color.AntiqueWhite;
            cmb_item_1.BackColor = Color.White;
        }

        private void cmb_item_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rate_2.Focus();
            txt_rate_2.BackColor=Color.AntiqueWhite;
            cmb_item_2.BackColor=Color.White;
        }

        private void cmb_item_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rate_3.Focus();
            txt_rate_3.BackColor = Color.AntiqueWhite;
            cmb_item_3.BackColor = Color.White;
        }

        private void cmb_item_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rate_4.Focus();
            txt_rate_4.BackColor = Color.AntiqueWhite;
            cmb_item_4.BackColor = Color.White;
        }

        private void cmb_item_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rate_5.Focus();
            txt_rate_5.BackColor = Color.AntiqueWhite;
            cmb_item_5.BackColor = Color.White;
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
                    string str = "insert into Mst_Party values('" + txt_party_code.Text + "','" + txt_party_name.Text + "','" + txt_party_add.Text + "','" + txt_party_con_no.Text + "','" + txt_pan_no.Text + "','" + cmb_item_1.GetItemText(cmb_item_1.SelectedItem) + "','" + txt_rate_1.Text + "','" + cmb_item_2.GetItemText(cmb_item_2.SelectedItem) + "','" + txt_rate_2.Text + "','" + cmb_item_3.GetItemText(cmb_item_3.SelectedItem) + "','" + txt_rate_3.Text + "','" + cmb_item_4.GetItemText(cmb_item_4.SelectedItem) + "','" + txt_rate_4.Text + "','" + cmb_item_5.GetItemText(cmb_item_5.SelectedItem) + "','" + txt_rate_5.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved Sucessfuly....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillgrid();
                    Undergrp1();
                    Undergrp2();
                    Undergrp3();
                    Undergrp4();
                    Undergrp5();
                    Clear();
                    color();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             con.Close();
        }

         public void Undergrp1()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmb_item_1.ValueMember = "Item_Name";
                cmb_item_1.DataSource = ds.Tables["Mst_Item"];
                cmb_item_1.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb_item_1.Enabled = true;
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
                 string str = "select Item_Name from Mst_Item";
                 SqlCommand cmd = new SqlCommand(str, con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 da.Fill(ds, "Mst_Item");
                 cmb_item_2.ValueMember = "Item_Name";
                 cmb_item_2.DataSource = ds.Tables["Mst_Item"];
                 cmb_item_2.DropDownStyle = ComboBoxStyle.DropDownList;
                 cmb_item_2.Enabled = true;
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
                 string str = "select Item_Name from Mst_Item";
                 SqlCommand cmd = new SqlCommand(str, con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 da.Fill(ds, "Mst_Item");
                 cmb_item_3.ValueMember = "Item_Name";
                 cmb_item_3.DataSource = ds.Tables["Mst_Item"];
                 cmb_item_3.DropDownStyle = ComboBoxStyle.DropDownList;
                 cmb_item_3.Enabled = true;
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
                 string str = "select Item_Name from Mst_Item";
                 SqlCommand cmd = new SqlCommand(str, con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 da.Fill(ds, "Mst_Item");
                 cmb_item_4.ValueMember = "Item_Name";
                 cmb_item_4.DataSource = ds.Tables["Mst_Item"];
                 cmb_item_4.DropDownStyle = ComboBoxStyle.DropDownList;
                 cmb_item_4.Enabled = true;
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
                 string str = "select Item_Name from Mst_Item";
                 SqlCommand cmd = new SqlCommand(str, con);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataSet ds = new DataSet();
                 da.Fill(ds, "Mst_Item");
                 cmb_item_5.ValueMember = "Item_Name";
                 cmb_item_5.DataSource = ds.Tables["Mst_Item"];
                 cmb_item_5.DropDownStyle = ComboBoxStyle.DropDownList;
                 cmb_item_5.Enabled = true;
                 cmd.ExecuteNonQuery();
                 con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             con.Close();
         }

         public void fillgrid()
         {
             try
             {
                 string str = "select Party_Code,Party_Name,Party_Con_No as Contact_No,Item_1,Rate_1,Item_2,Rate_2,Item_3,Rate_3,Item_4,Rate_4,Item_5,Rate_5 from Mst_Party";
                 SqlDataAdapter da = new SqlDataAdapter(str, con);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;
                 dataGridView1.Show();
                 dataGridView1.ForeColor = Color.Black;
                 Clear();
                 color();
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
                    string str = "update Mst_Party set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "',Party_Con_No='" + txt_party_con_no.Text + "',PAN_No='" + txt_pan_no.Text + "',Party_Add='" + txt_party_add.Text + "',Item_1='" + cmb_item_1.GetItemText(cmb_item_1.SelectedItem) + "',Rate_1='" + txt_rate_1.Text + "',Item_2='" + cmb_item_2.GetItemText(cmb_item_2.SelectedItem) + "',Rate_2='" + txt_rate_2.Text + "',Item_3='" + cmb_item_3.GetItemText(cmb_item_3.SelectedItem) + "',Rate_3='" + txt_rate_3.Text + "',Item_4='" + cmb_item_4.GetItemText(cmb_item_4.SelectedItem) + "',Rate_4='" + txt_rate_4.Text + "',Item_5='" + cmb_item_5.GetItemText(cmb_item_5.SelectedItem) + "',Rate_5='" + txt_rate_5.Text + "' where Party_Id='" + txt_extra.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully..!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    btn_save.Enabled = true;
                    btn_update.Enabled = false;
                    fillgrid();
                    Clear();
                    color();
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

                    txt_party_code.Text = row.Cells["Party_Code"].Value.ToString();
                    txt_party_name.Text = row.Cells["Party_Name"].Value.ToString();
                    txt_party_con_no.Text = row.Cells["Contact_No"].Value.ToString();
                    cmb_item_1.Text = row.Cells["Item_1"].Value.ToString();
                    txt_rate_1.Text = row.Cells["Rate_1"].Value.ToString();
                    cmb_item_2.Text = row.Cells["Item_2"].Value.ToString();
                    txt_rate_2.Text = row.Cells["Rate_2"].Value.ToString();
                    cmb_item_3.Text = row.Cells["Item_3"].Value.ToString();
                    txt_rate_3.Text = row.Cells["Rate_3"].Value.ToString();
                    cmb_item_4.Text = row.Cells["Item_4"].Value.ToString();
                    txt_rate_4.Text = row.Cells["Rate_4"].Value.ToString();
                    cmb_item_5.Text = row.Cells["Item_5"].Value.ToString();
                    txt_rate_5.Text = row.Cells["Rate_5"].Value.ToString();

                    con.Open();
                    string str = "select * from Mst_Party where Party_Code='" + txt_party_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_extra.Text = dr["Party_Code"].ToString();
                        txt_party_add.Text = dr["Party_Add"].ToString();
                        txt_pan_no.Text = dr["PAN_No"].ToString();
                        txt_extra.Text = dr["Party_Id"].ToString();
                        con.Close();
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                        txt_party_code.Focus();
                        txt_rate_1.BackColor = Color.White;
                        txt_rate_2.BackColor = Color.White;
                        txt_rate_3.BackColor = Color.White;
                        txt_rate_4.BackColor = Color.White;
                        txt_rate_5.BackColor = Color.White;
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
            color();
        }

        public void Clear()
        {
            txt_party_code.Text = string.Empty;
            txt_party_name.Text = string.Empty;
            txt_party_add.Text = string.Empty;
            txt_party_con_no.Text = string.Empty;
            txt_pan_no.Text = string.Empty;
            cmb_item_1.SelectedIndex = -1;
            txt_rate_1.Text = string.Empty;
            cmb_item_2.SelectedIndex = -1;
            txt_rate_2.Text = string.Empty;
            cmb_item_3.SelectedIndex = -1;
            txt_rate_3.Text = string.Empty;
            cmb_item_4.SelectedIndex = -1;
            txt_rate_4.Text = string.Empty;
            cmb_item_5.SelectedIndex = -1;
            txt_rate_5.Text = string.Empty;           
        }

        public void color()
        {
            txt_party_code.Focus();
            txt_party_code.BackColor = Color.AntiqueWhite;
            txt_party_name.BackColor = Color.White;
            txt_party_add.BackColor = Color.White;
            txt_party_con_no.BackColor = Color.White;
            txt_pan_no.BackColor = Color.White;
            cmb_item_1.BackColor = Color.White;
            txt_rate_1.BackColor = Color.White;
            cmb_item_2.BackColor = Color.White;
            txt_rate_2.BackColor = Color.White;
            cmb_item_3.BackColor = Color.White;
            txt_rate_3.BackColor = Color.White;
            cmb_item_4.BackColor = Color.White;
            txt_rate_4.BackColor = Color.White;
            cmb_item_5.BackColor = Color.White;
            txt_rate_5.BackColor = Color.White;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_party_code.Text == "")
                {
                    MessageBox.Show("Enter Item Code..", "validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_party_code.Focus();
                    txt_party_code.BackColor = Color.AntiqueWhite;
                    txt_party_name.BackColor = Color.White;

                }
                else
                {
                    if (MessageBox.Show(" Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        string str = "delete Mst_Party where Party_Id='" + txt_extra.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully..!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        fillgrid();
                        Clear();
                        color();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();        
        }

        private void txt_party_con_no_Leave(object sender, EventArgs e)
        {
            contact();
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

        private void txt_party_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }       
}




     
    

