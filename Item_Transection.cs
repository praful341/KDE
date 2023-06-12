using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace ItemTransection
{
    public partial class Item_Transection : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDE"].ConnectionString);
        SqlCommand cmd;
        string str;
        SqlDataAdapter da;
        SqlDataReader dr;
        public Item_Transection()
        {
            InitializeComponent();
        }

        public void count()
        {
            string qr = "select MAX(Bill_No) from Trn_Items";
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string x = dr[0].ToString();

                if (x.ToString() == "")
                {
                    txtbillno.Text = "1";
                }

                else
                {
                    //int x = int.Parse(dr[0].ToString());
                    int z = int.Parse(x.ToString());
                    z = z + 1;
                    txtbillno.Text = z.ToString();
                }
            }
            else
            {

                txtbillno.Text = "1";
            }
            con.Close();
        }

        private void txtcomcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_comcode();
            }
        }
        public void validate_comcode()
        {
            if (txtcomcode.Text == "")
            {
                MessageBox.Show("Enter Company Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcomcode.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Company where Com_Code='" + txtcomcode.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtcomcode.Text = dr["Com_Code"].ToString();
                        txtcomname.Text = dr["Com_Name"].ToString();
                        txtbillno.Focus();
                        txtcomcode.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Company Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcomcode.Focus();
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
        }

        private void txtcomcode_Enter(object sender, EventArgs e)
        {
            txtcomcode.BackColor = Color.AntiqueWhite;
        }

        private void txtbillno_Enter(object sender, EventArgs e)
        {
            txtbillno.BackColor = Color.AntiqueWhite;
        }

        private void txtdate_Enter(object sender, EventArgs e)
        {
            txtdate.BackColor = Color.AntiqueWhite;
        }

        private void txtpcode_Enter(object sender, EventArgs e)
        {
            txtpcode.BackColor = Color.AntiqueWhite;
        }

        private void txtnote_Enter(object sender, EventArgs e)
        {
            txtnote.BackColor = Color.AntiqueWhite;
        }

        private void Item_Transection_Load(object sender, EventArgs e)
        {
            count();
            DateTime thedate;
            thedate = DateTime.Today;
            txtdate.Text = thedate.ToString("dd/MM/yyyy");
            fillcombo1();
            fillcombo2();
            fillcombo3();
            fillcombo4();
            fillcombo5();
            clearcombo();



        }
        private void thedate()
        {
            try
            {
                DateTime thedate;
                thedate = DateTime.Today;
                txtdate.Text = thedate.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtbillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_billno();
                
            }
        }

        public void validate_billno()
        {
            if (txtbillno.Text == "")
            {
                MessageBox.Show("Enter Bill Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbillno.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Trn_Items where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtdate.Text = dr["Date"].ToString();
                        txtpcode.Text = dr["Party_Code"].ToString();
                        txtpname.Text = dr["Party_Name"].ToString();
                        txtno1.Text = dr["No1"].ToString();
                        txtno2.Text = dr["No2"].ToString();
                        txtno3.Text = dr["No3"].ToString();
                        txtno4.Text = dr["No4"].ToString();
                        txtno5.Text = dr["No5"].ToString();
                        cmbitem1.Text = dr["Item1"].ToString();
                        cmbitem2.Text = dr["Item2"].ToString();
                        cmbitem3.Text = dr["Item3"].ToString();
                        cmbitem4.Text = dr["Item4"].ToString();
                        cmbitem5.Text = dr["Item5"].ToString();
                        txtqty1.Text = dr["Qty1"].ToString();
                        txtqty2.Text = dr["Qty2"].ToString();
                        txtqty3.Text = dr["Qty3"].ToString();
                        txtqty4.Text = dr["Qty4"].ToString();
                        txtqty5.Text = dr["Qty5"].ToString();
                        txtrate1.Text = dr["Rate1"].ToString();
                        txtrate2.Text = dr["Rate2"].ToString();
                        txtrate3.Text = dr["Rate3"].ToString();
                        txtrate4.Text = dr["Rate4"].ToString();
                        txtrate5.Text = dr["Rate5"].ToString();
                        txtamt1.Text = dr["Amt1"].ToString();
                        txtamt2.Text = dr["Amt2"].ToString();
                        txtamt3.Text = dr["Amt3"].ToString();
                        txtamt4.Text = dr["Amt4"].ToString();
                        txtamt5.Text = dr["Amt5"].ToString();
                        txtnote.Text = dr["Note"].ToString();
                        txtdate.Focus();
                        txtbillno.BackColor = Color.White;
                        btnsave.Enabled = false;
                        btnupdate.Enabled = true;
                        sum();

                    }
                    else
                    {
                        lbltotalqty.Text = "[SUM]";
                        lbltotalamt.Text = "[SUM]";
                        txtpcode.Text = string.Empty;
                        txtpname.Text = string.Empty;
                        txtno1.Text = string.Empty;
                        txtno2.Text = string.Empty;
                        txtno3.Text = string.Empty;
                        txtno4.Text = string.Empty;
                        txtno5.Text = string.Empty;
                        cmbitem1.SelectedIndex = -1;
                        cmbitem2.SelectedIndex = -1;
                        cmbitem3.SelectedIndex = -1;
                        cmbitem4.SelectedIndex = -1;
                        cmbitem5.SelectedIndex = -1;
                        txtqty1.Text = string.Empty;
                        txtqty2.Text = string.Empty;
                        txtqty3.Text = string.Empty;
                        txtqty4.Text = string.Empty;
                        txtqty5.Text = string.Empty;
                        txtrate1.Text = string.Empty;
                        txtrate2.Text = string.Empty;
                        txtrate3.Text = string.Empty;
                        txtrate4.Text = string.Empty;
                        txtrate5.Text = string.Empty;
                        txtamt1.Text = string.Empty;
                        txtamt2.Text = string.Empty;
                        txtamt3.Text = string.Empty;
                        txtamt4.Text = string.Empty;
                        txtamt5.Text = string.Empty;
                        txtnote.Text = string.Empty;
                        btnsave.Enabled = true;
                        btnupdate.Enabled = false;
                        txtdate.Focus();
                        txtbillno.BackColor = Color.White;
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
        }

        private void txtdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpcode.Focus();
                txtdate.BackColor = Color.White;
            }
        }

        private void txtpcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_pcode();
            }
        }

        public void validate_pcode()
        {
            if (txtpcode.Text == "")
            {
                MessageBox.Show("Enter Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpcode.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtpcode.Text = dr["Party_Code"].ToString();
                        txtpname.Text = dr["Party_Name"].ToString();
                        txtno1.Focus();
                        txtpcode.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtpcode.Focus();
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcomcode.Text == "")
                {
                    MessageBox.Show("Enter Company Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcomcode.Focus();
                }
                else if (txtbillno.Text == "")
                {
                    MessageBox.Show("Enter Bill Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbillno.Focus();
                }
                else if (txtdate.MaskFull == false)
                {
                    MessageBox.Show("Enter Date", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdate.Focus();
                }
                else if (txtpcode.Text == "")
                {
                    MessageBox.Show("Enter Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpcode.Focus();
                }
                else
                {
                    con.Open();
                    str = "insert into Trn_Items values('" + txtpcode.Text + "','" + txtcomname.Text + "','" + txtbillno.Text + "','" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno1.Text + "','" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "','" + txtqty1.Text + "','" + txtrate1.Text + "','" + txtamt1.Text + "','" + txtno2.Text + "','" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "','" + txtqty2.Text + "','" + txtrate2.Text + "','" + txtamt2.Text + "','" + txtno3.Text + "','" + cmbitem3.GetItemText(cmbitem3.SelectedItem) + "','" + txtqty3.Text + "','" + txtrate3.Text + "','" + txtamt3.Text + "','" + txtno4.Text + "','" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "','" + txtqty4.Text + "','" + txtrate4.Text + "','" + txtamt4.Text + "','" + txtno5.Text + "','" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "','" + txtqty5.Text + "','" + txtrate5.Text + "','" + txtamt5.Text + "','" + txtnote.Text + "')";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    clear();
                    txtcomcode.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txtno1_Enter(object sender, EventArgs e)
        {
            txtno1.BackColor = Color.AntiqueWhite;
        }

        private void txtno2_Enter(object sender, EventArgs e)
        {
            txtno2.BackColor = Color.AntiqueWhite;
        }

        private void txtno3_Enter(object sender, EventArgs e)
        {
            txtno3.BackColor = Color.AntiqueWhite;
        }

        private void txtno4_Enter(object sender, EventArgs e)
        {
            txtno4.BackColor = Color.AntiqueWhite;
        }

        private void txtno5_Enter(object sender, EventArgs e)
        {
            txtno5.BackColor = Color.AntiqueWhite;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcomcode.Text == "")
                {
                    MessageBox.Show("Enter Company Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcomcode.Focus();
                }
                else if (txtbillno.Text == "")
                {
                    MessageBox.Show("Enter Bill Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbillno.Focus();
                }
                else if (txtdate.MaskFull == false)
                {
                    MessageBox.Show("Enter Date", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdate.Focus();
                }
                else if (txtpcode.Text == "")
                {
                    MessageBox.Show("Enter Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpcode.Focus();
                }
                else
                {
                    con.Open();
                    str = "update Trn_Items set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',No1='" + txtno1.Text + "',Item1='" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "',Qty1='" + txtqty1.Text + "',Rate1='" + txtrate1.Text + "',Amt1='" + txtamt1.Text + "',No2='" + txtno2.Text + "',Item2='" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "',Qty2='" + txtqty2.Text + "',Rate2='" + txtrate2.Text + "',Amt2='" + txtamt2.Text + "',No3='" + txtno3.Text + "',Item3='" + cmbitem3.GetItemText(cmbitem3.SelectedItem) + "',Qty3='" + txtqty3.Text + "',Rate3='" + txtrate3.Text + "',Amt3='" + txtamt3.Text + "',No4='" + txtno4.Text + "',Item4='" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "',Qty4='" + txtqty4.Text + "',Rate4='" + txtrate4.Text + "',Amt4='" + txtamt4.Text + "',No5='" + txtno5.Text + "',Item5='" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "',Qty5='" + txtqty5.Text + "',Rate5='" + txtrate5.Text + "',Amt5='" + txtamt5.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    clear();
                    txtcomcode.Focus();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcomcode.Text == "")
                {
                    MessageBox.Show("Enter Company Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtcomcode.Focus();
                }
                else if (txtbillno.Text == "")
                {
                    MessageBox.Show("Enter Bill Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbillno.Focus();
                }
                else if (txtdate.MaskFull == false)
                {
                    MessageBox.Show("Enter Date", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtdate.Focus();
                }
                else if (txtpcode.Text == "")
                {
                    MessageBox.Show("Enter Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtpcode.Focus();
                }
                else
                {
                    if (MessageBox.Show(" Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        con.Open();
                        str = "delete from Trn_Items where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
                        cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        clear();
                        txtcomcode.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            thedate();
            count();
            colorwhite();
            txtcomcode.Focus();
            txtcomcode.Text = string.Empty;
            txtcomname.Text = string.Empty;

            lbltotalqty.Text = "[SUM]";
            lbltotalamt.Text = "[SUM]";
            txtpcode.Text = string.Empty;
            txtpname.Text = string.Empty;
            txtno1.Text = string.Empty;
            txtno2.Text = string.Empty;
            txtno3.Text = string.Empty;
            txtno4.Text = string.Empty;
            txtno5.Text = string.Empty;
            cmbitem1.SelectedIndex = -1;
            cmbitem2.SelectedIndex = -1;
            cmbitem3.SelectedIndex = -1;
            cmbitem4.SelectedIndex = -1;
            cmbitem5.SelectedIndex = -1;
            txtqty1.Text = string.Empty;
            txtqty2.Text = string.Empty;
            txtqty3.Text = string.Empty;
            txtqty4.Text = string.Empty;
            txtqty5.Text = string.Empty;
            txtrate1.Text = string.Empty;
            txtrate2.Text = string.Empty;
            txtrate3.Text = string.Empty;
            txtrate4.Text = string.Empty;
            txtrate5.Text = string.Empty;
            txtamt1.Text = string.Empty;
            txtamt2.Text = string.Empty;
            txtamt3.Text = string.Empty;
            txtamt4.Text = string.Empty;
            txtamt5.Text = string.Empty;
            txtnote.Text = string.Empty;
            count();
            txtcomcode.Focus();
            btnupdate.Enabled = true;
            btnsave.Enabled = true;
            gridhelp.Hide();
        }



        private void cmbitem1_Enter(object sender, EventArgs e)
        {
            cmbitem1.BackColor = Color.AntiqueWhite;
        }

        private void cmbitem2_Enter(object sender, EventArgs e)
        {
            cmbitem2.BackColor = Color.AntiqueWhite;
        }

        private void cmbitem3_Enter(object sender, EventArgs e)
        {
            cmbitem3.BackColor = Color.AntiqueWhite;
        }

        private void cmbitem4_Enter(object sender, EventArgs e)
        {
            cmbitem4.BackColor = Color.AntiqueWhite;
        }

        private void cmbitem5_Enter(object sender, EventArgs e)
        {
            cmbitem5.BackColor = Color.AntiqueWhite;
        }

        private void txtqty1_Enter(object sender, EventArgs e)
        {
            txtqty1.BackColor = Color.AntiqueWhite;
        }

        private void txtqty2_Enter(object sender, EventArgs e)
        {
            txtqty2.BackColor = Color.AntiqueWhite;
        }

        private void txtqty3_Enter(object sender, EventArgs e)
        {
            txtqty3.BackColor = Color.AntiqueWhite;
        }

        private void txtqty4_Enter(object sender, EventArgs e)
        {
            txtqty4.BackColor = Color.AntiqueWhite;
        }

        private void txtqty5_Enter(object sender, EventArgs e)
        {
            txtqty5.BackColor = Color.AntiqueWhite;
        }

        private void txtrate1_Enter(object sender, EventArgs e)
        {
            txtrate1.BackColor = Color.AntiqueWhite;
        }

        private void txtrate2_Enter(object sender, EventArgs e)
        {
            txtrate2.BackColor = Color.AntiqueWhite;
        }

        private void txtrate3_Enter(object sender, EventArgs e)
        {
            txtrate3.BackColor = Color.AntiqueWhite;
        }

        private void txtrate4_Enter(object sender, EventArgs e)
        {
            txtrate4.BackColor = Color.AntiqueWhite;
        }

        private void txtrate5_Enter(object sender, EventArgs e)
        {
            txtrate5.BackColor = Color.AntiqueWhite;
        }

        private void txtno1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem1.Focus();
                txtno1.BackColor = Color.White;
            }
        }



        private void txtqty1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate1.Focus();
                txtqty1.BackColor = Color.White;
            }
        }

        private void txtrate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtno2.Focus();
                txtrate1.BackColor = Color.White;
                cal1();
            }
        }

        private void txtno2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem2.Focus();
                txtno2.BackColor = Color.White;
            }
        }



        private void cmbitem1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtqty1.Focus();
            cmbitem1.BackColor = Color.White;
        }

        private void cmbitem2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtqty2.Focus();
            cmbitem2.BackColor = Color.White;
        }

        private void txtqty2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate2.Focus();
                txtqty2.BackColor = Color.White;
            }
        }

        private void txtrate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtno3.Focus();
                txtrate2.BackColor = Color.White;
                cal2();
            }
        }

        private void txtno3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem3.Focus();
                txtno3.BackColor = Color.White;
            }
        }

        private void cmbitem3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtqty3.Focus();
            cmbitem3.BackColor = Color.White;
        }

        private void txtqty3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate3.Focus();
                txtqty3.BackColor = Color.White;
            }
        }

        private void txtrate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtno4.Focus();
                txtrate3.BackColor = Color.White;
                cal3();
            }
        }

        private void txtno4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem4.Focus();
                txtno4.BackColor = Color.White;
            }
        }

        private void cmbitem4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtqty4.Focus();
            cmbitem4.BackColor = Color.White;
        }

        private void txtqty4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate4.Focus();
                txtqty4.BackColor = Color.White;
            }
        }

        private void txtrate4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtno5.Focus();
                txtrate4.BackColor = Color.White;
                cal4();
            }
        }

        private void txtno5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem5.Focus();
                txtno5.BackColor = Color.White;
            }
        }

        private void cmbitem5_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtqty5.Focus();
            cmbitem5.BackColor = Color.White;

        }

        private void txtqty5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate5.Focus();
                txtqty5.BackColor = Color.White;
            }
        }

        private void txtrate5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtnote.Focus();
                txtrate5.BackColor = Color.White;
                cal5();
            }
        }

        public void cal1()
        {
            decimal amt = Convert.ToDecimal(txtqty1.Text) * Convert.ToDecimal(txtrate1.Text);
            txtamt1.Text = Convert.ToString(amt);
        }
        public void cal2()
        {
            decimal amt = Convert.ToDecimal(txtqty2.Text) * Convert.ToDecimal(txtrate2.Text);
            txtamt2.Text = Convert.ToString(amt);
        }
        public void cal3()
        {
            decimal amt = Convert.ToDecimal(txtqty3.Text) * Convert.ToDecimal(txtrate3.Text);
            txtamt3.Text = Convert.ToString(amt);
        }

        public void cal4()
        {
            decimal amt = Convert.ToDecimal(txtqty4.Text) * Convert.ToDecimal(txtrate4.Text);
            txtamt4.Text = Convert.ToString(amt);
        }
        public void cal5()
        {
            decimal amt = Convert.ToDecimal(txtqty5.Text) * Convert.ToDecimal(txtrate5.Text);
            txtamt5.Text = Convert.ToString(amt);
        }

        private void txtnote_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();

                    str = "select * from Trn_Items where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        btnupdate.Focus();
                        btnsave.Enabled = false;
                    }
                    else
                    {
                        btnsave.Focus();
                        btnupdate.Enabled = false;
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

        public void fillcombo1()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmbitem1.ValueMember = "Item_Name";
                cmbitem1.DataSource = ds.Tables["Mst_Item"];
                cmbitem1.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbitem1.Enabled = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillcombo2()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmbitem2.ValueMember = "Item_Name";
                cmbitem2.DataSource = ds.Tables["Mst_Item"];
                cmbitem2.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbitem2.Enabled = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillcombo3()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmbitem3.ValueMember = "Item_Name";
                cmbitem3.DataSource = ds.Tables["Mst_Item"];
                cmbitem3.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbitem3.Enabled = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillcombo4()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmbitem4.ValueMember = "Item_Name";
                cmbitem4.DataSource = ds.Tables["Mst_Item"];
                cmbitem4.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbitem4.Enabled = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillcombo5()
        {
            try
            {
                con.Open();
                string str = "select Item_Name from Mst_Item";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Item");
                cmbitem5.ValueMember = "Item_Name";
                cmbitem5.DataSource = ds.Tables["Mst_Item"];
                cmbitem5.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbitem5.Enabled = true;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void sum()
        {
            try
            {
                decimal sumqty = Convert.ToDecimal(txtqty1.Text) + Convert.ToDecimal(txtqty2.Text) + Convert.ToDecimal(txtqty3.Text) + Convert.ToDecimal(txtqty4.Text) + Convert.ToDecimal(txtqty5.Text);
                lbltotalqty.Text = sumqty.ToString();

                decimal sumamt = Convert.ToDecimal(txtamt1.Text) + Convert.ToDecimal(txtamt2.Text) + Convert.ToDecimal(txtamt3.Text) + Convert.ToDecimal(txtamt4.Text) + Convert.ToDecimal(txtamt5.Text);
                lbltotalamt.Text = sumamt.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void clearcombo()
        {
            cmbitem1.SelectedIndex = -1;
            cmbitem2.SelectedIndex = -1;
            cmbitem3.SelectedIndex = -1;
            cmbitem4.SelectedIndex = -1;
            cmbitem5.SelectedIndex = -1;
        }

        public void colorwhite()
        {
            txtcomcode.BackColor = Color.White;


            txtdate.BackColor = Color.White;
            txtpcode.BackColor = Color.White;

            txtno1.BackColor = Color.White;
            txtno2.BackColor = Color.White;
            txtno3.BackColor = Color.White;
            txtno4.BackColor = Color.White;
            txtno5.BackColor = Color.White;
            cmbitem1.BackColor = Color.White;
            cmbitem2.BackColor = Color.White;
            cmbitem3.BackColor = Color.White;
            cmbitem4.BackColor = Color.White;
            cmbitem5.BackColor = Color.White;
            txtqty1.BackColor = Color.White;
            txtqty2.BackColor = Color.White;
            txtqty3.BackColor = Color.White;
            txtqty4.BackColor = Color.White;
            txtqty5.BackColor = Color.White;
            txtrate1.BackColor = Color.White;
            txtrate2.BackColor = Color.White;
            txtrate3.BackColor = Color.White;
            txtrate4.BackColor = Color.White;
            txtrate5.BackColor = Color.White;

            txtnote.BackColor = Color.White;

        }

        private void txtcomcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                gridhelp.ForeColor = Color.Black;
                
                str = "select Com_Code as CompanyCode,Com_Name as CompanyName,Com_Add as Address from Mst_Company";
                da = new SqlDataAdapter(str, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridhelp.DataSource = dt;
                gridhelp.Show();
                gridhelp.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gridhelp.Hide();
                txtcomcode.Focus();
            }
        }

       
        private void txtpcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                gridhelpparty.ForeColor = Color.Black;
                str = "select Party_Code as PartyCode,Party_Name as PartyName,Party_Add Address from Mst_Party";
                da = new SqlDataAdapter(str,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridhelpparty.DataSource = dt;
                gridhelpparty.Show();
                gridhelpparty.Focus();
            }
        }

        private void gridhelpparty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                gridhelpparty.Hide();
                txtpcode.Focus();
            }
        }
    }
}



//private void txtnote_MultilineChanged(object sender, EventArgs e)
//       {
//           try
//           {
//               con.Open();

//               str = "select * from Trn_Items where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
//               cmd = new SqlCommand(str,con);
//               cmd.ExecuteNonQuery();
//               dr = cmd.ExecuteReader();
//               if (dr.HasRows)
//               {
//                   dr.Read();
//                   btnupdate.Focus();
//                   btnsave.Enabled = false;
//               }
//               else
//               {
//                   btnsave.Focus();
//                   btnupdate.Enabled = false;
//               }
//           }
//           catch (Exception ex)
//           {
//               MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
//           }
//       }