namespace lottory.gui
{
    partial class FrmSaleAdd
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
            this.btnUnActive = new System.Windows.Forms.Button();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.txtSaleId = new System.Windows.Forms.TextBox();
            this.txtSaleRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChkUnActive = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSaleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaleCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tab1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkDiscount = new System.Windows.Forms.CheckBox();
            this.dgvRate = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUnActive);
            this.groupBox1.Controls.Add(this.chkLimit);
            this.groupBox1.Controls.Add(this.txtLimit);
            this.groupBox1.Controls.Add(this.txtSaleId);
            this.groupBox1.Controls.Add(this.txtSaleRemark);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ChkUnActive);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtSaleName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSaleCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(296, 352);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnUnActive
            // 
            this.btnUnActive.Location = new System.Drawing.Point(196, 200);
            this.btnUnActive.Name = "btnUnActive";
            this.btnUnActive.Size = new System.Drawing.Size(86, 23);
            this.btnUnActive.TabIndex = 36;
            this.btnUnActive.Text = "ยกเลิกการใช้งาน";
            this.btnUnActive.UseVisualStyleBackColor = true;
            this.btnUnActive.Click += new System.EventHandler(this.btnUnActive_Click);
            // 
            // chkLimit
            // 
            this.chkLimit.AutoSize = true;
            this.chkLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkLimit.Location = new System.Drawing.Point(18, 141);
            this.chkLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(43, 21);
            this.chkLimit.TabIndex = 18;
            this.chkLimit.Text = "อั้น";
            this.chkLimit.UseVisualStyleBackColor = true;
            this.chkLimit.Visible = false;
            // 
            // txtLimit
            // 
            this.txtLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLimit.Location = new System.Drawing.Point(94, 141);
            this.txtLimit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(76, 23);
            this.txtLimit.TabIndex = 17;
            this.txtLimit.Visible = false;
            this.txtLimit.Enter += new System.EventHandler(this.txtLimit_Enter);
            this.txtLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLimit_KeyPress);
            this.txtLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLimit_KeyUp);
            this.txtLimit.Leave += new System.EventHandler(this.txtLimit_Leave);
            // 
            // txtSaleId
            // 
            this.txtSaleId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSaleId.Location = new System.Drawing.Point(184, 24);
            this.txtSaleId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaleId.Name = "txtSaleId";
            this.txtSaleId.Size = new System.Drawing.Size(76, 23);
            this.txtSaleId.TabIndex = 14;
            this.txtSaleId.Visible = false;
            // 
            // txtSaleRemark
            // 
            this.txtSaleRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSaleRemark.Location = new System.Drawing.Point(94, 102);
            this.txtSaleRemark.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaleRemark.Name = "txtSaleRemark";
            this.txtSaleRemark.Size = new System.Drawing.Size(174, 23);
            this.txtSaleRemark.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(15, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "หมายเหตุ";
            // 
            // ChkUnActive
            // 
            this.ChkUnActive.AutoSize = true;
            this.ChkUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ChkUnActive.Location = new System.Drawing.Point(129, 200);
            this.ChkUnActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChkUnActive.Name = "ChkUnActive";
            this.ChkUnActive.Size = new System.Drawing.Size(60, 21);
            this.ChkUnActive.TabIndex = 11;
            this.ChkUnActive.TabStop = true;
            this.ChkUnActive.Text = "ยกเลิก";
            this.ChkUnActive.UseVisualStyleBackColor = true;
            this.ChkUnActive.Click += new System.EventHandler(this.ChkUnActive_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkActive.Location = new System.Drawing.Point(14, 200);
            this.chkActive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 21);
            this.chkActive.TabIndex = 10;
            this.chkActive.TabStop = true;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Location = new System.Drawing.Point(145, 253);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 24);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.Location = new System.Drawing.Point(19, 253);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 24);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSaleName
            // 
            this.txtSaleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSaleName.Location = new System.Drawing.Point(94, 61);
            this.txtSaleName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaleName.Name = "txtSaleName";
            this.txtSaleName.Size = new System.Drawing.Size(174, 23);
            this.txtSaleName.TabIndex = 3;
            this.txtSaleName.Enter += new System.EventHandler(this.txtSaleName_Enter);
            this.txtSaleName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSaleName_KeyUp);
            this.txtSaleName.Leave += new System.EventHandler(this.txtSaleName_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ชื่อ";
            // 
            // txtSaleCode
            // 
            this.txtSaleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSaleCode.Location = new System.Drawing.Point(94, 24);
            this.txtSaleCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSaleCode.Name = "txtSaleCode";
            this.txtSaleCode.Size = new System.Drawing.Size(76, 23);
            this.txtSaleCode.TabIndex = 1;
            this.txtSaleCode.Enter += new System.EventHandler(this.txtSaleCode_Enter);
            this.txtSaleCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSaleCode_KeyUp);
            this.txtSaleCode.Leave += new System.EventHandler(this.txtSaleCode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัส";
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tabPage1);
            this.tab1.Controls.Add(this.tabPage2);
            this.tab1.Location = new System.Drawing.Point(309, 10);
            this.tab1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tab1.Name = "tab1";
            this.tab1.SelectedIndex = 0;
            this.tab1.Size = new System.Drawing.Size(578, 352);
            this.tab1.TabIndex = 20;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkDiscount);
            this.tabPage1.Controls.Add(this.dgvRate);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(570, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkDiscount
            // 
            this.chkDiscount.AutoSize = true;
            this.chkDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkDiscount.Location = new System.Drawing.Point(4, 5);
            this.chkDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkDiscount.Name = "chkDiscount";
            this.chkDiscount.Size = new System.Drawing.Size(122, 21);
            this.chkDiscount.TabIndex = 21;
            this.chkDiscount.Text = "กำหนดส่วนลดเอง";
            this.chkDiscount.UseVisualStyleBackColor = true;
            this.chkDiscount.CheckedChanged += new System.EventHandler(this.chkDiscount_CheckedChanged);
            this.chkDiscount.Click += new System.EventHandler(this.chkDiscount_Click);
            // 
            // dgvRate
            // 
            this.dgvRate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRate.Location = new System.Drawing.Point(4, 29);
            this.dgvRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRate.Name = "dgvRate";
            this.dgvRate.RowTemplate.Height = 24;
            this.dgvRate.Size = new System.Drawing.Size(562, 294);
            this.dgvRate.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(570, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 3);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(562, 320);
            this.dataGridView1.TabIndex = 21;
            // 
            // FrmSaleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 371);
            this.Controls.Add(this.tab1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSaleAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSaleAdd";
            this.Load += new System.EventHandler(this.FrmSaleAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSaleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ChkUnActive;
        private System.Windows.Forms.RadioButton chkActive;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSaleId;
        private System.Windows.Forms.TextBox txtSaleRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaleCode;
        private System.Windows.Forms.CheckBox chkLimit;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Button btnUnActive;
        private System.Windows.Forms.TabControl tab1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkDiscount;
        private System.Windows.Forms.DataGridView dgvRate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}