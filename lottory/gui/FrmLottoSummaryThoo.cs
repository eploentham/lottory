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
    public partial class FrmLottoSummaryThoo : Form
    {
        int colNumber = 0, colUp = 1, colTod = 2, colDown = 3, colRAmt = 4, colRAmtReward = 5, colRpayRate = 6, colRReward = 7;
        //int colR3Up = 13, colR3TodRate = 14, colR3Tod = 15, colR3DownRate = 16, colR3Down = 17;
        int col1Cnt = 8;
        LottoryControl lc;
        Staff sf;
        Boolean pageLoad = false;
        public FrmLottoSummaryThoo(String sfCode, String yearId, String monthId, String periodId, String rateId, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode, l, yearId, monthId, periodId);
        }
        private void initConfig(String sfCode, LottoryControl l, String yearId, String monthId, String periodId)
        {
            pageLoad = true;
            //String monthId = "";
            lc = l;
            //lc = new LottoryControl();
            //monthId = System.DateTime.Now.Month.ToString("00");
            sf = lc.sfdb.selectByCode(sfCode);
            CreateMyBorderlessWindow();
            cboMonth = lc.cf.setCboMonth(cboMonth);
            cboPeriod = lc.cf.setCboPeriod(cboPeriod);
            cboMonth.SelectedValue = monthId;
            cboYear = lc.cf.setCboYear(cboYear);
            cboYear.SelectedIndex = cboYear.FindStringExact(yearId);
            cboPeriod.SelectedValue = periodId;
            //cboPeriod = lc.setCboPeriodDefault(cboPeriod);
            //setControl(yearId, monthId, periodId, rateId);
            //this.Opacity = 20;
            pageLoad = false;
        }
        private void CreateMyBorderlessWindow()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
        }
        private void FrmLottoSummaryThoo_Load(object sender, EventArgs e)
        {

        }
        public void setControl(String yearId, String monthId, String periodId, String saleId)
        {
            dgv1.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            Font font1 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //List<Reward1> lRew1 = new List<Reward1>();

            //lRew1 = lc.selectByReward(yearId, monthId, periodId, rateId);
            DataTable dt = lc.lotdb.selectByThooTranfer(yearId, monthId, periodId, saleId);

            dgv1.ColumnCount = col1Cnt;
            dgv1.RowCount = 1;
            //row = 0;
            dgv1.Columns[colNumber].Width = 80;
            dgv1.Columns[colUp].Width = 80;
            dgv1.Columns[colTod].Width = 80;
            dgv1.Columns[colDown].Width = 80;
            dgv1.Columns[colRpayRate].Width = 100;
            dgv1.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv1.Columns[colRAmt].HeaderText = "ยอดเงิน";
            dgv1.Columns[colRAmtReward].HeaderText = "แทงถูก";
            dgv1.Columns[colUp].HeaderText = "บน";
            dgv1.Columns[colTod].HeaderText = "โต๊ด";
            dgv1.Columns[colDown].HeaderText = "ล่าง";

            dgv1.Columns[colRpayRate].HeaderText = "อัตราจ่าย";
            dgv1.Columns[colRReward].HeaderText = "จ่าย";
            dgv1.Columns[colRAmt].Visible = false;

            dgv1.Font = font;
            //lotNew = true;
            if (dt.Rows.Count > 0)
            {
                dgv1.RowCount = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dgv1[colNumber, i].Value = lc.cf.stringNull1(dt.Rows[i][lc.lotdb.lot.number].ToString());
                    dgv1[colUp, i].Value = lc.cf.stringNull1(dt.Rows[i][lc.lotdb.lot.up].ToString());
                    dgv1[colTod, i].Value = lc.cf.stringNull1(dt.Rows[i][lc.lotdb.lot.tod].ToString());
                    dgv1[colDown, i].Value = lc.cf.stringNull1(dt.Rows[i][lc.lotdb.lot.down].ToString());

                    //dgv1[colRpayRate, i].Value = rew1.PayRate;
                    //dgv1[colRReward, i].Value = rew1.Reward;
                    //dgv1[colRAmtReward, i].Value = rew1.Amt;
                    //if (Double.Parse(lc.cf.NumberNull(dgv1[colRReward, i].Value.ToString())) > 0)
                    //{
                    //    dgv1[colNumber, i].Style.Font = font1;
                    //    dgv1[colNumber, i].Style.ForeColor = Color.Red;
                    //    dgv1[colRReward, i].Style.Font = font1;
                    //    dgv1[colRReward, i].Style.ForeColor = Color.Red;
                    //    dgv1[colRAmtReward, i].Style.Font = font1;
                    //    dgv1[colRAmtReward, i].Style.ForeColor = Color.Red;
                    //}
                    //if (saleId.Equals("up"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                    //}
                    //else if (saleId.Equals("down"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                    //}
                    //else if (saleId.Equals("2down"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    //}
                    //else if (saleId.Equals("2up"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    //}
                    //else if (saleId.Equals("2tod"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    //}
                    //else if (saleId.Equals("3down"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    //}
                    //else if (saleId.Equals("3tod"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    //}
                    //else if (saleId.Equals("3up"))
                    //{
                    //    dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    //}
                }
            }
            dgv1.ReadOnly = true;
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
