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
    public partial class FrmThooAdd : Form
    {
        LottoryControl lc;
        Thoo tho;
        public String color = "";
        public FrmThooAdd()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            lc = new LottoryControl();
            tho = new Thoo();
        }
        public void setControl(String sfId)
        {
            tho = lc.selectThoobyPk(sfId);
            txtThooId.Text = tho.Id;
            txtThooCode.Text = tho.Code;
            txtThooName.Text = tho.Name;
            txtThooRemark.Text = tho.Remark;
            txtColor.Text = tho.Color;
            try
            {
                txtColor.BackColor = ColorTranslator.FromHtml(lc.getThooBackColor(tho.Color));
            }
            catch (Exception ex)
            {
            }
            if (tho.Limit1.Equals(""))
            {
                txtLimit.Text = "1,000,000";
            }
            else
            {
                txtLimit.Text = String.Format("{0:#,###,###.00}",Double.Parse(tho.Limit1));
            }

            if (tho.Active.Equals("1") || sfId.Equals(""))
            {
                chkActive.Checked = true;
                ChkUnActive.Checked = false;
                btnUnActive.Visible = false;
            }
            else
            {
                chkActive.Checked = false;
                ChkUnActive.Checked = true;
            }
        }
        private Thoo getControl()
        {
            tho.Id = txtThooId.Text;
            tho.Code = txtThooCode.Text;
            tho.Name = txtThooName.Text;
            tho.Remark = txtThooRemark.Text;
            tho.Limit1 = lc.cf.NumberNull(txtLimit.Text);
            tho.Default = "0";
            tho.Color = txtColor.Text;
            //if (chkActive.Checked)
            //{
            tho.Active = "1";
            //}
            return tho;
        }
        private void txtThooCodeFocus()
        {
            txtThooCode.SelectAll();
            txtThooCode.Focus();
        }
        private void txtThooNameFocus()
        {
            txtThooName.SelectAll();
            txtThooName.Focus();
        }
        private void txtLimitFocus()
        {
            txtLimit.SelectAll();
            txtLimit.Focus();
        }
        private void txtThooRemarkFocus()
        {
            txtThooRemark.SelectAll();
            txtThooRemark.Focus();
        }
        //private void txtThooCodeFocus()
        //{
        //    txtThooCode.SelectAll();
        //    txtThooCode.Focus();
        //}
        private void FrmThooAdd_Load(object sender, EventArgs e)
        {
            txtThooCodeFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtThooName.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtThooCode.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtThooId.Text.Equals(""))
            {
                tho = lc.thodb.selectByCode(txtThooCode.Text);
                if (!tho.Code.Equals(""))
                {
                    MessageBox.Show("aaaa", "aaaa");
                    return;
                }
            }
            tho = getControl();
            //color = tho.Color;
            if (lc.saveThoo(tho).Length >= 1)
            {
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }
        //private void setControlDisAbled()
        //{
        //    cboBrand.Enabled = false;
        //    txtSedanModel.Enabled = false;
        //    txtEngineCC.Enabled = false;
        //    groupBox2.Enabled = false;
        //    txtSedanPriceMin.Enabled = false;
        //    txtSedanPriceMax.Enabled = false;
        //    txtSedanPrice.Enabled = false;
        //    //btnPrint.Enabled = true;
        //    btnSave.Enabled = false;
        //    btnUnActive.Enabled = true;
        //}
        //private void setControlEnAbled()
        //{
        //    cboBrand.Enabled = true;
        //    txtSedanModel.Enabled = true;
        //    txtEngineCC.Enabled = true;
        //    groupBox2.Enabled = true;
        //    txtSedanPriceMin.Enabled = true;
        //    txtSedanPriceMax.Enabled = true;
        //    txtSedanPrice.Enabled = true;
        //    //btnPrint.Enabled = true;
        //    btnSave.Enabled = true;
        //    btnUnActive.Enabled = false;
        //}

        private void txtColor_Click(object sender, EventArgs e)
        {
            //if (colorDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    txtColor.BackColor = colorDialog1.Color;
            //}
        }

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtThooCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtThooNameFocus();
            }
        }

        private void txtThooName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLimitFocus();
            }
        }

        private void txtLimit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtThooRemarkFocus();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtThooCode_Enter(object sender, EventArgs e)
        {
            txtThooCode.BackColor = Color.LightYellow;
        }

        private void txtThooCode_Leave(object sender, EventArgs e)
        {
            txtThooCode.BackColor = Color.White;
        }

        private void txtThooName_Enter(object sender, EventArgs e)
        {
            txtThooName.BackColor = Color.LightYellow;
        }

        private void txtThooName_Leave(object sender, EventArgs e)
        {
            txtThooName.BackColor = Color.White;
        }

        private void txtLimit_Enter(object sender, EventArgs e)
        {
            txtLimit.BackColor = Color.LightYellow;
        }

        private void txtLimit_Leave(object sender, EventArgs e)
        {
            txtLimit.BackColor = Color.White;
        }

        private void txtThooRemark_Enter(object sender, EventArgs e)
        {
            txtThooRemark.BackColor = Color.LightYellow;
        }

        private void txtThooRemark_Leave(object sender, EventArgs e)
        {
            txtThooRemark.BackColor = Color.White;
        }

        private void txtThooRemark_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkActive.Focus();
            }
        }

        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;
                txtColor.Enabled = false;
                txtLimit.Enabled = false;
                txtThooCode.Enabled = false;
                txtThooName.Enabled = false;
                txtThooRemark.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;
                txtColor.Enabled = true;
                txtLimit.Enabled = true;
                txtThooCode.Enabled = true;
                txtThooName.Enabled = true;
                txtThooRemark.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                lc.thodb.VoidThoo(txtThooId.Text);
                this.Dispose();
            }
        }
    }
}
