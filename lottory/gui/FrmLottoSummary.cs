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
    public partial class FrmLottoSummary : Form
    {
        int row = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5, colUse1 = 7, colStatusOL = 8, colOverLimit = 9;
        int colRateId = 10, colThooTranferId = 11, colThooTranferName = 12;
        int col1Cnt = 13;
        
        //int colTRow = 0, colTName = 1, colTLimit = 2, colTAmt = 3, colTId = 4;
        int colRRow = 0, colRDescription = 1,colRAmt=2, colRAmtReward = 3, colRNetTotal=4, colRReward = 5, colRRec = 6, colRpayRate =7, colRLimit = 8, colRDiscount = 9, colRId = 10;
        int colSName = 0, colSAmt=1, colSPay=2, colSId=3, colSStatusDiscount=4, colSPerDiscount=5, colSCnt=6;
        int colTName = 0, colTAmt = 1, colTPay = 2, colTId = 3, colTCnt=4;
        //int colTName = 0, colSaleAmt = 1, colSalePay = 2, colSaleId = 3, colSaleCnt = 4;
        //int col1Cnt = 14;
        Boolean pageLoad=false;
        LottoryControl lc;
        Test1 t;
        Staff sf;
        Reward rw;
        ComboBox cboThoo, cboSale;
        ComboBoxItem cItem;
        FrmLottoSummaryRate frmSR;
        FrmLottoSummarySale frmSS;
        FrmLottoSummaryThoo frmST; 
        public FrmLottoSummary(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode,l);
            pageLoad = false;
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            pageLoad = true;
            rw = new Reward();
            String monthId = "", periodId = "";
            cboThoo = new ComboBox();
            cboSale = new ComboBox();
            //cf = new Config1();
            //lc = new LottoryControl();
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            cboThoo = lc.thodb.getCboThoo(cboThoo);
            cboSale = lc.saledb.getCboSale(cboSale);
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
            //cboStaff = lc.sfdb.getCboStaff(cboStaff);

            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            //setGrid(dgv1);
            //setControl1();
            setControl1();
            pageLoad = false;
            pB1.Visible = false;
        }
        public void setLC(Test1 l)
        {
            t = l;
            
        }
        private void setGrdRate()
        {
            pB1.Show();
            String rateId = "";
            DataTable dt = new DataTable();
            Double[] reward = new Double[2] { 0, 0 };
            double amt = 0;
            dt = lc.selectRateAll();
            dgvRate.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            Font font1 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            dgvRate.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (dt.Rows.Count > 0)
            {
                dgvRate.RowCount = dt.Rows.Count;
            }
            else
            {
                dgvRate.RowCount = 1;
            }
            //dgvRate.RowCount = dt.Rows.Count;
            dgvRate.ColumnCount = 11;
            dgvRate.Columns[colRRow].Width = 50;
            dgvRate.Columns[colRDescription].Width = 200;
            dgvRate.Columns[colRRec].Width = 60;
            dgvRate.Columns[colRReward].Width = 100;
            dgvRate.Columns[colRpayRate].Width = 100;
            dgvRate.Columns[colRDiscount].Width = 100;
            dgvRate.Columns[colRLimit].Width = 120;
            dgvRate.Columns[colRId].Width = 80;
            dgvRate.Columns[colRAmtReward].Width = 100;
            dgvRate.Columns[colRAmt].Width = 100;
            dgvRate.Columns[colRNetTotal].Width = 100;

            dgvRate.Columns[colRRow].HeaderText = "ลำดับ";
            dgvRate.Columns[colRpayRate].HeaderText = "อัตราจ่าย";
            dgvRate.Columns[colRDescription].HeaderText = "รายการ";
            dgvRate.Columns[colRRec].HeaderText = "ซื้อ";
            dgvRate.Columns[colRReward].HeaderText = "จ่าย";
            //dgvRate.Columns[colRRec].HeaderText = "ซื้อ";
            dgvRate.Columns[colRDiscount].HeaderText = "ส่วนลด";
            dgvRate.Columns[colRLimit].HeaderText = "จำนวนอั้น";
            dgvRate.Columns[colRAmt].HeaderText = "ยอดเงิน";
            dgvRate.Columns[colRAmtReward].HeaderText = "แทงถูก";
            dgvRate.Columns[colRNetTotal].HeaderText = "คงเหลือ";
            dgvRate.Columns[colRId].HeaderText = "id";//

            dgvRate.Columns[colRpayRate].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRRec].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRReward].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRDiscount].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRLimit].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRAmtReward].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRAmt].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvRate.Columns[colRNetTotal].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            //dgvRate.ReadOnly = true;

            if (dt.Rows.Count > 0)
            {
                pB1.Maximum = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pB1.Value = i;
                    rateId = dt.Rows[i][lc.ratedb.rate.Id].ToString();
                    reward = lc.lotdb.selectSumByRateReward(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), rateId);
                    amt = lc.lotdb.selectSumByRate(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), rateId);
                    dgvRate[colRRow, i].Value = (i + 1);
                    dgvRate[colRpayRate, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][lc.ratedb.rate.pay]);
                    dgvRate[colRDescription, i].Value = dt.Rows[i][lc.ratedb.rate.Description].ToString();
                    dgvRate[colRRec, i].Value = dt.Rows[i][lc.ratedb.rate.rec].ToString();
                    dgvRate[colRLimit, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i][lc.ratedb.rate.limit1]);
                    //dgvRate[colRDiscount, i].Value = dt.Rows[i][lc.ratedb.rate.discount].ToString();
                    dgvRate[colRId, i].Value = rateId;
                    dgvRate[colRAmtReward, i].Value = String.Format("{0:#,###,###.00}", reward[0]);
                    dgvRate[colRReward, i].Value = String.Format("{0:#,###,###.00}", reward[1]);
                    dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}", amt);
                    if (Double.Parse(lc.cf.NumberNull(dgvRate[colRReward, i].Value.ToString())) > 0)
                    {
                        dgvRate[colRReward, i].Style.Font = font1;
                        dgvRate[colRReward, i].Style.ForeColor = Color.Red;
                        dgvRate[colRAmtReward, i].Style.Font = font1;
                        dgvRate[colRAmtReward, i].Style.ForeColor = Color.Red;
                    }
                    if (rateId.Equals("up"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");                        
                    }
                    else if (rateId.Equals("down"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                    }
                    else if (rateId.Equals("2down"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rateId.Equals("2up"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rateId.Equals("2tod"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rateId.Equals("3down"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                    else if (rateId.Equals("3tod"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                    else if (rateId.Equals("3up"))
                    {
                        dgvRate.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                    //if ((i % 2) != 0)
                    //{
                    //    dgvRate.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    //}
                }
            }
            dgvRate.RowHeadersVisible = false;
            dgvRate.Columns[colRId].Visible = false;
            dgvRate.Columns[colRRow].Visible = false;
            dgvRate.Columns[colRDiscount].Visible = false;
            dgvRate.ReadOnly = true;
            dgvRate.Font = font;
            pB1.Hide();
            //setDataGrdThoo();
            //setThooAmount();
        }
        private void setGrdSale()
        {
            DataTable dt = new DataTable();
            dt = lc.lotdb.selectSumBySale(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            dgvSale.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvSale.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (dt.Rows.Count > 0)
            {
                dgvSale.RowCount = dt.Rows.Count;
            }
            else
            {
                dgvSale.RowCount = 1;
            }
            dgvSale.ColumnCount = colSCnt;
            dgvSale.Columns[colSName].Width = 200;
            dgvSale.Columns[colSAmt].Width = 100;
            dgvSale.Columns[colSPay].Width = 80;
            dgvSale.Columns[colSId].Width = 100;

            //dgvRate.Columns[colRRow].HeaderText = "ลำดับ";
            dgvSale.Columns[colSName].HeaderText = "sale";
            dgvSale.Columns[colSAmt].HeaderText = "ยอด";
            dgvSale.Columns[colSPay].HeaderText = "%ยอด";
            dgvSale.Columns[colSId].HeaderText = " ";
            dgvSale.Columns[colSAmt].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvSale.Columns[colSPay].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvSale.ReadOnly = true;

            if (dt.Rows.Count > 0)
            {
                dgvSale.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //dgvRate[colRRow, i].Value = (i + 1);
                    cItem = lc.getCboItem(cboSale, dt.Rows[i][lc.saledb.sale.Id].ToString());
                    dgvSale[colSName, i].Value = cItem.Text;
                    dgvSale[colSAmt, i].Value = String.Format("{0:#,###,###.00}",dt.Rows[i]["amt"]);
                    dgvSale[colSPay, i].Value = lc.getSalePercent(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dt.Rows[i][lc.saledb.sale.Id].ToString());
                    dgvSale[colSId, i].Value = dt.Rows[i][lc.saledb.sale.Id].ToString();
                    //dgvRate[colRDiscount, i].Value = dt.Rows[i][lc.ratedb.rate.discount].ToString();
                    //dgvRate[colRId, i].Value = dt.Rows[i][lc.ratedb.rate.Id].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvSale.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
            dgvSale.RowHeadersVisible = false;
            dgvSale.Columns[colSId].Visible = false;
            //dgvSale.Columns[colRRow].Visible = false;

            dgvSale.Font = font;
            dgvSale.ReadOnly = true;
            //setDataGrdThoo();
            //setThooAmount();
        }
        private void setGrdThooTranfer()
        {
            DataTable dt = new DataTable();
            dt = lc.lotdb.selectSumByThooTranfer(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            dgvThooTranfer.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvThooTranfer.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (dt.Rows.Count > 0)
            {
                dgvThooTranfer.RowCount = dt.Rows.Count;
            }
            else
            {
                dgvThooTranfer.RowCount = 1;
            }
            //dgvThooTranfer.RowCount = dt.Rows.Count;
            dgvThooTranfer.ColumnCount = colTCnt;
            dgvThooTranfer.Columns[colSName].Width = 200;
            dgvThooTranfer.Columns[colSAmt].Width = 100;
            dgvThooTranfer.Columns[colSPay].Width = 80;
            dgvThooTranfer.Columns[colSId].Width = 100;

            //dgvRate.Columns[colRRow].HeaderText = "ลำดับ";
            dgvThooTranfer.Columns[colTName].HeaderText = "เจ้ามือ";
            dgvThooTranfer.Columns[colTAmt].HeaderText = "ยอด";
            dgvThooTranfer.Columns[colTPay].HeaderText = "จ่าย";
            dgvThooTranfer.Columns[colTId].HeaderText = " ";
            dgvThooTranfer.Columns[colTAmt].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvThooTranfer.Columns[colTPay].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvThooTranfer.ReadOnly = true;

            if (dt.Rows.Count > 0)
            {
                dgvThooTranfer.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //dgvRate[colRRow, i].Value = (i + 1);
                    cItem = lc.getCboItem(cboThoo, dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString());
                    dgvThooTranfer[colTName, i].Value = cItem.Text;
                    dgvThooTranfer[colTAmt, i].Value = String.Format("{0:#,###,###.00}", dt.Rows[i]["amt"]);
                    dgvThooTranfer[colTPay, i].Value = "";
                    dgvThooTranfer[colTId, i].Value = dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString();
                    //dgvRate[colRDiscount, i].Value = dt.Rows[i][lc.ratedb.rate.discount].ToString();
                    //dgvRate[colRId, i].Value = dt.Rows[i][lc.ratedb.rate.Id].ToString();
                    dgvThooTranfer.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(lc.getThooBackColorByThoId(dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString()));
                    //if ((i % 2) != 0)
                    //{
                    //    dgvThooTranfer.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    //}
                }
            }
            dgvThooTranfer.RowHeadersVisible = false;
            dgvThooTranfer.Columns[colSId].Visible = false;
            //dgvSale.Columns[colRRow].Visible = false;
            dgvThooTranfer.ReadOnly = true;
            dgvThooTranfer.Font = font;
            //setDataGrdThoo();
            //setThooAmount();
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
            txtRewardDown2.ReadOnly = true;
            txtRDown31.ReadOnly = true;
            txtRDown32.ReadOnly = true;
            txtRDown33.ReadOnly = true;
            txtRDown34.ReadOnly = true;
            txtReward1.ReadOnly = true;
            
            //rw.dateReward;
        }
        //private void setGrid(DataGridView dgv)
        //{
        //    dgv.Rows.Clear();
        //    Font font = new Font("Microsoft Sans Serif", 12);

        //    //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

        //    dgv.ColumnCount = col1Cnt;
        //    dgv.RowCount = 1;
        //    //row = 0;
        //    dgv.Columns[colNumber].Width = 80;
        //    dgv.Columns[colUp].Width = 80;
        //    dgv.Columns[colTod].Width = 80;
        //    dgv.Columns[colDown].Width = 80;
        //    dgv.Columns[colUse1].Width = 90;
        //    dgv.Columns[colStatusOL].Width = 80;
        //    dgv.Columns[colOverLimit].Width = 110;
        //    dgv.Columns[colRemark].Width = 80;
        //    dgv.Columns[colRateId].Width = 60;
        //    dgv.Columns[colThooTranferName].Width = 100;

        //    dgv.Columns[colNumber].HeaderText = "ตัวเลข";
        //    dgv.Columns[colUp].HeaderText = "บน";
        //    dgv.Columns[colTod].HeaderText = "โต๊ด";
        //    dgv.Columns[colDown].HeaderText = "ล่าง";
        //    dgv.Columns[colUse1].HeaderText = "ยอดเงิน";
        //    dgv.Columns[colStatusOL].HeaderText = "สถานะ";
        //    dgv.Columns[colOverLimit].HeaderText = "วงเงิน(เกิน)";
        //    dgv.Columns[colThooTranferName].HeaderText = "ส่งต่อให้";

        //    dgv.Columns[colRowId].Visible = false;
        //    dgv.Columns[colThooTranferId].Visible = false;
        //    dgv.Columns[colLottoId1].Visible = false;
        //    dgv.Columns[colRemark].Visible = false;
        //    dgv.Columns[colRateId].Visible = false;
        //    dgv.Columns[colStatusOL].Visible = false;

        //    dgv1.Font = font;
        //}
        //private void setGrd1()
        //{
        //    double up = 0, tod = 0, down = 0, amt = 0;
        //    DataTable dt = new DataTable();
        //    dgv1.Rows.Clear();

        //    dt = lc.lotdb.selectByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
        //    if (dt.Rows.Count > 0)
        //    {
        //        dgv1.RowCount = dt.Rows.Count;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            try
        //            {
        //                setDataGrid1(dgv1, i, dt.Rows[i][lc.lotdb.lot.number].ToString(), dt.Rows[i][lc.lotdb.lot.up].ToString(),
        //                dt.Rows[i][lc.lotdb.lot.tod].ToString(), dt.Rows[i][lc.lotdb.lot.down].ToString(),
        //                dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString(), "", "", "",
        //                dt.Rows[i][lc.lotdb.lot.thooTranferId].ToString());
        //                up += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.up]));
        //                tod += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.tod]));
        //                down += Double.Parse(lc.cf.NumberNull(dt.Rows[i][lc.lotdb.lot.down]));
        //                amt += up + tod + down;
        //            }
        //            catch (Exception ex)
        //            {

        //            }
        //        }
        //    }

        //    setApprove();
        //    //setThooAmount();
        //    setRateAmount();
        //}
        //private void setDataGrid1(DataGridView dgv, int row, String number, String numUp, String numTod, String numDown, String rowId,
        //    String lottoId, String use1, String statusOL, String overLimit, String thooTranferId)
        //{
        //    if (dgv.Enabled == false)
        //    {
        //        return;
        //    }
        //    if (dgv1.RowCount <= row)
        //    {
        //        return;
        //    }
        //    dgv[colNumber, row].Value = number;
        //    dgv[colUp, row].Value = numUp;
        //    dgv[colTod, row].Value = numTod;
        //    dgv[colDown, row].Value = numDown;
        //    dgv[colRowId, row].Value = rowId;
        //    dgv[colLottoId1, row].Value = lottoId;
        //    dgv[colUse1, row].Value = use1;
        //    dgv[colStatusOL, row].Value = statusOL;
        //    dgv[colOverLimit, row].Value = overLimit;
        //    dgv[colThooTranferId, row].Value = thooTranferId;
        //    //cItem = lc.getCboItem(cboThoo, thooTranferId);
        //    //dgv[colThooTranferName, row].Value = cItem.Text;
        //}
        //private void setApprove()
        //{
        //    Rate r2Up = new Rate();
        //    Rate r3Up = new Rate();
        //    Rate r3Tod = new Rate();
        //    Rate r2Down = new Rate();
        //    Rate r3Down = new Rate();
        //    Rate rUp = new Rate();
        //    String num = "", up = "", down = "", tod = "";
        //    Decimal up1 = 0, limitUp1 = 0, useUp1 = 0, overLimit1 = 0;
        //    Decimal up2 = 0, limitUp2 = 0, useUp2 = 0, overLimit2 = 0;
        //    Decimal down2 = 0, limitDown2 = 0, useDown2 = 0, overLimitD2 = 0;
        //    Decimal up3 = 0, limitUp3 = 0, useUp3 = 0, overLimit3 = 0;
        //    Decimal down3 = 0, limitDown3 = 0, useDown3 = 0, overLimitD3 = 0;

        //    //if (!lc.fldb.setLock(sf.sited))
        //    //{
        //    //    MessageBox.Show("aaaa", "aaaa");
        //    //    return;
        //    //}
        //    r2Up = lc.ratedb.selectByPk("2up");
        //    r3Up = lc.ratedb.selectByPk("3up");
        //    r3Tod = lc.ratedb.selectByPk("3tod");
        //    r2Down = lc.ratedb.selectByPk("2down");
        //    r3Down = lc.ratedb.selectByPk("3down");
        //    rUp = lc.ratedb.selectByPk("up");

        //    useUp1 = Decimal.Parse(lc.cf.NumberNull(rUp.use1));
        //    limitUp1 = Decimal.Parse(lc.cf.NumberNull(rUp.limit1));

        //    useUp2 = Decimal.Parse(lc.cf.NumberNull(r2Up.use1));
        //    limitUp2 = Decimal.Parse(lc.cf.NumberNull(r2Up.limit1));
        //    useDown2 = Decimal.Parse(lc.cf.NumberNull(r2Down.use1));
        //    limitDown2 = Decimal.Parse(lc.cf.NumberNull(r2Down.limit1));

        //    useUp3 = Decimal.Parse(lc.cf.NumberNull(r3Up.use1));
        //    limitUp3 = Decimal.Parse(lc.cf.NumberNull(r3Up.limit1));
        //    useDown3 = Decimal.Parse(lc.cf.NumberNull(r3Down.use1));
        //    limitDown3 = Decimal.Parse(lc.cf.NumberNull(r3Down.limit1));

        //    for (int i = 0; i < dgv1.Rows.Count; i++)
        //    {
        //        if (dgv1[colNumber, i].Value == null)
        //        {
        //            continue;
        //        }
        //        num = dgv1[colNumber, i].Value.ToString();
        //        up = dgv1[colUp, i].Value.ToString();
        //        down = dgv1[colDown, i].Value.ToString();
        //        if (num.Length == 1)
        //        {
        //            up1 = Decimal.Parse(up);
        //            useUp1 += up1;
        //            if ((useUp1) <= limitUp1)
        //            {
        //                dgv1[colStatusOL, i].Value = "0";
        //            }
        //            else
        //            {
        //                dgv1[colStatusOL, i].Value = "1";
        //                overLimit1 += up1;
        //                dgv1[colOverLimit, i].Value = overLimit1;
        //            }
        //            dgv1[colUse1, i].Value = useUp1;
        //        }
        //        else if (num.Length == 2)
        //        {
        //            up2 = Decimal.Parse(up);
        //            useUp2 += (up2);
        //            down2 = Decimal.Parse(down);
        //            useDown2 += down2;
        //            if ((useUp2 + useDown2) <= limitUp2)
        //            {
        //                dgv1[colStatusOL, i].Value = "0";
        //            }
        //            else
        //            {
        //                dgv1[colStatusOL, i].Value = "1";
        //                overLimit2 += (up2 + down2);
        //                dgv1[colOverLimit, i].Value = overLimit2;
        //            }

        //            dgv1[colUse1, i].Value = (useUp2 + useDown2);
        //        }
        //        else if (num.Length == 3)
        //        {
        //            up3 = Decimal.Parse(up);
        //            useUp3 += up3;
        //            down3 = Decimal.Parse(down);
        //            useDown3 += down3;
        //            if ((useUp3 + useDown3) <= limitUp3)
        //            {
        //                dgv1[colStatusOL, i].Value = "0";
        //            }
        //            else
        //            {
        //                dgv1[colStatusOL, i].Value = "1";
        //                overLimit3 += (up3 + down3);
        //                dgv1[colOverLimit, i].Value = overLimit3;
        //            }
        //            dgv1[colUse1, i].Value = (useUp3 + useDown3);
        //        }
        //    }
        //    //lc.fldb.unLockLotto();
        //}
        //private void setThooAmount()
        //{
        //    double amt = 0;
        //    String thooId = "", thoo1Id = "";
        //    for (int i = 0; i < dgvThooTranfer.RowCount; i++)
        //    {
        //        if (dgvThooTranfer[colTId, i].Value == null)
        //        {
        //            continue;
        //        }
        //        thooId = dgvThooTranfer[colTId, i].Value.ToString();
        //        for (int j = 0; j < dgv1.RowCount; j++)
        //        {
        //            if (dgv1[colThooTranferId, j].Value == null)
        //            {
        //                continue;
        //            }
        //            thoo1Id = dgv1[colThooTranferId, j].Value.ToString();
        //            if (thooId.Equals(thoo1Id))
        //            {
        //                amt += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
        //                amt += Double.Parse(lc.cf.NumberNull(dgv1[colTod, j].Value));
        //                amt += Double.Parse(lc.cf.NumberNull(dgv1[colDown, j].Value));
        //            }
        //        }
        //        dgvThooTranfer[colTAmt, i].Value = String.Format("{0:#,###,###.##}", amt);
        //    }
        //}
        //private void setRateAmount()
        //{
        //    String rateId = "", rate1Id = "", num = "";
        //    double up = 0, up2 = 0, down2 = 0, up3 = 0, down3 = 0, tod3 = 0;
        //    for (int j = 0; j < dgv1.RowCount; j++)
        //    {
        //        if (dgv1[colNumber, j].Value == null)
        //        {
        //            continue;
        //        }
        //        num = dgv1[colNumber, j].Value.ToString();
        //        if (num.Length == 1)
        //        {
        //            up += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
        //        }
        //        else if (num.Length == 2)
        //        {
        //            up2 += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
        //            down2 += Double.Parse(lc.cf.NumberNull(dgv1[colDown, j].Value));
        //        }
        //        else if (num.Length == 3)
        //        {
        //            up3 += Double.Parse(lc.cf.NumberNull(dgv1[colUp, j].Value));
        //            down3 += Double.Parse(lc.cf.NumberNull(dgv1[colDown, j].Value));
        //            tod3 += Double.Parse(lc.cf.NumberNull(dgv1[colTod, j].Value));
        //        }
        //    }
        //    for (int i = 0; i < dgvRate.RowCount; i++)
        //    {
        //        if (dgvRate[colRId, i].Value == null)
        //        {
        //            continue;
        //        }
        //        rateId = dgvRate[colRId, i].Value.ToString();
        //        if (rateId.Equals("2down"))
        //        {
        //            dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",down2);
        //        }
        //        else if (rateId.Equals("2up"))
        //        {
        //            dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",up2);
        //        }
        //        else if (rateId.Equals("3down"))
        //        {
        //            dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",down3);
        //        }
        //        else if (rateId.Equals("3tod"))
        //        {
        //            dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",tod3);
        //        }
        //        else if (rateId.Equals("3up"))
        //        {
        //            dgvRate[colRAmt, i].Value = String.Format("{0:#,###,###.00}",up3);
        //        }
        //    }
        //}
        private void setControl1()
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            setControl();
            setGrdRate();
            //setGrd1();
            setGrdSale();
            setGrdThooTranfer();
            Cursor.Current = cursor;
        }

        private void FrmLottoSummary_Load(object sender, EventArgs e)
        {

        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl1();
            }
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl1();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl1();
            }
        }

        private void dgvRate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if (frmSR == null)
            {
                frmSR = new FrmLottoSummaryRate(sf.Id, cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvRate[colRId, e.RowIndex].Value.ToString(),lc);
            }
            frmSR.setControl(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvRate[colRId, e.RowIndex].Value.ToString());
            if (!frmSR.Visible)
            {
                frmSR.Show(this);
            }
            else
            {
                frmSR.Show();
                frmSR.Activate();
            }
            Cursor.Current = cursor;
        }

        private void dgvSale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if (frmSS == null)
            {
                frmSS = new FrmLottoSummarySale(sf.Id, cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvRate[colRId, e.RowIndex].Value.ToString(), lc);
            }
            frmSS.setControl(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvSale[colSId, e.RowIndex].Value.ToString());
            //FrmLottoSummarySale frm = new FrmLottoSummarySale(sf.Id, cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvRate[colRId, e.RowIndex].Value.ToString(), lc);
            //frm.ShowDialog(this);
            if (!frmSS.Visible)
            {
                frmSS.Show(this);
            }
            else
            {
                frmSS.Show();
                frmSS.Activate();
            }
            Cursor.Current = cursor;
        }

        private void dgvThooTranfer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            if (frmSS == null)
            {
                frmST = new FrmLottoSummaryThoo(sf.Id, cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvRate[colRId, e.RowIndex].Value.ToString(), lc);
            }
            frmST.setControl(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvThooTranfer[colTId, e.RowIndex].Value.ToString());
            //FrmLottoSummarySale frm = new FrmLottoSummarySale(sf.Id, cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), dgvRate[colRId, e.RowIndex].Value.ToString(), lc);
            //frm.ShowDialog(this);
            if (!frmST.Visible)
            {
                frmST.Show(this);
            }
            else
            {
                frmST.Show();
                frmST.Activate();
            }
            Cursor.Current = cursor;
        }
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Escape:
                    // ... Process Shift+Ctrl+Alt+B ...
                    this.Dispose();
                    return true; // signal that we've processed this key
            }
            return base.ProcessCmdKey(ref message, keys);
        }
    }
}
