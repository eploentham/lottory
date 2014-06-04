namespace lottory.gui
{
    partial class FrmLottoApprove
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
            this.btnInit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.txtTod = new System.Windows.Forms.TextBox();
            this.txtUp = new System.Windows.Forms.TextBox();
            this.dgvRate = new System.Windows.Forms.DataGridView();
            this.dgvThooTranfer = new System.Windows.Forms.DataGridView();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThooTranfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboPeriod);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1377, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(1013, 18);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(102, 41);
            this.btnInit.TabIndex = 62;
            this.btnInit.Text = "กำหนดค่า";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(793, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 41);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(591, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 41);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "คำนวณ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(451, 27);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 24);
            this.cboYear.TabIndex = 53;
            // 
            // cboPeriod
            // 
            this.cboPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(292, 24);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(142, 28);
            this.cboPeriod.TabIndex = 52;
            // 
            // cboMonth
            // 
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(125, 24);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(142, 28);
            this.cboMonth.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(18, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 50;
            this.label14.Text = "ประจำเดือน";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAmt);
            this.groupBox2.Controls.Add(this.txtDown);
            this.groupBox2.Controls.Add(this.txtTod);
            this.groupBox2.Controls.Add(this.txtUp);
            this.groupBox2.Controls.Add(this.dgvRate);
            this.groupBox2.Controls.Add(this.dgvThooTranfer);
            this.groupBox2.Controls.Add(this.dgv1);
            this.groupBox2.Location = new System.Drawing.Point(3, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1377, 742);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtAmt
            // 
            this.txtAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAmt.Location = new System.Drawing.Point(501, 700);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(122, 30);
            this.txtAmt.TabIndex = 6;
            this.txtAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDown
            // 
            this.txtDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDown.Location = new System.Drawing.Point(387, 700);
            this.txtDown.Name = "txtDown";
            this.txtDown.Size = new System.Drawing.Size(105, 30);
            this.txtDown.TabIndex = 5;
            this.txtDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTod
            // 
            this.txtTod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTod.Location = new System.Drawing.Point(274, 700);
            this.txtTod.Name = "txtTod";
            this.txtTod.Size = new System.Drawing.Size(105, 30);
            this.txtTod.TabIndex = 4;
            this.txtTod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUp
            // 
            this.txtUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUp.Location = new System.Drawing.Point(161, 700);
            this.txtUp.Name = "txtUp";
            this.txtUp.Size = new System.Drawing.Size(105, 30);
            this.txtUp.TabIndex = 3;
            this.txtUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvRate
            // 
            this.dgvRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRate.Location = new System.Drawing.Point(933, 429);
            this.dgvRate.Name = "dgvRate";
            this.dgvRate.RowHeadersVisible = false;
            this.dgvRate.RowTemplate.Height = 24;
            this.dgvRate.Size = new System.Drawing.Size(438, 265);
            this.dgvRate.TabIndex = 2;
            // 
            // dgvThooTranfer
            // 
            this.dgvThooTranfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThooTranfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThooTranfer.Location = new System.Drawing.Point(933, 21);
            this.dgvThooTranfer.Name = "dgvThooTranfer";
            this.dgvThooTranfer.RowTemplate.Height = 24;
            this.dgvThooTranfer.Size = new System.Drawing.Size(438, 402);
            this.dgvThooTranfer.TabIndex = 1;
            this.dgvThooTranfer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThooTranfer_CellDoubleClick);
            // 
            // dgv1
            // 
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(6, 21);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(921, 673);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // FrmLottoApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 864);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLottoApprove";
            this.Text = "หน้าจอตรวจสอบตัวเลข และโอนยอดให้เจ้ามือคนอื่น";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLottoApprove_FormClosed);
            this.Load += new System.EventHandler(this.FrmLottoApprove_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThooTranfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRate;
        private System.Windows.Forms.DataGridView dgvThooTranfer;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboThoo;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.TextBox txtTod;
        private System.Windows.Forms.TextBox txtUp;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.Button btnInit;
    }
}