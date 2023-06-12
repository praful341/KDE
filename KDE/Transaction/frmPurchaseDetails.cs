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
    public partial class frmPurchaseDetails : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        SqlCommand cmd;
        string str;
        SqlDataAdapter da;
        SqlDataReader dr;
        #endregion

        #region " Constructors "
        public frmPurchaseDetails()
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
            txtcomcode.Text = "01";
            txtcomname.Text = "Jay Jalaram Khaman & Patra";
            txtbillno.Focus();
        }

        private void txtbillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_billno();
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

        private void btnSave_Click(object sender, EventArgs e)
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
                    str = "insert into Trn_PurchaseSummary (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,Total_Qty,Total_Kg,Total_Rate,Total_Amount,Notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + lbltotalqty.Text + "','" + lblTotalKg.Text + "','" + lblTotalRate.Text + "','" + lbltotalamt.Text + "','" + txtnote.Text + "')";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    str = "insert into Trn_Purchase (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,item_code,Item,Qty,KG,Rate,Discount,Amout,notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno1.Text + "','" + txtcode1.Text + "', '" + txtItem1.Text + "','" + txtqty1.Text + "', '" + txtkg1.Text + "' ,'" + txtrate1.Text + "', '" + txtDiscount1.Text + "' ,'" + txtamt1.Text + "', '" + txtnote.Text + "')";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1 = new SqlCommand(str, con);
                    cmd1.ExecuteNonQuery();

                    if (txtItem2.Text != string.Empty && txtcode2.Text != "0" && txtqty2.Text != "0" && txtrate2.Text != "0" && txtamt2.Text != "0")
                    {
                        str = "insert into Trn_Purchase (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,item_code,Item,Qty,KG,Rate,Discount,Amout,notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno2.Text + "','" + txtcode2.Text + "', '" + txtItem2.Text + "','" + txtqty2.Text + "', '" + txtkg2.Text + "' ,'" + txtrate2.Text + "', '" + txtDiscount2.Text + "', '" + txtamt2.Text + "', '" + txtnote.Text + "')";
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2 = new SqlCommand(str, con);
                        cmd2.ExecuteNonQuery();
                    }

                    if (txtItem3.Text != string.Empty && txtcode3.Text != "0" && txtqty3.Text != "0" && txtrate3.Text != "0" && txtamt3.Text != "0")
                    {
                        str = "insert into Trn_Purchase (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,item_code,Item,Qty,KG,Rate,Discount,Amout,notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno3.Text + "','" + txtcode3.Text + "', '" + txtItem3.Text + "','" + txtqty3.Text + "', '" + txtkg3.Text + "' ,'" + txtrate3.Text + "', '" + txtDiscount3.Text + "', '" + txtamt3.Text + "', '" + txtnote.Text + "')";
                        SqlCommand cmd3 = new SqlCommand();
                        cmd3 = new SqlCommand(str, con);
                        cmd3.ExecuteNonQuery();
                    }

                    if (txtItem4.Text != string.Empty && txtcode4.Text != "0" && txtqty4.Text != "0" && txtrate4.Text != "0" && txtamt4.Text != "0")
                    {
                        str = "insert into Trn_Purchase (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,item_code,Item,Qty,KG,Rate,Discount,Amout,notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno4.Text + "','" + txtcode4.Text + "', '" + txtItem4.Text + "','" + txtqty4.Text + "', '" + txtkg4.Text + "' ,'" + txtrate4.Text + "', '" + txtDiscount4.Text + "', '" + txtamt4.Text + "', '" + txtnote.Text + "')";
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4 = new SqlCommand(str, con);
                        cmd4.ExecuteNonQuery();
                    }

                    if (txtItem5.Text != string.Empty && txtcode5.Text != "0" && txtqty5.Text != "0" && txtrate5.Text != "0" && txtamt5.Text != "0")
                    {
                        str = "insert into Trn_Purchase (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,item_code,Item,Qty,KG,Rate,Discount,Amout,notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno5.Text + "','" + txtcode5.Text + "', '" + txtItem5.Text + "','" + txtqty5.Text + "', '" + txtkg5.Text + "' ,'" + txtrate5.Text + "', '" + txtDiscount5.Text + "', '" + txtamt5.Text + "', '" + txtnote.Text + "')";
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    }

                    if (txtItem6.Text != string.Empty && txtcode6.Text != "0" && txtqty6.Text != "0" && txtrate6.Text != "0" && txtamt6.Text != "0")
                    {
                        str = "insert into Trn_Purchase (Com_Code,Com_Name,Bill_No,Date,Party_Code,Party_Name,No,item_code,Item,Qty,KG,Rate,Discount,Amout,notes) values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno6.Text + "','" + txtcode6.Text + "', '" + txtItem6.Text + "','" + txtqty6.Text + "', '" + txtkg6.Text + "' ,'" + txtrate6.Text + "', '" + txtDiscount6.Text + "', '" + txtamt6.Text + "', '" + txtnote.Text + "')";
                        SqlCommand cmd6 = new SqlCommand();
                        cmd6 = new SqlCommand(str, con);
                        cmd6.ExecuteNonQuery();
                    }

                    str = "insert into Trn_PurchaseDetails values('" + txtcomcode.Text + "','" + txtcomname.Text + "'," + txtbillno.Text + ",'" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "','" + txtpcode.Text + "','" + txtpname.Text + "','" + txtno1.Text + "','" + txtcode1.Text + "', '" + txtItem1.Text + "','" + txtqty1.Text + "', '" + txtkg1.Text + "' ,'" + txtrate1.Text + "', '" + txtDiscount1.Text + "', '" + txtamt1.Text + "', '" + txtno2.Text + "','" + txtcode2.Text + "', '" + txtItem2.Text + "','" + txtqty2.Text + "', '" + txtkg2.Text + "' ,'" + txtrate2.Text + "', '" + txtDiscount2.Text + "', '" + txtamt2.Text + "', '" + txtno3.Text + "','" + txtcode3.Text + "', '" + txtItem3.Text + "','" + txtqty3.Text + "', '" + txtkg3.Text + "' ,'" + txtrate3.Text + "', '" + txtDiscount3.Text + "', '" + txtamt3.Text + "','" + txtno4.Text + "','" + txtcode4.Text + "', '" + txtItem4.Text + "','" + txtqty4.Text + "', '" + txtkg4.Text + "' ,'" + txtrate4.Text + "', '" + txtDiscount4.Text + "', '" + txtamt4.Text + "', '" + txtno5.Text + "','" + txtcode5.Text + "', '" + txtItem5.Text + "','" + txtqty5.Text + "', '" + txtkg5.Text + "' ,'" + txtrate5.Text + "', '" + txtDiscount5.Text + "', '" + txtamt5.Text + "','" + txtno6.Text + "','" + txtcode6.Text + "', '" + txtItem6.Text + "','" + txtqty6.Text + "', '" + txtkg6.Text + "' ,'" + txtrate6.Text + "', '" + txtDiscount6.Text + "', '" + txtamt6.Text + "', '" + txtnote.Text + "')";
                    SqlCommand cmd7 = new SqlCommand();
                    cmd7 = new SqlCommand(str, con);
                    cmd7.ExecuteNonQuery();

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

        #region " Item 1 "
        private void txtno1_Enter(object sender, EventArgs e)
        {
            txtno1.BackColor = Color.AntiqueWhite;
        }

        private void txtno1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode1.Focus();
                txtno1.BackColor = Color.White;
            }
        }

        private void txtno1_Leave(object sender, EventArgs e)
        {
            txtno1.BackColor = Color.White;
        }

        private void txtcode1_Enter(object sender, EventArgs e)
        {
            txtcode1.BackColor = Color.AntiqueWhite;
        }

        private void txtcode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_ItemCode1();
            }
        }

        private void txtcode1_Leave(object sender, EventArgs e)
        {
            txtcode1.BackColor = Color.White;
        }

        private void txtqty1_Enter(object sender, EventArgs e)
        {
            txtqty1.BackColor = Color.AntiqueWhite;
        }

        private void txtqty1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtkg1.Focus();
                txtqty1.BackColor = Color.White;
            }
        }

        private void txtqty1_Leave(object sender, EventArgs e)
        {
            cal1();
            sum();
            txtqty1.BackColor = Color.White;
        }

        private void txtkg1_Enter(object sender, EventArgs e)
        {
            txtkg1.BackColor = Color.AntiqueWhite;
        }

        private void txtkg1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate1.Focus();
                txtkg1.BackColor = Color.White;
            }
        }

        private void txtkg1_Leave(object sender, EventArgs e)
        {
            txtkg1.BackColor = Color.White;
        }

        private void txtrate1_Enter(object sender, EventArgs e)
        {
            txtrate1.BackColor = Color.AntiqueWhite;
        }

        private void txtrate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount1.Focus();
                txtrate1.BackColor = Color.White;
                cal1();
            }
        }

        private void txtrate1_Leave(object sender, EventArgs e)
        {
            cal1();
            sum();
            txtrate1.BackColor = Color.White;
        }

        private void txtDiscount1_Enter(object sender, EventArgs e)
        {
            txtDiscount1.BackColor = Color.AntiqueWhite;
        }

        private void txtDiscount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode2.Focus();
                txtrate1.BackColor = Color.White;
                cal1();
            }
        }

        private void txtDiscount1_Leave(object sender, EventArgs e)
        {
            cal1();
            sum();
            txtDiscount1.BackColor = Color.White;
        }
        #endregion

        #region " Item 2 "
        private void txtno2_Enter(object sender, EventArgs e)
        {
            txtno2.BackColor = Color.AntiqueWhite;
        }

        private void txtno2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode2.Focus();
                txtno2.BackColor = Color.White;
            }
        }

        private void txtno2_Leave(object sender, EventArgs e)
        {
            txtno2.BackColor = Color.White;
        }

        private void txtcode2_Enter(object sender, EventArgs e)
        {
            txtcode2.BackColor = Color.AntiqueWhite;
        }

        private void txtcode2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_ItemCode2();
            }
        }

        private void txtcode2_Leave(object sender, EventArgs e)
        {
            txtcode2.BackColor = Color.White;
        }

        private void txtqty2_Enter(object sender, EventArgs e)
        {
            txtqty2.BackColor = Color.AntiqueWhite;
        }

        private void txtqty2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtkg2.Focus();
                txtqty2.BackColor = Color.White;
            }
        }

        private void txtqty2_Leave(object sender, EventArgs e)
        {
            txtkg2.BackColor = Color.White;
        }

        private void txtkg2_Enter(object sender, EventArgs e)
        {
            txtkg2.BackColor = Color.AntiqueWhite;
        }

        private void txtkg2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate2.Focus();
                txtkg2.BackColor = Color.White;
            }
        }

        private void txtkg2_Leave(object sender, EventArgs e)
        {
            txtkg2.BackColor = Color.White;
        }

        private void txtrate2_Enter(object sender, EventArgs e)
        {
            txtrate2.BackColor = Color.AntiqueWhite;
        }

        private void txtrate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount2.Focus();
                txtrate2.BackColor = Color.White;
                cal2();
            }
        }

        private void txtrate2_Leave(object sender, EventArgs e)
        {
            cal2();
            sum();
            txtrate2.BackColor = Color.White;
        }

        private void txtDiscount2_Enter(object sender, EventArgs e)
        {
            txtDiscount2.BackColor = Color.AntiqueWhite;
        }

        private void txtDiscount2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode3.Focus();
                txtrate2.BackColor = Color.White;
                cal2();
            }
        }

        private void txtDiscount2_Leave(object sender, EventArgs e)
        {
            cal2();
            sum();
            txtDiscount2.BackColor = Color.White;
        }
        #endregion

        #region " Item 3 "
        private void txtno3_Enter(object sender, EventArgs e)
        {
            txtno3.BackColor = Color.AntiqueWhite;
        }

        private void txtno3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode3.Focus();
                txtno3.BackColor = Color.White;
            }
        }

        private void txtno3_Leave(object sender, EventArgs e)
        {
            txtno3.BackColor = Color.White;
        }

        private void txtcode3_Enter(object sender, EventArgs e)
        {
            txtcode3.BackColor = Color.AntiqueWhite;
        }

        private void txtcode3_Leave(object sender, EventArgs e)
        {
            txtcode3.BackColor = Color.White;
        }

        private void txtcode3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_ItemCode3();
            }
        }

        private void txtqty3_Enter(object sender, EventArgs e)
        {
            txtqty3.BackColor = Color.AntiqueWhite;
        }

        private void txtqty3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtkg3.Focus();
                txtqty3.BackColor = Color.White;
            }
        }

        private void txtqty3_Leave(object sender, EventArgs e)
        {
            sum();
            cal3();
            txtqty3.BackColor = Color.White;
        }

        private void txtkg3_Enter(object sender, EventArgs e)
        {
            txtkg3.BackColor = Color.AntiqueWhite;
        }

        private void txtkg3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate3.Focus();
                txtkg3.BackColor = Color.White;
            }
        }

        private void txtkg3_Leave(object sender, EventArgs e)
        {
            txtkg3.BackColor = Color.White;
        }

        private void txtrate3_Enter(object sender, EventArgs e)
        {
            txtrate3.BackColor = Color.AntiqueWhite;
        }

        private void txtrate3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount3.Focus();
                txtrate3.BackColor = Color.White;
                cal3();
            }
        }

        private void txtrate3_Leave(object sender, EventArgs e)
        {
            cal3();
            sum();
            txtrate3.BackColor = Color.White;
        }

        private void txtDiscount3_Enter(object sender, EventArgs e)
        {
            txtDiscount3.BackColor = Color.AntiqueWhite;
        }

        private void txtDiscount3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode4.Focus();
                txtrate2.BackColor = Color.White;
                cal3();
            }
        }

        private void txtDiscount3_Leave(object sender, EventArgs e)
        {
            cal3();
            sum();
            txtDiscount3.BackColor = Color.White;
        }
        #endregion

        #region " Item 4 "
        private void txtno4_Enter(object sender, EventArgs e)
        {
            txtno4.BackColor = Color.AntiqueWhite;
        }

        private void txtno4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode4.Focus();
                txtno4.BackColor = Color.White;
            }
        }

        private void txtno4_Leave(object sender, EventArgs e)
        {
            txtno4.BackColor = Color.White;
        }

        private void txtcode4_Enter(object sender, EventArgs e)
        {
            txtcode4.BackColor = Color.AntiqueWhite;
        }

        private void txtcode4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_ItemCode4();
            }
        }

        private void txtcode4_Leave(object sender, EventArgs e)
        {
            txtcode4.BackColor = Color.White;
        }

        private void txtqty4_Enter(object sender, EventArgs e)
        {
            txtqty4.BackColor = Color.AntiqueWhite;
        }

        private void txtqty4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtkg4.Focus();
                txtqty4.BackColor = Color.White;
            }
        }

        private void txtqty4_Leave(object sender, EventArgs e)
        {
            sum();
            cal4();
            txtqty4.BackColor = Color.White;
        }

        private void txtkg4_Enter(object sender, EventArgs e)
        {
            txtkg4.BackColor = Color.AntiqueWhite;
        }

        private void txtkg4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate4.Focus();
                txtkg4.BackColor = Color.White;
            }
        }

        private void txtkg4_Leave(object sender, EventArgs e)
        {
            txtkg4.BackColor = Color.White;
        }

        private void txtrate4_Enter(object sender, EventArgs e)
        {
            txtrate4.BackColor = Color.AntiqueWhite;
        }

        private void txtrate4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount4.Focus();
                txtrate4.BackColor = Color.White;
                cal4();
            }
        }

        private void txtrate4_Leave(object sender, EventArgs e)
        {

            cal4();
            sum();
            txtrate4.BackColor = Color.White;
        }

        private void txtDiscount4_Enter(object sender, EventArgs e)
        {
            txtDiscount4.BackColor = Color.AntiqueWhite;
        }

        private void txtDiscount4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode5.Focus();
                txtrate4.BackColor = Color.White;
                cal4();
            }
        }

        private void txtDiscount4_Leave(object sender, EventArgs e)
        {
            cal4();
            sum();
            txtDiscount4.BackColor = Color.White;
        }
        #endregion

        #region " Item 5 "
        private void txtno5_Enter(object sender, EventArgs e)
        {
            txtno5.BackColor = Color.AntiqueWhite;
        }

        private void txtno5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode5.Focus();
                txtno5.BackColor = Color.White;
            }
        }

        private void txtno5_Leave(object sender, EventArgs e)
        {
            txtno5.BackColor = Color.White;
        }

        private void txtcode5_Enter(object sender, EventArgs e)
        {
            txtcode5.BackColor = Color.AntiqueWhite;
        }

        private void txtcode5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_ItemCode5();
            }
        }

        private void txtcode5_Leave(object sender, EventArgs e)
        {
            txtcode5.BackColor = Color.White;
        }

        private void txtqty5_Enter(object sender, EventArgs e)
        {
            txtqty5.BackColor = Color.AntiqueWhite;
        }

        private void txtqty5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtkg5.Focus();
                txtqty5.BackColor = Color.White;
            }
        }

        private void txtqty5_Leave(object sender, EventArgs e)
        {
            sum();
            cal5();
            txtqty5.BackColor = Color.White;
        }

        private void txtkg5_Enter(object sender, EventArgs e)
        {
            txtkg5.BackColor = Color.AntiqueWhite;
        }

        private void txtkg5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate5.Focus();
                txtkg5.BackColor = Color.White;
            }
        }

        private void txtkg5_Leave(object sender, EventArgs e)
        {
            txtkg5.BackColor = Color.White;
        }

        private void txtrate5_Enter(object sender, EventArgs e)
        {
            txtrate5.BackColor = Color.AntiqueWhite;
        }

        private void txtrate5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount5.Focus();
                txtrate5.BackColor = Color.White;
                cal5();
            }
        }

        private void txtrate5_Leave(object sender, EventArgs e)
        {
            cal5();
            sum();
            txtrate5.BackColor = Color.White;
        }

        private void txtDiscount5_Enter(object sender, EventArgs e)
        {
            txtDiscount5.BackColor = Color.AntiqueWhite;
        }

        private void txtDiscount5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode6.Focus();
                txtrate5.BackColor = Color.White;
                cal5();
            }
        }

        private void txtDiscount5_Leave(object sender, EventArgs e)
        {
            cal5();
            sum();
            txtDiscount5.BackColor = Color.White;
        }
        #endregion

        #region " Item 6 "
        private void txtno6_Enter(object sender, EventArgs e)
        {
            txtno6.BackColor = Color.AntiqueWhite;
        }

        private void txtno6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtcode6.Focus();
                txtno6.BackColor = Color.White;
            }
        }

        private void txtno6_Leave(object sender, EventArgs e)
        {
            txtno6.BackColor = Color.White;
        }

        private void txtcode6_Enter(object sender, EventArgs e)
        {
            txtcode6.BackColor = Color.AntiqueWhite;
        }

        private void txtcode6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                validate_ItemCode6();
            }
        }

        private void txtcode6_Leave(object sender, EventArgs e)
        {
            txtcode6.BackColor = Color.White;
        }

        private void txtqty6_Enter(object sender, EventArgs e)
        {
            txtqty6.BackColor = Color.AntiqueWhite;
        }

        private void txtqty6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtkg6.Focus();
                txtqty6.BackColor = Color.White;
            }
        }

        private void txtqty6_Leave(object sender, EventArgs e)
        {
            txtqty6.BackColor = Color.White;
        }

        private void txtkg6_Enter(object sender, EventArgs e)
        {
            txtkg6.BackColor = Color.AntiqueWhite;
        }

        private void txtkg6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtrate6.Focus();
                txtkg6.BackColor = Color.White;
            }
        }

        private void txtkg6_Leave(object sender, EventArgs e)
        {
            txtkg6.BackColor = Color.White;
        }

        private void txtrate6_Enter(object sender, EventArgs e)
        {
            txtrate6.BackColor = Color.AntiqueWhite;
        }

        private void txtrate6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDiscount6.Focus();
                txtrate6.BackColor = Color.White;
                cal6();
            }
        }

        private void txtrate6_Leave(object sender, EventArgs e)
        {
            cal6();
            sum();
            txtrate6.BackColor = Color.White;
        }

        private void txtDiscount6_Enter(object sender, EventArgs e)
        {
            txtDiscount6.BackColor = Color.AntiqueWhite;
        }

        private void txtDiscount6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtnote.Focus();
                txtrate6.BackColor = Color.White;
                cal6();
            }
        }

        private void txtDiscount6_Leave(object sender, EventArgs e)
        {
            cal6();
            sum();
            txtDiscount6.BackColor = Color.White;
        }

        #endregion

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
                    str = "update trn_purchasesummary set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', Total_Qty = '" + lbltotalqty.Text + "', Total_Kg = '" + lblTotalKg.Text + "', Total_Rate = '" + lblTotalRate.Text + "', Total_Amount = '" + lbltotalamt.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    str = "update trn_purchasedetails set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', Item_No_1 = '" + txtno1.Text + "', Item_Code_1 = '" + txtcode1.Text + "', Item_Name_1 = '" + txtItem1.Text + "', Qty_1 = '" + txtqty1.Text + "', KG_1 = '" + txtkg1.Text + "', Rate_1 = '" + txtrate1.Text + "', Discount_1 = '" + txtDiscount1.Text + "', Amout_1 = '" + txtamt1.Text + "', Item_No_2 = '" + txtno2.Text + "', Item_Code_2 = '" + txtcode2.Text + "', Item_Name_2 = '" + txtItem2.Text + "', Qty_2 = '" + txtqty2.Text + "', KG_2 = '" + txtkg2.Text + "', Rate_2 = '" + txtrate2.Text + "', Discount_2 = '" + txtDiscount2.Text + "', Amout_2 = '" + txtamt2.Text + "', Item_No_3 = '" + txtno3.Text + "', Item_Code_3 = '" + txtcode3.Text + "', Item_Name_3 = '" + txtItem3.Text + "', Qty_3 = '" + txtqty3.Text + "', KG_3 = '" + txtkg3.Text + "', Rate_3 = '" + txtrate3.Text + "', Discount_3 = '" + txtDiscount3.Text + "', Amout_3 = '" + txtamt3.Text + "', Item_No_4 = '" + txtno4.Text + "', Item_Code_4 = '" + txtcode4.Text + "', Item_Name_4 = '" + txtItem4.Text + "', Qty_4 = '" + txtqty4.Text + "', KG_4 = '" + txtkg4.Text + "', Rate_4 = '" + txtrate4.Text + "', Discount_4 = '" + txtDiscount4.Text + "', Amout_4 = '" + txtamt4.Text + "', Item_No_5 = '" + txtno5.Text + "', Item_Code_5 = '" + txtcode5.Text + "', Item_Name_5 = '" + txtItem5.Text + "', Qty_5 = '" + txtqty5.Text + "', KG_5 = '" + txtkg5.Text + "', Rate_5 = '" + txtrate5.Text + "', Discount_5 = '" + txtDiscount5.Text + "', Amout_5 = '" + txtamt5.Text + "', Item_No_6 = '" + txtno6.Text + "', Item_Code_6 = '" + txtcode6.Text + "', Item_Name_6 = '" + txtItem6.Text + "', Qty_6 = '" + txtqty6.Text + "', KG_6 = '" + txtkg6.Text + "', Rate_6 = '" + txtrate6.Text + "', Discount_6 = '" + txtDiscount6.Text + "', Amout_6 = '" + txtamt6.Text + "', Notes = '" + txtnote.Text + "' where Com_Code= '" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "'";
                    SqlCommand cmd0 = new SqlCommand();
                    cmd0 = new SqlCommand(str, con);
                    cmd0.ExecuteNonQuery();

                    str = "update trn_purchase set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', No = '" + txtno1.Text + "', item_code = '" + txtcode1.Text + "', Item = '" + txtItem1.Text + "', Qty = '" + txtqty1.Text + "', KG = '" + txtkg1.Text + "', Rate = '" + txtrate1.Text + "', Discount = '" + txtDiscount1.Text + "', Amout = '" + txtamt1.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "' and No = '" + txtno1.Text + "'";
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1 = new SqlCommand(str, con);
                    cmd1.ExecuteNonQuery();


                    //if (txtItem2.Text != string.Empty && txtkg2.Text != "0" && txtqty2.Text != "0" && txtrate2.Text != "0")
                    //{
                    str = "update trn_purchase set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', No = '" + txtno2.Text + "', item_code = '" + txtcode2.Text + "', Item = '" + txtItem2.Text + "', Qty = '" + txtqty2.Text + "', KG = '" + txtkg2.Text + "', Rate = '" + txtrate2.Text + "', Discount = '" + txtDiscount2.Text + "', Amout = '" + txtamt2.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "' and No = '" + txtno2.Text + "'";
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2 = new SqlCommand(str, con);
                        cmd2.ExecuteNonQuery();
                    //}
                    //if (txtItem3.Text != string.Empty && txtkg3.Text != "0" && txtqty3.Text != "0" && txtrate3.Text != "0")
                    //{
                        str = "update trn_purchase set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', No = '" + txtno3.Text + "', item_code = '" + txtcode3.Text + "', Item = '" + txtItem3.Text + "', Qty = '" + txtqty3.Text + "', KG = '" + txtkg3.Text + "', Rate = '" + txtrate3.Text + "', Discount = '" + txtDiscount3.Text + "', Amout = '" + txtamt3.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "' and No = '" + txtno3.Text + "'";
                        SqlCommand cmd3 = new SqlCommand();
                        cmd3 = new SqlCommand(str, con);
                        cmd3.ExecuteNonQuery();
                    //}
                    //if (txtItem4.Text != string.Empty && txtkg4.Text != "0" && txtqty4.Text != "0" && txtrate4.Text != "0")
                    //{
                        str = "update trn_purchase set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', No = '" + txtno4.Text + "', item_code = '" + txtcode4.Text + "', Item = '" + txtItem4.Text + "', Qty = '" + txtqty4.Text + "', KG = '" + txtkg4.Text + "', Rate = '" + txtrate4.Text + "', Discount = '" + txtDiscount4.Text + "',  Amout = '" + txtamt4.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "' and No = '" + txtno4.Text + "'";
                        SqlCommand cmd4 = new SqlCommand();
                        cmd4 = new SqlCommand(str, con);
                        cmd4.ExecuteNonQuery();
                    //}
                    //if (txtItem5.Text != string.Empty && txtkg5.Text != "0" && txtqty5.Text != "0" && txtrate5.Text != "0")
                    //{
                        str = "update trn_purchase set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', No = '" + txtno5.Text + "', item_code = '" + txtcode5.Text + "', Item = '" + txtItem5.Text + "', Qty = '" + txtqty5.Text + "', KG = '" + txtkg5.Text + "', Rate = '" + txtrate5.Text + "', Discount = '" + txtDiscount5.Text + "', Amout = '" + txtamt5.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "' and No = '" + txtno5.Text + "'";
                        SqlCommand cmd5 = new SqlCommand();
                        cmd5 = new SqlCommand(str, con);
                        cmd5.ExecuteNonQuery();
                    //}
                    //if (txtItem6.Text != string.Empty && txtkg6.Text != "0" && txtqty6.Text != "0" && txtrate6.Text != "0")
                    //{
                        str = "update trn_purchase set Date = '" + DateTime.Parse(txtdate.Text).ToString("MM/dd/yyyy") + "', Party_Code = '" + txtpcode.Text + "', Party_Name='" + txtpname.Text + "', No = '" + txtno6.Text + "', item_code = '" + txtcode6.Text + "', Item = '" + txtItem6.Text + "', Qty = '" + txtqty6.Text + "', KG = '" + txtkg6.Text + "', Rate = '" + txtrate6.Text + "', Discount = '" + txtDiscount6.Text + "', Amout = '" + txtamt6.Text + "', Notes = '" + txtnote.Text + "' where Com_Code='" + txtcomcode.Text + "' and Bill_No= '" + txtbillno.Text + "' and No = '" + txtno6.Text + "'";
                        SqlCommand cmd6 = new SqlCommand();
                        cmd6 = new SqlCommand(str, con);
                        cmd6.ExecuteNonQuery();
                    //}
                
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
                        str = "delete from trn_purchasesummary where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                        cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();

                        str = "delete from trn_purchase where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1 = new SqlCommand(str, con);
                        cmd1.ExecuteNonQuery();

                        str = "delete from trn_purchasedetails where Com_Code='" + txtcomcode.Text + "' and Bill_No=" + txtbillno.Text + "";
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2 = new SqlCommand(str, con);
                        cmd2.ExecuteNonQuery();

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

        private void txtnote_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == 13)
                {
                    con.Open();

                    str = "select * from Trn_Purchase where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
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
                str = "select Party_Code as PartyCode,Party_Name as PartyName,Party_Add Address from Mst_PurchaseParty";
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

        private void txtnote_Leave(object sender, EventArgs e)
        {
            txtnote.BackColor = Color.White;
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
            string qr = "select MAX(Bill_No) from Trn_Purchase";
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
            txtpcode.Text = string.Empty;
            txtpname.Text = string.Empty;
            txtbillno.Focus();
            thedate();
            count();
            colorwhite();

            txtcode1.Text = string.Empty;
            txtcode2.Text = string.Empty;
            txtcode3.Text = string.Empty;
            txtcode4.Text = string.Empty;
            txtcode5.Text = string.Empty;
            txtcode6.Text = string.Empty;

            txtItem1.Text = string.Empty;
            txtItem2.Text = string.Empty;
            txtItem3.Text = string.Empty;
            txtItem4.Text = string.Empty;
            txtItem5.Text = string.Empty;
            txtItem6.Text = string.Empty;

            txtqty1.Text = "0";
            txtqty2.Text = "0";
            txtqty3.Text = "0";
            txtqty4.Text = "0";
            txtqty5.Text = "0";
            txtqty6.Text = "0";

            txtkg1.Text = "0";
            txtkg2.Text = "0";
            txtkg3.Text = "0";
            txtkg4.Text = "0";
            txtkg5.Text = "0";
            txtkg6.Text = "0";

            txtrate1.Text = "0";
            txtrate2.Text = "0";
            txtrate3.Text = "0";
            txtrate4.Text = "0";
            txtrate5.Text = "0";
            txtrate6.Text = "0";

            txtDiscount1.Text = "0";
            txtDiscount2.Text = "0";
            txtDiscount3.Text = "0";
            txtDiscount4.Text = "0";
            txtDiscount5.Text = "0";
            txtDiscount6.Text = "0";

            txtamt1.Text = "0";
            txtamt2.Text = "0";
            txtamt3.Text = "0";
            txtamt4.Text = "0";
            txtamt5.Text = "0";
            txtamt6.Text = "0";

            lbltotalqty.Text = "0";
            lblTotalRate.Text = "0";
            lbltotalamt.Text = "0";
            lblTotalKg.Text = "0";

            txtnote.Text = string.Empty;
            count();
            btnupdate.Enabled = true;
            btnsave.Enabled = true;
            gridhelp.Hide();
            gridhelpparty.Hide();
        }

        public void sum()
        {
            try
            {
                double sumqty = (Convert.ToDouble(txtqty1.Text)) + (Convert.ToDouble(txtqty2.Text)) + (Convert.ToDouble(txtqty3.Text)) + (Convert.ToDouble(txtqty4.Text)) + (Convert.ToDouble(txtqty5.Text)) + (Convert.ToDouble(txtqty6.Text));
                lbltotalqty.Text = sumqty.ToString();

                double sumKg = (Convert.ToDouble(txtkg1.Text)) + (Convert.ToDouble(txtkg2.Text)) + (Convert.ToDouble(txtkg3.Text)) + (Convert.ToDouble(txtkg4.Text)) + (Convert.ToDouble(txtkg5.Text)) + (Convert.ToDouble(txtkg6.Text));
                lblTotalKg.Text = sumKg.ToString();

                double sumamt = (Convert.ToDouble(txtamt1.Text)) + (Convert.ToDouble(txtamt2.Text)) + (Convert.ToDouble(txtamt3.Text)) + (Convert.ToDouble(txtamt4.Text)) + (Convert.ToDouble(txtamt5.Text)) + (Convert.ToDouble(txtamt6.Text));
                lbltotalamt.Text = sumamt.ToString();

                if (sumamt > 0 && sumqty > 0)
                    lblTotalRate.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(sumamt)) / Convert.ToDouble(sumqty), 2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            try
            {
                decimal amt = (Convert.ToDecimal(txtqty1.Text)) * (Convert.ToDecimal(txtrate1.Text));
                decimal discount = 0;
                if (Convert.ToDouble(txtDiscount1.Text) != 0)
                    discount = Convert.ToDecimal((amt / 100) * Convert.ToDecimal(txtDiscount1.Text));
                txtamt1.Text = Convert.ToString(amt - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void cal2()
        {
            try
            {
                decimal amt = (Convert.ToDecimal(txtqty2.Text)) * (Convert.ToDecimal(txtrate2.Text));
                decimal discount = 0;
                if (Convert.ToDouble(txtDiscount2.Text) != 0)
                    discount = Convert.ToDecimal((amt / 100) * Convert.ToDecimal(txtDiscount2.Text));
                txtamt2.Text = Convert.ToString(amt - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void cal3()
        {
            try
            {
                decimal amt = (Convert.ToDecimal(txtqty3.Text)) * (Convert.ToDecimal(txtrate3.Text));
                decimal discount = 0;
                if (Convert.ToDouble(txtDiscount3.Text) != 0)
                    discount = Convert.ToDecimal((amt / 100) * Convert.ToDecimal(txtDiscount3.Text));
                txtamt3.Text = Convert.ToString(amt - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void cal4()
        {
            try
            {
                decimal amt = (Convert.ToDecimal(txtqty4.Text)) * (Convert.ToDecimal(txtrate4.Text));
                decimal discount = 0;
                if (Convert.ToDouble(txtDiscount4.Text) != 0)
                    discount = Convert.ToDecimal((amt / 100) * Convert.ToDecimal(txtDiscount4.Text));
                txtamt4.Text = Convert.ToString(amt - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void cal5()
        {
            try
            {
                decimal amt = (Convert.ToDecimal(txtqty5.Text)) * (Convert.ToDecimal(txtrate5.Text));
                decimal discount = 0;
                if (Convert.ToDouble(txtDiscount5.Text) != 0)
                    discount = Convert.ToDecimal((amt / 100) * Convert.ToDecimal(txtDiscount5.Text));
                txtamt5.Text = Convert.ToString(amt - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void cal6()
        {
            try
            {
                decimal amt = (Convert.ToDecimal(txtqty6.Text)) * (Convert.ToDecimal(txtrate6.Text));
                decimal discount = 0;
                if (Convert.ToDouble(txtDiscount6.Text) != 0)
                    discount = Convert.ToDecimal((amt / 100) * Convert.ToDecimal(txtDiscount6.Text));
                txtamt6.Text = Convert.ToString(amt - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    str = "select * from trn_purchasedetails where Com_Code='" + txtcomcode.Text + "' and Bill_No='" + txtbillno.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txt_id.Text = dr["Purchase_ID"].ToString();
                        txtdate.Text = dr["Date"].ToString();
                        txtpcode.Text = dr["Party_Code"].ToString();
                        txtpname.Text = dr["Party_Name"].ToString();

                        txtno1.Text = dr["Item_No_1"].ToString();
                        txtno2.Text = dr["Item_No_2"].ToString();
                        txtno3.Text = dr["Item_No_3"].ToString();
                        txtno4.Text = dr["Item_No_4"].ToString();
                        txtno5.Text = dr["Item_No_5"].ToString();
                        txtno6.Text = dr["Item_No_6"].ToString();

                        txtcode1.Text = dr["Item_Code_1"].ToString();
                        txtcode2.Text = dr["Item_Code_2"].ToString();
                        txtcode3.Text = dr["Item_Code_3"].ToString();
                        txtcode4.Text = dr["Item_Code_4"].ToString();
                        txtcode5.Text = dr["Item_Code_5"].ToString();
                        txtcode6.Text = dr["Item_Code_6"].ToString();

                        txtItem1.Text = dr["Item_Name_1"].ToString();
                        txtItem2.Text = dr["Item_Name_2"].ToString();
                        txtItem3.Text = dr["Item_Name_3"].ToString();
                        txtItem4.Text = dr["Item_Name_4"].ToString();
                        txtItem5.Text = dr["Item_Name_5"].ToString();
                        txtItem6.Text = dr["Item_Name_6"].ToString();

                        txtqty1.Text = dr["Qty_1"].ToString();
                        txtqty2.Text = dr["Qty_2"].ToString();
                        txtqty3.Text = dr["Qty_3"].ToString();
                        txtqty4.Text = dr["Qty_4"].ToString();
                        txtqty5.Text = dr["Qty_5"].ToString();
                        txtqty6.Text = dr["Qty_6"].ToString();

                        txtkg1.Text = dr["KG_1"].ToString();
                        txtkg2.Text = dr["KG_2"].ToString();
                        txtkg3.Text = dr["KG_3"].ToString();
                        txtkg4.Text = dr["KG_4"].ToString();
                        txtkg5.Text = dr["KG_5"].ToString();
                        txtkg6.Text = dr["KG_6"].ToString();

                        txtrate1.Text = dr["Rate_1"].ToString();
                        txtrate2.Text = dr["Rate_2"].ToString();
                        txtrate3.Text = dr["Rate_3"].ToString();
                        txtrate4.Text = dr["Rate_4"].ToString();
                        txtrate5.Text = dr["Rate_5"].ToString();
                        txtrate6.Text = dr["Rate_6"].ToString();

                        txtDiscount1.Text = dr["Discount_1"].ToString();
                        txtDiscount2.Text = dr["Discount_2"].ToString();
                        txtDiscount3.Text = dr["Discount_3"].ToString();
                        txtDiscount4.Text = dr["Discount_4"].ToString();
                        txtDiscount5.Text = dr["Discount_5"].ToString();
                        txtDiscount6.Text = dr["Discount_6"].ToString();

                        txtamt1.Text = dr["Amout_1"].ToString();
                        txtamt2.Text = dr["Amout_2"].ToString();
                        txtamt3.Text = dr["Amout_3"].ToString();
                        txtamt4.Text = dr["Amout_4"].ToString();
                        txtamt5.Text = dr["Amout_5"].ToString();
                        txtamt6.Text = dr["Amout_6"].ToString();

                        txtnote.Text = dr["Notes"].ToString();
                        txtdate.Focus();
                        txtbillno.BackColor = Color.White;
                        btnsave.Enabled = false;
                        btnupdate.Enabled = true;
                        btndelete.Enabled = true;
                        sum();
                    }
                    else
                    {
                        lbltotalqty.Text = "0";
                        lblTotalKg.Text = "0";
                        lblTotalRate.Text = "0";
                        lbltotalamt.Text = "0";
                        txtpcode.Text = string.Empty;
                        txtpname.Text = string.Empty;

                        txtcode1.Text = "0";
                        txtcode2.Text = "0";
                        txtcode3.Text = "0";
                        txtcode4.Text = "0";
                        txtcode5.Text = "0";
                        txtcode6.Text = "0";

                        txtItem1.Text = string.Empty;
                        txtItem2.Text = string.Empty;
                        txtItem3.Text = string.Empty;
                        txtItem4.Text = string.Empty;
                        txtItem5.Text = string.Empty;
                        txtItem6.Text = string.Empty;

                        txtqty1.Text = "0";
                        txtqty2.Text = "0";
                        txtqty3.Text = "0";
                        txtqty4.Text = "0";
                        txtqty5.Text = "0";
                        txtqty6.Text = "0";

                        txtkg1.Text = "0";
                        txtkg2.Text = "0";
                        txtkg3.Text = "0";
                        txtkg4.Text = "0";
                        txtkg5.Text = "0";
                        txtkg6.Text = "0";

                        txtrate1.Text = "0";
                        txtrate2.Text = "0";
                        txtrate3.Text = "0";
                        txtrate4.Text = "0";
                        txtrate5.Text = "0";
                        txtrate6.Text = "0";

                        txtDiscount1.Text = "0";
                        txtDiscount2.Text = "0";
                        txtDiscount3.Text = "0";
                        txtDiscount4.Text = "0";
                        txtDiscount5.Text = "0";
                        txtDiscount6.Text = "0";

                        txtamt1.Text = "0";
                        txtamt2.Text = "0";
                        txtamt3.Text = "0";
                        txtamt4.Text = "0";
                        txtamt5.Text = "0";
                        txtamt6.Text = "0";

                        txtnote.Text = string.Empty;
                        btnsave.Enabled = true;
                        btnupdate.Enabled = false;
                        btndelete.Enabled = false;
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
                    str = "select * from Mst_PurchaseParty where Party_Code='" + txtpcode.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtpcode.Text = dr["Party_Code"].ToString();
                        txtpname.Text = dr["Party_Name"].ToString();
                        txtcode1.Focus();
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

        public void validate_ItemCode1()
        {
            if (txtcode1.Text == "")
            {
                MessageBox.Show("Enter Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcode1.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Item where item_Code='" + txtcode1.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtItem1.Text = dr["Item_Name"].ToString();
                        txtqty1.Focus();
                        txtcode1.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcode1.Focus();
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

        public void validate_ItemCode2()
        {
            if (txtcode2.Text == "")
            {
                MessageBox.Show("Enter Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcode2.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Item where item_Code='" + txtcode2.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtItem2.Text = dr["Item_Name"].ToString();
                        txtqty2.Focus();
                        txtcode2.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcode2.Focus();
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

        public void validate_ItemCode3()
        {
            if (txtcode3.Text == "")
            {
                MessageBox.Show("Enter Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcode3.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Item where item_Code='" + txtcode3.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtItem3.Text = dr["Item_Name"].ToString();
                        txtqty3.Focus();
                        txtcode3.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcode3.Focus();
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

        public void validate_ItemCode4()
        {
            if (txtcode4.Text == "")
            {
                MessageBox.Show("Enter Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcode4.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Item where item_Code='" + txtcode4.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtItem4.Text = dr["Item_Name"].ToString();
                        txtqty4.Focus();
                        txtcode4.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcode4.Focus();
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

        public void validate_ItemCode5()
        {
            if (txtcode5.Text == "")
            {
                MessageBox.Show("Enter Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcode5.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Item where item_Code='" + txtcode5.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtItem5.Text = dr["Item_Name"].ToString();
                        txtqty5.Focus();
                        txtcode5.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcode5.Focus();
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

        public void validate_ItemCode6()
        {
            if (txtcode6.Text == "")
            {
                MessageBox.Show("Enter Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtcode6.Focus();
            }
            else
            {
                try
                {
                    con.Open();
                    str = "select * from Mst_Item where item_Code='" + txtcode6.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtItem6.Text = dr["Item_Name"].ToString();
                        txtqty6.Focus();
                        txtcode6.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Item Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtcode6.Focus();
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
    }
}

