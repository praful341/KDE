namespace KDE
{
    partial class frmBackup
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbservername = new System.Windows.Forms.ComboBox();
            this.cmbdatabasename = new System.Windows.Forms.ComboBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database Name  :  KDE";
            // 
            // cmbservername
            // 
            this.cmbservername.FormattingEnabled = true;
            this.cmbservername.Location = new System.Drawing.Point(113, 68);
            this.cmbservername.Name = "cmbservername";
            this.cmbservername.Size = new System.Drawing.Size(188, 21);
            this.cmbservername.TabIndex = 2;
            this.cmbservername.Visible = false;
            this.cmbservername.SelectedIndexChanged += new System.EventHandler(this.cmbservername_SelectedIndexChanged);
            // 
            // cmbdatabasename
            // 
            this.cmbdatabasename.FormattingEnabled = true;
            this.cmbdatabasename.Location = new System.Drawing.Point(113, 12);
            this.cmbdatabasename.Name = "cmbdatabasename";
            this.cmbdatabasename.Size = new System.Drawing.Size(188, 21);
            this.cmbdatabasename.TabIndex = 3;
            this.cmbdatabasename.Visible = false;
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(281, 127);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "Save";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Visible = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(198, 97);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back UP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 162);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.cmbdatabasename);
            this.Controls.Add(this.cmbservername);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*****Bill Generate System --> Backup";
            this.Load += new System.EventHandler(this.Backup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbservername;
        private System.Windows.Forms.ComboBox cmbdatabasename;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button button1;
    }
}