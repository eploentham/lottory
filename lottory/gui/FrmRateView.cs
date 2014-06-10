using lottory.control;
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

namespace lottory.gui
{
    public partial class FrmRateView : Form
    {
        LottoryControl lc;
        DataTable dt;
        int colCnt = 7;
        int colRow = 0, colDescription = 1, colRec = 2, colId = 6, colpay = 3, colLimit = 4, colDiscount = 5;
        public FrmRateView()
        {
            InitializeComponent();
            initConfig();
            setControl();
        }
        private void initConfig()
        {
            lc = new LottoryControl();
            //dt = lc.selectStaffAll();

        }
        private void setResize()
        {
            dgvView.Width = this.Width - 50;
            dgvView.Height = this.Height - 150;

            groupBox1.Width = this.Width - 50;
            //groupBox1.Height = this.Height = 150;
        }
        public void setControl()
        {
            DataTable dt = new DataTable();
            dt = lc.selectRateAll();
            dgvView.ColumnCount = colCnt;

            dgvView.RowCount = dt.Rows.Count + 1;
            dgvView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvView.Columns[colRow].Width = 50;
            dgvView.Columns[colDescription].Width = 200;
            dgvView.Columns[colRec].Width = 120;
            dgvView.Columns[colpay].Width = 120;
            dgvView.Columns[colDiscount].Width = 120;
            dgvView.Columns[colLimit].Width = 120;
            dgvView.Columns[colId].Width = 80;

            dgvView.Columns[colRow].HeaderText = "ลำดับ";
            dgvView.Columns[colpay].HeaderText = "จ่าย บาท";
            dgvView.Columns[colDescription].HeaderText = "รายการ";
            dgvView.Columns[colRec].HeaderText = "ซื้อ บาท";
            dgvView.Columns[colDiscount].HeaderText = "ส่วนลด บาท";
            dgvView.Columns[colLimit].HeaderText = "จำนวนอั้น บาท";
            dgvView.Columns[colId].HeaderText = "id";//

            dgvView.Columns[colId].HeaderText = "id";
            Font font = new Font("Microsoft Sans Serif", 12);

            dgvView.Font = font;
            dgvView.Columns[colId].Visible = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvView[colRow, i].Value = (i + 1);
                    dgvView[colpay, i].Value = dt.Rows[i][lc.ratedb.rate.pay].ToString();
                    dgvView[colDescription, i].Value = dt.Rows[i][lc.ratedb.rate.Description].ToString();
                    dgvView[colRec, i].Value = dt.Rows[i][lc.ratedb.rate.rec].ToString();
                    dgvView[colLimit, i].Value = dt.Rows[i][lc.ratedb.rate.limit1].ToString();
                    dgvView[colDiscount, i].Value = dt.Rows[i][lc.ratedb.rate.discount].ToString();
                    dgvView[colId, i].Value = dt.Rows[i][lc.ratedb.rate.Id].ToString();

                    if ((i % 2) != 0)
                    {
                        dgvView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                }
            }
        }
        private void FrmRateView_Load(object sender, EventArgs e)
        {
            
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
            FrmRateAdd frm = new FrmRateAdd();
            frm.setControl(dgvView[colId, e.RowIndex].Value.ToString());
            frm.ShowDialog(this);
            setControl();
        }
    }
}
