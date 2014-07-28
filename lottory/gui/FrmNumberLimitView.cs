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
    public partial class FrmNumberLimitView : Form
    {
        LottoryControl lc;
        DataTable dt;
        Staff sf;
        int colCnt = 6;
        int colRow = 0, colNumber = 1, colStatus = 2, colDesc = 3, colId = 5, colRemark = 4;
        public FrmNumberLimitView(String sfCode, LottoryControl l)
        {
            InitializeComponent();
            initConfig(sfCode, l);
        }
        private void initConfig(String sfCode, LottoryControl l)
        {
            lc = l;
            sf = lc.sfdb.selectByCode(sfCode);
            setGrd();
        }
        private void setGrd()
        {
            dgvView.Rows.Clear();
            Font font = new Font("Microsoft Sans Serif", 12);
            //dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dt = lc.nldb.selectAll();
            dgvView.ColumnCount = colCnt;
            dgvView.RowCount = 1;
            //row = 0;
            dgvView.Columns[colNumber].Width = 80;
            dgvView.Columns[colRow].Width = 80;
            dgvView.Columns[colStatus].Width = 120;
            dgvView.Columns[colDesc].Width = 150;
            dgvView.Columns[colRemark].Width = 150;

            dgvView.Columns[colNumber].HeaderText = "ตัวเลข";
            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colStatus].HeaderText = "สถานะ";
            dgvView.Columns[colDesc].HeaderText = "รายการ";
            dgvView.Columns[colRemark].HeaderText = "หมายเหตุ";

            dgvView.Columns[colId].Visible = false;
            //dgvView.Columns[colLottoId1].Visible = false;
            //dgvView.Columns[colRemark].Visible = false;

            dgvView.Font = font;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colNumber, i].Value = dt.Rows[i][lc.nldb.nl.number].ToString();
                    if (dt.Rows[i][lc.nldb.nl.StatusStart].ToString().Equals("1"))
                    {
                        dgvView[colStatus, i].Value = "ทันที และตลอดไป";
                        dgvView[colDesc, i].Value = "";
                    }
                    else
                    {
                        dgvView[colStatus, i].Value = "เฉพาะงวด";
                        dgvView[colDesc, i].Value = "ประจำเดือน "+lc.cf.getMonth(dt.Rows[i][lc.nldb.nl.monthLimitId].ToString()) + " งวด " + 
                            lc.cf.getPeriod(dt.Rows[i][lc.nldb.nl.periodLimitId].ToString()) + " ปี " + dt.Rows[i][lc.nldb.nl.periodLimitId].ToString();
                    }
                    
                    //dgvView[colDesc, i].Value = dt.Rows[i][lc.nldb.nl.number].ToString();
                    dgvView[colRemark, i].Value = dt.Rows[i][lc.nldb.nl.remark].ToString();
                    dgvView[colId, i].Value = dt.Rows[i][lc.nldb.nl.Id].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }

        private void FrmNumberLimitView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmNumberLimitAdd frm = new FrmNumberLimitAdd(sf.Code,lc,"");
            frm.ShowDialog(this);
        }

        private void dgvView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (dgvView[colId, e.RowIndex].Value == null)
            {
                return;
            }
            FrmNumberLimitAdd frm = new FrmNumberLimitAdd(sf.Code, lc,dgvView[colId, e.RowIndex].Value.ToString());
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setGrd();
        }
    }
}
