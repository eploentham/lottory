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
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRemark = 4, colRowId = 6, colLottoId1 = 5, colRUp=7, colRDown=8, colR2Up=9, colR2Down=10, colR3Up=11, colR3Down=13, colR3Tod=12;
        int col1Cnt = 14;
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
            //cboStaff = lc.sfdb.getCboStaff(cboStaff);

            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            //ComboBoxItem cbo = new ComboBoxItem();
            //cbo.Value = sf.Id;
            //cbo.Text = sf.Name;
            //cboStaff.Text = sf.Name;
            setControl();
            setGrid(dgv1);
            setGrid(dgv2);
            setGrid(dgv3);
            chkNum.Checked = true;
            if (chkNum.Checked)
            {
                dgv2.Visible = false;
                dgv3.Visible = false;
                dgv1.Width = 1000;       
            }
            setDGrd();
            pageLoad = false;
            dgv1.ReadOnly = true;
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
        private void setDataGrid1(DataGridView dgv, int row, String number, Double numUp, Double numTod, Double numDown, String rowId, String lottoId)
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
            dgv[colRUp, row].Value = "";
            dgv[colRDown, row].Value = "";
            dgv[colR2Up, row].Value = "";
            dgv[colR2Down, row].Value = "";
            dgv[colR3Up, row].Value = "";
            dgv[colR3Down, row].Value = "";
            dgv[colR3Tod, row].Value = "";

            //row++;

        }
        private void calReward()
        {
            String num = "";
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
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
            }
        }
        private void FrmLottoResult_Load(object sender, EventArgs e)
        {

        }
        private void setDGrd()
        {
            DataTable dt = new DataTable();
            dt = lc.lotdb.selectByPeriod(cboYear.Text, cboMonth.SelectedValue.ToString(), cboPeriod.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    setDataGrid1(dgv1, i, dt.Rows[i][lc.lotdb.lot.number].ToString(), Double.Parse(dt.Rows[i][lc.lotdb.lot.up].ToString()),
                        Double.Parse(dt.Rows[i][lc.lotdb.lot.tod].ToString()), Double.Parse(dt.Rows[i][lc.lotdb.lot.down].ToString()),
                        dt.Rows[i][lc.lotdb.lot.rowId].ToString(), dt.Rows[i][lc.lotdb.lot.lottoId].ToString());
                    if ((i % 2) != 0)
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
                //calReward();
            }
        }
        private void saveLottoReward()
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Cursor cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            calReward();
            String rowId = "", num = "", chk = "";
            for (int i = 0; i < dgv1.RowCount; i++)
            {
                num = dgv1[colNumber, i].Value.ToString();
                rowId = dgv1[colRowId, i].Value.ToString();
                if (num.Length == 1)
                {
                    if (!dgv1[colRUp, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateRewardUp(rowId, lc.rUp.pay, dgv1[colUp, i].Value.ToString());
                    }
                    if (!dgv1[colDown, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateRewardDown(rowId, lc.rDown.pay, dgv1[colDown, i].Value.ToString());
                    }

                }
                else if (num.Length == 2)
                {
                    if (!dgv1[colR2Up, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateReward2Up(rowId, lc.r2Up.pay, dgv1[colUp, i].Value.ToString());
                    }
                    if (!dgv1[colR2Up, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateReward2Down(rowId, lc.r2Down.pay, dgv1[colDown, i].Value.ToString());
                    }
                }
                else if (num.Length == 3)
                {
                    if (!dgv1[colR3Up, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateReward3Up(rowId, lc.r3Up.pay, dgv1[colUp, i].Value.ToString());
                    }
                    if (!dgv1[colR3Down, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateReward3Down(rowId, lc.r3Down.pay, dgv1[colDown, i].Value.ToString());
                    }
                    if (!dgv1[colR3Tod, i].Value.ToString().Equals(""))
                    {
                        chk = lc.lotdb.updateReward3Tod(rowId, lc.r3Tod.pay, dgv1[colTod, i].Value.ToString());
                    }
                }
                if (chk.Equals("1"))
                {
                    dgv1.Rows[i].DefaultCellStyle.BackColor = Color.DarkKhaki;
                }
            }
            lc.rwdb.updateStatusApprove(rw.rewardId, sf.Id);
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
    }
}
