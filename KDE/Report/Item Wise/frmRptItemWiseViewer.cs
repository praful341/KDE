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
    
    public partial class frmRptItemWiseViewer : Form
    {
        frmRptItemWise formlot = new frmRptItemWise();

        public frmRptItemWiseViewer()
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
     
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
                string str;
                con.Open();
                str = "select * from Mst_Transaction where Com_Code='" + formlot.Txt_Com_Code.Text + "' AND Party_Code='" + formlot.Txt_Party.Text + "'AND Date between '" + DateTime.Parse(formlot.Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(formlot.Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Transaction");

                ConnectionInfo myconnection = new ConnectionInfo();
                ReportDocument rpt = new ReportDocument();
               
                String report = Directory.GetCurrentDirectory();
                int index = report.ToLower().IndexOf("bin");
                if (index >= 0)
                {
                    report = report.Substring(0, index);
                }
                report = @"Report\\CrystalReport1.rpt";
                rpt.Load(report);
                //TextObject billno = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text3"];
                //billno.Text = formlot.txt_billNo.Text;
                TextObject srtdate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text4"];
                srtdate.Text = formlot.Txt_From_Date.Text;
                TextObject todate = (TextObject)rpt.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];
                todate.Text = formlot.Txt_To_Date.Text;
               

                rpt.SetDatabaseLogon("sa", "appin@123");
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
              

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
