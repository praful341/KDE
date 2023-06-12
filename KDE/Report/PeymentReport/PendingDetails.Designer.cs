namespace KDE
{
    partial class PendingDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingDetails));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Txt_To_Date = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_From_Date = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbillamount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpending = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Sum = new System.Windows.Forms.TextBox();
            this.lblP_Code = new System.Windows.Forms.Label();
            this.txtParty_Name = new System.Windows.Forms.TextBox();
            this.txtParty_Code = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Btn_Save);
            this.groupBox1.Controls.Add(this.Txt_To_Date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_From_Date);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbillamount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtpending);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Sum);
            this.groupBox1.Controls.Add(this.lblP_Code);
            this.groupBox1.Controls.Add(this.txtParty_Name);
            this.groupBox1.Controls.Add(this.txtParty_Code);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1207, 539);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Details";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.BurlyWood;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(758, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 26);
            this.button2.TabIndex = 90;
            this.button2.Text = "&Preview";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.BurlyWood;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(661, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 26);
            this.button1.TabIndex = 89;
            this.button1.Text = "&Print";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.BurlyWood;
            this.Btn_Save.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.ForeColor = System.Drawing.Color.Black;
            this.Btn_Save.Location = new System.Drawing.Point(495, 78);
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
            this.Txt_To_Date.Location = new System.Drawing.Point(369, 81);
            this.Txt_To_Date.Mask = "00/00/0000";
            this.Txt_To_Date.Name = "Txt_To_Date";
            this.Txt_To_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_To_Date.TabIndex = 86;
            this.Txt_To_Date.Enter += new System.EventHandler(this.Txt_To_Date_Enter);
            this.Txt_To_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_To_Date_KeyPress);
            this.Txt_To_Date.Leave += new System.EventHandler(this.Txt_To_Date_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(293, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 87;
            this.label3.Text = "To Date:";
            // 
            // Txt_From_Date
            // 
            this.Txt_From_Date.Font = new System.Drawing.Font("Verdana", 9F);
            this.Txt_From_Date.Location = new System.Drawing.Point(181, 80);
            this.Txt_From_Date.Mask = "00/00/0000";
            this.Txt_From_Date.Name = "Txt_From_Date";
            this.Txt_From_Date.Size = new System.Drawing.Size(91, 22);
            this.Txt_From_Date.TabIndex = 84;
            this.Txt_From_Date.Enter += new System.EventHandler(this.Txt_From_Date_Enter);
            this.Txt_From_Date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_From_Date_KeyPress);
            this.Txt_From_Date.Leave += new System.EventHandler(this.Txt_From_Date_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(72, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 14);
            this.label4.TabIndex = 85;
            this.label4.Text = "From Date:";
            // 
            // txtbillamount
            // 
            this.txtbillamount.AcceptsTab = true;
            this.txtbillamount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtbillamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbillamount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbillamount.ForeColor = System.Drawing.Color.Black;
            this.txtbillamount.Location = new System.Drawing.Point(944, 467);
            this.txtbillamount.MaxLength = 1000;
            this.txtbillamount.Name = "txtbillamount";
            this.txtbillamount.ReadOnly = true;
            this.txtbillamount.Size = new System.Drawing.Size(127, 23);
            this.txtbillamount.TabIndex = 83;
            this.txtbillamount.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(350, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 82;
            this.label2.Text = "Total Pending ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtpending
            // 
            this.txtpending.AcceptsTab = true;
            this.txtpending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtpending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpending.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpending.ForeColor = System.Drawing.Color.Red;
            this.txtpending.Location = new System.Drawing.Point(495, 467);
            this.txtpending.MaxLength = 1000;
            this.txtpending.Name = "txtpending";
            this.txtpending.ReadOnly = true;
            this.txtpending.Size = new System.Drawing.Size(257, 26);
            this.txtpending.TabIndex = 81;
            this.txtpending.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(762, 469);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 18);
            this.label1.TabIndex = 80;
            this.label1.Text = "Total Payment/ Bill  ";
            this.label1.Visible = false;
            // 
            // txt_Sum
            // 
            this.txt_Sum.AcceptsTab = true;
            this.txt_Sum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_Sum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Sum.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Sum.ForeColor = System.Drawing.Color.Black;
            this.txt_Sum.Location = new System.Drawing.Point(1069, 467);
            this.txt_Sum.MaxLength = 1000;
            this.txt_Sum.Name = "txt_Sum";
            this.txt_Sum.ReadOnly = true;
            this.txt_Sum.Size = new System.Drawing.Size(133, 23);
            this.txt_Sum.TabIndex = 79;
            this.txt_Sum.Visible = false;
            // 
            // lblP_Code
            // 
            this.lblP_Code.AutoSize = true;
            this.lblP_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP_Code.ForeColor = System.Drawing.Color.Black;
            this.lblP_Code.Location = new System.Drawing.Point(74, 42);
            this.lblP_Code.Name = "lblP_Code";
            this.lblP_Code.Size = new System.Drawing.Size(89, 14);
            this.lblP_Code.TabIndex = 78;
            this.lblP_Code.Text = "Party Code :";
            // 
            // txtParty_Name
            // 
            this.txtParty_Name.AcceptsTab = true;
            this.txtParty_Name.BackColor = System.Drawing.Color.White;
            this.txtParty_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Name.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Name.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Name.Location = new System.Drawing.Point(320, 40);
            this.txtParty_Name.MaxLength = 1000;
            this.txtParty_Name.Name = "txtParty_Name";
            this.txtParty_Name.ReadOnly = true;
            this.txtParty_Name.Size = new System.Drawing.Size(283, 22);
            this.txtParty_Name.TabIndex = 77;
            // 
            // txtParty_Code
            // 
            this.txtParty_Code.AcceptsTab = true;
            this.txtParty_Code.BackColor = System.Drawing.Color.White;
            this.txtParty_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtParty_Code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty_Code.ForeColor = System.Drawing.Color.Black;
            this.txtParty_Code.Location = new System.Drawing.Point(181, 40);
            this.txtParty_Code.MaxLength = 1000;
            this.txtParty_Code.Name = "txtParty_Code";
            this.txtParty_Code.Size = new System.Drawing.Size(115, 22);
            this.txtParty_Code.TabIndex = 76;
            this.txtParty_Code.Enter += new System.EventHandler(this.txtParty_Code_Enter);
            this.txtParty_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParty_Code_KeyPress);
            this.txtParty_Code.Leave += new System.EventHandler(this.txtParty_Code_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 352);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // PendingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1229, 563);
            this.Controls.Add(this.groupBox1);
            this.Name = "PendingDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PendingDetails";
            this.Activated += new System.EventHandler(this.PendingDetails_Activated);
            this.Load += new System.EventHandler(this.PendingDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtParty_Name;
        private System.Windows.Forms.TextBox txtParty_Code;
        private System.Windows.Forms.Label lblP_Code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Sum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpending;
        private System.Windows.Forms.TextBox txtbillamount;
        public System.Windows.Forms.MaskedTextBox Txt_To_Date;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.MaskedTextBox Txt_From_Date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button2;
    }
}