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
    public partial class FrmSaleAdd : Form
    {
        int colRRow = 0, colRDescription = 1, colRRec = 3, colRId = 7, colSaleId = 4, colRLimit = 5, colRDiscount = 6, colSRId = 2;
        LottoryControl lc;
        Sale s;
        public FrmSaleAdd(String saleId)
        {
            InitializeComponent();
            initConfig(saleId);
        }
        private void initConfig(String saleId)
        {
            lc = new LottoryControl();
            s = new Sale();
            setControl(saleId);
            //setGrdRate();
        }
        public void setControl(String saleId)
        {
            s = lc.selectSalebyPk(saleId);
            txtSaleId.Text = s.Id;
            txtSaleCode.Text = s.Code;
            txtSaleName.Text = s.Name;
            txtSaleRemark.Text = s.Remark;
            txtLimit.Text = s.Limit1;
            if (s.Active.Equals("1") || saleId.Equals(""))
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
            if (s.statusDiscount.Equals("1"))
            {
                dgvRate.Visible = true;
                chkDiscount.Checked = true;
            }
            else
            {
                dgvRate.Visible = false;
                chkDiscount.Checked = false;
            }
            setGrdRate();
        }
        private Sale getControl()
        {
            s.Id = txtSaleId.Text;
            s.Code = txtSaleCode.Text;
            s.Name = txtSaleName.Text;
            s.Remark = txtSaleRemark.Text;
            s.Limit1 = txtLimit.Text;
            s.Active = "1";
            if (chkDiscount.Checked)
            {
                s.statusDiscount = "1";
            }
            else
            {
                s.statusDiscount = "0";
            }
            return s;
        }
        private void setGrdRate()
        {
            DataTable dt = new DataTable();
            if (s.statusDiscount.Equals("1"))
            {
                dt = lc.srdb.selectBySale(s.Id);
                if (dt.Rows.Count <= 0)
                {
                    dt = lc.selectRateAlltoSaleRate();
                }                
            }
            else
            {
                dgvRate.Visible = false;
                return;
            }
            
            dgvRate.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvRate.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvRate.RowCount = dt.Rows.Count;
            dgvRate.ColumnCount = 8;
            dgvRate.Columns[colRRow].Width = 50;
            dgvRate.Columns[colRDescription].Width = 150;
            dgvRate.Columns[colRRec].Width = 110;
            dgvRate.Columns[colSaleId].Width = 110;
            dgvRate.Columns[colRDiscount].Width = 100;
            dgvRate.Columns[colRLimit].Width = 120;
            dgvRate.Columns[colRId].Width = 80;
            dgvRate.Columns[colSRId].Width = 110;

            dgvRate.Columns[colRRow].HeaderText = "ลำดับ";
            dgvRate.Columns[colSaleId].HeaderText = "";
            dgvRate.Columns[colRDescription].HeaderText = "รายการ";
            dgvRate.Columns[colRRec].HeaderText = "ซื้อ";
            dgvRate.Columns[colRDiscount].HeaderText = "ส่วนลด";
            dgvRate.Columns[colRLimit].HeaderText = "จำนวนอั้น";
            dgvRate.Columns[colSRId].HeaderText = "";
            dgvRate.Columns[colRId].HeaderText = "id";//

            dgvRate.Columns[colSaleId].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRRec].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRDiscount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colSRId].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRLimit].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;


            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvRate[colRRow, i].Value = (i + 1);
                    dgvRate[colSaleId, i].Value = lc.cf.stringNull1(dt.Rows[i][lc.srdb.sr.SaleId]);
                    dgvRate[colRDescription, i].Value = lc.cf.stringNull1(dt.Rows[i][lc.srdb.sr.Description]);
                    dgvRate[colRRec, i].Value = dt.Rows[i][lc.srdb.sr.rec].ToString();
                    dgvRate[colRLimit, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i][lc.srdb.sr.limit1]);
                    dgvRate[colRDiscount, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i][lc.srdb.sr.discount]);
                    dgvRate[colRId, i].Value = dt.Rows[i][lc.srdb.sr.RateId].ToString();
                    dgvRate[colSRId, i].Value = dt.Rows[i][lc.srdb.sr.Id].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            dgvRate.RowHeadersVisible = false;
            dgvRate.Columns[colRId].Visible = false;
            dgvRate.Columns[colRRow].Visible = false;
            dgvRate.Columns[colSaleId].Visible = false;
            dgvRate.Columns[colSRId].Visible = false;
            dgvRate.Font = font;
            //setDataGrdThoo();
            //setThooAmount();
        }
        private void txtSaleCodeFocus()
        {
            txtSaleCode.SelectAll();
            txtSaleCode.Focus();
        }
        private void txtSaleNameFocus()
        {
            txtSaleName.SelectAll();
            txtSaleName.Focus();
        }
        private void txtSaleRemarkFocus()
        {
            txtSaleRemark.SelectAll();
            txtSaleRemark.Focus();
        }
        private void txtLimitFocus()
        {
            txtLimit.SelectAll();
            txtLimit.Focus();
        }
        private void FrmSaleAdd_Load(object sender, EventArgs e)
        {
            txtSaleCodeFocus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSaleName.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtSaleCode.Text.Equals(""))
            {
                MessageBox.Show("aaa", "aaa");
                return;
            }
            if (txtSaleId.Text.Equals(""))
            {
                s = lc.saledb.selectByCode(txtSaleCode.Text);
                if (!s.Code.Equals(""))
                {
                    MessageBox.Show("รหัสที่สร้างใหม่ มีคนใช้แล้ว\n รหัส"+s.Code+" ชื่อ "+s.Name, "รหัสซ้ำ");
                    return;
                }
            }
            s = getControl();
            if (lc.saveSale(s).Length >= 1)
            {
                for (int i = 0; i < dgvRate.RowCount; i++)
                {
                    SaleRate sr = new SaleRate();
                    sr.SaleId = txtSaleId.Text;
                    sr.Description = dgvRate[colRDescription, i].Value.ToString();
                    sr.rec = dgvRate[colRRec, i].Value.ToString();
                    sr.limit1 = dgvRate[colRLimit, i].Value.ToString();
                    sr.discount = dgvRate[colRDiscount, i].Value.ToString();
                    sr.RateId=dgvRate[colRId, i].Value.ToString();
                    sr.Id=dgvRate[colSRId, i].Value.ToString();
                    sr.Active = "1";

                    lc.srdb.insertSaleRate(sr);
                }
                MessageBox.Show("บันทึกข้อมูล เรียบร้อย", "บันทึกข้อมูล");
                this.Dispose();
                //this.Hide();
            }
        }

        private void txtSaleCode_Enter(object sender, EventArgs e)
        {
            txtSaleCode.BackColor = Color.LightYellow;
        }

        private void txtSaleCode_Leave(object sender, EventArgs e)
        {
            txtSaleCode.BackColor = Color.White;
        }

        private void txtSaleCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSaleNameFocus();
            }
        }

        private void txtSaleName_Enter(object sender, EventArgs e)
        {
            txtSaleName.BackColor = Color.LightYellow;
        }

        private void txtSaleName_Leave(object sender, EventArgs e)
        {
            txtSaleName.BackColor = Color.White;
        }

        private void txtSaleName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSaleRemarkFocus();
            }
        }

        private void txtLimit_Enter(object sender, EventArgs e)
        {
            txtLimit.BackColor = Color.LightYellow;
        }

        private void txtLimit_Leave(object sender, EventArgs e)
        {
            txtLimit.BackColor = Color.White;
        }

        private void txtLimit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkActive.Focus();
            }
        }

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                lc.saledb.VoidSale(txtSaleId.Text);
                this.Dispose();
            }
        }

        private void chkDiscount_Click(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                dgvRate.Visible = true;
                s.statusDiscount = "1";
                setGrdRate();
            }
            else
            {
                dgvRate.Visible = false;
                s.statusDiscount = "0";
            }
        }

        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;

                txtSaleCode.Enabled = false;
                txtSaleName.Enabled = false;
                txtSaleRemark.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                chkDiscount.Enabled = false;
                dgvRate.Enabled = false;
                //dgvRate.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSalmon;
            }
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;

                txtSaleCode.Enabled = true;
                txtSaleName.Enabled = true;
                txtSaleRemark.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                chkDiscount.Enabled = true;
                dgvRate.Enabled = true;
            }
        }
    }
}
