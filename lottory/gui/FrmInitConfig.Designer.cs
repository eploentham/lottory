namespace lottory.gui
{
    partial class FrmInitConfig
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gBClient = new System.Windows.Forms.GroupBox();
            this.chkConnectServer = new System.Windows.Forms.CheckBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lV1 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gBServer = new System.Windows.Forms.GroupBox();
            this.txtPathShareData = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkDelImage = new System.Windows.Forms.CheckBox();
            this.btnPath1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPathBefore = new System.Windows.Forms.TextBox();
            this.txtPathShareImage = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnShare = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPathImage = new System.Windows.Forms.TextBox();
            this.btnIP = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.ChkClient = new System.Windows.Forms.RadioButton();
            this.ChkServer = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkClearInput = new System.Windows.Forms.CheckBox();
            this.txtConnectShareData = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConnectShareImage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gBClient.SuspendLayout();
            this.gBServer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 610);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gBClient);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.gBServer);
            this.groupBox3.Controls.Add(this.ChkClient);
            this.groupBox3.Controls.Add(this.ChkServer);
            this.groupBox3.Location = new System.Drawing.Point(6, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(894, 480);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ใช้งานหลายเครื่อง";
            // 
            // gBClient
            // 
            this.gBClient.Controls.Add(this.txtConnectShareImage);
            this.gBClient.Controls.Add(this.label10);
            this.gBClient.Controls.Add(this.txtConnectShareData);
            this.gBClient.Controls.Add(this.label8);
            this.gBClient.Controls.Add(this.chkConnectServer);
            this.gBClient.Controls.Add(this.txtHost);
            this.gBClient.Controls.Add(this.txtUser);
            this.gBClient.Controls.Add(this.txtPwd);
            this.gBClient.Controls.Add(this.label4);
            this.gBClient.Controls.Add(this.label1);
            this.gBClient.Controls.Add(this.txtDatabase);
            this.gBClient.Controls.Add(this.label2);
            this.gBClient.Controls.Add(this.lV1);
            this.gBClient.Controls.Add(this.label3);
            this.gBClient.Controls.Add(this.btnTest);
            this.gBClient.Location = new System.Drawing.Point(160, 251);
            this.gBClient.Name = "gBClient";
            this.gBClient.Size = new System.Drawing.Size(560, 223);
            this.gBClient.TabIndex = 29;
            this.gBClient.TabStop = false;
            this.gBClient.Text = "Client";
            // 
            // chkConnectServer
            // 
            this.chkConnectServer.AutoSize = true;
            this.chkConnectServer.Location = new System.Drawing.Point(18, 21);
            this.chkConnectServer.Name = "chkConnectServer";
            this.chkConnectServer.Size = new System.Drawing.Size(168, 21);
            this.chkConnectServer.TabIndex = 2;
            this.chkConnectServer.Text = "ต้องการใช้งานหลายเครื่อง";
            this.chkConnectServer.UseVisualStyleBackColor = true;
            this.chkConnectServer.Click += new System.EventHandler(this.chkConnectServer_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(160, 51);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(128, 22);
            this.txtHost.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(105, 161);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(128, 22);
            this.txtUser.TabIndex = 4;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(105, 189);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(128, 22);
            this.txtPwd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "server(IP)";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(105, 133);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(128, 22);
            this.txtDatabase.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "user";
            // 
            // lV1
            // 
            this.lV1.Location = new System.Drawing.Point(383, 120);
            this.lV1.Name = "lV1";
            this.lV1.Size = new System.Drawing.Size(162, 97);
            this.lV1.TabIndex = 10;
            this.lV1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "passwword";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(383, 86);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 32);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "ทดสอบ";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(779, 424);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 50);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "บันทึก";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gBServer
            // 
            this.gBServer.Controls.Add(this.txtPathShareData);
            this.gBServer.Controls.Add(this.label9);
            this.gBServer.Controls.Add(this.chkDelImage);
            this.gBServer.Controls.Add(this.btnPath1);
            this.gBServer.Controls.Add(this.label6);
            this.gBServer.Controls.Add(this.txtPathBefore);
            this.gBServer.Controls.Add(this.txtPathShareImage);
            this.gBServer.Controls.Add(this.btnPath);
            this.gBServer.Controls.Add(this.btnShare);
            this.gBServer.Controls.Add(this.label5);
            this.gBServer.Controls.Add(this.label7);
            this.gBServer.Controls.Add(this.txtPathImage);
            this.gBServer.Controls.Add(this.btnIP);
            this.gBServer.Controls.Add(this.txtIP);
            this.gBServer.Location = new System.Drawing.Point(160, 21);
            this.gBServer.Name = "gBServer";
            this.gBServer.Size = new System.Drawing.Size(728, 224);
            this.gBServer.TabIndex = 28;
            this.gBServer.TabStop = false;
            this.gBServer.Text = "Server";
            // 
            // txtPathShareData
            // 
            this.txtPathShareData.Location = new System.Drawing.Point(160, 155);
            this.txtPathShareData.Name = "txtPathShareData";
            this.txtPathShareData.Size = new System.Drawing.Size(225, 22);
            this.txtPathShareData.TabIndex = 29;
            this.txtPathShareData.Text = "lottory_data";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 17);
            this.label9.TabIndex = 30;
            this.label9.Text = "path share data :";
            // 
            // chkDelImage
            // 
            this.chkDelImage.AutoSize = true;
            this.chkDelImage.Location = new System.Drawing.Point(453, 194);
            this.chkDelImage.Name = "chkDelImage";
            this.chkDelImage.Size = new System.Drawing.Size(175, 21);
            this.chkDelImage.TabIndex = 16;
            this.chkDelImage.Text = "เมื่อนำรูปเข้าระบบ ให้ลบรูป";
            this.chkDelImage.UseVisualStyleBackColor = true;
            // 
            // btnPath1
            // 
            this.btnPath1.Location = new System.Drawing.Point(532, 28);
            this.btnPath1.Name = "btnPath1";
            this.btnPath1.Size = new System.Drawing.Size(29, 32);
            this.btnPath1.TabIndex = 19;
            this.btnPath1.Text = "...";
            this.btnPath1.UseVisualStyleBackColor = true;
            this.btnPath1.Click += new System.EventHandler(this.btnPath1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "path เก็บรูปก่อนเข้าระบบ";
            // 
            // txtPathBefore
            // 
            this.txtPathBefore.Location = new System.Drawing.Point(159, 33);
            this.txtPathBefore.Name = "txtPathBefore";
            this.txtPathBefore.Size = new System.Drawing.Size(366, 22);
            this.txtPathBefore.TabIndex = 17;
            // 
            // txtPathShareImage
            // 
            this.txtPathShareImage.Location = new System.Drawing.Point(160, 99);
            this.txtPathShareImage.Name = "txtPathShareImage";
            this.txtPathShareImage.Size = new System.Drawing.Size(225, 22);
            this.txtPathShareImage.TabIndex = 21;
            this.txtPathShareImage.Text = "lottory_image";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(532, 61);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(29, 32);
            this.btnPath.TabIndex = 15;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(567, 99);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(109, 50);
            this.btnShare.TabIndex = 20;
            this.btnShare.Text = "Share Folder";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "path เก็บรูป :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "path share pic :";
            // 
            // txtPathImage
            // 
            this.txtPathImage.Location = new System.Drawing.Point(160, 66);
            this.txtPathImage.Name = "txtPathImage";
            this.txtPathImage.Size = new System.Drawing.Size(366, 22);
            this.txtPathImage.TabIndex = 13;
            // 
            // btnIP
            // 
            this.btnIP.Location = new System.Drawing.Point(10, 194);
            this.btnIP.Name = "btnIP";
            this.btnIP.Size = new System.Drawing.Size(109, 27);
            this.btnIP.TabIndex = 25;
            this.btnIP.Text = "get IP";
            this.btnIP.UseVisualStyleBackColor = true;
            this.btnIP.Click += new System.EventHandler(this.btnIP_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(160, 196);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(225, 22);
            this.txtIP.TabIndex = 23;
            // 
            // ChkClient
            // 
            this.ChkClient.AutoSize = true;
            this.ChkClient.Location = new System.Drawing.Point(32, 251);
            this.ChkClient.Name = "ChkClient";
            this.ChkClient.Size = new System.Drawing.Size(100, 21);
            this.ChkClient.TabIndex = 27;
            this.ChkClient.TabStop = true;
            this.ChkClient.Text = "เครื่อง Client";
            this.ChkClient.UseVisualStyleBackColor = true;
            this.ChkClient.Click += new System.EventHandler(this.ChkClient_Click);
            // 
            // ChkServer
            // 
            this.ChkServer.AutoSize = true;
            this.ChkServer.Location = new System.Drawing.Point(32, 35);
            this.ChkServer.Name = "ChkServer";
            this.ChkServer.Size = new System.Drawing.Size(107, 21);
            this.ChkServer.TabIndex = 26;
            this.ChkServer.TabStop = true;
            this.ChkServer.Text = "เครื่อง Server";
            this.ChkServer.UseVisualStyleBackColor = true;
            this.ChkServer.Click += new System.EventHandler(this.ChkServer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkClearInput);
            this.groupBox2.Location = new System.Drawing.Point(6, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 108);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "หน้าจอป้อนข้อมูล";
            // 
            // chkClearInput
            // 
            this.chkClearInput.AutoSize = true;
            this.chkClearInput.Location = new System.Drawing.Point(6, 21);
            this.chkClearInput.Name = "chkClearInput";
            this.chkClearInput.Size = new System.Drawing.Size(149, 21);
            this.chkClearInput.TabIndex = 0;
            this.chkClearInput.Text = "ให้ล้างข้อมูลหลังบันทึก";
            this.chkClearInput.UseVisualStyleBackColor = true;
            // 
            // txtConnectShareData
            // 
            this.txtConnectShareData.Location = new System.Drawing.Point(160, 77);
            this.txtConnectShareData.Name = "txtConnectShareData";
            this.txtConnectShareData.Size = new System.Drawing.Size(128, 22);
            this.txtConnectShareData.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "path share data";
            // 
            // txtConnectShareImage
            // 
            this.txtConnectShareImage.Location = new System.Drawing.Point(160, 103);
            this.txtConnectShareImage.Name = "txtConnectShareImage";
            this.txtConnectShareImage.Size = new System.Drawing.Size(128, 22);
            this.txtConnectShareImage.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "path share image";
            // 
            // FrmInitConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 634);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmInitConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInitConfig";
            this.Load += new System.EventHandler(this.FrmInitConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gBClient.ResumeLayout(false);
            this.gBClient.PerformLayout();
            this.gBServer.ResumeLayout(false);
            this.gBServer.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkClearInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkConnectServer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ListView lV1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPathImage;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.CheckBox chkDelImage;
        private System.Windows.Forms.Button btnPath1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPathBefore;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPathShareImage;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnIP;
        private System.Windows.Forms.RadioButton ChkClient;
        private System.Windows.Forms.RadioButton ChkServer;
        private System.Windows.Forms.GroupBox gBServer;
        private System.Windows.Forms.GroupBox gBClient;
        private System.Windows.Forms.TextBox txtPathShareData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtConnectShareData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConnectShareImage;
        private System.Windows.Forms.Label label10;
    }
}