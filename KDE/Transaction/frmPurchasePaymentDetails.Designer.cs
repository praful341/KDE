namespace KDE
{
    partial class frmPurchasePaymentDetails
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
            this.lblP_Code = new System.Windows.Forms.Label();
            this.lblV_Id = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblRs = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtParty_Code = new System.Windows.Forms.TextBox();
            this.txtVoucher_Id = new System.Windows.Forms.TextBox();
            this.txtRs = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtParty_Name = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblP_Code
            // 
            this.lblP_Code.AutoSize = true;
            this.lblP_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP_Code.ForeColor = System.Drawing.Color.Black;
            this.lblP_Code.Location = new System.Drawing.Point(56, 35);
            this.lblP_Code.Name = "lblP_Code";
            this.lblP_Code.Size = new System.Drawing.Size(89, 14);
            this.lblP_Code.TabIndex = 0;
            this.lblP_Code.Text = "Party Code :";
            // 
            // lblV_Id
            // 
            this.lblV_Id.AutoSize = true;
            this.lblV_Id.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV_Id.ForeColor = System.Drawing.Color.Black;
            this.lblV_Id.Location = new System.Drawing.Point(56, 68);
            this.lblV_Id.Name = "lblV_Id";
            this.lblV_Id.Size = new System.Drawing.Size(88, 14);
            this.lblV_Id.TabIndex = 3;
            this.lblV_Id.Text = "Voucher Id :";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.Black;
            this.lbldate.Location = new System.Drawing.Point(56, 102);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(47, 14);
            this.lbldate.TabIndex = 5;
            this.lbldate.Text = "Date :";
            // 
            // lblRs
            // 
            this.lblRs.AutoSize = true;
            this.lblRs.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRs.ForeColor = System.Drawing.Color.Black;
            this.lblRs.Location = new System.Drawing.Point(56, 157);
            this.lblRs.Name = "lblRs";
            this.lblRs.Size = new System.Drawing.Size(36, 14);
            this.lblRs.TabIndex = 11;
            this.lblRs.Text = "Rs. :";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Black;
            this.lblNote.Location = new System.Drawing.Point(56, 190);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 14);
            this.lblNote.TabIndex = 13;
            this.lblNote.Text = "Note :";
            // 
            // txtParty_Code
            // 
            this.txtParty_Code.AcceptsTab = true;
            this.txtParty_Code.BackColor = System.Drawing.Color.White;
            this.txtParty_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Code.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Code.Location = new System.Drawing.Point(169, 33);
            this.txtParty_Code.MaxLength = 1000;
            this.txtParty_Code.Name = "txtParty_Code";
            this.txtParty_Code.Size = new System.Drawing.Size(115, 22);
            this.txtParty_Code.TabIndex = 1;
            this.txtParty_Code.Enter += new System.EventHandler(this.txtParty_Code_Enter);
            this.txtParty_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParty_Code_KeyPress);
            this.txtParty_Code.Leave += new System.EventHandler(this.txtParty_Code_Leave);
            // 
            // txtVoucher_Id
            // 
            this.txtVoucher_Id.AcceptsTab = true;
            this.txtVoucher_Id.BackColor = System.Drawing.Color.White;
            this.txtVoucher_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucher_Id.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoucher_Id.ForeColor = System.Drawing.Color.Black;
            this.txtVoucher_Id.Location = new System.Drawing.Point(169, 66);
            this.txtVoucher_Id.MaxLength = 1000;
            this.txtVoucher_Id.Name = "txtVoucher_Id";
            this.txtVoucher_Id.Size = new System.Drawing.Size(115, 22);
            this.txtVoucher_Id.TabIndex = 4;
            this.txtVoucher_Id.Enter += new System.EventHandler(this.txtVoucher_Id_Enter);
            this.txtVoucher_Id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVoucher_Id_KeyPress);
            this.txtVoucher_Id.Leave += new System.EventHandler(this.txtVoucher_Id_Leave);
            // 
            // txtRs
            // 
            this.txtRs.AcceptsTab = true;
            this.txtRs.BackColor = System.Drawing.Color.White;
            this.txtRs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRs.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRs.ForeColor = System.Drawing.Color.Black;
            this.txtRs.Location = new System.Drawing.Point(169, 155);
            this.txtRs.MaxLength = 1000;
            this.txtRs.Name = "txtRs";
            this.txtRs.Size = new System.Drawing.Size(115, 22);
            this.txtRs.TabIndex = 12;
            this.txtRs.Enter += new System.EventHandler(this.txtRs_Enter);
            this.txtRs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRs_KeyPress);
            this.txtRs.Leave += new System.EventHandler(this.txtRs_Leave);
            // 
            // txtNote
            // 
            this.txtNote.AcceptsTab = true;
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.Location = new System.Drawing.Point(169, 188);
            this.txtNote.MaxLength = 1000;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(214, 57);
            this.txtNote.TabIndex = 14;
            this.txtNote.Enter += new System.EventHandler(this.txtNote_Enter);
            this.txtNote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNote_KeyPress);
            this.txtNote.Leave += new System.EventHandler(this.txtNote_Leave);
            // 
            // txtParty_Name
            // 
            this.txtParty_Name.AcceptsTab = true;
            this.txtParty_Name.BackColor = System.Drawing.Color.White;
            this.txtParty_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Name.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Name.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Name.Location = new System.Drawing.Point(308, 33);
            this.txtParty_Name.MaxLength = 1000;
            this.txtParty_Name.Name = "txtParty_Name";
            this.txtParty_Name.ReadOnly = true;
            this.txtParty_Name.Size = new System.Drawing.Size(283, 22);
            this.txtParty_Name.TabIndex = 2;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(169, 99);
            this.txtDate.Mask = "00/00/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(90, 22);
            this.txtDate.TabIndex = 6;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            this.txtDate.Enter += new System.EventHandler(this.txtDate_Enter);
            this.txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDate_KeyPress);
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(169, 255);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(72, 25);
            this.btn_save.TabIndex = 15;
            this.btn_save.Text = "&Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_update.ForeColor = System.Drawing.Color.Black;
            this.btn_update.Location = new System.Drawing.Point(247, 255);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(77, 25);
            this.btn_update.TabIndex = 16;
            this.btn_update.Text = "&Update";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.Location = new System.Drawing.Point(408, 255);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(72, 25);
            this.btn_delete.TabIndex = 18;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Location = new System.Drawing.Point(0, 328);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(634, 215);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_reset.ForeColor = System.Drawing.Color.Black;
            this.btn_reset.Location = new System.Drawing.Point(330, 255);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(72, 25);
            this.btn_reset.TabIndex = 17;
            this.btn_reset.Text = "&Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(370, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pending Bill :";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_reset);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtParty_Name);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.txtRs);
            this.groupBox1.Controls.Add(this.txtVoucher_Id);
            this.groupBox1.Controls.Add(this.txtParty_Code);
            this.groupBox1.Controls.Add(this.lblNote);
            this.groupBox1.Controls.Add(this.lblRs);
            this.groupBox1.Controls.Add(this.lbldate);
            this.groupBox1.Controls.Add(this.lblV_Id);
            this.groupBox1.Controls.Add(this.lblP_Code);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 544);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Purchase Payment Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(470, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pending Bill :";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(56, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "Payment Type :";
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(169, 128);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(83, 22);
            this.cmbType.TabIndex = 10;
            this.cmbType.Enter += new System.EventHandler(this.cmbType_Enter);
            this.cmbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbType_KeyPress);
            this.cmbType.Leave += new System.EventHandler(this.cmbType_Leave);
            // 
            // frmPurchasePaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(659, 567);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPurchasePaymentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Payment Details";
            this.Load += new System.EventHandler(this.Payment_Details_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblP_Code;
        private System.Windows.Forms.Label lblV_Id;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblRs;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtParty_Code;
        private System.Windows.Forms.TextBox txtVoucher_Id;
        private System.Windows.Forms.TextBox txtRs;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtParty_Name;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;

    }
}