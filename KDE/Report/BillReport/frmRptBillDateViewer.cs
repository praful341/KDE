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
using System.Configuration;

namespace KDE
{
    public partial class frmRptBillDateViewer : Form
    {
        frmRptBillDate formlot = new frmRptBillDate();

        public frmRptBillDateViewer()
        {
            InitializeComponent();
            
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                if (formlot.Txt_Party.Text != "")
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
                    string str;
                    con.Open();
                    str = "select * from Trn_Items where Com_Code='" + formlot.Txt_Com_Code.Text + "' AND Party_Code='" + formlot.Txt_Party.Text + "'AND Date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Trn_Items");

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
                    billno.Text = formlot.txt_billNo.Text;
                    TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                    srtdate.Text = formlot.Txt_From_Date.Text;
                    TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                    todate.Text = formlot.Txt_To_Date.Text;
                    TextObject penamt = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text6"];
                    penamt.Text = formlot.txt_pen_amt.Text;
                    TextObject totamt = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];
                    totamt.Text = formlot.txtTot_Amt.Text;

                    int numToward = Convert.ToInt32(formlot.txtTot_Amt.Text);
                    TextObject totamtWord = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
                    totamtWord.Text = NumberToWords(numToward) + " Only ";

                    rpt.SetDatabaseLogon("sa", "appin@123");
                    rpt.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                    con.Close();
                }
                if (formlot.Txt_Party.Text == "")
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
                    string str;
                    con.Open();
                    str = "select * from Trn_Items where Com_Code='" + formlot.Txt_Com_Code.Text + "' AND Date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                    SqlDataAdapter da = new SqlDataAdapter(str, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Trn_Items");

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
                    billno.Text = formlot.txt_billNo.Text;
                    TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                    srtdate.Text = formlot.Txt_From_Date.Text;
                    TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                    todate.Text = formlot.Txt_To_Date.Text;
                    TextObject penamt = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text6"];
                    penamt.Text = formlot.txt_pen_amt.Text;
                    TextObject totamt = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];
                    totamt.Text = formlot.txtTot_Amt.Text;

                    int numToward = Convert.ToInt32(formlot.txtTot_Amt.Text);
                    TextObject totamtWord = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
                    totamtWord.Text = NumberToWords(numToward) + " Only "; 

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

        public string p_amt
        {
            get
            {
                return formlot.txt_pen_amt.Text;

            }
            set
            {
                formlot.txt_pen_amt.Text = value;

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
        
        public string BillNo
        {
            get
            {
                return formlot.txt_billNo.Text;

            }
            set
            {
                formlot.txt_billNo.Text = value;

            }
        }
        
        public string Tot_Amt
        {
            get
            {
                return formlot.txtTot_Amt.Text;

            }
            set
            {
                formlot.txtTot_Amt.Text = value;

            }
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return "Minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " Billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " Million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
