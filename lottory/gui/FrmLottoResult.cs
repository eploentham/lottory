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
    public partial class FrmLottoResult : Form
    {
        //int row = 0;
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5, colRUp=7, colRDown=8, colR2Up=9, colR2Down=10, colR3Up=11, colR3Down=13, colR3Tod=12, colSale=14;
        int col1Cnt = 15;
        int col2Number = 0, col2RewordUp = 1, col2RewardDown=2, col2Remark = 3, col2Rew=4, col2Cnt=5;
        int col3Number = 0, col3RewordUp = 1, col3RewardTod = 2, col3RewardDown = 3, col3Remark = 4, col3Rew = 5, col3Cnt = 6;
        LottoryControl lc;
        Staff sf;
        Reward rw;
        Boolean pageLoad = false;

        public FrmLottoResult(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode,l);
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            pageLoad = true;
            rw = new Reward();
            String monthId = "", periodId = "";
            //cf = new Config1();
            //lc = new LottoryControl();
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            //lc.sfdb.sf = sf;
            monthId = System.DateTime.Now.Month.ToString("00");
            //cboPeriod = lc.cf.setCboPeriod(cboPeriod);

            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            //cboStaff = lc.sfdb.getCboStaff(cboStaff);
            cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            cboSale = lc.saledb.getCboSale(cboSale);
            //ComboBoxItem cbo = new ComboBoxItem();
            //cbo.Value = sf.Id;
            //cbo.Text = sf.Name;
            //cboStaff.Text = sf.Name;
            setControl();
            setGrid(dgv1);
            setGrd2();
            setGrid(dgv3);
            chkNum.Checked = true;
            if (chkNum.Checked)
            {
                //dgv2.Visible = false;
                dgv3.Visible = false;
                //dgv1.Width = 1050;       
            }
            setDGrd();
            pageLoad = false;
            dgv1.ReadOnly = true;
            pB1.Visible = false;
        }
        private void setControl()
        {
            rw = lc.selectRewardByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            if (rw.Id.Equals(""))
            {
                btnSearch.Enabled = false;
            }
            else
            {
                btnSearch.Enabled = true;
            }
            
            txtRewardDown2.Text = rw.rewardDown2;
            txtRDown31.Text = rw.rewardDown31;
            txtRDown32.Text = rw.rewardDown32;
            txtRDown33.Text = rw.rewardDown33;
            txtRDown34.Text = rw.rewardDown34;
            txtReward1.Text = rw.reward1;
            txtRewardId.Text = rw.Id;
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
            dgv.Columns[colRUp].Width = 100;
            dgv.Columns[colRDown].Width = 100;
            dgv.Columns[colR2Up].Width = 100;
            dgv.Columns[colR2Down].Width = 100;
            dgv.Columns[colR3Up].Width = 100;
            dgv.Columns[colR3Down].Width = 100;
            dgv.Columns[colR3Tod].Width = 100;
            dgv.Columns[colRemark].Width = 60;
            dgv.Columns[colSale].Width = 150;
            dgv.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv.Columns[colUp].HeaderText = "บน";
            dgv.Columns[colTod].HeaderText = "โต๊ด";
            dgv.Columns[colDown].HeaderText = "ล่าง";
            dgv.Columns[colRUp].HeaderText = "ถูกวิ่งบน";
            dgv.Columns[colRDown].HeaderText = "ถูกวิ่งล่าง";
            dgv.Columns[colR2Up].HeaderText = "ถูก2ตัวบน";
            dgv.Columns[colR2Down].HeaderText = "ถูก2ตัวล่าง";
            dgv.Columns[colR3Up].HeaderText = "ถูก3ตัวบน";
            dgv.Columns[colR3Down].HeaderText = "ถูก3ตัวล่าง";
            dgv.Columns[colR3Tod].HeaderText = "ถูกโต๊ด";
            dgv.Columns[colSale].HeaderText = "คนเก็บโพย";

            dgv.Columns[colUp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colTod].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colDown].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colRUp].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colRDown].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colR2Up].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colR2Down].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colR3Up].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colR3Down].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dgv.Columns[colR3Tod].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dgv.Columns[colRowId].Visible = false;
            dgv.Columns[colLottoId1].Visible = false;
            dgv.Columns[colRemark].Visible = false;

            dgv.Font = font;

        }
        private void setGrd2()
        {
            dgv2.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            Font fontb = new Font("Microsoft Sans Serif", 12,  FontStyle.Bold);
            //Datagridv
            //dgv21.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv2.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgv2.ColumnCount = col2Cnt;
            dgv2.RowCount = 100;
            //row = 0;
            dgv2.Columns[col2Number].Width = 80;
            dgv2.Columns[col2RewordUp].Width = 120;
            dgv2.Columns[col2Remark].Width = 60;
            dgv2.Columns[col2Rew].Width = 120;

            dgv2.Columns[col2Number].HeaderText = "ตัวเลข";
            dgv2.Columns[col2RewordUp].HeaderText = "มูลค่าบน";
            dgv2.Columns[col2RewardDown].HeaderText = "มูลค่าล่าง";
            dgv2.Columns[col2Remark].HeaderText = "";
            dgv2.Columns[col2Rew].HeaderText = "ถูกรางวัล";
            String tmp = "";
            for (int i = 0; i < 100; i++)
            {
                tmp = "0" + i;
                if (tmp.Length <= 2)
                {
                    dgv2[col2Number, i].Value = tmp;
                }
                else
                {
                    dgv2[col2Number, i].Value = tmp.Substring(1);
                }
                if (!rw.reward1.Equals(""))
                {
                    if (rw.rewardDown2.Equals(dgv2[col2Number, i].Value.ToString()) || rw.reward1.Substring(rw.reward1.Length - 2).Equals(dgv2[col2Number, i].Value.ToString()))
                    {
                        dgv2[col2Number, i].Style.ForeColor = Color.Red;
                        dgv2[col2Number, i].Style.Font = fontb;
                        dgv2.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                }
            }

            DataTable dt = new DataTable();
            dt = lc.lotdb.selectByPeriod2(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv2[col2Remark, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = dt.Rows[i][lc.lotdb.lot.number].ToString();
                    dgv2[col2RewordUp, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = Double.Parse(dt.Rows[i]["up"].ToString());
                    dgv2[col2RewardDown, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = Double.Parse(dt.Rows[i]["down"].ToString());
                    if (rw.rewardDown2.Equals(dgv2[col2Number, i].Value.ToString()))
                    {
                        dgv2[col2RewardDown, i].Style.ForeColor = Color.Red;
                        dgv2[col2Rew, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = String.Format("{0:#,###,###.00}",Double.Parse(dt.Rows[i]["down"].ToString()) * Double.Parse(lc.r2Down.pay));
                    }else if (rw.up2.Equals(dgv2[col2Number, i].Value.ToString())){
                        dgv2[col2RewordUp, i].Style.ForeColor = Color.Red;
                        dgv2[col2Rew, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = String.Format("{0:#,###,###.00}",Double.Parse(dt.Rows[i]["up"].ToString()) * Double.Parse(lc.r2Up.pay));
                    }
                }
            }
            dgv2.Font = font;

        }
        private void setGrd3()
        {
            dgv2.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            Font fontb = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            //dgv21.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv2.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgv2.ColumnCount = col3Cnt;
            dgv2.RowCount = 1000;
            //row = 0;
            dgv2.Columns[col3Number].Width = 80;
            dgv2.Columns[col3RewordUp].Width = 100;
            dgv2.Columns[col3RewardTod].Width = 100;
            dgv2.Columns[col3RewardDown].Width = 100;
            dgv2.Columns[col3Remark].Width = 80;

            dgv2.Columns[col3Number].HeaderText = "ตัวเลข";
            dgv2.Columns[col3RewordUp].HeaderText = "มูลค่าบน";
            dgv2.Columns[col3RewardTod].HeaderText = "มูลค่าโต๊ด";
            dgv2.Columns[col3RewardDown].HeaderText = "มูลค่าล่าง";
            dgv2.Columns[col3Remark].HeaderText = "สถานะ";
            dgv2.Columns[col3Rew].HeaderText = "ถูกรางวัล";
            String tmp = "";
            for (int i = 0; i < 1000; i++)
            {
                tmp = "000" + i;
                if (tmp.Length <= 3)
                {
                    dgv2[col2Number, i].Value = tmp;
                }
                else
                {
                    dgv2[col2Number, i].Value = tmp.Substring(tmp.Length- 3);
                }
                if (rw.up3.Equals(dgv2[col2Number, i].Value))
                {
                    dgv2[col2Number, i].Style.ForeColor = Color.Red;
                    dgv2[col2Number, i].Style.Font = fontb;
                    dgv2.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                }
            }

            DataTable dt = new DataTable();
            dt = lc.lotdb.selectByPeriod3(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i][lc.lotdb.lot.number].ToString().Equals("576"))
                    {
                        tmp = "";
                    }
                    dgv2[col3Remark, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = dt.Rows[i][lc.lotdb.lot.number].ToString();
                    dgv2[col3RewordUp, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = lc.cf.stringNull2(dt.Rows[i]["up"].ToString());
                    dgv2[col3RewardTod, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = dt.Rows[i]["tod"].ToString();
                    dgv2[col3RewardDown, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = dt.Rows[i]["down"].ToString();
                    if (rw.up3.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//ตรง
                    {
                        Double amt = 0;
                        amt =  (Double.Parse(dt.Rows[i]["up"].ToString()) * Double.Parse(lc.r3Up.pay));
                        dgv2[col3Rew, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = String.Format("{0:#,###,###.00}", amt);
                        dgv2[col3RewordUp, i].Style.ForeColor = Color.Red;
                        //exit;
                        //ถ้าตรงถูก ต้องตรวจด้วยว่ามีแทงโต๊ดด้วยหรือเปล่า
                        if (dt.Rows[i]["tod"] != null)
                        {
                            if (!lc.cf.NumberNull1(dt.Rows[i]["tod"].ToString()).Equals("0"))
                            {
                                Double tod = 0;
                                tod = (Double.Parse(dt.Rows[i]["tod"].ToString()) * Double.Parse(lc.r3Tod.pay));
                                amt += tod;
                                dgv2[col3Rew, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Value = String.Format("{0:#,###,###.00}", amt);
                            }
                        }
                    }
                    else if (rw.tod31.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//โต๊ด
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.tod32.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//โต๊ด
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.tod33.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//โต๊ด
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.tod34.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//โต๊ด
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.tod35.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//โต๊ด
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.tod36.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//โต๊ด
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.rewardDown31.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//ล่าง
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.rewardDown32.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//ล่าง
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.rewardDown33.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//ล่าง
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rw.rewardDown34.Equals(dt.Rows[i][lc.lotdb.lot.number].ToString()))//ล่าง
                    {
                        dgv2[col2Number, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].Style.ForeColor = Color.Red;
                        dgv2.Rows[int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString())].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                }
            }
            dgv2.Font = font;
        }
        private void setDataGrid1(DataGridView dgv, int row, Int32 number, Double numUp, Double numTod, Double numDown, String rowId, String lottoId, String sale)
        {
            //if (dgv.Enabled == false)
            //{
            //    return;
            //}
            //dgv1.Rows.Insert(0, 1);
            //dgv1[col1Number, 0].Value = number;
            //dgv1[col1Up, 0].Value = numUp;
            //dgv1[col1Down, 0].Value = numDown;
            //dgv.Rows.Insert(dgv1.RowCount - 1, 1);
            //int r = 0;
            //r = row;
            dgv[colNumber, row].Value = number;
            dgv[colUp, row].Value = String.Format("{0:#,###,###.00}",numUp);
            dgv[colTod, row].Value = String.Format("{0:#,###,###.00}",numTod);
            dgv[colDown, row].Value = String.Format("{0:#,###,###.00}",numDown);
            dgv[colRowId, row].Value = rowId;
            dgv[colLottoId1, row].Value = lottoId;
            dgv[colRUp, row].Value = "0";
            dgv[colRDown, row].Value = "0";
            dgv[colR2Up, row].Value = "0";
            dgv[colR2Down, row].Value = "0";
            dgv[colR3Up, row].Value = "0";
            dgv[colR3Down, row].Value = "0";
            dgv[colR3Tod, row].Value = "0";
            dgv[colSale, row].Value = sale;
            //row++;

        }
        private void calReward()
        {
            String num = "";
            Double amt = 0, up = 0, tod = 0, down = 0, rUp = 0, rDown = 0, r2Up = 0, r2Down = 0, r3Up = 0, r3Down = 0, r3Tod = 0;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                if (dgv1[colNumber, i].Value == null)
                {
                    continue;
                }
                num = dgv1[colNumber, i].Value.ToString();
                if (num.Length == 1)
                {
                    dgv1[colRUp, i].Value = String.Format("{0:#,###,###.00}",lc.chkRewardUp(rw, num, Double.Parse(dgv1[colUp, i].Value.ToString())));
                    dgv1[colRDown, i].Value = String.Format("{0:#,###,###.00}",lc.chkRewardDown(rw, num, Double.Parse(dgv1[colDown, i].Value.ToString())));
                }
                else if (num.Length == 2)
                {
                    dgv1[colR2Up, i].Value = String.Format("{0:#,###,###.00}",lc.chkReward2Up(rw, num, Double.Parse(dgv1[colUp, i].Value.ToString())));
                    dgv1[colR2Down, i].Value = String.Format("{0:#,###,###.00}",lc.chkReward2Down(rw, num, Double.Parse(dgv1[colDown, i].Value.ToString())));
                }
                else if (num.Length == 3)
                {
                    dgv1[colR3Up, i].Value = String.Format("{0:#,###,###.00}",lc.chkReward3Up(rw, num, Double.Parse(dgv1[colUp, i].Value.ToString())));
                    dgv1[colR3Down, i].Value = String.Format("{0:#,###,###.00}",lc.chkReward3Down(rw, num, Double.Parse(dgv1[colDown, i].Value.ToString())));
                    dgv1[colR3Tod, i].Value = String.Format("{0:#,###,###.00}",lc.chkReward3Tod(rw, num, Double.Parse(dgv1[colTod, i].Value.ToString())));
                }
                rDown += (Double.Parse(dgv1[colRDown, i].Value.ToString()));
                r2Up += (Double.Parse(dgv1[colR2Up, i].Value.ToString()));
                r2Down += (Double.Parse(dgv1[colR2Down, i].Value.ToString()));
                r3Up += (Double.Parse(dgv1[colR3Up, i].Value.ToString()));
                r3Down += (Double.Parse(dgv1[colR3Down, i].Value.ToString()));
                r3Tod += (Double.Parse(dgv1[colR3Tod, i].Value.ToString()));
            }
            txtAmt.Text = amt.ToString("#,###.00");
            txtUp.Text = up.ToString("#,###.00");
            txtTod.Text = tod.ToString("#,###.00");
            txtDown.Text = down.ToString("#,###.00");
            txtRUp.Text = rUp.ToString("#,###.00");
            txtRDown.Text = rDown.ToString("#,###.00");
            txtR2Up.Text = r2Up.ToString("#,###.00");
            txtR2Down.Text = r2Down.ToString("#,###.00");
            txtR3Up.Text = r3Up.ToString("#,###.00");
            txtR3Down.Text = r3Down.ToString("#,###.00");
            txtR3Tod.Text = r3Tod.ToString("#,###.00");
        }
        private void FrmLottoResult_Load(object sender, EventArgs e)
        {

        }
        private void setDGrd()
        {
            DataTable dt = new DataTable();
            String num = "", chk = "";
            
            Font font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            if (txtSearch.Text.Equals(""))
            {
                if (cboSale.Text.Equals(""))
                {
                    dt = lc.lotdb.selectByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
                }
                else
                {
                    dt = lc.lotdb.selectByPeriodSale(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), lc.cf.getValueCboItem(cboSale));
                }
                
            }
            else
            {
                if (cboSale.Text.Equals(""))
                {
                    dt = lc.lotdb.selectByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), txtSearch.Text);
                }
                else
                {
                    dt = lc.lotdb.selectByPeriodSale(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString(), txtSearch.Text, lc.cf.getValueCboItem(cboSale));
                }
                
            }
            
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count+1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrid1(dgv1, i, int.Parse(dt.Rows[i][lc.lotdb.lot.number].ToString()), Double.Parse(dt.Rows[i][lc.lotdb.lot.up].ToString()),
                        Double.Parse(dt.Rows[i][lc.lotdb.lot.tod].ToString()), Double.Parse(dt.Rows[i][lc.lotdb.lot.down].ToString()),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString(), dt.Rows[i]["sale_name"].ToString());
                    
                    if ((i % 2) != 0)
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    num = dgv1[colNumber, i].Value.ToString();
                    if (num.Length == 1)
                    {
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colRUp, i].Value.ToString())) > 0)
                        {
                            //chk = lc.lotdb.updateRewardUp(rowId, lc.rUp.pay, dgv1[colRUp, i].Value.ToString());
                            dgv1[colRUp, i].Style.Font = font;
                            dgv1[colRUp, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colUp, i].Style.Font = font;
                            dgv1[colUp, i].Style.ForeColor = Color.Red;
                        }
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colRDown, i].Value.ToString())) > 0)
                        {
                            //chk = lc.lotdb.updateRewardDown(rowId, lc.rDown.pay, dgv1[colRDown, i].Value.ToString());
                            dgv1[colRDown, i].Style.Font = font;
                            dgv1[colRDown, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colDown, i].Style.Font = font;
                            dgv1[colDown, i].Style.ForeColor = Color.Red;
                        }
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                    }
                    else if (num.Length == 2)
                    {
                        if (num.Equals("90"))
                        {
                            chk = "";
                        }
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colR2Up, i].Value.ToString())) > 0)
                        {

                            //chk = lc.lotdb.updateReward2Up(rowId, lc.r2Up.pay, dgv1[colR2Up, i].Value.ToString());
                            dgv1[colR2Up, i].Style.Font = font;
                            dgv1[colR2Up, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colUp, i].Style.Font = font;
                            dgv1[colUp, i].Style.ForeColor = Color.Red;
                        }
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colR2Down, i].Value.ToString())) > 0)
                        {
                            //chk = lc.lotdb.updateReward2Down(rowId, lc.r2Down.pay, dgv1[colR2Down, i].Value.ToString());
                            dgv1[colR2Down, i].Style.Font = font;
                            dgv1[colR2Down, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colDown, i].Style.Font = font;
                            dgv1[colDown, i].Style.ForeColor = Color.Red;
                        }
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (num.Length == 3)
                    {
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colR3Up, i].Value.ToString())) > 0)
                        {
                            //chk = lc.lotdb.updateReward3Up(rowId, lc.r3Up.pay, dgv1[colR3Up, i].Value.ToString());
                            dgv1[colR3Up, i].Style.Font = font;
                            dgv1[colR3Up, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colUp, i].Style.Font = font;
                            dgv1[colUp, i].Style.ForeColor = Color.Red;
                        }
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colR3Tod, i].Value.ToString())) > 0)
                        {
                            //chk = lc.lotdb.updateReward3Down(rowId, lc.r3Down.pay, dgv1[colR3Tod, i].Value.ToString());
                            dgv1[colR3Tod, i].Style.Font = font;
                            dgv1[colR3Tod, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colTod, i].Style.Font = font;
                            dgv1[colTod, i].Style.ForeColor = Color.Red;
                        }
                        if (Double.Parse(lc.cf.NumberNull(dgv1[colR3Down, i].Value.ToString())) > 0)
                        {
                            //chk = lc.lotdb.updateReward3Tod(rowId, lc.r3Tod.pay, dgv1[colR3Down, i].Value.ToString());
                            dgv1[colR3Down, i].Style.Font = font;
                            dgv1[colR3Down, i].Style.ForeColor = Color.Red;
                            dgv1[colNumber, i].Style.Font = font;
                            dgv1[colNumber, i].Style.ForeColor = Color.Red;
                            dgv1[colDown, i].Style.Font = font;
                            dgv1[colDown, i].Style.ForeColor = Color.Red;
                        }
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                }
                calReward();
                
            }
        }
        private void saveLottoReward()
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            String numUp = "", numTod = "", numDown = "";
            Double amt = 0, up = 0, tod = 0, down = 0, rUp = 0, rDown = 0, r2Up = 0, r2Down = 0, r3Up = 0, r3Down = 0, r3Tod = 0;
            Font font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            pB1.Minimum = 0;
            pB1.Maximum = dgv1.Rows.Count;
            if(rw.Id.Equals(""))
            {
                return;
            }
            calReward();
            pB1.Visible = true;
            String rowId = "", num = "", chk = "";
            
            for (int i = 0; i < dgv1.RowCount; i++)
            {
                if (dgv1[colNumber, i].Value == null)
                {
                    continue;
                }
                num = dgv1[colNumber, i].Value.ToString();
                rowId = dgv1[colRowId, i].Value.ToString();
                numUp = dgv1[colUp, i].Value.ToString();
                numTod = dgv1[colTod, i].Value.ToString();
                numDown = dgv1[colDown, i].Value.ToString();
                rDown += (Double.Parse(dgv1[colRDown, i].Value.ToString()));
                r2Up += (Double.Parse(dgv1[colR2Up, i].Value.ToString()));
                r2Down += (Double.Parse(dgv1[colR2Down, i].Value.ToString()));
                r3Up += (Double.Parse(dgv1[colR3Up, i].Value.ToString()));
                r3Down += (Double.Parse(dgv1[colR3Down, i].Value.ToString()));
                r3Tod += (Double.Parse(dgv1[colR3Tod, i].Value.ToString()));
                if (num.Length == 1)
                {
                    //if (!dgv1[colRUp, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateRewardUp(rowId, lc.rUp.pay, dgv1[colUp, i].Value.ToString());
                    //}
                    //if (!dgv1[colDown, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateRewardDown(rowId, lc.rDown.pay, dgv1[colDown, i].Value.ToString());
                    //}
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colRUp, i].Value.ToString()))>0)
                    {
                        chk = lc.lotdb.updateRewardUp(rowId, lc.rUp.pay, dgv1[colRUp, i].Value.ToString());
                        dgv1[colRUp, i].Style.Font = font;
                        dgv1[colRUp, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colUp, i].Style.Font = font;
                        dgv1[colUp, i].Style.ForeColor = Color.Red;
                    }
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colRDown, i].Value.ToString())) > 0)
                    {
                        chk = lc.lotdb.updateRewardDown(rowId, lc.rDown.pay, dgv1[colRDown, i].Value.ToString());
                        dgv1[colRDown, i].Style.Font = font;
                        dgv1[colRDown, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colDown, i].Style.Font = font;
                        dgv1[colDown, i].Style.ForeColor = Color.Red;
                    }
                    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                }
                else if (num.Length == 2)
                {
                    //if (!dgv1[colR2Up, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateReward2Up(rowId, lc.r2Up.pay, dgv1[colUp, i].Value.ToString());
                    //}
                    //if (!dgv1[colR2Down, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateReward2Down(rowId, lc.r2Down.pay, dgv1[colDown, i].Value.ToString());
                    //}
                    if (num.Equals("90"))
                    {
                        chk = "";
                    }
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colR2Up, i].Value.ToString())) > 0)
                    {
                        
                        chk = lc.lotdb.updateReward2Up(rowId, lc.r2Up.pay, dgv1[colR2Up, i].Value.ToString());
                        dgv1[colR2Up, i].Style.Font = font;
                        dgv1[colR2Up, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colUp, i].Style.Font = font;
                        dgv1[colUp, i].Style.ForeColor = Color.Red;
                    }
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colR2Down, i].Value.ToString())) > 0)
                    {
                        chk = lc.lotdb.updateReward2Down(rowId, lc.r2Down.pay, dgv1[colR2Down, i].Value.ToString());
                        dgv1[colR2Down, i].Style.Font = font;
                        dgv1[colR2Down, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colDown, i].Style.Font = font;
                        dgv1[colDown, i].Style.ForeColor = Color.Red;
                    }
                    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                }
                else if (num.Length == 3)
                {
                    //if (!dgv1[colR3Up, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateReward3Up(rowId, lc.r3Up.pay, dgv1[colUp, i].Value.ToString());
                    //}
                    //if (!dgv1[colR3Down, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateReward3Down(rowId, lc.r3Down.pay, dgv1[colDown, i].Value.ToString());
                    //}
                    //if (!dgv1[colR3Tod, i].Value.ToString().Equals(""))
                    //{
                    //    chk = lc.lotdb.updateReward3Tod(rowId, lc.r3Tod.pay, dgv1[colTod, i].Value.ToString());
                    //}
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colR3Up, i].Value.ToString())) > 0)
                    {
                        chk = lc.lotdb.updateReward3Up(rowId, lc.r3Up.pay, dgv1[colR3Up, i].Value.ToString());
                        dgv1[colR3Up, i].Style.Font = font;
                        dgv1[colR3Up, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colUp, i].Style.Font = font;
                        dgv1[colUp, i].Style.ForeColor = Color.Red;
                    }
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colR3Tod, i].Value.ToString())) > 0)
                    {
                        chk = lc.lotdb.updateReward3Down(rowId, lc.r3Down.pay, dgv1[colR3Tod, i].Value.ToString());
                        dgv1[colR3Tod, i].Style.Font = font;
                        dgv1[colR3Tod, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colTod, i].Style.Font = font;
                        dgv1[colTod, i].Style.ForeColor = Color.Red;
                    }
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colR3Down, i].Value.ToString())) > 0)
                    {
                        chk = lc.lotdb.updateReward3Tod(rowId, lc.r3Tod.pay, dgv1[colR3Down, i].Value.ToString());
                        dgv1[colR3Down, i].Style.Font = font;
                        dgv1[colR3Down, i].Style.ForeColor = Color.Red;
                        dgv1[colNumber, i].Style.Font = font;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colDown, i].Style.Font = font;
                        dgv1[colDown, i].Style.ForeColor = Color.Red;
                    }
                    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                }
                //if (chk.Equals("1"))
                //{
                //    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                //}                
                up += (Double.Parse(numUp));
                tod += (Double.Parse(numTod));
                down += (Double.Parse(numDown));
                amt += (Double.Parse(numUp) + Double.Parse(numTod) + Double.Parse(numDown));
                pB1.Value = i;
            }
            //setGrdColor();
            txtAmt.Text = amt.ToString("#,###.00");
            txtUp.Text = up.ToString("#,###.00");
            txtTod.Text = tod.ToString("#,###.00");
            txtDown.Text = down.ToString("#,###.00");
            txtRUp.Text = rUp.ToString("#,###.00");
            txtRDown.Text = rDown.ToString("#,###.00");
            txtR2Up.Text = r2Up.ToString("#,###.00");
            txtR2Down.Text = r2Down.ToString("#,###.00");
            txtR3Up.Text = r3Up.ToString("#,###.00");
            txtR3Down.Text = r3Down.ToString("#,###.00");
            txtR3Tod.Text = r3Tod.ToString("#,###.00");
            lc.rwdb.updateStatusApprove(rw.Id, sf.Id);
            pB1.Visible = false;
            Cursor.Current = cursor;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            
            
            
            
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl();
                setDGrd();
            }            
        }

        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl();
                setDGrd();
                setGrd2();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!pageLoad)
            {
                setControl();
                setDGrd();
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            pB1.Visible = true;
            pB1.Minimum = 0;
            pB1.Maximum = dgv1.Rows.Count;
            setDGrd();
            pB1.Visible = false;
            Cursor.Current = cursor;
        }

        private void Chk3_Click(object sender, EventArgs e)
        {
            if (Chk3.Checked)
            {
                setGrd3();
            }
        }

        private void Chk2_Click(object sender, EventArgs e)
        {
            if (Chk2.Checked)
            {
                setGrd2();
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnS_Click(null,null);
            }
        }

        private void dgv2_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if ((e.Column.Index == col2RewordUp) || (e.Column.Index == col2RewardDown) || (e.Column.Index == col3RewardDown))
            {
                if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = 1;
                }
                else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = -1;
                }
                else
                {
                    e.SortResult = 0;
                }
                e.Handled = true;
            }
        }
    }
}
