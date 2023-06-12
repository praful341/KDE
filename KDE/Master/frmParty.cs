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
    public partial class frmParty : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        #endregion

        #region " Constructors "
        public frmParty()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void Party_Master_Load(object sender, EventArgs e)
        {
            DateTime thedate;
            thedate = DateTime.Today;
            txt_date.Text = thedate.ToString("dd/MM/yyyy");

            fillgrid();
            Clear();
            Undergrp1();
            Undergrp2();
            Undergrp3();
            Undergrp4();
            Undergrp5();
            Undergrp6();
            Undergrp7();
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

        private void cmb_item_1_Enter(object sender, EventArgs e)
        {
            cmb_item_1.BackColor = Color.AntiqueWhite;
            Undergrp1();
        }

        private void txt_rate_1_Enter(object sender, EventArgs e)
        {
            txt_rate_1.BackColor = Color.AntiqueWhite;
        }

        private void cmb_item_2_Enter(object sender, EventArgs e)
        {
            cmb_item_2.BackColor = Color.AntiqueWhite;
            Undergrp2();
        }

        private void txt_rate_2_Enter(object sender, EventArgs e)
        {
            txt_rate_2.BackColor = Color.AntiqueWhite;
        }

        private void cmb_item_3_Enter(object sender, EventArgs e)
        {
            cmb_item_3.BackColor = Color.AntiqueWhite;
            Undergrp3();
        }

        private void txt_rate_3_Enter(object sender, EventArgs e)
        {
            txt_rate_3.BackColor = Color.AntiqueWhite;
        }

        private void cmb_item_4_Enter(object sender, EventArgs e)
        {
            cmb_item_4.BackColor = Color.AntiqueWhite;
            Undergrp4();
        }

        private void txt_rate_4_Enter(object sender, EventArgs e)
        {
            txt_rate_4.BackColor = Color.AntiqueWhite;
        }

        private void cmb_item_5_Enter(object sender, EventArgs e)
        {
            cmb_item_5.BackColor = Color.AntiqueWhite;
            Undergrp5();
        }

        private void txt_rate_5_Enter(object sender, EventArgs e)
        {
            txt_rate_5.BackColor = Color.AntiqueWhite;
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

        private void cmb_item_1_Leave(object sender, EventArgs e)
        {
            cmb_item_1.BackColor = Color.White;
        }

        private void cmb_item_2_Leave(object sender, EventArgs e)
        {
            cmb_item_2.BackColor = Color.White;
        }

        private void cmb_item_3_Leave(object sender, EventArgs e)
        {
            cmb_item_3.BackColor = Color.White;
        }

        private void cmb_item_4_Leave(object sender, EventArgs e)
        {
            cmb_item_4.BackColor = Color.White;
        }

        private void cmb_item_5_Leave(object sender, EventArgs e)
        {
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
                        cmb_item_6.Text = dr["Item_6"].ToString();
                        txt_rate_6.Text = dr["Rate_6"].ToString();
                        cmb_item_7.Text = dr["Item_7"].ToString();
                        txt_rate_7.Text = dr["Rate_7"].ToString();
                        txt_extra.Text = dr["Party_Code"].ToString();

                        txt_party_name.Focus();
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                    }
                    else
                    {
                        //txt_party_name.Text = string.Empty;
                        // btn_save.Enabled = true;
                        //txt_party_add.Text = string.Empty;
                        //txt_party_con_no.Text = string.Empty;
                        //txt_pan_no.Text = string.Empty;
                        cmb_item_1.SelectedIndex = -1;
                        //txt_rate_1.Text = string.Empty;
                        cmb_item_2.SelectedIndex = -1;
                        //txt_rate_2.Text = string.Empty;
                        cmb_item_3.SelectedIndex = -1;
                        //txt_rate_3.Text = string.Empty;
                        cmb_item_4.SelectedIndex = -1;
                        //txt_rate_4.Text = string.Empty;
                        cmb_item_5.SelectedIndex = -1;
                        //txt_rate_5.Text = string.Empty;
                        cmb_item_6.SelectedIndex = -1;
                        cmb_item_7.SelectedIndex = -1;

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

        private void txt_pan_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rs.Focus();
            }
        }

        private void cmb_item_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_1.Focus();
                //fillrate1();
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
                //fillrate2();
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
                //fillrate3();
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
                //fillrate4();
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
                // fillrate5();
            }
        }

        private void txt_rate_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cmb_item_6.Focus();
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
                    string str = "insert into Mst_Party values('" + txt_party_code.Text + "','" + txt_party_name.Text + "','" + txt_party_add.Text + "','" + txt_party_con_no.Text + "','" + txt_pan_no.Text + "','" + cmb_item_1.GetItemText(cmb_item_1.SelectedItem) + "','" + txt_rate_1.Text + "','" + cmb_item_2.GetItemText(cmb_item_2.SelectedItem) + "','" + txt_rate_2.Text + "','" + cmb_item_3.GetItemText(cmb_item_3.SelectedItem) + "','" + txt_rate_3.Text + "','" + cmb_item_4.GetItemText(cmb_item_4.SelectedItem) + "','" + txt_rate_4.Text + "','" + cmb_item_5.GetItemText(cmb_item_5.SelectedItem) + "','" + txt_rate_5.Text + "','" + cmb_item_6.GetItemText(cmb_item_6.SelectedItem) + "','" + txt_rate_6.Text + "','" + cmb_item_7.GetItemText(cmb_item_7.SelectedItem) + "','" + txt_rate_7.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    if (txt_rs.Text != "")
                    {
                        string strr = "insert into Mst_Payment (billNo,partyCode,partyName,billTo,billAmount)values (" + Convert.ToInt32(0) + ",'" + txt_party_code.Text + "','" + txt_party_name.Text + "','" + DateTime.Parse(txt_date.Text).ToString("MM/dd/yyyy") + "'," + txt_rs.Text + ")";
                        SqlCommand cmdd = new SqlCommand(strr, con);
                        cmdd.ExecuteNonQuery();
                    }
                    //if (txt_rs.Text != "")
                    //{
                    //    string strr = "insert into Payment_Details (billNo,partyCode,partyName,billTo,billAmount)values (" + Convert.ToInt32(0) + ",'" + txt_party_code.Text + "','" + txt_party_name.Text + "','" + DateTime.Parse(txt_date.Text).ToString("MM/dd/yyyy") + "'," + txt_rs.Text + ")";
                    //    SqlCommand cmdd = new SqlCommand(strr, con);
                    //    cmdd.ExecuteNonQuery();
                    //}
                    con.Close();
                    MessageBox.Show("Record Saved Sucessfuly....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillgrid();
                    Undergrp1();
                    Undergrp2();
                    Undergrp3();
                    Undergrp4();
                    Undergrp5();
                    Undergrp6();
                    Undergrp7();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        //public void fillrate1()
        //{
        //    try
        //    {
        //        con.Open();
        //        string str = "select Item_Rate from Mst_Item where Item_Name='" + cmb_item_1.GetItemText(cmb_item_1.SelectedItem) + "'";
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            txt_rate_1.Text = dr["Item_Rate"].ToString();
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    con.Close();
        //}

        //public void fillrate2()
        //{
        //    try
        //    {
        //        con.Open();
        //        string str = "select Item_Rate from Mst_Item where Item_Name='" + cmb_item_2.GetItemText(cmb_item_2.SelectedItem) + "'";
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            txt_rate_2.Text = dr["Item_Rate"].ToString();
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    con.Close();
        //}

        //public void fillrate3()
        //{
        //    try
        //    {
        //        con.Open();
        //        string str = "select Item_Rate from Mst_Item where Item_Name='" + cmb_item_3.GetItemText(cmb_item_3.SelectedItem) + "'";
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            txt_rate_3.Text = dr["Item_Rate"].ToString();
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    con.Close();
        //}

        //public void fillrate4()
        //{
        //    try
        //    {
        //        con.Open();
        //        string str = "select Item_Rate from Mst_Item where Item_Name='" + cmb_item_4.GetItemText(cmb_item_4.SelectedItem) + "'";
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            txt_rate_4.Text = dr["Item_Rate"].ToString();
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    con.Close();
        //}

        //public void fillrate5()
        //{
        //    try
        //    {
        //        con.Open();
        //        string str = "select Item_Rate from Mst_Item where Item_Name='" + cmb_item_5.GetItemText(cmb_item_5.SelectedItem) + "'";
        //        SqlCommand cmd = new SqlCommand(str, con);
        //        cmd.ExecuteNonQuery();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            dr.Read();
        //            txt_rate_5.Text = dr["Item_Rate"].ToString();
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    con.Close();
        //}

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
                    string str = "update Mst_Party set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "',Party_Con_No='" + txt_party_con_no.Text + "',PAN_No='" + txt_pan_no.Text + "',Party_Add='" + txt_party_add.Text + "',Item_1='" + cmb_item_1.GetItemText(cmb_item_1.SelectedItem) + "',Rate_1='" + txt_rate_1.Text + "',Item_2='" + cmb_item_2.GetItemText(cmb_item_2.SelectedItem) + "',Rate_2='" + txt_rate_2.Text + "',Item_3='" + cmb_item_3.GetItemText(cmb_item_3.SelectedItem) + "',Rate_3='" + txt_rate_3.Text + "',Item_4='" + cmb_item_4.GetItemText(cmb_item_4.SelectedItem) + "',Rate_4='" + txt_rate_4.Text + "',Item_5='" + cmb_item_5.GetItemText(cmb_item_5.SelectedItem) + "',Rate_5='" + txt_rate_5.Text + "',Item_6='" + cmb_item_6.GetItemText(cmb_item_6.SelectedItem) + "',Rate_6='" + txt_rate_6.Text + "',Item_7='" + cmb_item_7.GetItemText(cmb_item_7.SelectedItem) + "',Rate_7='" + txt_rate_7.Text + "' where Party_Code='" + txt_extra.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    string str1 = "update Trn_Items set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "' where Party_Code='" + txt_extra.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(str1, con);
                    cmd1.ExecuteNonQuery();

                    string str2 = "update Payment_Details set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "' where Party_Code='" + txt_extra.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    cmd2.ExecuteNonQuery();

                    string str3 = "update Mst_Transaction set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "' where Party_Code='" + txt_extra.Text + "'";
                    SqlCommand cmd3 = new SqlCommand(str3, con);
                    cmd3.ExecuteNonQuery();

                    string str4 = "update Mst_Payment set partyCode='" + txt_party_code.Text + "',partyName='" + txt_party_name.Text + "' where partyCode='" + txt_extra.Text + "'";
                    SqlCommand cmd4 = new SqlCommand(str4, con);
                    cmd4.ExecuteNonQuery();

                    string str5 = "update Bill_details set Party_Code='" + txt_party_code.Text + "',Party_Name='" + txt_party_name.Text + "' where Party_Code='" + txt_extra.Text + "'";
                    SqlCommand cmd5 = new SqlCommand(str5, con);
                    cmd5.ExecuteNonQuery();
                    
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
                    cmb_item_6.Text = row.Cells["Item_6"].Value.ToString();
                    txt_rate_6.Text = row.Cells["Rate_6"].Value.ToString();
                    cmb_item_7.Text = row.Cells["Item_7"].Value.ToString();
                    txt_rate_7.Text = row.Cells["Rate_7"].Value.ToString();
                    txt_extra.Text = row.Cells["Party_Code"].Value.ToString();

                    con.Open();
                    string str = "select * from Mst_Party where Party_Code='" + txt_party_code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();

                        txt_party_add.Text = dr["Party_Add"].ToString();
                        txt_pan_no.Text = dr["PAN_No"].ToString();
                        //txt_extra.Text = dr["Party_Id"].ToString();
                        con.Close();
                        btn_save.Enabled = false;
                        btn_update.Enabled = true;
                        txt_party_code.Focus();
                    }
                    con.Close();
                    con.Open();
                    string strr = "select * from Bill_details where Party_Code='" + txt_party_code.Text + "'";
                    SqlCommand cmdd = new SqlCommand(strr, con);
                    cmdd.ExecuteNonQuery();
                    SqlDataReader drr = cmdd.ExecuteReader();

                    if (drr.HasRows)
                    {
                        drr.Read();
                        txt_date.Text = drr["To_date"].ToString();
                        txt_rs.Text = drr["Amount"].ToString();
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
                        string str = "delete Mst_Party where Party_Code='" + txt_extra.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        string str2 = "delete Bill_details where Party_Code='" + txt_extra.Text + "'";
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        cmd2.ExecuteNonQuery();

                        string str3 = "delete Mst_Payment where partyCode='" + txt_extra.Text + "'";
                        SqlCommand cmd3 = new SqlCommand(str3, con);
                        cmd3.ExecuteNonQuery();

                        string str4 = "delete Mst_Transaction where Party_Code='" + txt_extra.Text + "'";
                        SqlCommand cmd4 = new SqlCommand(str4, con);
                        cmd4.ExecuteNonQuery();

                        string str5 = "delete Payment_Details where Party_Code='" + txt_extra.Text + "'";
                        SqlCommand cmd5 = new SqlCommand(str5, con);
                        cmd5.ExecuteNonQuery();

                        string str6 = "delete Trn_Items where Party_Code='" + txt_extra.Text + "'";
                        SqlCommand cmd6 = new SqlCommand(str6, con);
                        cmd6.ExecuteNonQuery();

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

        private void txt_rs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmb_item_1.Focus();
            }
        }

        #endregion

        #region " Functions/ Procedures "
        public void fillgrid()
        {
            try
             {
                string str = "select Party_Code,Party_Name,Party_Con_No as Contact_No,Item_1,Rate_1,Item_2,Rate_2,Item_3,Rate_3,Item_4,Rate_4,Item_5,Rate_5,Item_6,Rate_6,Item_7,Rate_7 from Mst_Party ORDER BY Party_Code ";
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
            txt_party_code.Text = string.Empty;
            txt_party_name.Text = string.Empty;
            txt_party_add.Text = string.Empty;
            txt_party_con_no.Text = string.Empty;
            txt_pan_no.Text = string.Empty;
            txt_rs.Text = string.Empty;
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
            cmb_item_6.SelectedIndex = -1;
            txt_rate_6.Text = string.Empty;
            cmb_item_7.SelectedIndex = -1;
            txt_rate_7.Text = string.Empty;
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
                string str = "select Item_Name from Mst_Item where Item_Code=02";
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
                string str = "select Item_Name from Mst_Item where Item_Code=03";
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
                string str = "select Item_Name from Mst_Item where Item_Code=04";
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
                string str = "select Item_Name from Mst_Item where Item_Code=05";
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
        public void Undergrp6()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=06";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmb_item_6.ValueMember = "Item_Name";
                cmb_item_6.DataSource = ds.Tables["Mst_Item"];
                cmb_item_6.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb_item_6.Enabled = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void Undergrp7()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item where Item_Code=07";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmb_item_7.ValueMember = "Item_Name";
                cmb_item_7.DataSource = ds.Tables["Mst_Item"];
                cmb_item_7.DropDownStyle = ComboBoxStyle.DropDownList;
                cmb_item_7.Enabled = true;
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

        private void cmb_item_6_Enter(object sender, EventArgs e)
        {
            cmb_item_6.BackColor = Color.AntiqueWhite;
            Undergrp6();
        }

        private void cmb_item_6_Leave(object sender, EventArgs e)
        {
            cmb_item_6.BackColor = Color.White;
        }

        private void cmb_item_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_6.Focus();
                // fillrate5();
            }
        }

        private void cmb_item_7_Enter(object sender, EventArgs e)
        {
            cmb_item_7.BackColor = Color.AntiqueWhite;
            Undergrp7();
        }

        private void cmb_item_7_Leave(object sender, EventArgs e)
        {
            cmb_item_7.BackColor = Color.White;
        }

        private void cmb_item_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt_rate_7.Focus();
                // fillrate5();
            }
        }

        private void txt_rate_6_Enter(object sender, EventArgs e)
        {
            txt_rate_6.BackColor = Color.AntiqueWhite;
        }

        private void txt_rate_6_Leave(object sender, EventArgs e)
        {
            txt_rate_6.BackColor = Color.White;
        }

        private void txt_rate_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!!char.IsLetter(e.KeyChar) & (Keys)e.KeyChar != Keys.Back))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                cmb_item_7.Focus();
            }
        }

        private void txt_rate_7_Leave(object sender, EventArgs e)
        {
            txt_rate_7.BackColor = Color.White;
        }

        private void txt_rate_7_Enter(object sender, EventArgs e)
        {
            txt_rate_7.BackColor = Color.AntiqueWhite;
        }

        private void txt_rate_7_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}







