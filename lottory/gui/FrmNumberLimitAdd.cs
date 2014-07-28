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
    public partial class FrmNumberLimitAdd : Form
    {
        LottoryControl lc;
        //DataTable dt;
        Staff sf;
        NumberLimit nl;
        public FrmNumberLimitAdd(String sfCode, LottoryControl l, String nlId)
        {
            InitializeComponent();
            initConfig(sfCode, l, nlId);
        }
        private void initConfig(String sfCode, LottoryControl l, String nlId)
        {
            String monthId = "", periodId = "";
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            monthId = System.DateTime.Now.Month.ToString("00");
            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboYear = lc.cf.setCboYear(cboYear);
            cboMonth.SelectedValue = monthId;
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            setControl(nlId);
        }
        private void setControl(String nlId)
        {
            nl = lc.nldb.selectByPk(nlId);
            txtInput.Text = nl.number;
            
            if (nl.StatusStart.Equals("1"))
            {
                setChkFalse();
                chkImmediately.Checked = true;
                chkPeriod.Checked = false;
            }
            else if (nl.StatusStart.Equals("2"))
            {
                setChkTrue();
                chkPeriod.Checked = true;
                chkPeriod.Checked = false;
                cboYear.Text = nl.yearLimitId;
                cboMonth.Text = lc.cf.getMonth(nl.monthLimitId);
                cboPeriod.Text = lc.cf.getPeriod(nl.periodLimitId);
            }
            else
            {
                setChkFalse();
                chkImmediately.Checked=true;
            }
            txtNlId.Text = nl.Id;
            if (nl.Active.Equals("1") || nlId.Equals(""))
            {
                chkActive.Checked = true;
                ChkUnActive.Checked = false;
                btnUnActive.Visible = false;
            }
            else
            {
                chkActive.Checked = false;
                ChkUnActive.Checked = true;
                btnUnActive.Visible = true;
            }
        }
        private void setNumberLimit()
        {
            nl.number = txtInput.Text;
            if (chkPeriod.Checked)
            {
                nl.StatusStart = "2";
                nl.monthLimitId = cboMonth.SelectedValue.ToString();
                nl.periodLimitId = cboPeriod.SelectedValue.ToString();
                nl.yearLimitId = cboYear.Text;
            }
            else
            {
                nl.StatusStart = "1";
            }
            nl.Active = "1";
            nl.Id = txtNlId.Text;
        }
        private void setChkTrue()
        {
            cboMonth.Visible = true;
            cboYear.Visible = true;
            cboPeriod.Visible = true;
            label14.Visible = true;
        }
        private void setChkFalse()
        {
            cboMonth.Visible = false;
            cboYear.Visible = false;
            cboPeriod.Visible = false;
            label14.Visible = false;
        }
        private void FrmNumberLimitAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            setNumberLimit();
            if (lc.nldb.insertNumberLimit(nl).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
            }
        }

        private void chkImmediately_Click(object sender, EventArgs e)
        {
            setChkFalse();
        }

        private void chkPeriod_Click(object sender, EventArgs e)
        {
            setChkTrue();
            //lc.nldb.insertNumberLimit(nl);
        }

        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;

                txtInput.Enabled = false;
                cboYear.Enabled = false;
                cboMonth.Enabled = false;
                cboPeriod.Enabled = false;
                chkImmediately.Enabled = false;
                chkPeriod.Enabled = false;
                
                btnSave.Enabled = false;
                //btnCancel.Enabled = false;
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;

                txtInput.Enabled = true;
                cboYear.Enabled = true;
                cboMonth.Enabled = true;
                cboPeriod.Enabled = true;
                chkImmediately.Enabled = true;
                chkPeriod.Enabled = true;

                btnSave.Enabled = true;
            }
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                lc.nldb.VoidNUmberLimit(txtNlId.Text);
                this.Dispose();
            }
        }
    }
}
