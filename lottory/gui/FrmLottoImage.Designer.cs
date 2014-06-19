namespace lottory.gui
{
    partial class FrmLottoImage
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
            this.pB1 = new System.Windows.Forms.ProgressBar();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.lV1 = new System.Windows.Forms.ListView();
            this.lVNew = new System.Windows.Forms.ListView();
            this.picRotate = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRotate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pB1);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboPeriod);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1377, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(6, 65);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(1365, 23);
            this.pB1.TabIndex = 63;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(1013, 18);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(102, 41);
            this.btnInit.TabIndex = 62;
            this.btnInit.Text = "กำหนดค่า";
            this.btnInit.UseVisualStyleBackColor = true;
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
            this.btnSearch.Text = "ดึงรูป";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(440, 24);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 28);
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
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(1133, 102);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(567, 702);
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            // 
            // lV1
            // 
            this.lV1.Location = new System.Drawing.Point(12, 102);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(553, 702);
            this.lV1.TabIndex = 4;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lV1_ItemCheck);
            this.lV1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lV1_ItemChecked);
            this.lV1.SelectedIndexChanged += new System.EventHandler(this.lV1_SelectedIndexChanged);
            // 
            // lVNew
            // 
            this.lVNew.Location = new System.Drawing.Point(574, 102);
            this.lVNew.Name = "lVNew";
            this.lVNew.Size = new System.Drawing.Size(553, 702);
            this.lVNew.TabIndex = 6;
            this.lVNew.UseCompatibleStateImageBehavior = false;
            this.lVNew.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lVNew_ItemCheck);
            this.lVNew.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lVNew_ItemChecked);
            // 
            // picRotate
            // 
            this.picRotate.Image = global::lottory.Properties.Resources.rotate2;
            this.picRotate.Location = new System.Drawing.Point(1645, 41);
            this.picRotate.Name = "picRotate";
            this.picRotate.Size = new System.Drawing.Size(55, 55);
            this.picRotate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRotate.TabIndex = 7;
            this.picRotate.TabStop = false;
            // 
            // FrmLottoImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 834);
            this.Controls.Add(this.picRotate);
            this.Controls.Add(this.lVNew);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.lV1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLottoImage";
            this.Text = "FrmLottoImage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLottoImage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRotate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.ListView lV1;
        private System.Windows.Forms.ListView lVNew;
        private System.Windows.Forms.PictureBox picRotate;
        private System.Windows.Forms.ProgressBar pB1;
    }
}