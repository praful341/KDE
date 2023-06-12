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
namespace KDE
{
    public partial class frmItemDetails : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
        Validation Val = new Validation();

        #region " Data Members "
        SqlCommand cmd;
        string str;
        SqlDataAdapter da;
        SqlDataReader dr;
        #endregion

        #region " Constructors "
        public frmItemDetails()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void txtcomcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_comcode();
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
            fillcombo6();
            fillcombo7();
            clearcombo();
            txtcomcode.Text = "01";
            txtcomname.Text = "Jay Jalaram Khaman & Patra";
            txtbillno.Focus();
        }

        private void txtbillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_billno();
                fillcombo1();
                fillcombo2();
                fillcombo3();
                fillcombo4();
                fillcombo5();
                fillcombo6();
                fillcombo7();
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
                    str = "insert into Trn_Items values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno1.Text + "','" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "','" + txtqty1.Text + "','" + txtrate1.Text + "','" + txtamt1.Text + "','" + txtno2.Text + "','" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "','" + txtqty2.Text + "','" + txtrate2.Text + "','" + txtamt2.Text + "','" + txtno3.Text + "','" + cmbitem3.GetItemText(cmbitem3.SelectedItem) + "','" + txtqty3.Text + "','" + txtrate3.Text + "','" + txtamt3.Text + "','" + txtno4.Text + "','" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "','" + txtqty4.Text + "','" + txtrate4.Text + "','" + txtamt4.Text + "','" + txtno5.Text + "','" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "','" + txtqty5.Text + "','" + txtrate5.Text + "','" + txtamt5.Text + "','" + txtno6.Text + "','" + cmbitem6.GetItemText(cmbitem6.SelectedItem) + "','" + txtqty6.Text + "','" + txtrate6.Text + "','" + txtamt6.Text + "','" + txtno7.Text + "','" + cmbitem7.GetItemText(cmbitem7.SelectedItem) + "','" + txtqty7.Text + "','" + txtrate7.Text + "','" + txtamt7.Text + "','" + txtnote.Text + "')";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','"+txtno1.Text+"','" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "','" + txtqty1.Text + "','" + txtrate1.Text + "','" + txtamt1.Text + "')";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1 = new SqlCommand(str, con);
                    cmd1.ExecuteNonQuery();

                    if (cmbitem2.SelectedIndex != null && txtqty2.Text != "0"&& txtrate2.Text != "0")
                    {
                        str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno2.Text + "','" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "','" + txtqty2.Text + "','" + txtrate2.Text + "','" + txtamt2.Text + "')";
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2 = new SqlCommand(str, con);
                        cmd2.ExecuteNonQuery();

                    }

                    if (cmbitem3.SelectedIndex != null && txtqty3.Text != "0" && txtrate3.Text != "0")
                    {
                        str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno3.Text + "','" + cmbitem3.GetItemText(cmbitem3.SelectedItem) + "','" + txtqty3.Text + "','" + txtrate3.Text + "','" + txtamt3.Text + "')";
                        SqlCommand cmd3 = new SqlCommand();
                        cmd3 = new SqlCommand(str, con);
                        cmd3.ExecuteNonQuery();
                    }

                    if (cmbitem4.SelectedIndex != null && txtqty4.Text != "0" && txtrate4.Text != "0")
                    {
                        str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno4.Text + "','" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "','" + txtqty4.Text + "','" + txtrate4.Text + "','" + txtamt4.Text + "')";
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4 = new SqlCommand(str, con);
                        cmd4.ExecuteNonQuery();
                    }

                    if (cmbitem5.SelectedIndex != null && txtqty5.Text != "0" && txtrate5.Text != "0")
                    {
                        str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno5.Text + "','" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "','" + txtqty5.Text + "','" + txtrate5.Text + "','" + txtamt5.Text + "')";
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }
                    if (cmbitem6.SelectedIndex != null && txtqty6.Text != "0" && txtrate6.Text != "0")
                    {
                        str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno6.Text + "','" + cmbitem6.GetItemText(cmbitem6.SelectedItem) + "','" + txtqty6.Text + "','" + txtrate6.Text + "','" + txtamt6.Text + "')";
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }
                    if (cmbitem7.SelectedIndex != null && txtqty7.Text != "0" && txtrate7.Text != "0")
                    {
                        str = "insert into Mst_Transaction (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,Item,Qty,Rate,Amout) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno7.Text + "','" + cmbitem7.GetItemText(cmbitem7.SelectedItem) + "','" + txtqty7.Text + "','" + txtrate7.Text + "','" + txtamt7.Text + "')";
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }

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
                    str = "update Trn_Items set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',No1='" + txtno1.Text + "',Item1='" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "',Qty1='" + txtqty1.Text + "',Rate1='" + txtrate1.Text + "',Amt1='" + txtamt1.Text + "',No2='" + txtno2.Text + "',Item2='" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "',Qty2='" + txtqty2.Text + "',Rate2='" + txtrate2.Text + "',Amt2='" + txtamt2.Text + "',No3='" + txtno3.Text + "',Item3='" + cmbitem3.GetItemText(cmbitem3.SelectedItem) + "',Qty3='" + txtqty3.Text + "',Rate3='" + txtrate3.Text + "',Amt3='" + txtamt3.Text + "',No4='" + txtno4.Text + "',Item4='" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "',Qty4='" + txtqty4.Text + "',Rate4='" + txtrate4.Text + "',Amt4='" + txtamt4.Text + "',No5='" + txtno5.Text + "',Item5='" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "',Qty5='" + txtqty5.Text + "',Rate5='" + txtrate5.Text + "',Amt5='" + txtamt5.Text + "',No6='" + txtno6.Text + "',Item6='" + cmbitem6.GetItemText(cmbitem6.SelectedItem) + "',Qty6='" + txtqty6.Text + "',Rate6='" + txtrate6.Text + "',Amt6='" + txtamt6.Text + "',No7='" + txtno7.Text + "',Item7='" + cmbitem7.GetItemText(cmbitem7.SelectedItem) + "',Qty7='" + txtqty7.Text + "',Rate7='" + txtrate7.Text + "',Amt7='" + txtamt7.Text + "', note = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();


                    str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "',Qty='" + txtqty1.Text + "',Rate='" + txtrate1.Text + "',Amout='" + txtamt1.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + " and No='" + txtno1.Text + "'";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1 = new SqlCommand(str, con);
                    cmd1.ExecuteNonQuery();


                    if (cmbitem2.SelectedIndex != null && txtqty2.Text != "0" && txtrate2.Text != "0")
                    {
                        str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "',Qty='" + txtqty2.Text + "',Rate='" + txtrate2.Text + "',Amout='" + txtamt2.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "and No='" + txtno2.Text + "'";

                        SqlCommand cmd2 = new SqlCommand();

                        cmd2 = new SqlCommand(str, con);
                        cmd2.ExecuteNonQuery();
                    }

                    if (cmbitem3.SelectedIndex != null && txtqty3.Text != "0" && txtrate3.Text != "0")
                    {
                        str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "',Qty='" + txtqty3.Text + "',Rate='" + txtrate3.Text + "',Amout='" + txtamt3.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "and No='" + txtno3.Text + "'";
                        SqlCommand cmd3 = new SqlCommand();

                        cmd3 = new SqlCommand(str, con);
                        cmd3.ExecuteNonQuery();


                    }

                    if (cmbitem4.SelectedIndex != null && txtqty4.Text != "0" && txtrate4.Text != "0")
                    {
                        str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "',Qty='" + txtqty4.Text + "',Rate='" + txtrate4.Text + "',Amout='" + txtamt4.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "and No='" + txtno4.Text + "'";
                        SqlCommand cmd4 = new SqlCommand();

                        cmd4 = new SqlCommand(str, con);
                        cmd4.ExecuteNonQuery();

                    }

                    if (cmbitem5.SelectedIndex != null && txtqty5.Text != "0" && txtrate5.Text != "0")
                    {
                        str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "',Qty='" + txtqty5.Text + "',Rate='" + txtrate5.Text + "',Amout='" + txtamt5.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "and No='" + txtno5.Text + "'";
                        SqlCommand cmd5 = new SqlCommand();

                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }
                    if (cmbitem6.SelectedIndex != null && txtqty6.Text != "0" && txtrate6.Text != "0")
                    {
                        str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem6.GetItemText(cmbitem6.SelectedItem) + "',Qty='" + txtqty6.Text + "',Rate='" + txtrate6.Text + "',Amout='" + txtamt6.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "and No='" + txtno6.Text + "'";
                        SqlCommand cmd5 = new SqlCommand();

                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }
                    if (cmbitem7.SelectedIndex != null && txtqty7.Text != "0" && txtrate7.Text != "0")
                    {
                        str = "update Mst_Transaction set Date='" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "',Party_Code='" + txtpcode.Text + "',Party_Name='" + txtpname.Text + "',Item='" + cmbitem7.GetItemText(cmbitem7.SelectedItem) + "',Qty='" + txtqty7.Text + "',Rate='" + txtrate7.Text + "',Amout='" + txtamt7.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "and No='" + txtno7.Text + "'";
                        SqlCommand cmd5 = new SqlCommand();

                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }

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
                        str = "delete from Trn_Items where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                        cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        str = "delete from Mst_Transaction where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1 = new SqlCommand(str, con);
                        cmd1.ExecuteNonQuery();

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

        private void cmbitem1_Enter(object sender, EventArgs e)
        {
            cmbitem1.BackColor = Color.AntiqueWhite;
            fillcombo1();
        }

        private void cmbitem2_Enter(object sender, EventArgs e)
        {
            cmbitem2.BackColor = Color.AntiqueWhite;
            fillcombo2();
        }

        private void cmbitem3_Enter(object sender, EventArgs e)
        {
            cmbitem3.BackColor = Color.AntiqueWhite;
            fillcombo3();
        }

        private void cmbitem4_Enter(object sender, EventArgs e)
        {
            cmbitem4.BackColor = Color.AntiqueWhite;
            fillcombo4();
        }

        private void cmbitem5_Enter(object sender, EventArgs e)
        {
            cmbitem5.BackColor = Color.AntiqueWhite;
            fillcombo5();
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
                txtno6.Focus();
                txtrate5.BackColor = Color.White;
                cal5();
            }
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
                da = new SqlDataAdapter(str, con);
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

        private void txtcomcode_Leave(object sender, EventArgs e)
        {
            txtcomcode.BackColor = Color.White;
        }

        private void txtbillno_Leave(object sender, EventArgs e)
        {
            txtbillno.BackColor = Color.White;
        }

        private void txtdate_Leave(object sender, EventArgs e)
        {
            txtdate.BackColor = Color.White;
        }

        private void txtpcode_Leave(object sender, EventArgs e)
        {
            txtpcode.BackColor = Color.White;
        }

        private void txtno1_Leave(object sender, EventArgs e)
        {
            txtno1.BackColor = Color.White;
        }

        private void txtno2_Leave(object sender, EventArgs e)
        {
            txtno2.BackColor = Color.White;
        }

        private void txtno3_Leave(object sender, EventArgs e)
        {
            txtno3.BackColor = Color.White;
        }

        private void txtno4_Leave(object sender, EventArgs e)
        {
            txtno4.BackColor = Color.White;
        }

        private void txtno5_Leave(object sender, EventArgs e)
        {
            txtno5.BackColor = Color.White;
        }

        private void cmbitem1_Leave(object sender, EventArgs e)
        {
            cmbitem1.BackColor = Color.White;
        }

        private void cmbitem2_Leave(object sender, EventArgs e)
        {
            cmbitem2.BackColor = Color.White;
        }

        private void cmbitem3_Leave(object sender, EventArgs e)
        {
            cmbitem3.BackColor = Color.White;
        }

        private void cmbitem4_Leave(object sender, EventArgs e)
        {
            cmbitem4.BackColor = Color.White;
        }

        private void cmbitem5_Leave(object sender, EventArgs e)
        {
            cmbitem5.BackColor = Color.White;
        }

        private void txtqty1_Leave(object sender, EventArgs e)
        {
            cal1();
            sum();
            txtqty1.BackColor = Color.White;
        }

        private void txtqty2_Leave(object sender, EventArgs e)
        {
            cal2();
            sum();
            txtqty2.BackColor = Color.White;

        }

        private void txtqty3_Leave(object sender, EventArgs e)
        {
            sum();
            cal3();
            txtqty3.BackColor = Color.White;
        }

        private void txtqty4_Leave(object sender, EventArgs e)
        {
            sum();
            cal4();
            txtqty4.BackColor = Color.White;
        }

        private void txtqty5_Leave(object sender, EventArgs e)
        {
            sum();
            cal5();
            txtqty5.BackColor = Color.White;
        }

        private void txtrate1_Leave(object sender, EventArgs e)
        {
            
            cal1();
            sum();
            txtrate1.BackColor = Color.White;
        }

        private void txtrate2_Leave(object sender, EventArgs e)
        {
            
            cal2();
            sum();
            txtrate2.BackColor = Color.White;
        }

        private void txtrate3_Leave(object sender, EventArgs e)
        {
            
            cal3();
            sum();
            txtrate3.BackColor = Color.White;
        }

        private void txtrate4_Leave(object sender, EventArgs e)
        {            
            cal4();
            sum();
            txtrate4.BackColor = Color.White;
        }

        private void txtrate5_Leave(object sender, EventArgs e)
        {            
            cal5();
            sum();
            txtrate5.BackColor = Color.White;
        }

        private void txtnote_Leave(object sender, EventArgs e)
        {
            txtnote.BackColor = Color.White;
        }

        private void cmbitem1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate1();
                txtqty1.Focus();
            }
        }

        private void cmbitem2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate2();
                txtqty2.Focus();
            }
        }

        private void cmbitem3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate3();
                txtqty3.Focus();
            }
        }

        private void cmbitem4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate4();
                txtqty4.Focus();
            }
        }

        private void cmbitem5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate5();
                txtqty5.Focus();
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

        #endregion

        #region " Functions/ Procedures "
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

        public void clear()
        {
            thedate();
            count();
            colorwhite();
            txtbillno.Focus();
            lbltotalqty.Text = "0";
            lbltotalamt.Text = "0";
            txtpcode.Text = string.Empty;
            txtpname.Text = string.Empty;
            cmbitem1.SelectedIndex = -1;
            cmbitem2.SelectedIndex = -1;
            cmbitem3.SelectedIndex = -1;
            cmbitem4.SelectedIndex = -1;
            cmbitem5.SelectedIndex = -1;
            cmbitem6.SelectedIndex = -1;
            cmbitem7.SelectedIndex = -1;
            txtqty1.Text = "0";
            txtqty2.Text = "0";
            txtqty3.Text = "0";
            txtqty4.Text = "0";
            txtqty5.Text = "0";
            txtqty6.Text = "0";
            txtqty7.Text = "0";
            txtrate1.Text = "0";
            txtrate2.Text = "0";
            txtrate3.Text = "0";
            txtrate4.Text = "0";
            txtrate5.Text = "0";
            txtrate6.Text = "0";
            txtrate7.Text = "0";
            txtamt1.Text = "0";
            txtamt2.Text = "0";
            txtamt3.Text = "0";
            txtamt4.Text = "0";
            txtamt5.Text = "0";
            txtamt6.Text = "0";
            txtamt7.Text = "0";
            txtnote.Text = string.Empty;
            count();
            btnupdate.Enabled = true;
            btnsave.Enabled = true;
            gridhelp.Hide();
            gridhelpparty.Hide();
        }

        public void fillrate1()
        {
            try
            {
                con.Open();
                str = "select Item_1,Rate_1 from Mst_Party where Item_1='" + cmbitem1.GetItemText(cmbitem1.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate1.Text = dr["Rate_1"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void fillrate2()
        {
            try
            {
                con.Open();
                str = "select Item_2,Rate_2 from Mst_Party where Item_2='" + cmbitem2.GetItemText(cmbitem2.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate2.Text = dr["Rate_2"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void fillrate3()
        {
            try
            {
                con.Open();
                str = "select Item_3,Rate_3 from Mst_Party where Item_3='" + cmbitem3.GetItemText(cmbitem3.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate3.Text = dr["Rate_3"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void fillrate4()
        {
            try
            {
                con.Open();
                str = "select Item_4,Rate_4 from Mst_Party where Item_4='" + cmbitem4.GetItemText(cmbitem4.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate4.Text = dr["Rate_4"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void fillrate5()
        {
            try
            {
                con.Open();
                str = "select Item_5,Rate_5 from Mst_Party where Item_5='" + cmbitem5.GetItemText(cmbitem5.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate5.Text = dr["Rate_5"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillrate6()
        {
            try
            {
                con.Open();
                str = "select Item_6,Rate_6 from Mst_Party where Item_6='" + cmbitem6.GetItemText(cmbitem6.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate6.Text = dr["Rate_6"].ToString();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void fillrate7()
        {
            try
            {
                con.Open();
                str = "select Item_7,Rate_7 from Mst_Party where Item_7='" + cmbitem7.GetItemText(cmbitem7.SelectedItem) + "'and Party_Code='" + txtpcode.Text + "'";
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtrate7.Text = dr["Rate_7"].ToString();
                }
                con.Close();

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
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem1.ValueMember = "Item_1";
                cmbitem1.DataSource = ds.Tables["Mst_Party"];
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
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem2.ValueMember = "Item_2";
                cmbitem2.DataSource = ds.Tables["Mst_Party"];
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
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem3.ValueMember = "Item_3";
                cmbitem3.DataSource = ds.Tables["Mst_Party"];
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
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem4.ValueMember = "Item_4";
                cmbitem4.DataSource = ds.Tables["Mst_Party"];
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
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem5.ValueMember = "Item_5";
                cmbitem5.DataSource = ds.Tables["Mst_Party"];
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillcombo6()
        {
            try
            {
                con.Open();
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem6.ValueMember = "Item_6";
                cmbitem6.DataSource = ds.Tables["Mst_Party"];
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void fillcombo7()
        {
            try
            {
                con.Open();
                string str = "select * from Mst_Party where Party_Code='" + txtpcode.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Party");
                cmbitem7.ValueMember = "Item_7";
                cmbitem7.DataSource = ds.Tables["Mst_Party"];
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
                double sumqty = (Val.ToDouble(txtqty1.Text)) + (Val.ToDouble(txtqty2.Text)) + (Val.ToDouble(txtqty3.Text)) + (Val.ToDouble(txtqty4.Text)) + (Val.ToDouble(txtqty5.Text)) + (Val.ToDouble(txtqty6.Text)) + (Val.ToDouble(txtqty7.Text));
                lbltotalqty.Text = sumqty.ToString();

                double sumamt = (Val.ToDouble(txtamt1.Text)) + (Val.ToDouble(txtamt2.Text)) + (Val.ToDouble(txtamt3.Text)) + (Val.ToDouble(txtamt4.Text)) + (Val.ToDouble(txtamt5.Text)) + (Val.ToDouble(txtamt6.Text)) + (Val.ToDouble(txtamt7.Text));
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
            cmbitem6.SelectedIndex = -1;
            cmbitem7.SelectedIndex = -1;
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
            txtno6.BackColor = Color.White;
            txtno7.BackColor = Color.White;
            cmbitem1.BackColor = Color.White;
            cmbitem2.BackColor = Color.White;
            cmbitem3.BackColor = Color.White;
            cmbitem4.BackColor = Color.White;
            cmbitem5.BackColor = Color.White;
            cmbitem6.BackColor = Color.White;
            cmbitem7.BackColor = Color.White;
            txtqty1.BackColor = Color.White;
            txtqty2.BackColor = Color.White;
            txtqty3.BackColor = Color.White;
            txtqty4.BackColor = Color.White;
            txtqty5.BackColor = Color.White;
            txtqty6.BackColor = Color.White;
            txtqty7.BackColor = Color.White;
            txtrate1.BackColor = Color.White;
            txtrate2.BackColor = Color.White;
            txtrate3.BackColor = Color.White;
            txtrate4.BackColor = Color.White;
            txtrate5.BackColor = Color.White;
            txtrate6.BackColor = Color.White;
            txtrate7.BackColor = Color.White;

            txtnote.BackColor = Color.White;

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

        public void cal1()
        {
            double amt = (Val.ToDouble(txtqty1.Text)) * (Val.ToDouble(txtrate1.Text));
            txtamt1.Text = Val.ToString(amt);
        }

        public void cal2()
        {
            decimal amt = (Val.ToDecimal(txtqty2.Text)) * (Val.ToDecimal(txtrate2.Text));
            txtamt2.Text = Val.ToString(amt);
        }

        public void cal3()
        {
            decimal amt = (Val.ToDecimal(txtqty3.Text)) * (Val.ToDecimal(txtrate3.Text));
            txtamt3.Text = Val.ToString(amt);
        }

        public void cal4()
        {
            decimal amt = (Val.ToDecimal(txtqty4.Text)) * (Val.ToDecimal(txtrate4.Text));
            txtamt4.Text = Val.ToString(amt);
        }

        public void cal5()
        {
            decimal amt = (Val.ToDecimal(txtqty5.Text)) * (Val.ToDecimal(txtrate5.Text));
            txtamt5.Text = Val.ToString(amt);
        }
        public void cal6()
        {
            decimal amt = (Val.ToDecimal(txtqty6.Text)) * (Val.ToDecimal(txtrate6.Text));
            txtamt6.Text = Val.ToString(amt);
        }
        public void cal7()
        {
            decimal amt = (Val.ToDecimal(txtqty7.Text)) * (Val.ToDecimal(txtrate7.Text));
            txtamt7.Text = Val.ToString(amt);
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
                        txt_id.Text = dr["Id"].ToString();
                        txtdate.Text = dr["Date"].ToString();
                        txtpcode.Text = dr["Party_Code"].ToString();
                        txtpname.Text = dr["Party_Name"].ToString();
                        txtno1.Text = dr["No1"].ToString();
                        txtno2.Text = dr["No2"].ToString();
                        txtno3.Text = dr["No3"].ToString();
                        txtno4.Text = dr["No4"].ToString();
                        txtno5.Text = dr["No5"].ToString();
                        txtno6.Text = dr["No6"].ToString();
                        txtno7.Text = dr["No7"].ToString();

                        txtqty1.Text = dr["Qty1"].ToString();
                        txtqty2.Text = dr["Qty2"].ToString();
                        txtqty3.Text = dr["Qty3"].ToString();
                        txtqty4.Text = dr["Qty4"].ToString();
                        txtqty5.Text = dr["Qty5"].ToString();
                        txtqty6.Text = dr["Qty6"].ToString();
                        txtqty7.Text = dr["Qty7"].ToString();
                        txtrate1.Text = dr["Rate1"].ToString();
                        txtrate2.Text = dr["Rate2"].ToString();
                        txtrate3.Text = dr["Rate3"].ToString();
                        txtrate4.Text = dr["Rate4"].ToString();
                        txtrate5.Text = dr["Rate5"].ToString();
                        txtrate6.Text = dr["Rate6"].ToString();
                        txtrate7.Text = dr["Rate7"].ToString();
                        txtamt1.Text = dr["Amt1"].ToString();
                        txtamt2.Text = dr["Amt2"].ToString();
                        txtamt3.Text = dr["Amt3"].ToString();
                        txtamt4.Text = dr["Amt4"].ToString();
                        txtamt5.Text = dr["Amt5"].ToString();
                        txtamt6.Text = dr["Amt6"].ToString();
                        txtamt7.Text = dr["Amt7"].ToString();
                        txtnote.Text = dr["Note"].ToString();
                        txtdate.Focus();
                        txtbillno.BackColor = Color.White;
                        btnsave.Enabled = false;
                        btnupdate.Enabled = true;
                        sum();


                    }
                    else
                    {
                        lbltotalqty.Text = "0";
                        lbltotalamt.Text = "0";
                        txtpcode.Text = string.Empty;
                        txtpname.Text = string.Empty;
                        // txtno1.Text = string.Empty;
                        //  txtno2.Text = string.Empty;
                        //  txtno3.Text = string.Empty;
                        //  txtno4.Text = string.Empty;
                        //  txtno5.Text = string.Empty;
                        cmbitem1.SelectedIndex = -1;
                        cmbitem2.SelectedIndex = -1;
                        cmbitem3.SelectedIndex = -1;
                        cmbitem4.SelectedIndex = -1;
                        cmbitem5.SelectedIndex = -1;
                        cmbitem6.SelectedIndex = -1;
                        cmbitem7.SelectedIndex = -1;
                        txtqty1.Text = "0";
                        txtqty2.Text = "0";
                        txtqty3.Text = "0";
                        txtqty4.Text = "0";
                        txtqty5.Text = "0";
                        txtqty6.Text = "0";
                        txtqty7.Text = "0";
                        txtrate1.Text = "0";
                        txtrate2.Text = "0";
                        txtrate3.Text = "0";
                        txtrate4.Text = "0";
                        txtrate5.Text = "0";
                        txtrate6.Text = "0";
                        txtrate7.Text = "0";
                        txtamt1.Text = "0";
                        txtamt2.Text = "0";
                        txtamt3.Text = "0";
                        txtamt4.Text = "0";
                        txtamt5.Text = "0";
                        txtamt6.Text = "0";
                        txtamt7.Text = "0";
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
        #endregion

        private void txtqty6_Enter(object sender, EventArgs e)
        {
            txtqty6.BackColor = Color.AntiqueWhite;
        }

        private void txtqty6_Leave(object sender, EventArgs e)
        {
            sum();
            cal6();
            txtqty6.BackColor = Color.White;
        }

        private void txtqty6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate6.Focus();
                txtqty6.BackColor = Color.White;
            }
        }

        private void txtqty7_Enter(object sender, EventArgs e)
        {
            txtqty7.BackColor = Color.AntiqueWhite;
        }

        private void txtqty7_Leave(object sender, EventArgs e)
        {
            sum();
            cal7();
            txtqty7.BackColor = Color.White;
        }

        private void txtqty7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate7.Focus();
                txtqty7.BackColor = Color.White;
            }
        }

        private void txtrate6_Enter(object sender, EventArgs e)
        {
            txtrate6.BackColor = Color.AntiqueWhite;
        }

        private void txtrate6_Leave(object sender, EventArgs e)
        {
            cal6();
            sum();
            txtrate6.BackColor = Color.White;
        }

        private void txtrate6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtno7.Focus();
                txtrate6.BackColor = Color.White;
                cal6();
            }           
        }

        private void txtrate7_Enter(object sender, EventArgs e)
        {
            txtrate7.BackColor = Color.AntiqueWhite;
        }

        private void txtrate7_Leave(object sender, EventArgs e)
        {
            cal7();
            sum();
            txtrate7.BackColor = Color.White;
        }

        private void txtrate7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtnote.Focus();
                txtrate7.BackColor = Color.White;
                cal7();
            }
        }

        private void cmbitem6_Enter(object sender, EventArgs e)
        {
            cmbitem6.BackColor = Color.AntiqueWhite;
            fillcombo6();
        }

        private void cmbitem6_Leave(object sender, EventArgs e)
        {
            cmbitem6.BackColor = Color.White;
        }

        private void cmbitem6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate6();
                txtqty6.Focus();
            }
        }

        private void cmbitem7_Enter(object sender, EventArgs e)
        {
            cmbitem7.BackColor = Color.AntiqueWhite;
            fillcombo7();
        }

        private void cmbitem7_Leave(object sender, EventArgs e)
        {
            cmbitem7.BackColor = Color.White;
        }

        private void cmbitem7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fillrate7();
                txtqty7.Focus();
            }
        }

        private void txtno6_Enter(object sender, EventArgs e)
        {
            txtno6.BackColor = Color.AntiqueWhite;
        }

        private void txtno6_Leave(object sender, EventArgs e)
        {
            txtno6.BackColor = Color.White;
        }

        private void txtno6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem6.Focus();
                txtno6.BackColor = Color.White;
            }
        }

        private void txtno7_Enter(object sender, EventArgs e)
        {
            txtno7.BackColor = Color.AntiqueWhite;
        }

        private void txtno7_Leave(object sender, EventArgs e)
        {
            txtno7.BackColor = Color.White;
        }

        private void txtno7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cmbitem7.Focus();
                txtno7.BackColor = Color.White;
            }
        }
    }
}

