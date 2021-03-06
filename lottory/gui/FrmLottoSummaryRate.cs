﻿using lottory.control;
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
    public partial class FrmLottoSummaryRate : Form
    {
        int colNumber = 0, colRAmt = 1, colRAmtReward = 2, colRpayRate = 4, colRReward = 3;
        //int colR3Up = 13, colR3TodRate = 14, colR3Tod = 15, colR3DownRate = 16, colR3Down = 17;
        int col1Cnt = 5;
        LottoryControl lc;
        Staff sf;
        Boolean pageLoad = false;
        public FrmLottoSummaryRate(String sfCode, String yearId, String monthId, String periodId, String rateId, LottoryControl l)
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
        public void setControl(String yearId, String monthId, String periodId, String rateId)
        {
            dgv1.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            Font font1 = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            //dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            List<Reward1> lRew1 = new List<Reward1>();

            //lRew1 = lc.selectByReward(yearId, monthId, periodId, rateId);
            lRew1 = lc.selectByLenNumber(yearId, monthId, periodId, rateId);

            dgv1.ColumnCount = col1Cnt;
            dgv1.RowCount = 1;
            //row = 0;
            dgv1.Columns[colNumber].Width = 80;
            //dgv1.Columns[colUp].Width = 80;
            //dgv1.Columns[colTod].Width = 80;
            //dgv1.Columns[colDown].Width = 80;
            dgv1.Columns[colRpayRate].Width = 100;
            dgv1.Columns[colNumber].HeaderText = "ตัวเลข";
            dgv1.Columns[colRAmt].HeaderText = "ยอดเงิน";
            dgv1.Columns[colRAmtReward].HeaderText = "แทงถูก";
            //dgv1.Columns[colTod].HeaderText = "โต๊ด";
            //dgv1.Columns[colDown].HeaderText = "ล่าง";

            dgv1.Columns[colRpayRate].HeaderText = "อัตราจ่าย";
            dgv1.Columns[colRReward].HeaderText = "จ่าย";
            dgv1.Columns[colRAmt].Visible = false;

            dgv1.Font = font;
            //lotNew = true;
            if (lRew1.Count > 0)
            {
                dgv1.RowCount = lRew1.Count;
                for (int i = 0; i < lRew1.Count; i++)
                {
                    Reward1 rew1 = lRew1[i];
                    dgv1[colNumber, i].Value = lc.cf.stringNull1(rew1.number);

                    dgv1[colRpayRate, i].Value = rew1.PayRate;
                    dgv1[colRReward, i].Value = rew1.Reward;
                    dgv1[colRAmtReward, i].Value = rew1.Amt;
                    if (Double.Parse(lc.cf.NumberNull(dgv1[colRReward, i].Value.ToString())) > 0)
                    {
                        dgv1[colNumber, i].Style.Font = font1;
                        dgv1[colNumber, i].Style.ForeColor = Color.Red;
                        dgv1[colRReward, i].Style.Font = font1;
                        dgv1[colRReward, i].Style.ForeColor = Color.Red;
                        dgv1[colRAmtReward, i].Style.Font = font1;
                        dgv1[colRAmtReward, i].Style.ForeColor = Color.Red;
                    }
                    if (rateId.Equals("up"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                    }
                    else if (rateId.Equals("down"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#174e75");
                    }
                    else if (rateId.Equals("2down"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rateId.Equals("2up"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rateId.Equals("2tod"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#789640");
                    }
                    else if (rateId.Equals("3down"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                    else if (rateId.Equals("3tod"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                    else if (rateId.Equals("3up"))
                    {
                        dgv1.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#788540");
                    }
                }
            }
            dgv1.ReadOnly = true;
        }

        private void FrmLottoSummaryRate_Load(object sender, EventArgs e)
        {

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

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
