using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace KDE
{
    public partial class frmPurchasePaymentDetails : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KDEConnectionString"].ConnectionString);

        #region " Data Members "
        string str;
        #endregion

        #region " Constructors "
        public frmPurchasePaymentDetails()
        {
            InitializeComponent();
        }
        #endregion

        #region " Events "
        private void txtParty_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    P_Code_Validation();

                CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                txtParty_Code.Text = textInfo.ToTitleCase(txtParty_Code.Text);
                txtParty_Code.SelectionStart = txtParty_Code.Text.Length;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
        }

        private void Payment_Details_Load(object sender, EventArgs e)
        {
            txtParty_Code.Focus();
            count();
            Fillgrid();
            fillcombo();
            thedate();
        }

        private void txtVoucher_Id_Enter(object sender, EventArgs e)
        {
            try
            {
                txtVoucher_Id.BackColor = System.Drawing.Color.AntiqueWhite;
                txtVoucher_Id.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtVoucher_Id.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtVoucher_Id_Leave(object sender, EventArgs e)
        {
            try
            {
                txtVoucher_Id.BackColor = System.Drawing.Color.White;
                txtVoucher_Id.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtVoucher_Id.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtVoucher_Id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                V_ID_Val();
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = System.Drawing.Color.AntiqueWhite;
                txtDate.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtDate.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDate.BackColor = System.Drawing.Color.White;
                txtDate.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtDate.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmbType.Focus();
        }

        private void cmbType_Enter(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = System.Drawing.Color.AntiqueWhite;
                cmbType.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                cmbType.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbType_Leave(object sender, EventArgs e)
        {
            try
            {
                cmbType.BackColor = System.Drawing.Color.White;
                cmbType.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                cmbType.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtRs.Focus();
        }

        private void txtRs_Enter(object sender, EventArgs e)
        {
            try
            {
                txtRs.BackColor = System.Drawing.Color.AntiqueWhite;
                txtRs.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRs.ForeColor = System.Drawing.Color.Black;
                txtNote.SelectionStart = txtNote.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtRs_Leave(object sender, EventArgs e)
        {

            try
            {
                txtRs.BackColor = System.Drawing.Color.White;
                txtRs.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtRs.ForeColor = System.Drawing.Color.Black;
                txtNote.SelectionStart = txtNote.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtRs_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)

                    if (txtRs.Text == "")
                    {
                        MessageBox.Show("Enter Rs....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRs.Focus();
                    }
                    else
                    {
                        txtNote.SelectionStart = txtNote.Text.Length;
                        txtNote.Focus();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNote_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNote.BackColor = System.Drawing.Color.AntiqueWhite;
                txtNote.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtNote.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNote.BackColor = System.Drawing.Color.White;
                txtNote.Font = new System.Drawing.Font("Verdana", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtNote.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNote_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtNote.Text = textInfo.ToTitleCase(txtNote.Text);
            txtNote.SelectionStart = txtNote.Text.Length;
            
            if (e.KeyChar == 13)
                data_val();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtParty_Code.Text == "")
                {
                    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtParty_Code.Focus();
                }
                else if (txtVoucher_Id.Text == "")
                {
                    MessageBox.Show("Enter Voucher_ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVoucher_Id.Focus();
                }
                else if (txtDate.Text == "  /  /")
                {
                    MessageBox.Show("Enter Date....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDate.Focus();
                }
                else if (txtRs.Text == "")
                {
                    MessageBox.Show("Enter Rs....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRs.Focus();
                }
                else if (cmbType.Text == "")
                {
                    MessageBox.Show("Enter Payment Type....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbType.Focus();
                }
                else
                {
                    con.Open();
                    str = "insert into Mst_Purchasepayment(Party_Code,Party_Name,Voucher_Id,Date,Type,Rs,Note) values('" + txtParty_Code.Text + "','" + txtParty_Name.Text + "','" + txtVoucher_Id.Text + "','" + DateTime.Parse(txtDate.Text).ToString("MM/dd/yyyy") + "', '" + cmbType.GetItemText(cmbType.SelectedItem) + "', " + txtRs.Text + ", '" + txtNote.Text + "') ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();

                    string str1 = "insert into Trn_PurchaseSummary(Party_Code,Party_Name,PaymentVou_ID,PaymentRecDate,Type,PaymentRecAmount,PaymentRecNotes) values('" + txtParty_Code.Text + "','" + txtParty_Name.Text + "','" + txtVoucher_Id.Text + "','" + DateTime.Parse(txtDate.Text).ToString("MM/dd/yyyy") + "', '" + cmbType.GetItemText(cmbType.SelectedItem) + "', " + txtRs.Text + ",'" + txtNote.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(str1, con);
                    cmd1.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Record Saved Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    Fillgrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtParty_Code.Text == "")
                {
                    MessageBox.Show("Enter Party Code....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtParty_Code.Focus();
                }
                else if (txtVoucher_Id.Text == "")
                {
                    MessageBox.Show("Enter Voucher_ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVoucher_Id.Focus();
                }
                else if (cmbType.Text == "")
                {
                    MessageBox.Show("Enter Payment Type....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbType.Focus();
                }
                else
                {
                    txtNote.SelectionStart = txtNote.Text.Length;
                    con.Open();
                    str = "update Mst_Purchasepayment set Party_Name='" + txtParty_Name.Text + "', Date='" + DateTime.Parse(txtDate.Text).ToString("MM/dd/yyyy") + "',Rs=" + txtRs.Text + ", Note='" + txtNote.Text + "', Type = '" + cmbType.GetItemText(cmbType.SelectedItem) + "' where Party_Code='" + txtParty_Code.Text + "' and Voucher_Id ='" + txtVoucher_Id.Text + "'   ";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    string str1 = "update Trn_PurchaseSummary set Party_Name = '" + txtParty_Name.Text + "', PaymentRecDate = '" + DateTime.Parse(txtDate.Text).ToString("MM/dd/yyyy") + "', PaymentRecAmount = " + txtRs.Text + ", PaymentRecNotes = '" + txtNote.Text + "', Type = '" + cmbType.GetItemText(cmbType.SelectedItem) + "' where Party_Code ='" + txtParty_Code.Text + "' and PaymentVou_ID = '" + txtVoucher_Id.Text + "'";
                    SqlCommand cmdD = new SqlCommand(str1, con);
                    cmdD.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Record Updated Successfully....!!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                    Fillgrid();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    txtVoucher_Id.Text = row.Cells["ID"].Value.ToString();
                    txtParty_Code.Text = row.Cells["PartyCode"].Value.ToString();
                    txtParty_Name.Text = row.Cells["PartyName"].Value.ToString();
                    txtDate.Text = row.Cells["Date"].Value.ToString();
                    cmbType.Text = row.Cells["Type"].Value.ToString();
                    txtRs.Text = row.Cells["Rs"].Value.ToString();
                    txtNote.Text = row.Cells["Note"].Value.ToString();
                    btn_save.Enabled = false;
                    btn_update.Enabled = true;
                    txtParty_Code.Focus();
                    txtParty_Code.SelectionStart = txtParty_Code.Text.Length;
                    txtNote.SelectionStart = txtNote.Text.Length;
                    txtVoucher_Id.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
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
                    DialogResult result;
                    result = MessageBox.Show("Are you sure you want to Delete this Payment Detail ??", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        con.Open();
                        str = "delete from Mst_Purchasepayment where Party_Code='" + txtParty_Code.Text + "' and Voucher_Id='" + txtVoucher_Id.Text + "' ";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.ExecuteNonQuery();
                        string str1 = "delete from Trn_PurchaseSummary where Party_Code ='" + txtParty_Code.Text + "' and PaymentVou_ID = '" + txtVoucher_Id.Text + "' ";
                        SqlCommand cmdd = new SqlCommand(str1, con);
                        cmdd.ExecuteNonQuery();

                        con.Close();
                        MessageBox.Show("Record Deleted Successfully....!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clear();
                        count();
                        Fillgrid();


                    }

                    if (result == DialogResult.No)
                    {
                        txtParty_Code.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            clear();
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
                    str = "select * from mst_purchaseparty where Party_Code='" + txtParty_Code.Text + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtParty_Name.Text = dr["Party_Name"].ToString();
                        txtVoucher_Id.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Party Code", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtParty_Code.Focus();
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

        private void thedate()
        {
            try
            {
                DateTime thedate;
                thedate = DateTime.Today;
                txtDate.Text = thedate.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void count()
        {
            str = "select MAX(Voucher_Id) from Mst_Purchasepayment";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string x = dr[0].ToString();

                if (x.ToString() == "")
                {
                    txtVoucher_Id.Text = "1";
                }

                else
                {
                    //int x = int.Parse(dr[0].ToString());
                    int z = int.Parse(x.ToString());
                    z = z + 1;
                    txtVoucher_Id.Text = z.ToString();
                }
            }
            else
            {
                txtVoucher_Id.Text = "1";
            }
            con.Close();
        }

        private void V_ID_Val()
        {
            try
            {
                if (txtVoucher_Id.Text == "")
                {
                    MessageBox.Show("Enter Voucher_ID....!!!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtVoucher_Id.Focus();
                }
                else
                {
                    con.Open();
                    str = "select * from Mst_Purchasepayment where Voucher_Id=" + txtVoucher_Id.Text + "";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        dr.Read();
                        txtParty_Code.Text = dr["Party_Code"].ToString();
                        txtParty_Name.Text = dr["Party_Name"].ToString();
                        txtDate.Text = dr["Date"].ToString();
                        txtRs.Text = dr["Rs"].ToString();
                        txtNote.Text = dr["Note"].ToString();
                        txtDate.Focus();
                        btn_save.Enabled = false;
                        txtNote.SelectionStart = txtNote.Text.Length;
                    }
                    else
                    {
                        btn_save.Enabled = true;
                        txtDate.Focus();

                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            } con.Close();
        }

        private void data_val()
        {
            try
            {
                con.Open();
                str = "select * from Mst_Purchasepayment where Party_Code='" + txtParty_Code.Text + "' and Voucher_Id='" + txtVoucher_Id.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();

                    btn_update.Enabled = true;
                    btn_update.Focus();
                    txtNote.SelectionStart = txtNote.Text.Length;
                }
                else
                {
                    btn_save.Enabled = true;
                    btn_save.Focus();
                    btn_update.Enabled = false;
                } 
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } con.Close();
        }

        private void clear()
        {
            txtParty_Code.Text = string.Empty;
            txtParty_Name.Text = string.Empty;
            txtVoucher_Id.Text = string.Empty;
            txtDate.Text = string.Empty;
            cmbType.SelectedIndex = -1;
            txtRs.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtParty_Code.Focus();
            txtVoucher_Id.Enabled = true;
            thedate();
            count();
        }

        private void Fillgrid()
        {
            try
            {
                con.Open();
                dataGridView1.ForeColor = Color.Black;
                str = "select Voucher_Id as ID, Party_Code as PartyCode, Date, Rs, Type, Party_Name as PartyName, Note from Mst_Purchasepayment";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Mst_Purchasepayment");
                dataGridView1.DataSource = ds.Tables["Mst_Purchasepayment"];
                dataGridView1.Show();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        public void fillcombo()
        {
            try
            {
                DataTable dtbDetail = new DataTable();
                dtbDetail.Columns.Add("Type");
                dtbDetail.Rows.Add("Rs.");
                dtbDetail.Rows.Add("Cheque");
                cmbType.DataSource = dtbDetail;
                cmbType.ValueMember = "Type";
                cmbType.DisplayMember = "Type";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
