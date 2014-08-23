using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmInitConfig : Form
    {
        LottoryControl lc;
        Staff sf;
        public FrmInitConfig(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode, l);
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            if (lc.initC.clearInput.Equals("yes"))
            {
                chkClearInput.Checked = true;
            }
            else
            {
                chkClearInput.Checked = false;
            }
            if (lc.initC.StatusServer.Equals("yes"))
            {
                ChkServer.Checked = true;
                gBServer.Visible = true;
                ChkClient.Checked = false;
                gBClient.Visible = false;

                chkConnectServer.Checked = true;
                txtHost.Text = lc.initC.ServerIP;
                txtUser.Text = lc.initC.User;
                txtPwd.Text = lc.initC.Password;
                txtDatabase.Text = lc.initC.Database;
                txtDatabase.Visible = true;
                txtHost.Visible = true;
                txtPwd.Visible = true;
                txtUser.Visible = true;
            }
            else
            {
                ChkServer.Checked = false;
                gBServer.Visible = false;
                ChkClient.Checked = true;
                gBClient.Visible = true;

                chkConnectServer.Checked = false;
                txtDatabase.Visible = false;
                txtHost.Visible = false;
                txtPwd.Visible = false;
                txtUser.Visible = false;
            }

            txtPathImage.Text = lc.initC.pathImage;
            txtPathBefore.Text = lc.initC.pathImageBefore;
            if (lc.initC.delImage.Equals("yes"))
            {
                chkDelImage.Checked = true;
            }
            else
            {
                chkDelImage.Checked = false;
            }
        }
        private void FrmInitConfig_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lc.SetClearInput(chkClearInput.Checked);
            if (ChkServer.Checked)
            {
                lc.SetSetatusServer(true);
                lc.SetPathImage(txtPathImage.Text);
                lc.SetPathImageBefore(txtPathBefore.Text);
                lc.SetDelImage(chkDelImage.Checked);

                lc.SetPathShareImage(txtPathShareImage.Text);
                lc.SetPathShareData(txtPathShareData.Text);
            }
            else
            {
                lc.SetSetatusServer(false);
                lc.SetConnectServer(chkConnectServer.Checked, txtHost.Text, txtUser.Text, txtPwd.Text);
                //lc.SetPathImage(txtPathImage.Text);

                lc.SetPathShareImage(txtConnectShareData.Text);
                lc.SetPathShareData(txtConnectShareImage.Text);
            }
            

            lc.GetConfig();
        }

        private void chkConnectServer_Click(object sender, EventArgs e)
        {
            if (chkConnectServer.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                btnTest.Visible = true;
                lV1.Visible = true;

                txtHost.Visible = true;
                label8.Visible = true;
                label10.Visible = true;
                txtConnectShareData.Visible = true;
                txtConnectShareImage.Visible = true;

                txtDatabase.Visible = true;
                txtUser.Visible = true;
                txtPwd.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                btnTest.Visible = false;
                lV1.Visible = false;

                txtHost.Visible = false;
                label8.Visible = false;
                label10.Visible = false;
                txtConnectShareData.Visible = false;
                txtConnectShareImage.Visible = false;

                txtDatabase.Visible = false;
                txtUser.Visible = false;
                txtPwd.Visible = false;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            //OpenFileDialog theDialog = new OpenFileDialog();
            //theDialog.Title = "Open Path File";
            ////theDialog.Filter = "TXT files|*.txt";
            //theDialog.InitialDirectory = @"C:\";
            //if (theDialog.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show(theDialog.FileName.ToString());
            //}
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            txtPathImage.Text = fbd.SelectedPath;
        }

        private void btnPath1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            txtPathBefore.Text = fbd.SelectedPath;
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            lc.CreateSharedFolder(txtPathImage.Text, txtPathShareImage.Text, txtPathShareImage.Text);
            lc.CreateSharedFolder(Environment.CurrentDirectory + "\\Database\\", txtPathShareData.Text, txtPathShareData.Text);
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            txtIP.Text = lc.LocalIPAddress();
        }

        private void ChkServer_Click(object sender, EventArgs e)
        {
            gBServer.Visible = true;
            gBClient.Visible = false;
        }

        private void ChkClient_Click(object sender, EventArgs e)
        {
            gBServer.Visible = false;
            gBClient.Visible = true;
        }

    }
}
