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


namespace KDE
{
    public partial class PendingDetails : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);
        string str;
        Bitmap bm;
        int i = 0;
        
        DataGridViewPrinter MyDataGridViewPrinter;

       

        public PendingDetails()
        {
            InitializeComponent();


            //RowCount = 0;
            //ColCount = 0;

            //CellValueChanged = false;
            //Ascending = false;

            //MyDataRow = null;

            //MyDataTable = new DataTable("NewTable");
            //CurrentDataGridCellLocation = new DataGridCell();

            //SummaryCols = new ArrayList();

        }
       
       //// public delegate void DataGridDisableCellHandler(object sender, DataGridDisableCellEventArgs e);

       // private int RowCount;
       // private int ColCount;
       // private int SortedColNum;

       // private bool Ascending;
       // private bool CellValueChanged;

       // private string SourceTable;

       // private DataView MyDataView;
       // private DataSet MyDataSet;
       // private DataRow MyDataRow;
       // private DataTable MyDataTable;

       // private ArrayList SummaryCols;
       // private DataGridCell CurrentDataGridCellLocation;

       // private static Brush FooterBackColor;
       // private static Brush FooterForeColor;

       // public DataSet GridDataSet
       // {
       //     set
       //     {
       //         MyDataSet = value;
       //     }
       // }

       // public ArrayList SummaryColumns
       // {
       //     get
       //     {
       //         return SummaryCols;
       //     }
       //     set
       //     {
       //         SummaryCols = value;
       //     }
       // }

       // public string DataSourceTable
       // {
       //     get
       //     {
       //         return SourceTable;
       //     }
       //     set
       //     {
       //         SourceTable = value;
       //     }
       // }

       // public static Brush FooterColor
       // {
       //     get
       //     {
       //         return FooterBackColor;
       //     }
       //     set
       //     {
       //         FooterBackColor = value;
       //     }
       // }

       // public static Brush FooterFontColor
       // {
       //     get
       //     {
       //         return FooterForeColor;
       //     }
       //     set
       //     {
       //         FooterForeColor = value;
       //     }
       // }

       // public void BindDataGrid()
       // {
       //     MyDataTable = MyDataSet.Tables[0];
       //     MyDataView = MyDataTable.DefaultView;
       //     this.DataSource = MyDataView;

       //     DataGridTableStyle TableStyle = new DataGridTableStyle();
       //     TableStyle.MappingName = DataSourceTable;

       //     // Add a Boolean data type column to the DataTable object.
       //     // You can use this column during your custom sorting.
       //     MyDataTable.Columns.Add("ID", System.Type.GetType("System.Boolean"));
       //     MyDataTable.Columns["ID"].DefaultValue = false;
       //     MyDataTable.Columns["ID"].ColumnMapping = MappingType.Hidden;
       //     ColCount = MyDataTable.Columns.Count;

       //     // Create a footer row for the DataTable object.
       //     MyDataRow = MyDataTable.NewRow();

       //     // Set the footer value as an empty string for all columns that contains string values.
       //     for (int MyIterator = 0; MyIterator < ColCount; MyIterator++)
       //     {
       //         if (MyDataTable.Columns[MyIterator].DataType.ToString() == "System.String")
       //         {
       //             MyDataRow[MyIterator] = "";
       //         }
       //     }

       //     // Add the footer row to the DataTable object.
       //     MyDataTable.Rows.Add(MyDataRow);
       //     RowCount = MyDataTable.Rows.Count;

       //     // Add a MyDataGridTextBox control to each cell of the DataGrid control.
       //     MyDataGridTextBox TempDataGridTextBox;
       //     for (int MyIterator = 0; MyIterator < ColCount - 1; MyIterator++)
       //     {
       //         TempDataGridTextBox = new MyDataGridTextBox(MyIterator);
       //         TempDataGridTextBox.HeaderText = MyDataTable.Columns[MyIterator].ColumnName;
       //         TempDataGridTextBox.MappingName = MyDataTable.Columns[MyIterator].ColumnName;
       //         TempDataGridTextBox.DataGridDisableCell += new DataGridDisableCellHandler(SetEnableValues);

       //         // Disable the default sorting feature of the DataGrid control.
       //         TableStyle.AllowSorting = false;
       //         TableStyle.GridColumnStyles.Add(TempDataGridTextBox);
       //     }

       //     this.TableStyles.Add(TableStyle);
       //     this.DataSource = MyDataView;
       //     MyDataView.ApplyDefaultSort = false;
       //     MyDataView.AllowNew = false;

       //     // Set the value of the footer cell.
       //     DataGridCell MyCell = new DataGridCell();
       //     MyCell.RowNumber = MyDataTable.Rows.Count - 1;

       //     // Calculate the value for each of the cells in the footer.
       //     string[] MyArray = new string[2];
       //     foreach (String MyString in SummaryCols)
       //     {
       //         MyArray = MyString.Split(',');
       //         MyCell.ColumnNumber = Convert.ToInt32(MyArray[0]);
       //         this[MyCell] = MyDataTable.Compute(MyArray[1], "ID is null").ToString();
       //     }

       //     // Associate the ColumnChanged event of the MyDataTable object with the corresponding event handler.
       //     this.MyDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.MyDataTable_ColumnChanged);
       // }


        private void PendingDetails_Load(object sender, EventArgs e)
        {
                    
          
        }

        private void txtParty_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
                        
            if (e.KeyChar==13)
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
                    txtParty_Code.Focus();
                    txtParty_Code.SelectAll();
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
                        Txt_From_Date.Focus();
                    }
                    else
                    {
                        MessageBox.Show("InValid Party Code","Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtParty_Code.Focus();
                        txtParty_Code.SelectAll();
                    } con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }

        private void PendingDetails_Activated(object sender, EventArgs e)
        {
            txtParty_Code.Focus();
        }
        public void SumGrid()
        {
            
                decimal sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value);
                   // sum1 += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                }
                txt_Sum.Text = sum.ToString();
                //lbl_credit.Text = sum1.ToString();

            
           
          
        }

        public void data()
        {

            str = "select SUM(Amount) from Bill_details where Party_Code='" + txtParty_Code.Text + "' and To_date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
             SqlCommand cmd = new SqlCommand(str, con);
             cmd.ExecuteNonQuery();
             SqlDataReader dr = cmd.ExecuteReader();
             dr.Read();
             txtbillamount.Text = (dr[0].ToString());
             dr.Close();
                    
        }
        public void data2()
        {

            str = "select SUM(Rs) from Payment_Details where Party_Code='" + txtParty_Code.Text + "' and Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txt_Sum.Text = (dr[0].ToString());

            dr.Close();
        }
        public void subtract()
        {
            txtpending.Text = (Convert.ToDecimal(txtbillamount.Text) - Convert.ToDecimal(txt_Sum.Text)).ToString();
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
               //str = "SELECT Bill_details.To_date as 'Bill Date',Payment_Details.Voucher_Id as 'Voucher ID',Payment_Details.Date as 'Pay. Rec. Date',Bill_details.From_date as 'Bill Date From',Bill_details.To_date as 'To Date',Payment_Details.Note as 'Pay. Rec. Note',Bill_details.Bill_No as 'Bill No',Payment_Details.Rs as 'Pay. Rec. Rs.',Bill_details.Amount as 'Bill Amount' FROM Bill_details Bill_details FULL OUTER JOIN Payment_Details ON (Payment_Details.Bill_details_ID=Bill_details.Bill_details_ID) AND (Payment_Details.Party_Code=Bill_details.Party_Code) where (Bill_details.Party_Code='" + txtParty_Code.Text + "' or Payment_Details.Party_Code='" + txtParty_Code.Text + "') and (Bill_details.To_date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' or Payment_Details.Date between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "')";
                str = "select billTo as 'Bill Date',payRecDate as 'Pay. Rec. Date',billNo as 'Bill No',payVouId as 'Pay. Vou. ID',billForm as 'Bill Date From',billTo as 'To Date',payRecNote as 'Pay. Rec. Note',payreceive as 'Pay. Rec. Rs.',billAmount as 'Bill Rs.' from Mst_Payment where partyCode='" + txtParty_Code.Text + "'  and (billTo between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' or payRecDate between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "')";
                SqlCommand cmd = new SqlCommand(str, con);
   
                SqlDataAdapter da;
                da = new SqlDataAdapter(cmd);
                DataSet ds;
                ds = new DataSet();
                con.Open();

                da.Fill(ds, "Mst_Payment");
               

                dataGridView1.DataSource = ds.Tables["Mst_Payment"];
                dataGridView1.Show();
              //  SumGrid();
                
              //  subtract();
                dataGridView1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridView1.ForeColor = System.Drawing.Color.Black;
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
                }
               
                //data();
                
                //data2();
                //subtract();
                con.Close();
                gettotal();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        private void AddARow(DataTable table)
        {
            // Use the NewRow method to create a DataRow with 
            // the table's schema.
            DataRow newRow = table.NewRow();

            // Add the row to the rows collection.
            table.Rows.Add(newRow);
        }

        protected void gettotal()
        {
            dataGridView1[0, dataGridView1.Rows.Count - 1].Value = "Total Sum";
            dataGridView1[0, dataGridView1.Rows.Count - 1].Style.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1[0, dataGridView1.Rows.Count - 1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1[0, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[1, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[2, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[3, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[4, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[5, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[6, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[7, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[7, dataGridView1.Rows.Count - 1].Style.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1[7, dataGridView1.Rows.Count - 1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1[8, dataGridView1.Rows.Count - 1].Style.BackColor = Color.LightPink;
            dataGridView1[8, dataGridView1.Rows.Count - 1].Style.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1[8, dataGridView1.Rows.Count - 1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            con.Open();
            int defval = 0;

            str = "SELECT sum(billAmount) FROM Mst_Payment where partyCode='" + txtParty_Code.Text + "' and billTo between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "' ";
            SqlCommand cmd = new SqlCommand(str, con);



            var firstColumn = cmd.ExecuteScalar();

            if (firstColumn != System.DBNull.Value)
            {
                decimal Tatolbillamt = Convert.ToDecimal(cmd.ExecuteScalar());
                dataGridView1[8, dataGridView1.Rows.Count - 1].Value = String.Format("{0}", Tatolbillamt);

            }
            else
            {
                dataGridView1[8, dataGridView1.Rows.Count - 1].Value = String.Format("{0}", defval);

            }
            
            string strr;
            strr = "SELECT sum(payreceive) FROM Mst_Payment where partyCode='" + txtParty_Code.Text + "' and payRecDate between '" + DateTime.Parse(Txt_From_Date.Text).ToString("MM/dd/yyyy") + "' and '" + DateTime.Parse(Txt_To_Date.Text).ToString("MM/dd/yyyy") + "'";
            SqlCommand cmdd = new SqlCommand(strr, con);
            var firstColumnn = cmdd.ExecuteScalar();

            if (firstColumnn != System.DBNull.Value)
            {
                decimal Tatolpayamt = Convert.ToDecimal(cmdd.ExecuteScalar());
                dataGridView1[7, dataGridView1.Rows.Count - 1].Value = String.Format("{0}", Tatolpayamt);
            }
            else
            {
                dataGridView1[7, dataGridView1.Rows.Count - 1].Value = String.Format("{0}", defval);

            }
            if (firstColumn != System.DBNull.Value && firstColumnn != System.DBNull.Value)
            {
                decimal Tatolbillamt = Convert.ToDecimal(cmd.ExecuteScalar());
                decimal Tatolpayamt = Convert.ToDecimal(cmdd.ExecuteScalar());
                decimal tatolpending = Tatolbillamt - Tatolpayamt;
                txtpending.Text = tatolpending.ToString();
            }
            else
            {
                if (firstColumn == System.DBNull.Value && firstColumnn != System.DBNull.Value)
                {
                    decimal Tatolpayamt = Convert.ToDecimal(cmdd.ExecuteScalar());
                    decimal tatolpending = Convert.ToDecimal(defval) - Tatolpayamt;
                    txtpending.Text = tatolpending.ToString();
                }
                if (firstColumn != System.DBNull.Value && firstColumnn == System.DBNull.Value)
                {
                    decimal Tatolbillamt = Convert.ToDecimal(cmd.ExecuteScalar());
                    decimal tatolpending = Tatolbillamt - Convert.ToDecimal(defval);
                    txtpending.Text = tatolpending.ToString();
                }
               
            }
            

            con.Close();
            con.Dispose();
            cmd.Dispose();
            
            
           
            
            //int index = this.dataGridView1.Rows.Count;
            //index++;
            //this.dataGridView1.Rows.Add();
            //dataGridView1[7, dataGridView1.Rows.Count - 2].Value = String.Format("{0}", Tatolpayamt);
            //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Style.BackColor = Color.Yellow;
            ////dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Red;
        }
        //private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        //{
        //    switch ((int)(e.Item.ItemType))
        //    {

        //        case (int)ListItemType.Item:
        //        case (int)ListItemType.AlternatingItem:
        //            //Calculate total for the field of each row and alternating row.
        //            myTotal += Convert.ToDouble(e.Item.Cells2.Text);
        //            //Format the data, and then align the text of each cell to the right.
        //            e.Item.Cells2.Text = Convert.ToDouble(e.Item.Cells2.Text).ToString("##,##0.00");
        //            e.Item.Cells2.Attributes.Add("align", "right");
        //            break;
        //        case (int)ListItemType.Footer:
        //            //Use the footer to display the summary row.
        //            e.Item.Cells1.Text = "Total Sales";
        //            e.Item.Cells1.Attributes.Add("align", "left");
        //            e.Item.Cells2.Attributes.Add("align", "right");
        //            e.Item.Cells2.Text = myTotal.ToString("c");
        //            break;

        //    }

        //}
        private void txtParty_Code_Enter(object sender, EventArgs e)
        {
            try
            {
                txtParty_Code.BackColor = System.Drawing.Color.AntiqueWhite;
                txtParty_Code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtParty_Code.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void txtParty_Code_Leave(object sender, EventArgs e)
        {
            try
            {
                txtParty_Code.BackColor = System.Drawing.Color.White;
                txtParty_Code.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtParty_Code.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void Txt_From_Date_Enter(object sender, EventArgs e)
        {
            try
            {
                Txt_From_Date.BackColor = System.Drawing.Color.AntiqueWhite;
                Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_From_Date.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void Txt_To_Date_Enter(object sender, EventArgs e)
        {
            try
            {
                Txt_To_Date.BackColor = System.Drawing.Color.AntiqueWhite;
                Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_To_Date.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void Txt_From_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                Txt_From_Date.BackColor = System.Drawing.Color.White;
                Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_From_Date.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void Txt_To_Date_Leave(object sender, EventArgs e)
        {
            try
            {
                Txt_To_Date.BackColor = System.Drawing.Color.White;
                Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Txt_To_Date.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    SolidBrush br = new SolidBrush(Color.Beige);
            //    e.Graphics.FillRectangle(br, e.CellBounds);
            //    e.PaintContent(e.ClipBounds);
            //    e.Handled = true;
            //}
            //else
            //{
            //    SolidBrush br = new SolidBrush(Color.Crimson);
            //    e.Graphics.FillRectangle(br, e.CellBounds);
            //    e.PaintContent(e.ClipBounds);
            //    e.Handled = true;

            //}
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;

           
            
        }
        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = txtParty_Name.Text;
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Do you want the report to be centered on the page", "Party Account - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, printDocument1, true, true, txtParty_Name.Text, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, printDocument1, false, true, txtParty_Name.Text, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = printDocument1;
                MyPrintPreviewDialog.ShowDialog();
            }
        }
        //private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
        //    {
        //        if (dataGridView1[2, i].Value != DBNull.Value)
        //            sum += (int)dataGridView1[2, i].Value;
        //    }
        //    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = sum;
        //}

       
    }
}
