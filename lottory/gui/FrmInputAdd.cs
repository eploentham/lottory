using lottory.control;
using lottory.gui;
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

namespace lottory
{
    public partial class FrmInputAdd : Form
    {
        int row = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId=6, colLottoId1=5;
        int col1Cnt = 7;

        int colLottoNumber = 0, colLottoUp=1, colLottoTod=2, colLottoDown=3, colLottoRemark=4, colLottoId=5, colSale=6, colLottoVoid=7;
        int colLottoCnt = 8;
        
        int col3Number = 0, col3Up = 1, col3Down = 2, col3Remark=3;
        int col3Cnt = 4;
        Boolean lotNew = false, clearGrd1 = false, pageLoad = false, txtDownBackFirst = false, txtTodBackFirst = false;
        Staff sf;
        Thoo tho;
        //Config1 cf;
        LottoryControl lc;
        String lotId1 = "";
        Color btnEditColor;
        ComboBox cboSale1;
        //Test1 t;
        
        public FrmInputAdd(String sfCode, LottoryControl l)
        {
            //lc = l;
            pageLoad = true;
            InitializeComponent();
            //lc = l;
            initConfig(sfCode,l);
            pageLoad = false;
        }

        private void initConfig(String sfCode, LottoryControl l)
        {
            String monthId = "", periodId = "";
            //cf = new Config1();
            //lc = new LottoryControl();
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            tho = lc.thodb.selectByDefault();
            //lc.sfdb.sf = sf;
            monthId = System.DateTime.Now.Month.ToString("00");

            setGrid1();
            setGridLotto(1);
            
            //setGrid2();
            //setGrid3();
            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboSale = lc.saledb.getCboSale(cboSale);
            cboSale1 = cboSale;
            cboThoo = lc.thodb.getCboThoo(cboThoo);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            ComboBoxItem cbo = new ComboBoxItem();
            cbo.Value = sf.Id;
            cbo.Text = sf.Name;
            cboStaff.Text = sf.Name;
            cboThoo.Text = tho.Name;
            lotNew = true;
            clearGrd1 = false;
            
            btnEdit.Enabled = false;
            btnEditColor = btnEdit.BackColor;
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            setGridLot();
            label18.Text = "";
        }
        private void ExitApplication()
        {
            Application.Exit();
        }
        private void setGridLotto(int row)
        {
            dgvLotto.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            dgvLotto.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvLotto.ColumnCount = colLottoCnt;
            dgvLotto.RowCount = row;
            row = 0;
            dgvLotto.Columns[colLottoNumber].Width = 150;
            dgvLotto.Columns[colLottoTod].Width = 100;
            dgvLotto.Columns[colLottoUp].Width = 80;
            dgvLotto.Columns[colLottoDown].Width = 80;
            dgvLotto.Columns[colSale].Width = 80;
            dgvLotto.Columns[colLottoRemark].Width = 60;
            dgvLotto.Columns[colLottoVoid].Width = 60;
            dgvLotto.Columns[colLottoNumber].HeaderText = "LOT";
            dgvLotto.Columns[colLottoUp].HeaderText = "รวมบน";
            dgvLotto.Columns[colLottoTod].HeaderText = "รวมโต๊ด";
            dgvLotto.Columns[colLottoDown].HeaderText = "รวมล่าง";
            dgvLotto.Columns[colSale].HeaderText = "sale";
            dgvLotto.Columns[colLottoVoid].HeaderText = "   ";

            dgvLotto.Columns[colLottoUp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvLotto.Columns[colLottoTod].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvLotto.Columns[colLottoDown].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dgvLotto.Columns[colLottoRemark].Visible = false;
            dgvLotto.Columns[colLottoId].Visible = false;
            dgvLotto.Columns[colLottoNumber].Visible = false;

            dgvLotto.ReadOnly = true;

            dgvLotto.Font = font;
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
            dgv1.Columns[colDown].Width=80;
            dgv1.Columns[colRemark].Width = 60;
            dgv1.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv1.Columns[colUp].HeaderText = "บน";
            dgv1.Columns[colTod].HeaderText = "โต๊ด";
            dgv1.Columns[colDown].HeaderText = "ล่าง";
            dgv1.Columns[colRowId].Visible = false;
            dgv1.Columns[colLottoId1].Visible = false;
            dgv1.Columns[colRemark].Visible = false;

            dgv1.Font=font;
            //dgv1[col1Number, 0].Value = "0";
            //dgv1[col1Number, 1].Value = "1";
            //dgv1[col1Number, 2].Value = "2";
            //dgv1[col1Number, 3].Value = "3";
            //dgv1[col1Number, 4].Value = "4";
            //dgv1[col1Number, 5].Value = "5";
            //dgv1[col1Number, 6].Value = "6";
            //dgv1[col1Number, 7].Value = "7";
            //dgv1[col1Number, 8].Value = "8";
            //dgv1[col1Number, 9].Value = "9";
            lotNew = true;
        }
        private void setGrid1(String lotoId)
        {
            DataTable dt = lc.lotdb.selectByLot(lotoId);
            setGrid1();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrid1(dt.Rows[i][lc.lotdb.lot.number].ToString(), dt.Rows[i][lc.lotdb.lot.up].ToString(),
                        dt.Rows[i][lc.lotdb.lot.tod].ToString(), dt.Rows[i][lc.lotdb.lot.down].ToString(), 
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString());
                }
                lotId1 = lotoId;
            }
            dgv1.Enabled = false;
        }
        private void setDataGrid1(String number, String numUp, String numTod, String numDown, String rowId, String lottoId)
        {
            //if (dgv1.Enabled == false)
            //{
            //    return;
            //}
            //dgv1.Rows.Insert(0, 1);
            //dgv1[col1Number, 0].Value = number;
            //dgv1[col1Up, 0].Value = numUp;
            //dgv1[col1Down, 0].Value = numDown;
            dgv1.Rows.Insert(dgv1.RowCount - 1, 1);
            //if ((dgv1.RowCount % 2) != 0)
            //{
            //    dgv1.Rows[dgv1.RowCount-1].DefaultCellStyle.BackColor = Color.DarkKhaki;
            //}
            //int r = 0;
            //r = row;
            
            dgv1[colNumber, row].Value = number;
            dgv1[colUp, row].Value = numUp;
            dgv1[colTod, row].Value = numTod;
            dgv1[colDown, row].Value = numDown;
            dgv1[colRowId, row].Value = rowId;
            dgv1[colLottoId1, row].Value = lottoId;
            dgv1.FirstDisplayedScrollingRowIndex = row;

            row++;
            
            //dgv1.RowCount = dgv1.RowCount + 1;
            

            //DataRow dr = new DataRow();
            //dr[col1Number].Value = "";
        }
        private Lotto setLotto(int row)
        {
            Lotto lot = new Lotto();
            lot.rowNumber=row.ToString();
            lot.Active = "1";
            lot.dateCancel = "";
            lot.dateCreate = "";
            lot.dateModi = "";
            
            
            lot.lottoId = dgv1[colLottoId1, row].Value.ToString();
            lot.yearId = cboYear.Text;
            lot.monthId = cboMonth.SelectedValue.ToString();
                        
            lot.periodId = cboPeriod.SelectedValue.ToString();
            lot.Remark = "";
            lot.rowId = dgv1[colRowId, row].Value.ToString();
            //lot.saleId = cboSale.SelectedValue.ToString();

            lot.saleId = lc.cf.getValueCboItem(cboSale);
            lot.staffId = lc.cf.getValueCboItem(cboStaff);
            lot.thooId = lc.cf.getValueCboItem(cboThoo);
            lot.thooTranferId = lot.thooId;

            lot.staffCancel = "";
            lot.staffCreate = "";

            lot.staffModi = "";
            
            lot.number = lc.cf.LottoNull(dgv1[colNumber, row].Value);
            lot.down = lc.cf.LottoNull(dgv1[colDown, row].Value);
            lot.tod = lc.cf.LottoNull(dgv1[colTod, row].Value);
            lot.up = lc.cf.LottoNull(dgv1[colUp, row].Value);
            lot.statusInput = "1";
            lot.imgId = "";

            return lot;
        }
        private void setGridLot()
        {
            setGridLotto(1);
            ComboBoxItem iStaff = (ComboBoxItem)cboStaff.SelectedItem;
            ComboBoxItem iSale;
            DataTable dt = new DataTable();
            dt = lc.lotdb.selectSumByStaff(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), iStaff.Value);
            if (dt.Rows.Count > 0)
            {
                setGridLotto(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvLotto[colLottoUp, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i]["up11"]);
                    dgvLotto[colLottoDown, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i]["down11"]);
                    dgvLotto[colLottoTod, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i]["tod1"]);

                    dgvLotto[colLottoId, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
                    dgvLotto[colLottoNumber, i].Value = dt.Rows[i][lc.lotdb.lot.lottoId].ToString();
                    iSale = lc.getCboItem(cboSale1, dt.Rows[i][lc.lotdb.lot.saleId].ToString());
                    dgvLotto[colSale, i].Value = iSale.Text;
                    dgvLotto[colLottoVoid, i].Value = "ยกเลิก";
                    if ((i % 2) != 0)
                    {
                        dgvLotto.Rows[i].DefaultCellStyle.BackColor = Color.Cornsilk;
                    }
                }                
            }
        }
        private void setGrdColor()
        {
            String numUp = "", numTod = "", numDown = "";
            Double amt = 0;
            for (int i = 0; i < dgv1.RowCount-1; i++)
            {
                numUp = lc.cf.NumberNull2(dgv1[colUp, i].Value.ToString());
                numTod = lc.cf.NumberNull2(dgv1[colTod, i].Value.ToString());
                numDown = lc.cf.NumberNull2(dgv1[colDown, i].Value.ToString());
                amt += (Double.Parse(numUp) + Double.Parse(numTod) + Double.Parse(numDown));
                if ((i % 2) != 0)
                {
                    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                }
            }
            lbAmt.Text = "รวม : " + amt.ToString();
        }
        private void saveLotto()
        {
            Lotto lot = new Lotto();
            String lotId = "", Cbdl = "";
            //if (lotNew)
            //{
            lotId = lot.getGenID();
            Cbdl = lc.lotdb.selectCDbl();
            //}
            for (int i = 0; i < dgv1.RowCount; i++)
            {
                if (dgv1[colNumber, i].Value == null)
                {
                    continue;
                }
                lot = setLotto(i);
                if (lot.lottoId.Equals(""))
                {
                    if (lotNew)
                    {
                        lot.lottoId = lotId;
                        lot.CDbl = Cbdl;
                    }
                    else
                    {
                        lot.lottoId = lotId1;
                    }
                    
                }
                lc.saveLotto(lot);
                dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
            }
            refresh();
        }
        private void refresh()
        {
            setGrid1();
            setGridLot();
            lotNew = true;
            lotId1 = "";
            btnEdit.Enabled = false;
        }
 
        private void txtInputFocus()
        {
            txtInput.SelectAll();
            txtInput.Focus();
        }
        private void txtDownFocus()
        {
            txtDown.SelectAll();
            txtDown.Focus();
        }
        private void txtUpFocus()
        {
            txtUp.SelectAll();
            txtUp.Focus();
        }
        private void txtTodFocus()
        {
            txtTod.SelectAll();
            txtTod.Focus();
        }
        private void clearInput()
        {
            txtInput.Text = "";
            txtUp.Text = "";
            txtTod.Text = "";
            txtDown.Text = "";
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            txtInputFocus();
        }

        private void FrmInput_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sf.Priority.Equals("1"))
            {
                ExitApplication();
            }            
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtInput.Text.Length > 3)
                {
                    return;
                }
                if (lc.chkNumberLimit(txtInput.Text))
                {
                    label18.Text = "เลขอั้น";
                    return;
                }
                else
                    if (txtInput.Text.Equals(""))
                    {
                        return;
                    }
                {
                    label18.Text = "OK";
                    txtUpFocus();
                }
            }
        }

        private void txtUp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTodBackFirst = true;
                txtTodFocus();
            }
        }

        private void txtDown_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (clearGrd1)
                {
                    setGrid1();
                    clearGrd1 = false;
                }
                if (lc.chkNumberLimit(txtInput.Text))
                {
                    label18.Text = "เลขอั้น";
                    return;
                }
                else
                {
                    label18.Text = "";
                }
                //if (txtInput.Text.Length == 1)
                //{
                    //setDgv1Down();
                if (txtInput.Text.Length <= 0)
                {
                    return;
                }
                else if (txtInput.Text.Length == 1)
                {
                    setDataGrid1(txtInput.Text, txtUp.Text, "0", txtDown.Text, "", "");
                }
                else if (txtInput.Text.Length == 2)
                {
                    setDataGrid1(txtInput.Text, txtUp.Text, "0", txtDown.Text, "", "");
                }
                else 
                {
                    setDataGrid1(txtInput.Text, txtUp.Text, txtTod.Text, txtDown.Text, "", "");
                }
                //setDataGrid1(txtInput.Text, txtUp.Text, txtTod.Text, txtDown.Text,"","");
                setGrdColor();
                txtInputFocus();
                clearInput();
            }
            else if ((e.KeyCode == Keys.Back) && (txtDown.Text.Equals("")))
            {
                if (!txtDownBackFirst)
                {
                    txtTodFocus();
                }
                txtDownBackFirst = false;
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain(this, sf.Code, lc);
            frm.Show();
            this.Hide();
        }

        private void txtTod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDownBackFirst = true;
                txtDownFocus();
            }
            else if ((e.KeyCode == Keys.Back) && (txtTod.Text.Equals("")))
            {
                if (!txtTodBackFirst)
                {
                    txtTodFocus();
                }
                txtTodBackFirst = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            btnSave.Enabled = false;
            saveLotto();
            row = 0;
            btnSave.Enabled = true;
            Cursor.Current = cursor;
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain(this,sf.Code, lc);
            frm.Show();
            this.Hide();
        }

        private void dgvLotto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLotto[colLottoId, e.RowIndex].Value == null)
            {
                return;
            }
            if (e.ColumnIndex == colLottoVoid)
            {
                if (MessageBox.Show("ยกเลิก", "ต้องการยกเลิกทั้งใบ",  MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    lc.lotdb.VoidLotto(dgvLotto[colLottoId, e.RowIndex].Value.ToString(), sf.Id);
                    refresh();
                }
            }
            else
            {
                setGrid1(dgvLotto[colLottoId, e.RowIndex].Value.ToString());
                setGrdColor();
                clearGrd1 = true;
                btnEdit.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.BackColor == btnEditColor)
            {
                btnEdit.BackColor = Color.FromArgb(171, 214, 121);
            }
            else
            {
                btnEdit.BackColor = btnEditColor;
                lotId1 = "";
            }
            
            //if (btnEdit.Text.Equals("แก้ไข"))
            //{
            //    btnEdit.Text = "ป้อนใหม่";
            //    lotNew = false;
            //}
            //else
            //{
            //    btnEdit.Text = "แก้ไข";
            //    lotNew = true;
            //}
            dgv1.Enabled = true;
            lotNew = false;
            clearGrd1 = false;
        }

        private void txtInput_Enter(object sender, EventArgs e)
        {
            txtInput.BackColor = Color.LightYellow;
        }

        private void txtInput_Leave(object sender, EventArgs e)
        {
            txtInput.BackColor = Color.White;
        }

        private void txtUp_Enter(object sender, EventArgs e)
        {
            txtUp.BackColor = Color.LightYellow;
        }

        private void txtUp_Leave(object sender, EventArgs e)
        {
            txtUp.BackColor = Color.White;
        }

        private void txtTod_Enter(object sender, EventArgs e)
        {
            txtTod.BackColor = Color.LightYellow;
        }

        private void txtTod_Leave(object sender, EventArgs e)
        {
            txtTod.BackColor = Color.White;
        }

        private void txtDown_Enter(object sender, EventArgs e)
        {
            txtDown.BackColor = Color.LightYellow;
        }

        private void txtDown_Leave(object sender, EventArgs e)
        {
            txtDown.BackColor = Color.White;
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.End:
                    // ... Process Shift+Ctrl+Alt+B ...
                    Cursor cursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    btnSave.Enabled = false;
                    saveLotto();
                    row = 0;
                    btnSave.Enabled = true;
                    Cursor.Current = cursor;
                    return true; // signal that we've processed this key
                case Keys.Insert:
                    txtInputFocus();
                    return true;
            }
            // run base implementation
            return base.ProcessCmdKey(ref message, keys);
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setGridLot();
            }            
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setGridLot();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setGridLot();
            }
        }
    }
}
