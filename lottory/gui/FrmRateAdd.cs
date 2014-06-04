using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmRateAdd : Form
    {
        LottoryControl lc;
        Rate rate;
        public FrmRateAdd()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            lc = new LottoryControl();
            rate = new Rate();
        }
        public void setControl(String staffId)
        {
            rate = lc.selectRatebyPk(staffId);
            txtRateId.Text = rate.Id;
            txtDescription.Text = rate.Description;
            txtRec.Text = rate.rec;
            txtPay.Text = rate.pay;
            txtDiscount.Text = rate.discount;
            txtLimit.Text = rate.limit1;
            txtThooId.Text = rate.thooId;
            //if (tho.Active.Equals("1"))
            //{
            //    chkActive.Checked = true;
            //    ChkUnActive.Checked = false;
            //}
            //else
            //{
            //    chkActive.Checked = false;
            //    ChkUnActive.Checked = true;
            //}
        }
        private Rate getControl()
        {
            rate.Id = txtRateId.Text;
            rate.Description = txtDescription.Text;
            rate.rec = txtRec.Text;
            rate.pay = txtPay.Text;
            rate.discount = txtDiscount.Text;
            rate.limit1 = txtLimit.Text;
            rate.thooId = txtThooId.Text;
            //if (chkActive.Checked)
            //{
            rate.Active = "1";
            //}
            return rate;
        }
        private void FrmRateAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDescription.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtRec.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtPay.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtDiscount.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtLimit.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            //if (txtDiscount.Text.Equals(""))
            //{
            //    MessageBox.Show("aaa", "aaa");
            //    return;
            //}
            //if (txtDescription.Text.Equals(""))
            //{
            //    rate = lc.ratedb.selectByCode(txtDescription.Text);
            //    if (!tho.Code.Equals(""))
            //    {
            //        MessageBox.Show("aaaa", "aaaa");
            //        return;
            //    }
            //}
            rate = getControl();
            if (lc.saveRate(rate).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }
    }
}
