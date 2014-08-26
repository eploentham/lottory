using lottory.control;
using lottory.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lottory.gui
{
    public partial class FrmInputApprove : Form
    {
        int row = 0;
        int colLLotId = 0, colLsfId = 1, colLDateTime = 2, colLStatusInput = 3, colLRemark = 4, colLStatusInputId = 6, colLImgId = 5;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5;
        int col1Cnt = 7;
        LottoryControl lc;
        Staff sf;
        Boolean pageLoad = false;

        public FrmInputApprove(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode,l);
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            pageLoad = true;
            String monthId = "", periodId = "";
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            //lc.sfdb.sf = sf;
            monthId = System.DateTime.Now.Month.ToString("00");
            if ((System.DateTime.Now.Day >= 2) && (System.DateTime.Now.Day <= 17))
            {
                cboPeriod.SelectedValue = "02";
            }
            else
            {
                cboPeriod.SelectedValue = "01";
            }
            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboSale = lc.saledb.getCboSale(cboSale);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            ComboBoxItem cbo = new ComboBoxItem();
            cbo.Value = sf.Id;
            cbo.Text = sf.Name;
            cboStaff.Text = sf.Name;
            gBLotto.Visible = false;
            gBLot.Visible = false;
            setGrdLotto();
            setGrid1();
            setDataGrdLotto();
            pageLoad = false;
        }
        private void setGrdLotto()
        {
            dgvLotto.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLotto.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvLotto.ColumnCount = col1Cnt;
            dgvLotto.RowCount = 1;
            row = 0;
            dgvLotto.Columns[colLLotId].Width = 80;
            dgvLotto.Columns[colLsfId].Width = 80;
            dgvLotto.Columns[colLDateTime].Width = 120;
            dgvLotto.Columns[colLStatusInput].Width = 100;
            dgvLotto.Columns[colLRemark].Width = 60;
            dgvLotto.Columns[colLLotId].HeaderText = "Lot Id";
            dgvLotto.Columns[colLsfId].HeaderText = "ผู้ป้อน";
            dgvLotto.Columns[colLDateTime].HeaderText = "วัน เวลา ป้อน";
            dgvLotto.Columns[colLStatusInput].HeaderText = "สถานะป้อน";
            dgvLotto.Columns[colLStatusInputId].Visible = false;
            dgvLotto.Columns[colLImgId].Visible = false;
            dgvLotto.Columns[colLRemark].Visible = false;
            dgvLotto.Font = font;
            dgvLotto.ReadOnly = true;

        }
        private void setGrid1()
        {
            dgv1.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgv1.ColumnCount = col1Cnt;
            dgv1.RowCount = 1;
            row = 0;
            dgv1.Columns[colNumber].Width = 80;
            dgv1.Columns[colUp].Width = 80;
            dgv1.Columns[colTod].Width = 80;
            dgv1.Columns[colDown].Width = 80;
            dgv1.Columns[colLRemark].Width = 60;
            dgv1.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv1.Columns[colUp].HeaderText = "บน";
            dgv1.Columns[colTod].HeaderText = "โต๊ด";
            dgv1.Columns[colDown].HeaderText = "ล่าง";
            dgv1.Columns[colRowId].Visible = false;
            dgv1.Columns[colLottoId1].Visible = false;
            dgv1.Columns[colLRemark].Visible = false;

            dgv1.Font = font;

            //lotNew = true;
        }
        private void setDataGrid1(String number, String numUp, String numTod, String numDown, String rowId, String lottoId)
        {
            dgv1[colLLotId, row].Value = number;
            dgv1[colLsfId, row].Value = numUp;
            dgv1[colLDateTime, row].Value = numTod;
            dgv1[colLStatusInput, row].Value = numDown;
            dgv1[colLStatusInputId, row].Value = rowId;
            dgv1[colLImgId, row].Value = lottoId;

            row++;
        }
        private void setDataGrdLotto(String dateCreate, String sfId, String lotId, String statusInput, String imgId)
        {

            dgvLotto[colLLotId, row].Value = lotId;
            dgvLotto[colLsfId, row].Value = lc.getTextCboItem(lc.cbosf,sfId);
            dgvLotto[colLStatusInput, row].Value = lc.getStatusInput(statusInput);
            dgvLotto[colLImgId, row].Value = imgId;
            dgvLotto[colLStatusInputId, row].Value = statusInput;
            if (!dateCreate.Equals(""))
            {
                dgvLotto[colLDateTime, row].Value = System.DateTime.FromOADate(Double.Parse(dateCreate));
            }
            row++;
        }
        private void setDataGrdLotto()
        {
            dgvLotto.Rows.Clear();
            row = 0;
            gBLot.Visible = false;
            DataTable dt = lc.lotdb.selectByStaffGroupLot(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), lc.cf.getValueCboItem(cboStaff));
            
            if (dt.Rows.Count > 0)
            {
                dgvLotto.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrdLotto(dt.Rows[i][lc.lotdb.lot.CDbl].ToString(), dt.Rows[i][lc.lotdb.lot.staffId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString(),
                        dt.Rows[i][lc.lotdb.lot.statusInput].ToString(), dt.Rows[i][lc.lotdb.lot.imgId].ToString());
                    if ((i % 2) != 0)
                    {
                        dgvLotto.Rows[i].DefaultCellStyle.BackColor = Color.Cornsilk;
                    }
                }
            }
            //dgv1.Enabled = false;
        }
        private void viewImage(String imgId)
        {
            Image1 img = new Image1();
            //txtImgId.Text = name[index];
            //txtIndex.Text = index.ToString();
            img = lc.imgdb.selectByPk(imgId);
            if (img.FLock.Equals("1"))
            {
                MessageBox.Show("viewImage img.FLock", "1111");
                return;
            }
            //lc.imgdb.UpdateLock(txtImgId.Text);

            String pahtFile = lc.initC.pathImage + "\\" + cboYear.Text + "\\" + cboMonth.SelectedValue.ToString() + "\\" + cboPeriod.SelectedValue.ToString();
            //File.
            if (File.Exists(pahtFile + "\\" + imgId+"_1.lotto"))
            {
                //pic1.Image = Image.FromFile(pahtFile + "\\" + name[index]);
                Image im = GetCopyImage(pahtFile + "\\" + imgId + "_1.lotto");
                pic1.Image = im;
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                //picRotate.Visible = true;
                //picZoomM.Visible = true;
                //picZoomP.Visible = true;
                //picHand.Visible = true;
            }
        }
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
        private void setGrid1(String imgId)
        {
            DataTable dt = lc.lotdb.selectByImg(imgId);
            //setGrdLotto();
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //setDataGrid1(dt.Rows[i][lc.lotdb.lot.number].ToString(), dt.Rows[i][lc.lotdb.lot.up].ToString(),
                    //    dt.Rows[i][lc.lotdb.lot.tod].ToString(), dt.Rows[i][lc.lotdb.lot.down].ToString(),
                    //    dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString());
                    dgv1[colNumber, i].Value = dt.Rows[i][lc.lotdb.lot.number].ToString();
                    dgv1[colUp, i].Value = dt.Rows[i][lc.lotdb.lot.up].ToString();
                    dgv1[colTod, i].Value = dt.Rows[i][lc.lotdb.lot.tod].ToString();
                    dgv1[colDown, i].Value = dt.Rows[i][lc.lotdb.lot.down].ToString();
                    dgv1[colLottoId1, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
                    //dgv1[colLottoId1, row].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
                    dgv1[colRowId, i].Value = dt.Rows[i][lc.lotdb.lot.rowId].ToString();
                    //dgv1[colLImgId, row].Value = lottoId;

                    if ((i % 2) != 0)
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
                //lotId1 = lotoId;
                dgv1.ReadOnly = true;
            }
            else
            {
                dgv1.ReadOnly = false;
            }
        }
        private void setLotto(String rowId)
        {
            Lotto lot = new Lotto();
            lot = lc.lotdb.selectByPk(rowId);
            if (!lot.rowId.Equals(""))
            {
                gBLotto.Visible = true;
            }
            else
            {
                gBLotto.Visible = false;
            }
            if (lot.Active.Equals("1"))
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
            txtDown.Text = lot.down;
            txtInput.Text = lot.number;
            txtTod.Text = lot.tod;
            txtUp.Text = lot.up;
            txtRowId.Text = lot.rowId;
        }
        private void viewLotto(String lotoId)
        {
            DataTable dt = lc.lotdb.selectByLot(lotoId);
            setGrid1();
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrid1(dt.Rows[i][lc.lotdb.lot.number].ToString(), dt.Rows[i][lc.lotdb.lot.up].ToString(),
                        dt.Rows[i][lc.lotdb.lot.tod].ToString(), dt.Rows[i][lc.lotdb.lot.down].ToString(),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString());
                }
                //lotId1 = lotoId;
            }
            dgv1.Enabled = false;
        }
        private void FrmInputView_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            setDataGrdLotto();
        }

        private void dgvLotto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgvLotto[colLImgId, e.RowIndex].Value == null)
            {
                return;
            }
            if (dgvLotto[colLStatusInputId, e.RowIndex].Value == null)
            {
                return;
            }
            txtImgId.Text = dgvLotto[colLImgId, e.RowIndex].Value.ToString();
            if (dgvLotto[colLStatusInputId, e.RowIndex].Value.ToString().Equals("2"))
            {
                viewImage(txtImgId.Text);
                setGrid1(txtImgId.Text);
                gBLot.Visible = true;
                chkLotActive.Checked = true;
            }
            else
            {
                viewLotto("");
            }
            
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgv1[colRowId, e.RowIndex].Value == null)
            {
                return;
            }
            //txtLotId.Text = dgv1[colRowId, e.RowIndex].Value.ToString();
            setLotto(dgv1[colRowId, e.RowIndex].Value.ToString());
        }

        private void chkActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = false;
            }
        }

        private void ChkUnActive_Click(object sender, EventArgs e)
        {
            if (ChkUnActive.Checked)
            {
                btnUnActive.Visible = true;
            }
        }

        private void btnUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิก", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                lc.lotdb.VoidRowId(txtRowId.Text, sf.Id);
                txtDown.Text = "";
                txtInput.Text = "";
                txtTod.Text = "";
                txtUp.Text = "";
                setGrid1(txtImgId.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String chk = "";
            if (MessageBox.Show("ต้องการแก้ไขข้อมูล", "แก้ไขข้อมูล", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                chk = lc.lotdb.updateInputApprove(txtRowId.Text, sf.Id, txtInput.Text, txtUp.Text, txtTod.Text, txtDown.Text);
                if(chk.Equals("1"))
                {
                    MessageBox.Show("แก้ไขข้อมูล เรียบร้อย", "แก้ไขข้อมูล");
                    setGrid1(txtImgId.Text);
                }
            }
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setDataGrdLotto();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setDataGrdLotto();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setDataGrdLotto();
            }
        }

        private void chkLotActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnLotUnActive.Visible = false;
            }
        }

        private void chkLotUnActive_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked)
            {
                btnUnActive.Visible = true;
            }
        }

        private void btnLotUnActive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิกทั้งใบ", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                lc.lotdb.VoidLotto(txtLotId.Text, sf.Id);
                txtDown.Text = "";
                txtInput.Text = "";
                txtTod.Text = "";
                txtUp.Text = "";
                setGrid1(txtImgId.Text);
            }
        }

        private void chkLotDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการยกเลิกทั้งใบ และลบภาพด้วย", "ยกเลิก", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                lc.lotdb.VoidLotto(txtLotId.Text, sf.Id);
                txtDown.Text = "";
                txtInput.Text = "";
                txtTod.Text = "";
                txtUp.Text = "";
                setGrid1(txtImgId.Text);
            }
        }
    }
}
