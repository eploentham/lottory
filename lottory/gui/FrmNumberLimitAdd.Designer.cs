namespace lottory.gui
{
    partial class FrmNumberLimitAdd
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
            this.txtNlId = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkPeriod = new System.Windows.Forms.RadioButton();
            this.chkImmediately = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUnActive = new System.Windows.Forms.Button();
            this.ChkUnActive = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtNlId);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.chkPeriod);
            this.groupBox1.Controls.Add(this.chkImmediately);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInput);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboPeriod);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 285);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtNlId
            // 
            this.txtNlId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNlId.Location = new System.Drawing.Point(338, 26);
            this.txtNlId.Name = "txtNlId";
            this.txtNlId.Size = new System.Drawing.Size(100, 38);
            this.txtNlId.TabIndex = 59;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(698, 195);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 84);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkPeriod
            // 
            this.chkPeriod.AutoSize = true;
            this.chkPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkPeriod.Location = new System.Drawing.Point(82, 150);
            this.chkPeriod.Name = "chkPeriod";
            this.chkPeriod.Size = new System.Drawing.Size(99, 24);
            this.chkPeriod.TabIndex = 57;
            this.chkPeriod.TabStop = true;
            this.chkPeriod.Text = "เฉพาะงวด";
            this.chkPeriod.UseVisualStyleBackColor = true;
            this.chkPeriod.Click += new System.EventHandler(this.chkPeriod_Click);
            // 
            // chkImmediately
            // 
            this.chkImmediately.AutoSize = true;
            this.chkImmediately.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkImmediately.Location = new System.Drawing.Point(82, 84);
            this.chkImmediately.Name = "chkImmediately";
            this.chkImmediately.Size = new System.Drawing.Size(151, 24);
            this.chkImmediately.TabIndex = 56;
            this.chkImmediately.TabStop = true;
            this.chkImmediately.Text = "ทันที และตลอดไป";
            this.chkImmediately.UseVisualStyleBackColor = true;
            this.chkImmediately.Click += new System.EventHandler(this.chkImmediately_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "ตัวเลข";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtInput.Location = new System.Drawing.Point(82, 21);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(100, 38);
            this.txtInput.TabIndex = 54;
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(624, 150);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 28);
            this.cboYear.TabIndex = 53;
            // 
            // cboPeriod
            // 
            this.cboPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(465, 150);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(142, 28);
            this.cboPeriod.TabIndex = 52;
            // 
            // cboMonth
            // 
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(298, 150);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(142, 28);
            this.cboMonth.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(202, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 50;
            this.label14.Text = "ประจำเดือน";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUnActive);
            this.groupBox2.Controls.Add(this.ChkUnActive);
            this.groupBox2.Controls.Add(this.chkActive);
            this.groupBox2.Location = new System.Drawing.Point(58, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 54);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            // 
            // btnUnActive
            // 
            this.btnUnActive.Location = new System.Drawing.Point(269, 19);
            this.btnUnActive.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnActive.Name = "btnUnActive";
            this.btnUnActive.Size = new System.Drawing.Size(114, 28);
            this.btnUnActive.TabIndex = 65;
            this.btnUnActive.Text = "ยกเลิกการใช้งาน";
            this.btnUnActive.UseVisualStyleBackColor = true;
            this.btnUnActive.Click += new System.EventHandler(this.btnUnActive_Click);
            // 
            // ChkUnActive
            // 
            this.ChkUnActive.AutoSize = true;
            this.ChkUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ChkUnActive.Location = new System.Drawing.Point(179, 19);
            this.ChkUnActive.Name = "ChkUnActive";
            this.ChkUnActive.Size = new System.Drawing.Size(74, 24);
            this.ChkUnActive.TabIndex = 64;
            this.ChkUnActive.TabStop = true;
            this.ChkUnActive.Text = "ยกเลิก";
            this.ChkUnActive.UseVisualStyleBackColor = true;
            this.ChkUnActive.Click += new System.EventHandler(this.ChkUnActive_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkActive.Location = new System.Drawing.Point(26, 19);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(74, 24);
            this.chkActive.TabIndex = 63;
            this.chkActive.TabStop = true;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
            // 
            // FrmNumberLimitAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 327);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmNumberLimitAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNumberLimit";
            this.Load += new System.EventHandler(this.FrmNumberLimitAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.RadioButton chkPeriod;
        private System.Windows.Forms.RadioButton chkImmediately;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNlId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUnActive;
        private System.Windows.Forms.RadioButton ChkUnActive;
        private System.Windows.Forms.RadioButton chkActive;
    }
}