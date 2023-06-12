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
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms.Design;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;
using System.Configuration;

namespace KDE
{
    public partial class frmRptDuplicateBill : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        string str;
        #endregion

        #region " Constructors "
        public frmRptDuplicateBill()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            txtbillno.Focus();
        }

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
        }

        private void txtParty_Code_MouseClick(object sender, MouseEventArgs e)
        {
            txtParty_Code.SelectAll();
            txtbillno.SelectAll();
        }

        private void txtParty_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                P_Code_Validation();
            }
        }

        private void txtbillno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    if (txtbillno.Text == "")
                    {
                        MessageBox.Show("Enter Bill No", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtbillno.Focus();
                    }
                    else
                    {
                        con.Open();
                        str = "select * from Bill_details where Bill_No='" + txtbillno.Text + "'";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            Txt_From_Date.Text = Convert.ToDateTime(dr["From_date"]).ToString("dd/MM/yyyy");
                            Txt_To_Date.Text = Convert.ToDateTime(dr["To_date"]).ToString("dd/MM/yyyy");
                            txt_pen_amt.Text = dr["For_out"].ToString();
                            txtTot_Amt.Text = dr["Total_amt"].ToString();
                            txtParty_Code.Text = dr["Party_Code"].ToString();
                            txtParty_Name.Text = dr["Party_Name"].ToString();
                            Btn_Save.Focus();

                            dr.Close();

                        }
                        else
                        {

                            MessageBox.Show("Invalid Bill No....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtbillno.Focus();
                            txtbillno.SelectAll();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            if (txtParty_Code.Text != "")
            {
                con.Open();

                //str = "SELECT sum(billAmount) FROM  Mst_Payment where partyCode='" + Txt_Party.Text + "' ";
                //SqlCommand cmd = new SqlCommand(str, con);
                //var billamtck = cmd.ExecuteScalar();
                //if (billamtck != System.DBNull.Value)
                //{
                //    Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());

                //}
                //else
                //{
                //    Decimal billamount = 0;
                //}
                //string str1;
                //str1 = "SELECT sum(payreceive) FROM  Mst_Payment where partyCode='" + Txt_Party.Text + "' ";
                //SqlCommand cmd1 = new SqlCommand(str1, con);
                //var payamtck = cmd1.ExecuteScalar();
                //if (payamtck != System.DBNull.Value)
                //{
                //    Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                //}
                //else
                //{
                //    Decimal payamount = 0;
                //}

                //string str2;
                //str2 = "select SUM(Amout) from Mst_Transaction where Com_Code='" + Txt_Com_Code.Text + "'  AND Party_Code='" + Txt_Party.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                //SqlCommand cmd2 = new SqlCommand(str2, con);
                //var totamt = cmd2.ExecuteScalar();
                //if (totamt != System.DBNull.Value)
                //{
                //    int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                //}
                //else
                //{
                //    int totamt1 = 0;
                //}


                //if (billamtck != System.DBNull.Value && payamtck != System.DBNull.Value && totamt != System.DBNull.Value)
                //{
                //    Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                //    Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                //    int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());

                //    Decimal penbal = billamount - payamount;

                //    txt_pen_amt.Text = penbal.ToString();
                //    Decimal sumamt = penbal + totamt1;
                //    txtTot_Amt.Text = sumamt.ToString("0");

                //}

                //else
                //{
                //    if (billamtck != System.DBNull.Value && payamtck == System.DBNull.Value && totamt != System.DBNull.Value)
                //    {
                //        Decimal billamount = Convert.ToDecimal(cmd.ExecuteScalar());
                //        int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                //        Decimal penbal = billamount - 0;
                //        Decimal sumamt = penbal + totamt1;
                //        txt_pen_amt.Text = penbal.ToString();
                //        txtTot_Amt.Text = sumamt.ToString("0");

                //    }

                //    else
                //    {
                //        if (billamtck == System.DBNull.Value && payamtck != System.DBNull.Value && totamt != System.DBNull.Value)
                //        {
                //            Decimal payamount = Convert.ToDecimal(cmd1.ExecuteScalar());
                //            Decimal penbal = 0 - payamount;
                //            txt_pen_amt.Text = penbal.ToString();
                //            Decimal sumamt = 0 + penbal;
                //            txtTot_Amt.Text = sumamt.ToString("0");
                //        }

                //        else
                //        {
                //            if (totamt != System.DBNull.Value)
                //            {
                //                txt_pen_amt.Text = "0";
                //                int totamt1 = Convert.ToInt32(cmd2.ExecuteScalar());
                //                Decimal sumamt = 0 + totamt1;
                //                txtTot_Amt.Text = sumamt.ToString("0");
                //            }
                //            else
                //            {
                //                txt_pen_amt.Text = "0";
                //            }


                //        }

                //    }
                //}

                //if (textBox1.Text != "")
                //{
                //    con.Close();
                //    con.Open();
                //    string strr = "select * from Bill_details where Bill_No='" + txt_billNo.Text + "'";
                //    SqlCommand cmdd = new SqlCommand(strr, con);
                //    cmdd.ExecuteNonQuery();
                //    SqlDataReader dr = cmdd.ExecuteReader();

                //    if (dr.HasRows)
                //    {
                //        dr.Read();
                //        dr.Close();
                //        con.Close();
                //    }
                //    else
                //    {

                //        DialogResult result;
                //        result = MessageBox.Show("Are you want to Save this Bill..?", "Bill Save Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (result == DialogResult.Yes)
                //        {

                //            ShowMyDialogBox();

                //            if (textBox2.Text == "123")
                //            {
                //                con.Close();
                //                con.Open();
                //                str = "insert into Bill_details(Com_Code,Com_Name,Party_Code,Party_Name,Bill_No,From_date,To_date,Amount,For_out,Total_amt) values('" + Txt_Com_Code.Text + "','" + Txt_Com_Name.Text + "','" + Txt_Party.Text + "','" + txtParty_Name.Text + "'," + txt_billNo.Text + ",'" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "'," + textBox1.Text + ",'" + txt_pen_amt.Text + "','" + txtTot_Amt.Text + "')";
                //                cmd = new SqlCommand(str, con);
                //                cmd.ExecuteNonQuery();
                //                string strt = "insert into Mst_Payment(partyCode,partyName,billNo,billForm,billTo,billAmount) values('" + Txt_Party.Text + "','" + txtParty_Name.Text + "'," + txt_billNo.Text + ",'" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "','" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "'," + textBox1.Text + ")";
                //                cmd1 = new SqlCommand(strt, con);
                //                cmd1.ExecuteNonQuery();

                //                con.Close();

                //            }
                //        }
                //    }
                //    con.Close();

                //}

                con.Close();
                con.Open();
                str = "select * from Trn_Items where Party_Code='" + txtParty_Code.Text + "' AND Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Trn_Items");

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Data Found...!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtParty_Code.Focus();
                }
                else
                {
                    ReportDocument rpt = new ReportDocument();


                    String report = Directory.GetCurrentDirectory();
                    int index = report.ToLower().IndexOf("bin");
                    if (index >= 0)
                    {
                        report = report.Substring(0, index);
                    }
                    report = @"Report\\Final_bill.rpt";
                    rpt.Load(report);
                    TextObject billno = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text3"];
                    billno.Text = txtbillno.Text;
                    TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                    srtdate.Text = Txt_From_Date.Text;
                    TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                    todate.Text = Txt_To_Date.Text;
                    TextObject penamt = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text6"];
                    penamt.Text = txt_pen_amt.Text;
                    TextObject totamt = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];
                    totamt.Text = txtTot_Amt.Text;

                    //rpt.SetDatabaseLogon("sa", "admin@123");
                    //rpt.SetDataSource(ds);
                    //crystalReportViewer1.ReportSource = rpt;
                    //crystalReportViewer1.Refresh();
                    //crystalReportViewer1.Show();

                    rpt.SetDatabaseLogon("sa", "appin@123");
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();


                }
                con.Close();
            }
           

        }

        private void txtbillno_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtbillno.Text = "";
            txtParty_Code.Text = "";
            txtParty_Name.Text = "";
            Txt_From_Date.Text = "";
            Txt_To_Date.Text = "";
            txt_pen_amt.Text = "";
            txtTot_Amt.Text = "";
            txtbillno.Focus();
            crystalReportViewer1.Hide();
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
