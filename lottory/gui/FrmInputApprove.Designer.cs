﻿namespace lottory.gui
{
    partial class FrmInputApprove
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.dgvLotto = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtImgId = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboStaff = new System.Windows.Forms.ComboBox();
            this.cboSale = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPeriod = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gBLotto = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRowId = new System.Windows.Forms.TextBox();
            this.btnUnActive = new System.Windows.Forms.Button();
            this.ChkUnActive = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.gBLot = new System.Windows.Forms.GroupBox();
            this.chkLotDel = new System.Windows.Forms.RadioButton();
            this.txtLotId = new System.Windows.Forms.TextBox();
            this.btnLotUnActive = new System.Windows.Forms.Button();
            this.chkLotUnActive = new System.Windows.Forms.RadioButton();
            this.chkLotActive = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotto)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gBLotto.SuspendLayout();
            this.gBLot.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv1);
            this.groupBox1.Controls.Add(this.pic1);
            this.groupBox1.Controls.Add(this.dgvLotto);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1658, 700);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgv1
            // 
            this.dgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(1096, 21);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 24;
            this.dgv1.Size = new System.Drawing.Size(605, 702);
            this.dgv1.TabIndex = 41;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // pic1
            // 
            this.pic1.Location = new System.Drawing.Point(523, 21);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(567, 702);
            this.pic1.TabIndex = 4;
            this.pic1.TabStop = false;
            // 
            // dgvLotto
            // 
            this.dgvLotto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotto.Location = new System.Drawing.Point(6, 21);
            this.dgvLotto.Name = "dgvLotto";
            this.dgvLotto.RowTemplate.Height = 24;
            this.dgvLotto.Size = new System.Drawing.Size(511, 673);
            this.dgvLotto.TabIndex = 0;
            this.dgvLotto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLotto_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtImgId);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.cboYear);
            this.groupBox2.Controls.Add(this.cboStaff);
            this.groupBox2.Controls.Add(this.cboSale);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboPeriod);
            this.groupBox2.Controls.Add(this.cboMonth);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1377, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เงื่อนไข";
            // 
            // txtImgId
            // 
            this.txtImgId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtImgId.Location = new System.Drawing.Point(1287, 19);
            this.txtImgId.Name = "txtImgId";
            this.txtImgId.Size = new System.Drawing.Size(39, 34);
            this.txtImgId.TabIndex = 58;
            this.txtImgId.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1035, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(86, 21);
            this.radioButton2.TabIndex = 48;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "แยกตัวเลข";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(967, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 21);
            this.radioButton1.TabIndex = 47;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "รวม";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1185, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 32);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(395, 27);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 28);
            this.cboYear.TabIndex = 45;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // cboStaff
            // 
            this.cboStaff.FormattingEnabled = true;
            this.cboStaff.Location = new System.Drawing.Point(589, 30);
            this.cboStaff.Name = "cboStaff";
            this.cboStaff.Size = new System.Drawing.Size(142, 24);
            this.cboStaff.TabIndex = 26;
            // 
            // cboSale
            // 
            this.cboSale.FormattingEnabled = true;
            this.cboSale.Location = new System.Drawing.Point(808, 30);
            this.cboSale.Name = "cboSale";
            this.cboSale.Size = new System.Drawing.Size(142, 24);
            this.cboSale.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(766, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Sale";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(543, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "ผู้ป้อน";
            // 
            // cboPeriod
            // 
            this.cboPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboPeriod.FormattingEnabled = true;
            this.cboPeriod.Location = new System.Drawing.Point(247, 27);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(142, 28);
            this.cboPeriod.TabIndex = 22;
            this.cboPeriod.SelectedIndexChanged += new System.EventHandler(this.cboPeriod_SelectedIndexChanged);
            // 
            // cboMonth
            // 
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(99, 27);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(142, 28);
            this.cboMonth.TabIndex = 21;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label14.Location = new System.Drawing.Point(6, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "ประจำเดือน";
            // 
            // gBLotto
            // 
            this.gBLotto.Controls.Add(this.btnSave);
            this.gBLotto.Controls.Add(this.txtRowId);
            this.gBLotto.Controls.Add(this.btnUnActive);
            this.gBLotto.Controls.Add(this.ChkUnActive);
            this.gBLotto.Controls.Add(this.chkActive);
            this.gBLotto.Controls.Add(this.label3);
            this.gBLotto.Controls.Add(this.txtDown);
            this.gBLotto.Controls.Add(this.label15);
            this.gBLotto.Controls.Add(this.txtTod);
            this.gBLotto.Controls.Add(this.label2);
            this.gBLotto.Controls.Add(this.txtUp);
            this.gBLotto.Controls.Add(this.label1);
            this.gBLotto.Controls.Add(this.txtInput);
            this.gBLotto.Location = new System.Drawing.Point(1108, 783);
            this.gBLotto.Name = "gBLotto";
            this.gBLotto.Size = new System.Drawing.Size(562, 98);
            this.gBLotto.TabIndex = 2;
            this.gBLotto.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSave.Location = new System.Drawing.Point(6, 60);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRowId
            // 
            this.txtRowId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRowId.Location = new System.Drawing.Point(511, 60);
            this.txtRowId.Name = "txtRowId";
            this.txtRowId.Size = new System.Drawing.Size(39, 34);
            this.txtRowId.TabIndex = 57;
            this.txtRowId.Visible = false;
            // 
            // btnUnActive
            // 
            this.btnUnActive.Location = new System.Drawing.Point(383, 62);
            this.btnUnActive.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnActive.Name = "btnUnActive";
            this.btnUnActive.Size = new System.Drawing.Size(114, 28);
            this.btnUnActive.TabIndex = 56;
            this.btnUnActive.Text = "ยกเลิกการใช้งาน";
            this.btnUnActive.UseVisualStyleBackColor = true;
            this.btnUnActive.Click += new System.EventHandler(this.btnUnActive_Click);
            // 
            // ChkUnActive
            // 
            this.ChkUnActive.AutoSize = true;
            this.ChkUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ChkUnActive.Location = new System.Drawing.Point(263, 63);
            this.ChkUnActive.Name = "ChkUnActive";
            this.ChkUnActive.Size = new System.Drawing.Size(74, 24);
            this.ChkUnActive.TabIndex = 55;
            this.ChkUnActive.TabStop = true;
            this.ChkUnActive.Text = "ยกเลิก";
            this.ChkUnActive.UseVisualStyleBackColor = true;
            this.ChkUnActive.Click += new System.EventHandler(this.ChkUnActive_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkActive.Location = new System.Drawing.Point(110, 63);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(74, 24);
            this.chkActive.TabIndex = 54;
            this.chkActive.TabStop = true;
            this.chkActive.Text = "ใช้งาน";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.Click += new System.EventHandler(this.chkActive_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(425, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "ล่าง ";
            // 
            // txtDown
            // 
            this.txtDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDown.Location = new System.Drawing.Point(470, 14);
            this.txtDown.Name = "txtDown";
            this.txtDown.Size = new System.Drawing.Size(79, 34);
            this.txtDown.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label15.Location = new System.Drawing.Point(292, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "โต๊ด";
            // 
            // txtTod
            // 
            this.txtTod.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTod.Location = new System.Drawing.Point(335, 14);
            this.txtTod.Name = "txtTod";
            this.txtTod.Size = new System.Drawing.Size(79, 34);
            this.txtTod.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(164, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "บน";
            // 
            // txtUp
            // 
            this.txtUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtUp.Location = new System.Drawing.Point(204, 14);
            this.txtUp.Name = "txtUp";
            this.txtUp.Size = new System.Drawing.Size(79, 34);
            this.txtUp.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "ตัวเลข :";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtInput.Location = new System.Drawing.Point(77, 14);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(79, 34);
            this.txtInput.TabIndex = 41;
            // 
            // gBLot
            // 
            this.gBLot.Controls.Add(this.chkLotDel);
            this.gBLot.Controls.Add(this.txtLotId);
            this.gBLot.Controls.Add(this.btnLotUnActive);
            this.gBLot.Controls.Add(this.chkLotUnActive);
            this.gBLot.Controls.Add(this.chkLotActive);
            this.gBLot.Location = new System.Drawing.Point(12, 783);
            this.gBLot.Name = "gBLot";
            this.gBLot.Size = new System.Drawing.Size(509, 73);
            this.gBLot.TabIndex = 3;
            this.gBLot.TabStop = false;
            this.gBLot.Text = "ยกเลิกทั้งใบ";
            // 
            // chkLotDel
            // 
            this.chkLotDel.AutoSize = true;
            this.chkLotDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkLotDel.Location = new System.Drawing.Point(184, 25);
            this.chkLotDel.Name = "chkLotDel";
            this.chkLotDel.Size = new System.Drawing.Size(153, 24);
            this.chkLotDel.TabIndex = 63;
            this.chkLotDel.TabStop = true;
            this.chkLotDel.Text = "ยกเลิก ลบภาพด้วย";
            this.chkLotDel.UseVisualStyleBackColor = true;
            this.chkLotDel.Click += new System.EventHandler(this.chkLotDel_Click);
            // 
            // txtLotId
            // 
            this.txtLotId.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtLotId.Location = new System.Drawing.Point(465, 25);
            this.txtLotId.Name = "txtLotId";
            this.txtLotId.Size = new System.Drawing.Size(39, 34);
            this.txtLotId.TabIndex = 62;
            this.txtLotId.Visible = false;
            // 
            // btnLotUnActive
            // 
            this.btnLotUnActive.Location = new System.Drawing.Point(344, 24);
            this.btnLotUnActive.Margin = new System.Windows.Forms.Padding(4);
            this.btnLotUnActive.Name = "btnLotUnActive";
            this.btnLotUnActive.Size = new System.Drawing.Size(114, 28);
            this.btnLotUnActive.TabIndex = 61;
            this.btnLotUnActive.Text = "ยกเลิกการใช้งาน";
            this.btnLotUnActive.UseVisualStyleBackColor = true;
            this.btnLotUnActive.Click += new System.EventHandler(this.btnLotUnActive_Click);
            // 
            // chkLotUnActive
            // 
            this.chkLotUnActive.AutoSize = true;
            this.chkLotUnActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkLotUnActive.Location = new System.Drawing.Point(99, 25);
            this.chkLotUnActive.Name = "chkLotUnActive";
            this.chkLotUnActive.Size = new System.Drawing.Size(74, 24);
            this.chkLotUnActive.TabIndex = 60;
            this.chkLotUnActive.TabStop = true;
            this.chkLotUnActive.Text = "ยกเลิก";
            this.chkLotUnActive.UseVisualStyleBackColor = true;
            this.chkLotUnActive.Click += new System.EventHandler(this.chkLotUnActive_Click);
            // 
            // chkLotActive
            // 
            this.chkLotActive.AutoSize = true;
            this.chkLotActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.chkLotActive.Location = new System.Drawing.Point(13, 25);
            this.chkLotActive.Name = "chkLotActive";
            this.chkLotActive.Size = new System.Drawing.Size(74, 24);
            this.chkLotActive.TabIndex = 59;
            this.chkLotActive.TabStop = true;
            this.chkLotActive.Text = "ใช้งาน";
            this.chkLotActive.UseVisualStyleBackColor = true;
            this.chkLotActive.Click += new System.EventHandler(this.chkLotActive_Click);
            // 
            // FrmInputApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 893);
            this.Controls.Add(this.gBLot);
            this.Controls.Add(this.gBLotto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmInputApprove";
            this.Text = "หน้าจอยืนยันตัวเลข";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInputView_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotto)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gBLotto.ResumeLayout(false);
            this.gBLotto.PerformLayout();
            this.gBLot.ResumeLayout(false);
            this.gBLot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLotto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboPeriod;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboStaff;
        private System.Windows.Forms.ComboBox cboSale;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.GroupBox gBLotto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.Button btnUnActive;
        private System.Windows.Forms.RadioButton ChkUnActive;
        private System.Windows.Forms.RadioButton chkActive;
        private System.Windows.Forms.TextBox txtRowId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtImgId;
        private System.Windows.Forms.GroupBox gBLot;
        private System.Windows.Forms.TextBox txtLotId;
        private System.Windows.Forms.Button btnLotUnActive;
        private System.Windows.Forms.RadioButton chkLotUnActive;
        private System.Windows.Forms.RadioButton chkLotActive;
        private System.Windows.Forms.RadioButton chkLotDel;
    }
}