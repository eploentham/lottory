using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory
{
    public partial class FrmRewardAdd : Form
    {
        LottoryControl lc;
        Staff sf;
        Reward rw;
        Boolean pageLoad = false;
        public FrmRewardAdd(String sfCode)
        {
            InitializeComponent();
            initConfig(sfCode);
        }
        private void initConfig(String sfCode)
        {
            pageLoad = true;
            rw = new Reward();
            String monthId = "", periodId = "";
            //cf = new Config1();
            lc = new LottoryControl();
            sf = lc.sfdb.selectByCode(sfCode);
            //lc.sfdb.sf = sf;
            monthId = System.DateTime.Now.Month.ToString("00");
            //if ((System.DateTime.Now.Day >= 2) && (System.DateTime.Now.Day <= 17))
            //{
            //    cboPeriod.SelectedValue = "02";
            //}
            //else
            //{
            //    cboPeriod.SelectedValue = "01";
            //}

            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            ComboBoxItem cbo = new ComboBoxItem();
            cbo.Value = sf.Id;
            cbo.Text = sf.Name;
            cboStaff.Text = sf.Name;
            setControl();
            pageLoad = false;
        }
        private void setControl()
        {
            rw = lc.selectRewardByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            txtRewardDown2.Text = rw.rewardDown2;
            txtRDown31.Text = rw.rewardDown31;
            txtRDown32.Text = rw.rewardDown32;
            txtRDown33.Text = rw.rewardDown33;
            txtRDown34.Text = rw.rewardDown34;
            txtReward1.Text = rw.reward1;
            txtRewardId.Text = rw.rewardId;
            //rw.dateReward;
        }
        private Reward getControl()
        {
            rw.rewardDown2 = txtRewardDown2.Text;
            rw.rewardDown31 = txtRDown31.Text;
            rw.rewardDown32 = txtRDown32.Text;
            rw.rewardDown33 = txtRDown33.Text;
            rw.rewardDown34 = txtRDown34.Text;
            rw.reward1 = txtReward1.Text;
            rw.rewardId = txtRewardId.Text;
            rw.dateReward = lc.cf.datetoDB();
            rw.yearId = cboYear.Text;
            rw.monthId = cboMonth.SelectedValue.ToString();
            rw.periodId = cboPeriod.SelectedValue.ToString();
            rw.Remark = "";
            rw.staffId = lc.cf.getValueCboItem(cboStaff);
            return rw;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            rw = getControl();            
            if (lc.saveReward(rw).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
            }
        }

        private void txtReward1_Enter(object sender, EventArgs e)
        {
            txtReward1.BackColor = Color.LightYellow;
        }

        private void txtReward1_Leave(object sender, EventArgs e)
        {
            txtReward1.BackColor = Color.White;
        }

        private void txtRewardDown2_Enter(object sender, EventArgs e)
        {
            txtRewardDown2.BackColor = Color.LightYellow;
        }

        private void txtRewardDown2_Leave(object sender, EventArgs e)
        {
            txtRewardDown2.BackColor = Color.White;
        }

        private void txtRDown31_Enter(object sender, EventArgs e)
        {
            txtRDown31.BackColor = Color.LightYellow;
        }

        private void txtRDown31_Leave(object sender, EventArgs e)
        {
            txtRDown31.BackColor = Color.White;
        }

        private void txtRDown32_Enter(object sender, EventArgs e)
        {
            txtRDown32.BackColor = Color.LightYellow;
        }

        private void txtRDown32_Leave(object sender, EventArgs e)
        {
            txtRDown32.BackColor = Color.White;
        }

        private void txtRDown33_Enter(object sender, EventArgs e)
        {
            txtRDown33.BackColor = Color.LightYellow;
        }

        private void txtRDown33_Leave(object sender, EventArgs e)
        {
            txtRDown33.BackColor = Color.White;
        }

        private void txtRDown34_Enter(object sender, EventArgs e)
        {
            txtRDown34.BackColor = Color.LightYellow;
        }

        private void txtRDown34_Leave(object sender, EventArgs e)
        {
            txtRDown34.BackColor = Color.White;
        }

        private void txtRDown31_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRDown31.Text.Length == 3)
            {
                txtRDown32.Focus();
            }
        }

        private void txtRDown31_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRDown32_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRDown33_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRDown34_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRDown32_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRDown32.Text.Length == 3)
            {
                txtRDown33.Focus();
            }
        }

        private void txtRDown33_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRDown33.Text.Length == 3)
            {
                txtRDown34.Focus();
            }
        }

        private void txtRewardDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRewardDown2_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRewardDown2.Text.Length == 2)
            {
                txtRDown31.Focus();
            }
        }

        private void txtReward1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtReward1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtReward1.Text.Length == 6)
            {
                txtRewardDown2.Focus();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl();
            }
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl();
            }
        }

        private void txtRDown34_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtRDown34.Text.Length == 3)
            {
                btnSave.Focus();
            }
        }

        private void FrmRewardAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
