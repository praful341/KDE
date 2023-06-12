namespace KDE
{
    partial class frmRptPaymetPendingDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Txt_To_Date = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_From_Date = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblP_Code = new System.Windows.Forms.Label();
            this.txtParty_Code = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.crystalReportViewer1);
            this.groupBox1.Controls.Add(this.Btn_Save);
            this.groupBox1.Controls.Add(this.Txt_To_Date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_From_Date);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblP_Code);
            this.groupBox1.Controls.Add(this.txtParty_Code);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1346, 726);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(261, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 90;
            this.label1.Text = "...";
            this.label1.Visible = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 70);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1340, 653);
            this.crystalReportViewer1.TabIndex = 89;
            this.crystalReportViewer1.Visible = false;
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.BurlyWood;
            this.Btn_Save.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.ForeColor = System.Drawing.Color.Black;
            this.Btn_Save.Location = new System.Drawing.Point(937, 28);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(91, 26);
            this.Btn_Save.TabIndex = 88;
            this.Btn_Save.Text = "&Show";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Txt_To_Date
            // 
            this.Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_To_Date.Location = new System.Drawing.Point(786, 30);
            this.Txt_To_Date.Mask = "00/00/0000";
            this.Txt_To_Date.Name = "Txt_To_Date";
            this.Txt_To_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_To_Date.TabIndex = 86;
            this.Txt_To_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_To_Date_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(751, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 14);
            this.label3.TabIndex = 87;
            this.label3.Text = "to ";
            // 
            // Txt_From_Date
            // 
            this.Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_From_Date.Location = new System.Drawing.Point(647, 31);
            this.Txt_From_Date.Mask = "00/00/0000";
            this.Txt_From_Date.Name = "Txt_From_Date";
            this.Txt_From_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_From_Date.TabIndex = 84;
            this.Txt_From_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_From_Date_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(538, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 85;
            this.label4.Text = "From Date:";
            // 
            // lblP_Code
            // 
            this.lblP_Code.AutoSize = true;
            this.lblP_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP_Code.ForeColor = System.Drawing.Color.Black;
            this.lblP_Code.Location = new System.Drawing.Point(74, 34);
            this.lblP_Code.Name = "lblP_Code";
            this.lblP_Code.Size = new System.Drawing.Size(89, 14);
            this.lblP_Code.TabIndex = 78;
            this.lblP_Code.Text = "Party Code :";
            // 
            // txtParty_Code
            // 
            this.txtParty_Code.AcceptsTab = true;
            this.txtParty_Code.BackColor = System.Drawing.Color.White;
            this.txtParty_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Code.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Code.Location = new System.Drawing.Point(181, 32);
            this.txtParty_Code.MaxLength = 1000;
            this.txtParty_Code.Name = "txtParty_Code";
            this.txtParty_Code.Size = new System.Drawing.Size(66, 22);
            this.txtParty_Code.TabIndex = 76;
            this.txtParty_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParty_Code_KeyPress);
            // 
            // Pending_Payment_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.groupBox1);
            this.Name = "Pending_Payment_Details";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pending_Payment_Details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Save;
        public System.Windows.Forms.MaskedTextBox Txt_To_Date;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox Txt_From_Date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblP_Code;
        private System.Windows.Forms.TextBox txtParty_Code;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}