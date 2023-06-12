namespace KDE
{
    partial class frmPurchaseParty
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_party_con_no = new System.Windows.Forms.TextBox();
            this.txt_party_add = new System.Windows.Forms.TextBox();
            this.txt_pan_no = new System.Windows.Forms.TextBox();
            this.txt_party_name = new System.Windows.Forms.TextBox();
            this.txt_party_code = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.btn_reset);
            this.groupBox3.Controls.Add(this.btn_delete);
            this.groupBox3.Controls.Add(this.btn_update);
            this.groupBox3.Controls.Add(this.btn_save);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(616, 568);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase Party Master";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Location = new System.Drawing.Point(14, 300);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(587, 250);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_reset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.Black;
            this.btn_reset.Location = new System.Drawing.Point(510, 256);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(91, 26);
            this.btn_reset.TabIndex = 7;
            this.btn_reset.Text = "&Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_delete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Black;
            this.btn_delete.Location = new System.Drawing.Point(413, 256);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(91, 26);
            this.btn_delete.TabIndex = 6;
            this.btn_delete.Text = "&Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_update.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update.ForeColor = System.Drawing.Color.Black;
            this.btn_update.Location = new System.Drawing.Point(316, 256);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(91, 26);
            this.btn_update.TabIndex = 5;
            this.btn_update.Text = "&Update";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_save.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Location = new System.Drawing.Point(219, 256);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 26);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "&Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.txtPartyID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_party_con_no);
            this.groupBox1.Controls.Add(this.txt_party_add);
            this.groupBox1.Controls.Add(this.txt_pan_no);
            this.groupBox1.Controls.Add(this.txt_party_name);
            this.groupBox1.Controls.Add(this.txt_party_code);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(14, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(587, 212);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Detail";
            // 
            // txtPartyID
            // 
            this.txtPartyID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartyID.ForeColor = System.Drawing.Color.Black;
            this.txtPartyID.Location = new System.Drawing.Point(480, 24);
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(89, 22);
            this.txtPartyID.TabIndex = 40;
            this.txtPartyID.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(453, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(221, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "*";
            // 
            // txt_party_con_no
            // 
            this.txt_party_con_no.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_party_con_no.ForeColor = System.Drawing.Color.Black;
            this.txt_party_con_no.Location = new System.Drawing.Point(125, 126);
            this.txt_party_con_no.MaxLength = 13;
            this.txt_party_con_no.Name = "txt_party_con_no";
            this.txt_party_con_no.Size = new System.Drawing.Size(163, 22);
            this.txt_party_con_no.TabIndex = 14;
            this.txt_party_con_no.Enter += new System.EventHandler(this.txt_party_con_no_Enter);
            this.txt_party_con_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_party_con_no_KeyPress);
            this.txt_party_con_no.Leave += new System.EventHandler(this.txt_party_con_no_Leave);
            // 
            // txt_party_add
            // 
            this.txt_party_add.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_party_add.ForeColor = System.Drawing.Color.Black;
            this.txt_party_add.Location = new System.Drawing.Point(125, 84);
            this.txt_party_add.Multiline = true;
            this.txt_party_add.Name = "txt_party_add";
            this.txt_party_add.Size = new System.Drawing.Size(322, 35);
            this.txt_party_add.TabIndex = 13;
            this.txt_party_add.Enter += new System.EventHandler(this.txt_party_add_Enter);
            this.txt_party_add.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_party_add_KeyPress);
            this.txt_party_add.Leave += new System.EventHandler(this.txt_party_add_Leave);
            // 
            // txt_pan_no
            // 
            this.txt_pan_no.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pan_no.ForeColor = System.Drawing.Color.Black;
            this.txt_pan_no.Location = new System.Drawing.Point(126, 154);
            this.txt_pan_no.Name = "txt_pan_no";
            this.txt_pan_no.Size = new System.Drawing.Size(164, 22);
            this.txt_pan_no.TabIndex = 12;
            this.txt_pan_no.Enter += new System.EventHandler(this.txt_pan_no_Enter);
            this.txt_pan_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pan_no_KeyPress);
            this.txt_pan_no.Leave += new System.EventHandler(this.txt_pan_no_Leave);
            // 
            // txt_party_name
            // 
            this.txt_party_name.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_party_name.ForeColor = System.Drawing.Color.Black;
            this.txt_party_name.Location = new System.Drawing.Point(126, 56);
            this.txt_party_name.Name = "txt_party_name";
            this.txt_party_name.Size = new System.Drawing.Size(321, 22);
            this.txt_party_name.TabIndex = 11;
            this.txt_party_name.Enter += new System.EventHandler(this.txt_party_name_Enter);
            this.txt_party_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_party_name_KeyPress);
            this.txt_party_name.Leave += new System.EventHandler(this.txt_party_name_Leave);
            // 
            // txt_party_code
            // 
            this.txt_party_code.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_party_code.ForeColor = System.Drawing.Color.Black;
            this.txt_party_code.Location = new System.Drawing.Point(126, 28);
            this.txt_party_code.Name = "txt_party_code";
            this.txt_party_code.Size = new System.Drawing.Size(89, 22);
            this.txt_party_code.TabIndex = 10;
            this.txt_party_code.Enter += new System.EventHandler(this.txt_party_code_Enter);
            this.txt_party_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_party_code_KeyDown);
            this.txt_party_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_party_code_KeyPress);
            this.txt_party_code.Leave += new System.EventHandler(this.txt_party_code_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "PAN No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Party Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contact No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Party Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Party Code";
            // 
            // frmPurchaseParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(641, 594);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPurchaseParty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*****Bill Generate System --> Master --> Purchase Party";
            this.Load += new System.EventHandler(this.Party_Master_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_party_con_no;
        private System.Windows.Forms.TextBox txt_party_add;
        private System.Windows.Forms.TextBox txt_pan_no;
        private System.Windows.Forms.TextBox txt_party_name;
        private System.Windows.Forms.TextBox txt_party_code;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPartyID;
    }
}

