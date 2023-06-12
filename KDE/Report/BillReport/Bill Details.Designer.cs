namespace KDE
{
    partial class Bill_Details
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
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Txt_To_Date = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_From_Date = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblP_Code = new System.Windows.Forms.Label();
            this.txtParty_Name = new System.Windows.Forms.TextBox();
            this.txtParty_Code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtbillno);
            this.groupBox1.Controls.Add(this.Btn_Save);
            this.groupBox1.Controls.Add(this.Txt_To_Date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_From_Date);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblP_Code);
            this.groupBox1.Controls.Add(this.txtParty_Name);
            this.groupBox1.Controls.Add(this.txtParty_Code);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1205, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.BurlyWood;
            this.Btn_Save.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.ForeColor = System.Drawing.Color.Black;
            this.Btn_Save.Location = new System.Drawing.Point(180, 98);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(91, 26);
            this.Btn_Save.TabIndex = 96;
            this.Btn_Save.Text = "&Show";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Txt_To_Date
            // 
            this.Txt_To_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_To_Date.Location = new System.Drawing.Point(611, 60);
            this.Txt_To_Date.Mask = "00/00/0000";
            this.Txt_To_Date.Name = "Txt_To_Date";
            this.Txt_To_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_To_Date.TabIndex = 4;
            this.Txt_To_Date.TabStop = false;
            this.Txt_To_Date.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtParty_Code_MouseClick);
            this.Txt_To_Date.Enter += new System.EventHandler(this.txtParty_Code_Enter);
            this.Txt_To_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_To_Date_KeyPress);
            this.Txt_To_Date.Leave += new System.EventHandler(this.txtParty_Code_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(535, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 95;
            this.label3.Text = "To Date:";
            // 
            // Txt_From_Date
            // 
            this.Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_From_Date.Location = new System.Drawing.Point(423, 59);
            this.Txt_From_Date.Mask = "00/00/0000";
            this.Txt_From_Date.Name = "Txt_From_Date";
            this.Txt_From_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_From_Date.TabIndex = 3;
            this.Txt_From_Date.TabStop = false;
            this.Txt_From_Date.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtParty_Code_MouseClick);
            this.Txt_From_Date.Enter += new System.EventHandler(this.txtParty_Code_Enter);
            this.Txt_From_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_From_Date_KeyPress);
            this.Txt_From_Date.Leave += new System.EventHandler(this.txtParty_Code_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(314, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 93;
            this.label4.Text = "From Date:";
            // 
            // lblP_Code
            // 
            this.lblP_Code.AutoSize = true;
            this.lblP_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP_Code.ForeColor = System.Drawing.Color.Black;
            this.lblP_Code.Location = new System.Drawing.Point(73, 31);
            this.lblP_Code.Name = "lblP_Code";
            this.lblP_Code.Size = new System.Drawing.Size(84, 14);
            this.lblP_Code.TabIndex = 91;
            this.lblP_Code.Text = "Party Code ";
            // 
            // txtParty_Name
            // 
            this.txtParty_Name.AcceptsTab = true;
            this.txtParty_Name.BackColor = System.Drawing.Color.White;
            this.txtParty_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Name.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Name.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Name.Location = new System.Drawing.Point(244, 29);
            this.txtParty_Name.MaxLength = 1000;
            this.txtParty_Name.Name = "txtParty_Name";
            this.txtParty_Name.ReadOnly = true;
            this.txtParty_Name.Size = new System.Drawing.Size(270, 22);
            this.txtParty_Name.TabIndex = 90;
            this.txtParty_Name.TabStop = false;
            // 
            // txtParty_Code
            // 
            this.txtParty_Code.AcceptsTab = true;
            this.txtParty_Code.BackColor = System.Drawing.Color.White;
            this.txtParty_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Code.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Code.Location = new System.Drawing.Point(180, 29);
            this.txtParty_Code.MaxLength = 1000;
            this.txtParty_Code.Name = "txtParty_Code";
            this.txtParty_Code.Size = new System.Drawing.Size(58, 22);
            this.txtParty_Code.TabIndex = 89;
            this.txtParty_Code.TabStop = false;
            this.txtParty_Code.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtParty_Code_MouseClick);
            this.txtParty_Code.Enter += new System.EventHandler(this.txtParty_Code_Enter);
            this.txtParty_Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParty_Code_KeyDown);
            this.txtParty_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParty_Code_KeyPress);
            this.txtParty_Code.Leave += new System.EventHandler(this.txtParty_Code_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(73, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 98;
            this.label1.Text = "Bill No";
            // 
            // txtbillno
            // 
            this.txtbillno.AcceptsTab = true;
            this.txtbillno.BackColor = System.Drawing.Color.White;
            this.txtbillno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbillno.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbillno.ForeColor = System.Drawing.Color.Black;
            this.txtbillno.Location = new System.Drawing.Point(180, 57);
            this.txtbillno.MaxLength = 1000;
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.Size = new System.Drawing.Size(58, 22);
            this.txtbillno.TabIndex = 2;
            this.txtbillno.TabStop = false;
            this.txtbillno.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtParty_Code_MouseClick);
            this.txtbillno.Enter += new System.EventHandler(this.txtParty_Code_Enter);
            this.txtbillno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbillno_KeyPress);
            this.txtbillno.Leave += new System.EventHandler(this.txtParty_Code_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1199, 392);
            this.dataGridView1.TabIndex = 1;
            // 
            // Bill_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1229, 563);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Bill_Details";
            this.Text = "Bill_Details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbillno;
        private System.Windows.Forms.Button Btn_Save;
        public System.Windows.Forms.MaskedTextBox Txt_To_Date;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox Txt_From_Date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblP_Code;
        private System.Windows.Forms.TextBox txtParty_Name;
        private System.Windows.Forms.TextBox txtParty_Code;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}