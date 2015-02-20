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
            this.cboSale = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBrowe = new System.Windows.Forms.Button();
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
            this.cboThoo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRotate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboThoo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cboSale);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnBrowe);
            this.groupBox1.Controls.Add(this.pB1);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.cboPeriod);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(9, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1353, 76);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboSale
            // 
            this.cboSale.FormattingEnabled = true;
            this.cboSale.Location = new System.Drawing.Point(463, 22);
            this.cboSale.Margin = new System.Windows.Forms.Padding(2);
            this.cboSale.Name = "cboSale";
            this.cboSale.Size = new System.Drawing.Size(108, 21);
            this.cboSale.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(416, 26);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Sale :";
            // 
            // btnBrowe
            // 
            this.btnBrowe.Location = new System.Drawing.Point(898, 15);
            this.btnBrowe.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowe.Name = "btnBrowe";
            this.btnBrowe.Size = new System.Drawing.Size(28, 33);
            this.btnBrowe.TabIndex = 64;
            this.btnBrowe.Text = "...";
            this.btnBrowe.UseVisualStyleBackColor = true;
            this.btnBrowe.Click += new System.EventHandler(this.btnBrowe_Click);
            // 
            // pB1
            // 
            this.pB1.Location = new System.Drawing.Point(4, 53);
            this.pB1.Margin = new System.Windows.Forms.Padding(2);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(1024, 19);
            this.pB1.TabIndex = 63;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(1134, 15);
            this.btnInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(76, 33);
            this.btnInit.TabIndex = 62;
            this.btnInit.Text = "กำหนดค่า";
            this.btnInit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(969, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 33);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(817, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 33);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "ดึงรูป";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(330, 20);
            this.cboYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(75, 25);
            this.cboYear.TabIndex = 53;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // cboPeriod
            // 
            this.cboPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(219, 20);
            this.cboPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(108, 25);
            this.cboPeriod.TabIndex = 52;
            this.cboPeriod.SelectedIndexChanged += new System.EventHandler(this.cboPeriod_SelectedIndexChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(94, 20);
            this.cboMonth.Margin = new System.Windows.Forms.Padding(2);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(108, 25);
            this.cboMonth.TabIndex = 51;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(14, 22);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 50;
            this.label14.Text = "ประจำเดือน";
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(1220, 83);
            this.pic1.Margin = new System.Windows.Forms.Padding(2);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(533, 672);
            this.pic1.TabIndex = 5;
            this.pic1.TabStop = false;
            // 
            // lV1
            // 
            this.lV1.Location = new System.Drawing.Point(9, 83);
            this.lV1.Margin = new System.Windows.Forms.Padding(2);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(594, 878);
            this.lV1.TabIndex = 4;
            this.lV1.UseCompatibleStateImageBehavior = false;
            this.lV1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lV1_MouseClick);
            // 
            // lVNew
            // 
            this.lVNew.Location = new System.Drawing.Point(619, 83);
            this.lVNew.Margin = new System.Windows.Forms.Padding(2);
            this.lVNew.Name = "lVNew";
            this.lVNew.Size = new System.Drawing.Size(594, 878);
            this.lVNew.TabIndex = 6;
            this.lVNew.UseCompatibleStateImageBehavior = false;
            this.lVNew.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lVNew_MouseClick);
            // 
            // picRotate
            // 
            this.picRotate.Image = global::lottory.Properties.Resources.rotate2;
            this.picRotate.Location = new System.Drawing.Point(1595, 33);
            this.picRotate.Margin = new System.Windows.Forms.Padding(2);
            this.picRotate.Name = "picRotate";
            this.picRotate.Size = new System.Drawing.Size(41, 45);
            this.picRotate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRotate.TabIndex = 7;
            this.picRotate.TabStop = false;
            // 
            // cboThoo
            // 
            this.cboThoo.FormattingEnabled = true;
            this.cboThoo.Location = new System.Drawing.Point(647, 22);
            this.cboThoo.Margin = new System.Windows.Forms.Padding(2);
            this.cboThoo.Name = "cboThoo";
            this.cboThoo.Size = new System.Drawing.Size(108, 21);
            this.cboThoo.TabIndex = 66;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(600, 26);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 65;
            this.label16.Text = "เจ้ามือ :";
            // 
            // FrmLottoImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1764, 972);
            this.Controls.Add(this.picRotate);
            this.Controls.Add(this.lVNew);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.lV1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Button btnBrowe;
        private System.Windows.Forms.ComboBox cboSale;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboThoo;
        private System.Windows.Forms.Label label16;
    }
}