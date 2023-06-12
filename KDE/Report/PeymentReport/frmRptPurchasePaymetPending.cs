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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;

namespace KDE
{
    public partial class frmRptPurchasePaymetPending : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
        string str;

        public frmRptPurchasePaymetPending()
        {
           
            InitializeComponent();
        }

        private void txtParty_Code_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                P_Code_Validation();
            }
        }

        private void P_Code_Validation()
        {
            try
            {
                if (txtParty_Code.Text == "")
                {
                    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_From_Date.Focus();
                    txtParty_Code.SelectAll();
                }
                else
                {
                    con.Open();
                    str = "select * from Mst_PurchaseParty where Party_Code='" + txtParty_Code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        label1.Text = dr["Party_Name"].ToString();
                        label1.Show();
                        Txt_From_Date.Focus();
                    }
                    else
                    {
                        MessageBox.Show("InValid Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtParty_Code.Focus();
                        txtParty_Code.SelectAll();
                    } 
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }

        private void Txt_From_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Txt_To_Date.Focus();
        }

        private void Txt_To_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                Btn_Save.Focus();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtParty_Code.Text!="" && Txt_From_Date.Text!="  /  /" && Txt_To_Date.Text!="  /  /")
                {
                    crystalReportViewer1.Show();
                    con.Open();
                    str = "SELECT * From trn_purchasesummary where Party_Code ='" + txtParty_Code.Text + "' and (Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' or PaymentRecDate between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "')  ORDER BY Party_Code ";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "trn_purchasesummary");
                    ReportDocument rpt = new ReportDocument();
                    String report = Directory.GetCurrentDirectory();
                    int index = report.ToLower().IndexOf("bin");
                    if (index >= 0)
                    {
                        report = report.Substring(0, index);
                    }
                    report = @"Report\PurchasePaymentDetails.rpt";
                    rpt.Load(report);
                    TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
                    srtdate.Text = Txt_From_Date.Text;
                    TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
                    todate.Text = Txt_To_Date.Text;
                    crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rpt.SetDatabaseLogon("sa", "appin@123");
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                    con.Close();
                }
                //else if (txtParty_Code.Text != "" && Txt_From_Date.Text == "  /  /" && Txt_To_Date.Text == "  /  /")
                //{
                //    crystalReportViewer1.Show();
                //    con.Open();
                //    str = "SELECT * From Mst_Payment where partyCode='" + txtParty_Code.Text + "'  ORDER BY partyCode ";
                //    SqlDataAdapter da = new SqlDataAdapter(str, con);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds, "Mst_Payment");
                //    ReportDocument rpt = new ReportDocument();
                //    String report = Directory.GetCurrentDirectory();
                //    int index = report.ToLower().IndexOf("bin");
                //    if (index >= 0)
                //    {
                //        report = report.Substring(0, index);
                //    }
                //    report = @"Report\PaymentDetails.rpt";
                //    rpt.Load(report);
                //    TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
                //    srtdate.Text = Txt_From_Date.Text;
                //    TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
                //    todate.Text = Txt_To_Date.Text;
                //    crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //     rpt.SetDatabaseLogon("sa", "appin@123");
                //    rpt.SetDataSource(ds);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();


                //    con.Close();
                //}
                //else if (txtParty_Code.Text == "" && Txt_From_Date.Text != "  /  /" && Txt_To_Date.Text != "  /  /")
                //{
                //    crystalReportViewer1.Show();
                //    con.Open();
                //    str = "SELECT * From Mst_Payment where (billTo between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' or payRecDate between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "')  ORDER BY partyCode ";
                //    SqlDataAdapter da = new SqlDataAdapter(str, con);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds, "Mst_Payment");
                //    ReportDocument rpt = new ReportDocument();
                //    String report = Directory.GetCurrentDirectory();
                //    int index = report.ToLower().IndexOf("bin");
                //    if (index >= 0)
                //    {
                //        report = report.Substring(0, index);
                //    }
                //    report = @"Report\AllPaymentDetails.rpt";
                //    rpt.Load(report);
                //    crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //    //rpt.DataDefinition.FormulaFields["fromdate"].Text="'"+Txt_From_Date.Text+"'";
                //    //TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text4"];
                //    //srtdate.Text = Txt_From_Date.Text;
                //    //TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
                //    //todate.Text = Txt_To_Date.Text;

                //     rpt.SetDatabaseLogon("sa", "appin@123");
                //    rpt.SetDataSource(ds);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();


                //    con.Close();
                //}
                //else
                //{
                //    crystalReportViewer1.Show();
                //    con.Open();
                //    str = "SELECT * From Mst_Payment ORDER BY partyCode";
                //    SqlDataAdapter da = new SqlDataAdapter(str, con);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds, "Mst_Payment");
                //    ReportDocument rpt = new ReportDocument();
                //    String report = Directory.GetCurrentDirectory();
                //    int index = report.ToLower().IndexOf("bin");
                //    if (index >= 0)
                //    {
                //        report = report.Substring(0, index);
                //    }
                //    report = @"Report\AllPaymentDetails.rpt";
                //    rpt.Load(report);
                //    //rpt.DataDefinition.FormulaFields["fromdate*"].Text = "'" + Txt_From_Date.Text + "'";

                //    //TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text4"];
                //    //srtdate.Text = Txt_From_Date.Text;
                //    //TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
                //    //todate.Text = Txt_To_Date.Text;

                //    crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                //     rpt.SetDatabaseLogon("sa", "appin@123");
                //    rpt.SetDataSource(ds);
                //    crystalReportViewer1.ReportSource = rpt;
                //    crystalReportViewer1.Refresh();
                //}
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
    }
}
