using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms.Design;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System.IO;



namespace KDE
{
    
    public partial class frmRptPaymetViewer : Form
    {
        frmRptPaymet formlot = new frmRptPaymet();

        public frmRptPaymetViewer()
        {
            InitializeComponent();
            
        }

       
        public string C_Code
        {
            get
            {
                return formlot.Txt_Com_Code.Text;

            }
            set
            {
                formlot.Txt_Com_Code.Text = value;

            }
        }

     

        public string P_Code
        {
            get
            {
                return formlot.Txt_Party.Text;

            }
            set
            {
                formlot.Txt_Party.Text = value;

            }
        }
      
        public string F_Date
        {
            get
            {
                return formlot.Txt_From_Date.Text;

            }
            set
            {
                formlot.Txt_From_Date.Text = value;

            }
        }
        public string T_Date
        {
            get
            {
                return formlot.Txt_To_Date.Text;

            }
            set
            {
                formlot.Txt_To_Date.Text = value;

            }
        }
        //public string BillNo
        //{
        //    get
        //    {
        //        return formlot.txt_billNo.Text;

        //    }
        //    set
        //    {
        //        formlot.txt_billNo.Text = value;

        //    }
        //}
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                if (formlot.Txt_Party.Text != "")
                {
                        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
                        string str;
                        con.Open();
                        str = "SELECT * From Bill_details Bill_details FULL OUTER JOIN Payment_Details ON (Payment_Details.Bill_details_ID=Bill_details.Bill_details_ID) AND (Payment_Details.Party_Code=Bill_details.Party_Code) where (Payment_Details.Party_Code='" + formlot.Txt_Party.Text + "' or Bill_details.Party_Code='" + formlot.Txt_Party.Text + "') and (Payment_Details.Date between'" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' or Bill_details.To_date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "') ";
                        SqlDataAdapter da = new SqlDataAdapter(str, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                       // da.Fill(ds, "Payment_Details");
                        //str = "select * from Payment_Details where Party_Code='" + formlot.Txt_Party.Text + "'AND Date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                        //SqlDataAdapter daa = new SqlDataAdapter(str, con);
                        //daa.Fill(ds, "Payment_Details");


                    ReportDocument rpt = new ReportDocument();


                    String report = Directory.GetCurrentDirectory();
                    int index = report.ToLower().IndexOf("bin");
                    if (index >= 0)
                    {
                        report = report.Substring(0, index);
                    }
                    report = @"Report\\PaymentDetails.rpt";
                    rpt.Load(report);


                    //TextObject billno = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text3"];
                    //billno.Text = formlot.txt_billNo.Text;
                    //TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text13"];
                    //srtdate.Text = formlot.Txt_From_Date.Text;
                    //TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
                    //todate.Text = formlot.Txt_To_Date.Text;

                    rpt.SetDatabaseLogon("sa", "appin@123");
                    rpt.SetDataSource(ds.Tables);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                    con.Close();
                }
                if (formlot.Txt_Party.Text == "")
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
                    string str;
                    con.Open();
                    str = "select * from Bill_details where Com_Code='" + formlot.Txt_Com_Code.Text + "' AND To_date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Bill_details");

                    str = "select * from Payment_Details where Date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                    SqlDataAdapter daa = new SqlDataAdapter(str, con);
                    daa.Fill(ds, "Payment_Details");

                    ReportDocument rpt = new ReportDocument();


                    String report = Directory.GetCurrentDirectory();
                    int index = report.ToLower().IndexOf("bin");
                    if (index >= 0)
                    {
                        report = report.Substring(0, index);
                    }
                    report = @"Report\\Party_account.rpt";
                    rpt.Load(report);


                    //TextObject billno = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text3"];
                    //billno.Text = formlot.txt_billNo.Text;
                    //TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text13"];
                    //srtdate.Text = formlot.Txt_From_Date.Text;
                    //TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];
                    //todate.Text = formlot.Txt_To_Date.Text;

                    rpt.SetDatabaseLogon("sa", "appin@123");
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


    }
}
