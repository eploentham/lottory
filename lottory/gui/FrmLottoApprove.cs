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
    public partial class FrmLottoApprove : Form
    {
        //int row = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5, colUse1 = 7, colStatusOL = 8, colOLUp = 9, colOLTod=10, colOLDown=11;
        int colRateId = 12, colThooTranferId = 13, colThooTranferName= 14;
        int col1Cnt = 15;
        int colTRow=0, colTName = 1, colTLimit = 2, colTAmt = 3, colTId=4;
        int colRRow = 0, colRDescription = 1, colRRec = 3, colRId = 7, colRpay = 4, colRLimit = 5, colRDiscount = 6, colRAmt=2;
        LottoryControl lc;
        Staff sf;
        Reward rw;
        public static String thooId = "";
        ComboBoxItem cItem;

        public FrmLottoApprove(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            
            initConfig(sfCode,l);
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            rw = new Reward();
            cboThoo = new ComboBox();
            
            cItem = new ComboBoxItem();
            String monthId = "", periodId = "";

            lc = l;
            cboThoo = lc.thodb.getCboThoo(cboThoo);
            sf = lc.sfdb.selectByCode(sfCode);
            //lc.sfdb.sf = sf;
            monthId = System.DateTime.Now.Month.ToString("00");

            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            //cboStaff = lc.sfdb.getCboStaff(cboStaff);

            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);

            setControl();
            setGrid(dgv1);
            //setGrid(dgv3);
            setGrdThoo();
            setGrdRate();
            dgv1.ReadOnly = true;
            dgvThooTranfer.ReadOnly = true;
            dgvRate.ReadOnly = true;
            txtAmt.ReadOnly = true;
            txtDown.ReadOnly = true;
            txtUp.ReadOnly = true;
            txtTod.ReadOnly = true;
            txtTho.ReadOnly = true;
            txtNetTotal.ReadOnly = true;
            setGrd2();
            if (dgv1.Rows.Count > 1)
            {
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
                btnVoid.Visible = true;
            }
            else
            {
                btnVoid.Visible = false;
            }
            pB1.Visible = false;
            //dgvRate.Hide();
        }
        private void setControl()
        {
            //rw = lc.selectRewardByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            //txtRewardDown2.Text = rw.rewardDown2;
            //txtRewardDown3.Text = rw.rewardDown3;
            //txtReward1.Text = rw.reward1;
            //txtRewardId.Text = rw.rewardId;
            //rw.dateReward;
        }
        private void setGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);

            //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgv.ColumnCount = col1Cnt;
            dgv.RowCount = 1;
            //row = 0;
            dgv.Columns[colNumber].Width = 80;
            dgv.Columns[colUp].Width = 80;
            dgv.Columns[colTod].Width = 80;
            dgv.Columns[colDown].Width = 80;
            dgv.Columns[colUse1].Width = 90;
            dgv.Columns[colStatusOL].Width = 80;
            dgv.Columns[colOLUp].Width = 110;
            dgv.Columns[colRemark].Width = 80;
            dgv.Columns[colRateId].Width = 60;
            dgv.Columns[colThooTranferName].Width = 100;

            dgv.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv.Columns[colUp].HeaderText = "บน";
            dgv.Columns[colTod].HeaderText = "โต๊ด";
            dgv.Columns[colDown].HeaderText = "ล่าง";
            dgv.Columns[colUse1].HeaderText = "ยอดเงิน";
            dgv.Columns[colStatusOL].HeaderText = "สถานะ";
            dgv.Columns[colOLUp].HeaderText = "เกิน.(บน)";
            dgv.Columns[colOLTod].HeaderText = "เกิน.(โต๊ด)";
            dgv.Columns[colOLDown].HeaderText = "เกิน.(ล่าง)";
            dgv.Columns[colThooTranferName].HeaderText = "ส่งต่อให้";

            dgv.Columns[colUp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colTod].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colDown].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colUse1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colOLUp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colOLTod].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colOLDown].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dgv.Columns[colRowId].Visible = false;
            dgv.Columns[colThooTranferId].Visible = false;
            dgv.Columns[colLottoId1].Visible = false;
            dgv.Columns[colRemark].Visible = false;
            dgv.Columns[colRateId].Visible = false;
            dgv.Columns[colStatusOL].Visible = false;

            dgv.Font = font;
        }
        private void setGrdThoo()
        {
            dgvThooTranfer.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvThooTranfer.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvThooTranfer.ColumnCount = 5;
            dgvThooTranfer.RowCount = 1;
            dgvThooTranfer.Columns[colTName].Width = 100;
            dgvThooTranfer.Columns[colTLimit].Width = 110;
            dgvThooTranfer.Columns[colTAmt].Width = 110;

            dgvThooTranfer.Columns[colTRow].HeaderText = "ลำดับ";
            dgvThooTranfer.Columns[colTName].HeaderText = "เจ้ามือ";
            dgvThooTranfer.Columns[colTLimit].HeaderText = "อั้น";
            dgvThooTranfer.Columns[colTAmt].HeaderText = "รวมเงิน";

            dgvThooTranfer.Columns[colTLimit].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvThooTranfer.Columns[colTAmt].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dgvThooTranfer.RowHeadersVisible = false;
            dgvThooTranfer.Columns[colTId].Visible = false;
            dgvThooTranfer.Columns[colTRow].Visible = false;

            dgvThooTranfer.Font = font;
            setDataGrdThoo();
            //setThooAmount();
        }
        private void setGrdRate()
        {
            DataTable dt = new DataTable();
            dt = lc.selectRateAll();
            dgvRate.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvRate.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvRate.RowCount = dt.Rows.Count;
            dgvRate.ColumnCount = 8;
            dgvRate.Columns[colRRow].Width = 50;
            dgvRate.Columns[colRDescription].Width = 150;
            dgvRate.Columns[colRRec].Width = 110;
            dgvRate.Columns[colRpay].Width = 110;
            dgvRate.Columns[colRDiscount].Width = 100;
            dgvRate.Columns[colRLimit].Width = 120;
            dgvRate.Columns[colRId].Width = 80;
            dgvRate.Columns[colRAmt].Width = 110;

            dgvRate.Columns[colRRow].HeaderText = "ลำดับ";
            dgvRate.Columns[colRpay].HeaderText = "จ่าย";
            dgvRate.Columns[colRDescription].HeaderText = "รายการ";
            dgvRate.Columns[colRRec].HeaderText = "ซื้อ";
            dgvRate.Columns[colRDiscount].HeaderText = "ส่วนลด";
            dgvRate.Columns[colRLimit].HeaderText = "จำนวนอั้น";
            dgvRate.Columns[colRAmt].HeaderText = "ยอดเงิน";
            dgvRate.Columns[colRId].HeaderText = "id";//

            dgvRate.Columns[colRpay].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRRec].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRDiscount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRAmt].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRLimit].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;            

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvRate[colRRow, i].Value = (i + 1);
                    dgvRate[colRpay, i].Value = dt.Rows[i][lc.ratedb.rate.pay].ToString();
                    dgvRate[colRDescription, i].Value = dt.Rows[i][lc.ratedb.rate.Description].ToString();
                    dgvRate[colRRec, i].Value = dt.Rows[i][lc.ratedb.rate.rec].ToString();
                    dgvRate[colRLimit, i].Value = dt.Rows[i][lc.ratedb.rate.limit1].ToString();
                    dgvRate[colRDiscount, i].Value = dt.Rows[i][lc.ratedb.rate.discount].ToString();
                    dgvRate[colRId, i].Value = dt.Rows[i][lc.ratedb.rate.Id].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            dgvRate.RowHeadersVisible = false;
            dgvRate.Columns[colRId].Visible = false;
            dgvRate.Columns[colRRow].Visible = false;

            dgvRate.Font = font;
            //setDataGrdThoo();
            //setThooAmount();
        }
        private void setDataGrdThoo()
        {
            DataTable dt = new DataTable();
            dt = lc.selectThooAll();
            dgvThooTranfer.RowCount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        dgvThooTranfer[colTRow, i].Value = (i + 1);
                        dgvThooTranfer[colTName, i].Value = dt.Rows[i][lc.thodb.tho.Name].ToString();
                        dgvThooTranfer[colTLimit, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i][lc.thodb.tho.Limit1]);
                        dgvThooTranfer[colTAmt, i].Value = "";
                        dgvThooTranfer[colTId, i].Value = dt.Rows[i][lc.thodb.tho.Id].ToString();
                        dgvThooTranfer.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(lc.getThooBackColor(dt.Rows[i][lc.thodb.tho.Color].ToString()));
                    }
                    catch (Exception ex)
                    {
                    }
                    //if ((i % 2) != 0)
                    //{
                    //    dgvThoo.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    //}
                }
            }
        }
        private void setRateAmount()
        {
            String rateId = "", rate1Id = "", num="";
            double up = 0, up2=0, down2=0, up3=0,down3=0, tod3=0;
            for (int j = 0; j < dgv1.RowCount; j++)
            {
                if (dgv1[colNumber, j].Value == null)
                {
                    continue;
                }
                num = dgv1[colNumber, j].Value.ToString();
                if (num.Length == 1)
                {
                    up += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
                }
                else if (num.Length == 2)
                {
                    up2 += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
                    down2 += Double.Parse(lc.cf.NumberNull(dgv1[colDown, j].Value));
                }
                else if (num.Length == 3)
                {
                    up3 += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
                    down3 += Double.Parse(lc.cf.NumberNull(dgv1[colDown, j].Value));
                    tod3 += Double.Parse(lc.cf.NumberNull(dgv1[colTod, j].Value));
                }
            }
            for (int i = 0; i < dgvRate.RowCount; i++)
            {
                if (dgvRate[colRId, i].Value == null)
                {
                    continue;
                }
                rateId = dgvRate[colRId, i].Value.ToString();
                if (rateId.Equals("2down"))
                {
                    dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",down2);
                }
                else if (rateId.Equals("2up"))
                {
                    dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",up2);
                }
                else if (rateId.Equals("3down"))
                {
                    dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",down3);
                }
                else if (rateId.Equals("3tod"))
                {
                    dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",tod3);
                }
                else if (rateId.Equals("3up"))
                {
                    dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",up3);
                }
            }
        }
        private void setThooAmount()
        {
            double amt = 0;
            String thooId = "", thoo1Id="";
            Font font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            for (int i = 0; i < dgvThooTranfer.RowCount; i++)
            {
                amt = 0;
                if (dgvThooTranfer[colTId, i].Value == null)
                {
                    continue;
                }
                thooId = dgvThooTranfer[colTId, i].Value.ToString();
                for (int j = 0; j < dgv1.RowCount; j++)
                {
                    if (dgv1[colThooTranferId, j].Value == null)
                    {
                        continue;
                    }
                    thoo1Id = dgv1[colThooTranferId, j].Value.ToString();
                    if (thooId.Equals(thoo1Id))
                    {
                        amt += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
                        amt += Double.Parse(lc.cf.NumberNull(dgv1[colTod, j].Value));
                        amt += Double.Parse(lc.cf.NumberNull(dgv1[colDown, j].Value));
                    }
                }
                if (amt >= Double.Parse(lc.cf.NumberNull(dgvThooTranfer[colTLimit, i].Value)))
                {
                    dgvThooTranfer[colTAmt, i].Style.Font = font;
                    dgvThooTranfer[colTAmt, i].Style.ForeColor = Color.Red;
                }
                
                dgvThooTranfer[colTAmt, i].Value = String.Format("{0:#,###,###.00}",amt);

            }
        }
        private void setDataGrid1(DataGridView dgv, int row, String number, Double numUp, Double numTod, Double numDown, String rowId,
            String lottoId, String use1, String statusOL, String OLUp, String OLTod, String OLDown, String thooTranferId)
        {
            if (dgv.Enabled == false)
            {
                return;
            }
            if (dgv1.RowCount <= row)
            {
                return;
            }

            dgv[colNumber, row].Value = number;
            dgv[colUp, row].Value = String.Format("{0:#,###,###.00}",numUp);
            dgv[colTod, row].Value = String.Format("{0:#,###,###.00}",numTod);
            dgv[colDown, row].Value = String.Format("{0:#,###,###.00}",numDown);
            dgv[colRowId, row].Value = rowId;
            dgv[colLottoId1, row].Value = lottoId;
            dgv[colUse1, row].Value = use1;
            dgv[colStatusOL, row].Value = statusOL;
            if (OLUp.Equals("0.00"))
            {
                dgv[colOLUp, row].Value = "";
            }
            else
            {
                dgv[colOLUp, row].Value = OLUp;
            }
            if (OLTod.Equals("0.00"))
            {
                dgv[colOLTod, row].Value = "";
            }
            else
            {
                dgv[colOLTod, row].Value = OLTod;
            }
            if (OLDown.Equals("0.00"))
            {
                dgv[colOLDown, row].Value = "";
            }
            else
            {
                dgv[colOLDown, row].Value = OLDown;
            }
            
            dgv[colThooTranferId, row].Value = thooTranferId;
            cItem = lc.getCboItem(cboThoo, thooTranferId);
            dgv[colThooTranferName, row].Value = cItem.Text;
            //row++;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            setGrd1();
        }
        private void setGrd2()
        {
            Font font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            Font fontStrike = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
            double up = 0, tod = 0, down = 0, amt = 0;
            DataTable dt = new DataTable();
            Thoo t = new Thoo();
            dt = lc.lotdb.selectApprovedByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        setDataGrid1(dgv1, i, dt.Rows[i][lc.lotdb.lot.number].ToString(), Double.Parse(dt.Rows[i][lc.lotdb.lot.up].ToString()),
                        Double.Parse(dt.Rows[i][lc.lotdb.lot.tod].ToString()), Double.Parse(dt.Rows[i][lc.lotdb.lot.down].ToString()),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString(), dt.Rows[i][lc.lotdb.lot.use1].ToString(),
                        dt.Rows[i][lc.lotdb.lot.statusOverLimit].ToString(), dt.Rows[i][lc.lotdb.lot.OLUp].ToString(), dt.Rows[i][lc.lotdb.lot.OLTod].ToString(), dt.Rows[i][lc.lotdb.lot.OLDown].ToString(),
                        dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString());
                        up += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.up]));
                        tod += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.tod]));
                        down += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.down]));
                        //amt += up + tod + down;
                        t = lc.getThoo(dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString());
                        if (dgv1[colThooTranferId, i].Value.ToString().Length > 0)
                        {
                            dgv1.Rows[i].DefaultCellStyle.Font = fontStrike;
                        }
                        if (dgv1[colStatusOL, i].Value.ToString().Equals("1"))
                        {
                            dgv1[colOLUp, i].Style.Font = font;
                            dgv1[colOLUp, i].Style.ForeColor = Color.Red;
                            dgv1[colOLTod, i].Style.Font = font;
                            dgv1[colOLTod, i].Style.ForeColor = Color.Red;
                            dgv1[colOLDown, i].Style.Font = font;
                            dgv1[colOLDown, i].Style.ForeColor = Color.Red;
                        }
                        if (dgv1[colNumber, i].Value.ToString().Length == 1)
                        {
                            dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                        }
                        else if (dgv1[colNumber, i].Value.ToString().Length == 2)
                        {
                            dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                        }
                        else if (dgv1[colNumber, i].Value.ToString().Length == 3)
                        {
                            dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                        }
                        //c = ColorTranslator.FromHtml(t.Color);
                        //dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(lc.getThooBackColor(t.Color));
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            txtUp.Text = String.Format("{0:#,###,###.00}", up);
            txtTod.Text = String.Format("{0:#,###,###.00}", tod);
            txtDown.Text = String.Format("{0:#,###,###.00}", down);
            txtAmt.Text = String.Format("{0:#,###,###.00}", (up + tod + down));
            setThooAmount();
            setRateAmount();
        }
        private void setGrd1()
        {
            double up = 0, tod = 0, down = 0, amt = 0;
            DataTable dt = new DataTable();
            dgv1.Rows.Clear();
            //Color c = new Color();
            dgv1.Visible = false;
            
            Thoo t = new Thoo();
            dt = lc.lotdb.selectByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        setDataGrid1(dgv1, i, dt.Rows[i][lc.lotdb.lot.number].ToString(), Double.Parse(dt.Rows[i][lc.lotdb.lot.up].ToString()),
                        Double.Parse(dt.Rows[i][lc.lotdb.lot.tod].ToString()), Double.Parse(dt.Rows[i][lc.lotdb.lot.down].ToString()),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString(), "", "", "", "", "",
                        dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString());
                        up += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.up]));
                        tod += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.tod]));
                        down += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.down]));
                        //amt += up + tod + down;
                        t = lc.getThoo(dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString());
                        //c = ColorTranslator.FromHtml(t.Color);
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(lc.getThooBackColor(t.Color));
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            txtUp.Text = String.Format("{0:#,###,###.00}", up);
            txtTod.Text = String.Format("{0:#,###,###.00}", tod);
            txtDown.Text = String.Format("{0:#,###,###.00}", down);
            txtAmt.Text = String.Format("{0:#,###,###.00}", (up + tod + down));
            dgv1.Visible = true;
            setApprove();
            setThooAmount();
            setRateAmount();
        }
        private void setApprove()
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            Font font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            Font fontStrike = new Font("Microsoft Sans Serif", 12, FontStyle.Strikeout);
            Rate r2Up = new Rate();
            Rate r3Up = new Rate();
            Rate r3Tod = new Rate();
            Rate r2Down = new Rate();
            Rate r3Down = new Rate();
            Rate rUp = new Rate();
            String num = "", up = "", down = "", tod = "";
            Decimal up1 = 0, limitUp1 = 0, useUp1 = 0, overLimit1 = 0;
            Decimal up2 = 0, limitUp2 = 0, useUp2 = 0, overLimit2 = 0;
            Decimal down2 = 0, limitDown2 = 0, useDown2 = 0, overLimitD2 = 0;
            Decimal up3 = 0, limitUp3 = 0, useUp3 = 0, overLimit3 = 0,tod3=0, limitTod3=0;
            Decimal down3 = 0, limitDown3 = 0, useDown3 = 0, overLimitD3 = 0, useTod3=0;

            if (!lc.fldb.setLock(sf.Id))
            {
                MessageBox.Show("setApprove", "aaaa");
                return;
            }
            r2Up = lc.ratedb.selectByPk("2up");
            r3Up = lc.ratedb.selectByPk("3up");
            r3Tod = lc.ratedb.selectByPk("3tod");
            r2Down = lc.ratedb.selectByPk("2down");
            r3Down = lc.ratedb.selectByPk("3down");
            rUp = lc.ratedb.selectByPk("up");

            useUp1 = Decimal.Parse(lc.cf.NumberNull(rUp.use1));
            limitUp1 = Decimal.Parse(lc.cf.NumberNull(rUp.limit1));

            useUp2 = Decimal.Parse(lc.cf.NumberNull(r2Up.use1));
            limitUp2 = Decimal.Parse(lc.cf.NumberNull(r2Up.limit1));
            useDown2 = Decimal.Parse(lc.cf.NumberNull(r2Down.use1));
            limitDown2 = Decimal.Parse(lc.cf.NumberNull(r2Down.limit1));

            useUp3 = Decimal.Parse(lc.cf.NumberNull(r3Up.use1));
            limitUp3 = Decimal.Parse(lc.cf.NumberNull(r3Up.limit1));
            useDown3 = Decimal.Parse(lc.cf.NumberNull(r3Down.use1));
            limitDown3 = Decimal.Parse(lc.cf.NumberNull(r3Down.limit1));
            limitTod3 = Decimal.Parse(lc.cf.NumberNull(r3Tod.limit1));

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1[colNumber, i].Value == null)
                {
                    continue;
                }
                num = dgv1[colNumber, i].Value.ToString();
                up = dgv1[colUp, i].Value.ToString();
                down = dgv1[colDown, i].Value.ToString();
                tod = dgv1[colTod, i].Value.ToString();
                if (dgv1[colThooTranferId, i].Value.ToString().Length <= 0)
                {
                    //continue;
                }
                if (num.Length == 1)
                {
                    if (dgv1[colThooTranferId, i].Value.ToString().Length <= 0)
                    {
                        up1 = Decimal.Parse(up);
                        useUp1 += up1;
                        if ((useUp1) <= limitUp1)
                        {
                            dgv1[colStatusOL, i].Value = "0";
                        }
                        else
                        {
                            dgv1[colStatusOL, i].Value = "1";
                            overLimit1 += up1;
                            dgv1[colOLUp, i].Value = String.Format("{0:#,###,###.00}",overLimit1);
                            //dgv1[colOLTod, i].Value = "0";
                            //dgv1[colOLDown, i].Value = "0";
                            dgv1[colOLUp, i].Style.Font = font;
                            dgv1[colOLUp, i].Style.ForeColor = Color.Red;
                        }
                        dgv1[colUse1, i].Value = String.Format("{0:#,###,###.00}",useUp1);
                    }
                    else
                    {
                        dgv1.Rows[i].DefaultCellStyle.Font = fontStrike;
                    }
                    
                    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                }
                else if (num.Length == 2)
                {
                    if (dgv1[colThooTranferId, i].Value.ToString().Length <= 0)
                    {
                        up2 = Decimal.Parse(up);
                        useUp2 += (up2);
                        down2 = Decimal.Parse(down);
                        useDown2 += down2;
                        if ((useUp2) <= limitUp2)
                        {
                            dgv1[colStatusOL, i].Value = "0";
                        }
                        else
                        {
                            dgv1[colStatusOL, i].Value = "1";
                            overLimit2 += (up2 + down2);
                            dgv1[colOLUp, i].Value = String.Format("{0:#,###,###.00}",(useUp2 - limitUp2));
                            dgv1[colOLUp, i].Style.Font = font;
                            dgv1[colOLUp, i].Style.ForeColor = Color.Red;
                        }
                        if ((useDown2) <= limitDown2)
                        {
                            dgv1[colStatusOL, i].Value = "0";
                        }
                        else
                        {
                            dgv1[colStatusOL, i].Value = "1";
                            overLimit2 += (up2 + down2);
                            dgv1[colOLDown, i].Value = String.Format("{0:#,###,###.00}",(useDown2 - limitDown2));
                            dgv1[colOLDown, i].Style.Font = font;
                            dgv1[colOLDown, i].Style.ForeColor = Color.Red;
                        }
                        dgv1[colUse1, i].Value = String.Format("{0:#,###,###.00}",(useUp2 + useDown2));
                    }
                    else
                    {
                        dgv1.Rows[i].DefaultCellStyle.Font = fontStrike;
                    }
                    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                }
                else if (num.Length == 3)
                {
                    if (dgv1[colThooTranferId, i].Value.ToString().Length <= 0)
                    {
                        up3 = Decimal.Parse(up);
                        useUp3 += up3;
                        down3 = Decimal.Parse(down);
                        useDown3 += down3;
                        tod3 = Decimal.Parse(tod);
                        useTod3 += tod3;
                        if ((useUp3) <= limitUp3)
                        {
                            dgv1[colStatusOL, i].Value = "0";
                        }
                        else
                        {
                            dgv1[colStatusOL, i].Value = "1";
                            //overLimit3 += (up3 + down3);
                            dgv1[colOLUp, i].Value = String.Format("{0:#,###,###.00}",(useUp3 - limitUp3));
                            dgv1[colOLUp, i].Style.Font = font;
                            dgv1[colOLUp, i].Style.ForeColor = Color.Red;
                        }
                        if ((useTod3) <= limitTod3)
                        {
                            dgv1[colStatusOL, i].Value = "0";
                        }
                        else
                        {
                            dgv1[colStatusOL, i].Value = "1";
                            //overLimit3 += (up3 + down3);
                            dgv1[colOLTod, i].Value = String.Format("{0:#,###,###.00}",(useTod3 - limitTod3));
                            dgv1[colOLTod, i].Style.Font = font;
                            dgv1[colOLTod, i].Style.ForeColor = Color.Red;
                        }
                        if ((useDown3) <= limitDown3)
                        {
                            dgv1[colStatusOL, i].Value = "0";
                        }
                        else
                        {
                            dgv1[colStatusOL, i].Value = "1";
                            //overLimit3 += (up3 + down3);
                            dgv1[colOLDown, i].Value = String.Format("{0:#,###,###.00}",(useDown3 - limitDown3));
                            dgv1[colOLDown, i].Style.Font = font;
                            dgv1[colOLDown, i].Style.ForeColor = Color.Red;
                        }

                        dgv1[colUse1, i].Value = String.Format("{0:#,###,###.00}",(useUp3 + useDown3 + useTod3));
                    }
                    else
                    {
                        dgv1.Rows[i].DefaultCellStyle.Font = fontStrike;
                    }
                    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                }
            }
            lc.fldb.unLockLotto();
            lc.rwdb.updateStatusApprove(rw.Id, sf.Id);
            Cursor.Current = cursor;
        }
        private void ExitApplication()
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            String statusOL = "", OLUp = "", OLDown = "", OLTod = "", down = "", tod = "";
            String lottoId = "", rowId = "", chk="";
            pB1.Visible = true;
            //Lotto lot = new Lotto();
            pB1.Minimum = 0;
            pB1.Maximum = dgv1.Rows.Count;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1[colNumber, i].Value == null)
                {
                    continue;
                }
                lottoId = dgv1[colLottoId1, i].Value.ToString();
                rowId = dgv1[colRowId, i].Value.ToString();
                //lot.rowId = rowId;

                statusOL = lc.cf.stringNull1(dgv1[colStatusOL, i].Value);
                if (dgv1[colOLUp, i].Value != null)
                {
                    OLUp = lc.cf.NumberNull1(dgv1[colOLUp, i].Value.ToString());
                }
                else
                {
                    OLUp = "0";
                }
                if (dgv1[colOLDown, i].Value != null)
                {
                    OLDown = lc.cf.NumberNull1(dgv1[colOLDown, i].Value.ToString());
                }
                else
                {
                    OLDown = "0";
                }
                if (dgv1[colOLTod, i].Value != null)
                {
                    OLTod = lc.cf.NumberNull1(dgv1[colOLTod, i].Value.ToString());
                }
                else
                {
                    OLTod = "0";
                }
                
                //down = dgv1[colDown, i].Value.ToString();
                //lot.statusOverLimit = statusOL;
                //lot.overLimit = overLimit;
                //lot.staffApproveId = sf.Id;
                //lot.thooTranferId = lc.cf.stringNull1(dgv1[colThooTranfer, i].Value);
                chk = lc.lotdb.updateApprove(rowId, OLUp, OLDown, OLTod, lc.cf.NumberNull(dgv1[colUse1, i].Value), statusOL, lc.cf.stringNull1(dgv1[colThooTranferId, i].Value), sf.Id);
                if (chk.Equals("1"))
                {
                    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                }
                pB1.Value = i;
            }
            pB1.Visible = false;
            Cursor.Current = cursor;
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String thooId = "";
            FrmLottoThoo frm = new FrmLottoThoo(sf.Id, dgv1[colRowId, e.RowIndex].Value.ToString(), thooId, lc);
            
            frm.ShowDialog(this);
            thooId = frm.thooId;
            //cItem = lc.getCboItem(cboThoo, thooId);
            //dgv1[colThooTranferId, e.RowIndex].Value = cItem.Value;
            //dgv1[colThooTranferName, e.RowIndex].Value = cItem.Text;
            setGrd1();
        }

        private void dgvThooTranfer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmLottoThooPrint frm = new FrmLottoThooPrint(sf.Id, dgvThooTranfer[colTId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
        }

        private void FrmLottoApprove_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sf.Priority.Equals("2"))
            {
                ExitApplication();
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain(this, sf.Code, lc);
            frm.Show();
            this.Hide();
        }

        private void FrmLottoApprove_Load(object sender, EventArgs e)
        {

        }

    }
}
