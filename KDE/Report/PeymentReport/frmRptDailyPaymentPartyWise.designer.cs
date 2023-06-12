namespace KDE
{
    partial class frmRptDailyPaymentPartyWise
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.txtParty_Name = new System.Windows.Forms.TextBox();
            this.Txt_To_Date = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_From_Date = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_Party = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.Btn_Save);
            this.groupBox1.Controls.Add(this.txtParty_Name);
            this.groupBox1.Controls.Add(this.Txt_To_Date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_From_Date);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txt_Party);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 247);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Report";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(635, 176);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.BurlyWood;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(280, 125);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 26);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.BurlyWood;
            this.Btn_Save.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.ForeColor = System.Drawing.Color.Black;
            this.Btn_Save.Location = new System.Drawing.Point(182, 125);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(91, 26);
            this.Btn_Save.TabIndex = 14;
            this.Btn_Save.Text = "&Show";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // txtParty_Name
            // 
            this.txtParty_Name.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtParty_Name.Location = new System.Drawing.Point(283, 96);
            this.txtParty_Name.Name = "txtParty_Name";
            this.txtParty_Name.ReadOnly = true;
            this.txtParty_Name.Size = new System.Drawing.Size(267, 22);
            this.txtParty_Name.TabIndex = 13;
            this.txtParty_Name.Visible = false;
            // 
            // Txt_To_Date
            // 
            this.Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_To_Date.Location = new System.Drawing.Point(363, 60);
            this.Txt_To_Date.Mask = "00/00/0000";
            this.Txt_To_Date.Name = "Txt_To_Date";
            this.Txt_To_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_To_Date.TabIndex = 11;
            this.Txt_To_Date.Enter += new System.EventHandler(this.Txt_To_Date_Enter);
            this.Txt_To_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_To_Date_KeyPress);
            this.Txt_To_Date.Leave += new System.EventHandler(this.Txt_To_Date_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(294, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "To Date:";
            // 
            // Txt_From_Date
            // 
            this.Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_From_Date.Location = new System.Drawing.Point(182, 60);
            this.Txt_From_Date.Mask = "00/00/0000";
            this.Txt_From_Date.Name = "Txt_From_Date";
            this.Txt_From_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_From_Date.TabIndex = 9;
            this.Txt_From_Date.Enter += new System.EventHandler(this.Txt_From_Date_Enter);
            this.Txt_From_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_From_Date_KeyPress);
            this.Txt_From_Date.Leave += new System.EventHandler(this.Txt_From_Date_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(81, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "From Date";
            // 
            // Txt_Party
            // 
            this.Txt_Party.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_Party.Location = new System.Drawing.Point(186, 96);
            this.Txt_Party.Name = "Txt_Party";
            this.Txt_Party.Size = new System.Drawing.Size(91, 22);
            this.Txt_Party.TabIndex = 7;
            this.Txt_Party.Visible = false;
            this.Txt_Party.Enter += new System.EventHandler(this.Txt_Party_Enter);
            this.Txt_Party.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Party_KeyDown);
            this.Txt_Party.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Party_KeyPress);
            this.Txt_Party.Leave += new System.EventHandler(this.Txt_Party_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(77, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Party Code";
            this.label2.Visible = false;
            // 
            // frmRptDailyPaymentPartyWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(710, 269);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRptDailyPaymentPartyWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*****Bill Generate System --> Daily Payment Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.TextBox txtParty_Name;
        public System.Windows.Forms.MaskedTextBox Txt_To_Date;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox Txt_From_Date;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox Txt_Party;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}