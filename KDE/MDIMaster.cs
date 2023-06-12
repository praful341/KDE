using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDE
{
    public partial class MDIMaster : Form
    {
        #region " Data Members "
        private int childFormNumber = 0;
        SystemMenuManager menuManager;
        MdiClient client;
        #endregion

        #region " Constructors "
        public MDIMaster()
        {
            InitializeComponent();
            timer2.Enabled = true;
            timer2.Interval = 1000;
            this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            IsMdiContainer = true;
            client = Controls.OfType<MdiClient>().First();
            client.GotFocus += (s, e) =>
            {
                if (!MdiChildren.Any(x => x.Visible)) client.SendToBack();
            };
        }
        #endregion

        #region " Events "
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompany obj = new frmCompany { MdiParent = this };
            showform(obj);


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null && this.MdiChildren.Length == 0)
            {
                DialogResult result;
                result = MessageBox.Show("Are you sure you want to Exit?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {

                }
            }
            else
            {
                this.ActiveMdiChild.Close();
            }

        }

        private void nvPiTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParty obj = new frmParty { MdiParent = this };
            showform(obj);

        }

        private void piTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPurchaseParty obj = new frmPurchaseParty { MdiParent = this };
            showform(obj);
        }

        private void nvAieTmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItem obj = new frmItem { MdiParent = this };
            showform(obj);
        }

        private void vciNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemDetails obj = new frmItemDetails { MdiParent = this };
            //frmItemDetailsNew obj = new frmItemDetailsNew { MdiParent = this };
            showform(obj);
        }

        private void blToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void aieTmViezToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptItemWise obj = new frmRptItemWise { MdiParent = this };
            showform(obj);
        }

        private void tarKVieZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptBillDate obj = new frmRptBillDate { MdiParent = this };
            showform(obj);
        }

        private void pmTATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentDetails obj = new frmPaymentDetails { MdiParent = this };
            showform(obj);
        }

        private void dddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseDetails obj = new frmPurchaseDetails { MdiParent = this };
            showform(obj);
        }

        private void prccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasePaymentDetails obj = new frmPurchasePaymentDetails { MdiParent = this };
            showform(obj);
        }

        private void pmºTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Payment_report obj = new Payment_report { MdiParent = this };
            //showform(obj);
        }

        private void pendingBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptPaymetPendingDetails obj = new frmRptPaymetPendingDetails { MdiParent = this };
            showform(obj);
        }

        private void dTiBkapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup obj = new frmBackup { MdiParent = this };
            showform(obj);
        }

        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Payment_report obj = new Payment_report { MdiParent = this };
            //showform(obj);
        }

        private void dlkTBkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptDuplicateBill obj = new frmRptDuplicateBill { MdiParent = this };
            showform(obj);
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    label2.Text = DateTime.Now.ToLongTimeString();
        //    label2.Show();
        //}

        private void piTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptBillDatePartyWise obj = new frmRptBillDatePartyWise { MdiParent = this };
            showform(obj);
        }

        private void pmºTRpiTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptDailyPaymentPartyWise obj = new frmRptDailyPaymentPartyWise { MdiParent = this };
            showform(obj);
        }

        private void pmºTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRptPurchasePaymetPending obj = new frmRptPurchasePaymetPending { MdiParent = this };
            showform(obj);
        }
        #endregion

        #region " Functions/ Procedures "
        private void showform(Form childform)
        {
            client.BringToFront();
            childform.Show();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //string FileName = OpenFile                                                                                                                        eDialog.FileName;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            DateTime thedate;
            thedate = DateTime.Now;
            label3.Text = thedate.ToString("dddd, dd/MM/yyyy ,");
        }
        #endregion
    }
}
