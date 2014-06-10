using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (lc.initC.connectServer.Equals("yes"))
            {
                chkConnectServer.Checked = true;
                txtHost.Text = lc.initC.Host;
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
                chkConnectServer.Checked = false;
                txtDatabase.Visible = false;
                txtHost.Visible = false;
                txtPwd.Visible = false;
                txtUser.Visible = false;
            }
        }
        private void FrmInitConfig_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lc.SetClearInput(chkClearInput.Checked);

            lc.SetConnectServer(chkConnectServer.Checked, txtHost.Text, txtUser.Text, txtPwd.Text);

        }
    }
}
