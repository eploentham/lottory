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
    public partial class FrmRewardView : Form
    {
        LottoryControl lc;
        Staff sf;
        int colCnt = 7;
        int colRow = 0, colPeriod = 2, colYear=3, colR1 = 4, colR3 = 5, colId = 1, colR2 = 6;
        public FrmRewardView(String sfCode)
        {
            InitializeComponent();
            initConfig(sfCode);
            setGrd();
        }
        private void initConfig(String sfCode)
        {
            lc = new LottoryControl();
            sf = lc.sfdb.selectByCode(sfCode);
            //dt = lc.selectStaffAll();
        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;

            groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        public void setGrd()
        {
            DataTable dt = new DataTable();
            dt = lc.rwdb.selectAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colPeriod].Width = 220;
            dgvView.Columns[colYear].Width = 80;
            dgvView.Columns[colR1].Width = 120;
            dgvView.Columns[colR3].Width = 180;
            dgvView.Columns[colR2].Width = 80;
            
            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            //dgvView.Columns[colId].HeaderText = "code";
            dgvView.Columns[colPeriod].HeaderText = "ประจำงวดที่";
            dgvView.Columns[colYear].HeaderText = "ปี";
            dgvView.Columns[colR1].HeaderText = "รางวัลที่ 1";
            dgvView.Columns[colR3].HeaderText = "รางวัลเลขท้าย3ตัว";
            dgvView.Columns[colR2].HeaderText = "2ตัว";

            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colId, i].Value = dt.Rows[i][lc.rwdb.rw.Id].ToString();
                    dgvView[colPeriod, i].Value = "ประจำเดือน " + lc.cf.getMonth(dt.Rows[i][lc.rwdb.rw.monthId].ToString()) + " " +
                            lc.cf.getPeriod(dt.Rows[i][lc.rwdb.rw.periodId].ToString()) ;
                    dgvView[colR1, i].Value = dt.Rows[i][lc.rwdb.rw.reward1].ToString();
                    dgvView[colR3, i].Value = dt.Rows[i][lc.rwdb.rw.rewardDown31].ToString() + " " + dt.Rows[i][lc.rwdb.rw.rewardDown32].ToString() + " "
                        + dt.Rows[i][lc.rwdb.rw.rewardDown33].ToString() + " " + dt.Rows[i][lc.rwdb.rw.rewardDown34].ToString();
                    dgvView[colYear, i].Value = dt.Rows[i][lc.rwdb.rw.yearId].ToString();
                    dgvView[colR2, i].Value = dt.Rows[i][lc.rwdb.rw.rewardDown2].ToString();
                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void FrmRewardView_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmRewardAdd frm = new FrmRewardAdd(sf.Id,lc,"");
            //frm.setControl("");
            frm.ShowDialog(this);
            setGrd();
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

            FrmRewardAdd frm = new FrmRewardAdd(sf.Code,lc, dgvView[colId, e.RowIndex].Value.ToString());
            //frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setGrd();
            
        }
    }
}
