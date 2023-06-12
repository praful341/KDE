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
    public partial class frmRptBillDate : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        string str;
        SqlCommand cmd;
        frmEnterPasword formlot = new frmEnterPasword();
        #endregion

        #region " Constructors "
        public frmRptBillDate()
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

        private void Txt_Party_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    P_Code_Validation();
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
                //else if (Txt_Party.Text == "")
                //{
                //    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Txt_Party.Focus();
                //}
                else if (txt_billNo.Text == "")
                {
                    MessageBox.Show("Enter Bill No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_billNo.Focus();
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
                    if (Txt_Party.Text != "")
                    {
                        con.Open();

                        str = "SELECT sum(billAmount) FROM  Mst_Payment where partyCode='" + Txt_Party.Text + "' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        var billamtck = cmd.ExecuteScalar();
                        if (billamtck != System.DBNull.Value)
                        {
                            Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                        }
                        else
                        {
                            Decimal billamount = 0;
                        }
                        string str1;
                        str1 = "SELECT sum(payreceive) FROM  Mst_Payment where partyCode='" + Txt_Party.Text + "' ";
                        SqlCommand cmd1 = new SqlCommand(str1, con);
                        var payamtck = cmd1.ExecuteScalar();
                        if (payamtck != System.DBNull.Value)
                        {
                            Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                        }
                        else
                        {
                            Decimal payamount = 0;
                        }

                        string str2;
                        str2 = "select SUM(Amout) from Mst_Transaction where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        var totamt = cmd2.ExecuteScalar();
                        if (totamt != System.DBNull.Value)
                        {
                            int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                        }
                        else
                        {
                            int totamt1 = 0;
                        }


                        if (billamtck != System.DBNull.Value && payamtck != System.DBNull.Value && totamt != System.DBNull.Value)
                        {
                            Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                            Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                            int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());

                            Decimal penbal = billamount - payamount;

                            txt_pen_amt.Text = penbal.ToString();
                            Decimal sumamt = penbal + totamt1;
                            txtTot_Amt.Text = sumamt.ToString("0");

                        }

                        else
                        {
                            if (billamtck != System.DBNull.Value && payamtck == System.DBNull.Value && totamt != System.DBNull.Value)
                            {
                                Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                                int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                                Decimal penbal = billamount - 0;
                                Decimal sumamt = penbal + totamt1;
                                txt_pen_amt.Text = penbal.ToString();
                                txtTot_Amt.Text = sumamt.ToString("0");

                            }

                            else
                            {
                                if (billamtck == System.DBNull.Value && payamtck != System.DBNull.Value && totamt != System.DBNull.Value)
                                {
                                    Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                                    Decimal penbal = 0 - payamount;
                                    txt_pen_amt.Text = penbal.ToString();
                                    Decimal sumamt = 0 + penbal;
                                    txtTot_Amt.Text = sumamt.ToString("0");
                                }

                                else
                                {
                                    if (totamt != System.DBNull.Value)
                                    {
                                        txt_pen_amt.Text = "0";
                                        int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                                        Decimal sumamt = 0 + totamt1;
                                        txtTot_Amt.Text = sumamt.ToString("0");
                                    }
                                    else
                                    {
                                        txt_pen_amt.Text = "0";
                                    }
                                }
                            }
                        }

                        if (textBox1.Text != "")
                        {
                            con.Close();
                            con.Open();
                            string strr = "select * from Bill_details where Bill_No='" + txt_billNo.Text + "'";
                            SqlCommand cmdd = new SqlCommand(strr, con);
                            cmdd.ExecuteNonQuery();
                            SqlDataReader dr = cmdd.ExecuteReader();

                            if (dr.HasRows)
                            {
                                dr.Read();
                                dr.Close();
                                con.Close();
                            }
                            else
                            {

                                DialogResult result;
                                result = MessageBox.Show("Are you want to Save this Bill..?", "Bill Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {

                                    ShowMyDialogBox();

                                    if (textBox2.Text == "123")
                                    {
                                        con.Close();
                                        con.Open();
                                        str = "insert into Bill_details(Com_Code,Com_Name,Party_Code,Party_Name,Bill_No,From_date,To_date,Amount,For_out,Total_amt) values('" + Txt_Com_Code.Text + "','" + Txt_Com_Name.Text + "','" + Txt_Party.Text + "','" + txtParty_Name.Text + "'," + txt_billNo.Text + ",'" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "'," + textBox1.Text + ",'" + txt_pen_amt.Text + "','" + txtTot_Amt.Text + "')";
                                        cmd = new SqlCommand(str, con);
                                        cmd.ExecuteNonQuery();
                                        string strt = "insert into Mst_Payment(partyCode,partyName,billNo,billForm,billTo,billAmount) values('" + Txt_Party.Text + "','" + txtParty_Name.Text + "'," + txt_billNo.Text + ",'" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "'," + textBox1.Text + ")";
                                        cmd1 = new SqlCommand(strt, con);
                                        cmd1.ExecuteNonQuery();

                                        con.Close();

                                    }
                                }
                            }
                            con.Close();

                        }

                        con.Close();
                        con.Open();
                        str = "select * from Trn_Items where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
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
                            str = "select sum(amt1)+sum(amt2)+sum(amt3)+sum(amt4)+sum(amt5) from Trn_Items where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                            SqlCommand cmdck = new SqlCommand(str, con);
                            var CmdCk = cmdck.ExecuteScalar();
                            int ck1 = Convert.ToInt32(cmdck.ExecuteScalar());

                            str2 = "select Amount from Bill_details where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND From_date='" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and To_date='" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                            SqlCommand cmdck2 = new SqlCommand(str2, con);
                            var CmdCk2 = cmdck2.ExecuteScalar();

                            if (CmdCk2 == System.DBNull.Value)
                            {

                            }
                            else
                            {
                                int ck2 = Convert.ToInt32(cmdck2.ExecuteScalar());
                                if (ck1 != ck2)
                                {
                                    con.Close();
                                    con.Open();
                                    str = "update Bill_details set Amount='" + CmdCk + "' where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND From_date= '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and To_date= '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                                    SqlCommand cmdup = new SqlCommand(str, con);
                                    cmdup.ExecuteNonQuery();
                                    con.Close();
                                    con.Open();
                                    str = "update Mst_Payment set billAmount='" + CmdCk + "' where partyCode='" + Txt_Party.Text + "' AND billForm='" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and billTo='" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                                    SqlCommand cmdup2 = new SqlCommand(str, con);
                                    cmdup2.ExecuteNonQuery();
                                }
                            }
                            frmRptBillDateViewer obj = new frmRptBillDateViewer();
                            obj.C_Code = Txt_Com_Code.Text;

                            obj.P_Code = Txt_Party.Text;

                            obj.F_Date = Txt_From_Date.Text;
                            obj.T_Date = Txt_To_Date.Text;
                            obj.BillNo = txt_billNo.Text;
                            obj.p_amt = txt_pen_amt.Text;
                            obj.Tot_Amt = txtTot_Amt.Text;

                            obj.Show();


                        }
                        con.Close();
                    }
                    if (Txt_Party.Text == "")
                    {
                        string str;
                        con.Open();

                        str = "SELECT sum(billAmount) FROM  Mst_Payment where billDate between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        var billamtck = cmd.ExecuteScalar();
                        if (billamtck != System.DBNull.Value)
                        {
                            Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                        }
                        else
                        {
                            Decimal billamount = 0;
                        }
                        string str1;
                        str1 = "SELECT sum(payreceive) FROM  Mst_Payment where Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        SqlCommand cmd1 = new SqlCommand(str1, con);
                        var payamtck = cmd1.ExecuteScalar();
                        if (payamtck != System.DBNull.Value)
                        {
                            Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                        }
                        else
                        {
                            Decimal payamount = 0;
                        }

                        string str2;
                        str2 = "select SUM(Amout) from Mst_Transaction where Com_Code='" + Txt_Com_Code.Text + "' and Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        SqlCommand cmd2 = new SqlCommand(str2, con);
                        var totamt = cmd2.ExecuteScalar();
                        if (totamt != System.DBNull.Value)
                        {
                            Decimal totamt1 = Convert.ToDecimal(cmd2.ExecuteScalar());
                        }
                        else
                        {
                            Decimal totamt1 = 0;
                        }
                        if (billamtck != System.DBNull.Value && payamtck != System.DBNull.Value && totamt != System.DBNull.Value)
                        {
                            Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                            Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                            int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());

                            Decimal penbal = billamount - payamount;

                            txt_pen_amt.Text = penbal.ToString();
                            Decimal sumamt = penbal + totamt1;
                            txtTot_Amt.Text = sumamt.ToString("0");

                        }

                        else
                        {
                            if (billamtck != System.DBNull.Value && payamtck == System.DBNull.Value && totamt != System.DBNull.Value)
                            {
                                Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                                int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                                Decimal penbal = billamount - 0;
                                Decimal sumamt = penbal + totamt1;
                                txt_pen_amt.Text = penbal.ToString();
                                txtTot_Amt.Text = sumamt.ToString("0");

                            }

                            else
                            {
                                if (billamtck == System.DBNull.Value && payamtck != System.DBNull.Value && totamt != System.DBNull.Value)
                                {
                                    Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                                    Decimal penbal = 0 - payamount;
                                    txt_pen_amt.Text = penbal.ToString();
                                    Decimal sumamt = 0 + penbal;
                                    txtTot_Amt.Text = sumamt.ToString("0");
                                }

                                else
                                {
                                    if (totamt != System.DBNull.Value)
                                    {
                                        txt_pen_amt.Text = "0";
                                        int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                                        Decimal sumamt = 0 + totamt1;
                                        txtTot_Amt.Text = sumamt.ToString("0");
                                    }
                                    else
                                    {
                                        txt_pen_amt.Text = "0";
                                    }
                                }
                            }
                        }

                        con.Close();
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
                            str = "select sum(amt1)+sum(amt2)+sum(amt3)+sum(amt4)+sum(amt5) from Trn_Items where Com_Code='" + Txt_Com_Code.Text + "'  AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                            SqlCommand cmdck = new SqlCommand(str, con);
                            var CmdCk = cmdck.ExecuteScalar();
                            int ck1 = Convert.ToInt32(cmdck.ExecuteScalar());

                            str2 = "select Amount from Bill_details where Com_Code='" + Txt_Com_Code.Text + "'  AND From_date='" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and To_date='" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                            SqlCommand cmdck2 = new SqlCommand(str2, con);
                            var CmdCk2 = cmdck2.ExecuteScalar();

                            if (CmdCk2 == System.DBNull.Value)
                            {

                            }
                            else
                            {
                                int ck2 = Convert.ToInt32(cmdck2.ExecuteScalar());
                                if (ck1 != ck2)
                                {
                                    con.Close();
                                    con.Open();
                                    str = "update Bill_details set Amount='" + CmdCk + "' where Com_Code='" + Txt_Com_Code.Text + "'  AND From_date= '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and To_date= '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                                    SqlCommand cmdup = new SqlCommand(str, con);
                                    cmdup.ExecuteNonQuery();
                                    con.Close();
                                    con.Open();
                                    str = "update Mst_Payment set billAmount='" + CmdCk + "' where billForm='" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and billTo='" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                                    SqlCommand cmdup2 = new SqlCommand(str, con);
                                    cmdup2.ExecuteNonQuery();
                                }

                            }
                            frmRptBillDateViewer obj = new frmRptBillDateViewer();
                            obj.C_Code = Txt_Com_Code.Text;

                            obj.P_Code = Txt_Party.Text;

                            obj.F_Date = Txt_From_Date.Text;
                            obj.T_Date = Txt_To_Date.Text;
                            obj.BillNo = txt_billNo.Text;
                            obj.p_amt = txt_pen_amt.Text;
                            //  obj.Tot_Amt = txtTot_Amt.Text;
                            obj.Show();


                        }
                        con.Close();
                    }

                }
                count();
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

        private void Txt_To_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    bill_vali();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
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

        private void Txt_Party_Leave(object sender, EventArgs e)
        {
            Txt_Party.BackColor = System.Drawing.Color.White;
            Txt_Party.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_Party.ForeColor = System.Drawing.Color.Black;
        }

        private void Txt_Party_Enter(object sender, EventArgs e)
        {
            Txt_Party.BackColor = System.Drawing.Color.AntiqueWhite;
            Txt_Party.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Txt_Party.ForeColor = System.Drawing.Color.Black;
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

        private void Txt_Party_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                    P_code_help();

                if (e.KeyCode == Keys.Escape)
                    dataGridView1.Hide();
                Txt_Party.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_billNo_Enter(object sender, EventArgs e)
        {
            txt_billNo.BackColor = System.Drawing.Color.AntiqueWhite;
            txt_billNo.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_billNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_billNo_Leave(object sender, EventArgs e)
        {
            txt_billNo.BackColor = System.Drawing.Color.White;
            txt_billNo.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt_billNo.ForeColor = System.Drawing.Color.Black;
        }

        private void txt_billNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Txt_From_Date.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowReport_date_Load(object sender, EventArgs e)
        {
            count();
            Txt_Com_Code.Text = "01";
            Txt_Com_Name.Text = "Jay Jalaram Khaman & Patra";
            txtParty_Name.Focus();
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
                        Txt_Party.Focus();
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

        private void P_Code_Validation()
        {
            try
            {
                if (Txt_Party.Text == "")
                {
                    //MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_From_Date.Focus();
                }
                else
                {

                    con.Open();
                    str = "select * from Mst_Party where Party_Code='" + Txt_Party.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtParty_Name.Text = dr["Party_Name"].ToString();
                        txt_billNo.Focus();

                        dr.Close();

                    }
                    else
                    {

                        MessageBox.Show("Enter Valid Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Txt_Party.Focus();
                    }


                } con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();

        }

        private void bill_vali()
        {

            con.Open();
            str = "select SUM(Amout) from Mst_Transaction where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                textBox1.Text = dr[""].ToString();
                dr.Close();

                Btn_Save.Show();
                btnClose.Show();
                Btn_Save.Focus();
            }
            con.Close();
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

        public void count()
        {
            string qr = "select MAX(Bill_No) from Bill_details";
            con.Open();
            SqlCommand cmd = new SqlCommand(qr, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string x = dr[0].ToString();

                if (x.ToString() == "")
                {
                    txt_billNo.Text = "1";
                }

                else
                {
                    //int x = int.Parse(dr[0].ToString());
                    int z = int.Parse(x.ToString());
                    z = z + 1;
                    txt_billNo.Text = z.ToString();
                }
            }
            else
            {

                txt_billNo.Text = "1";
            }
            con.Close();
        }
        #endregion
    }
}
